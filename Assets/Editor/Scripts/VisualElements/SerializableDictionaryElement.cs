using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SavageWorld.Runtime.Utilities;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;
using Object = UnityEngine.Object;

namespace SavageWorld.Editor.VisualElements
{
    [UxmlElement]
    public partial class SerializableDictionaryElement : VisualElement
    {
        #region Fields
        private static readonly string _styleName = "SerializableDictionaryStyle";
        private static readonly string _stylePath = StaticValues.GetStylePath(_styleName);
        private static readonly string _ussKey = "serializable-dictionary__cell__key";
        private static readonly string _ussValue = "serializable-dictionary__cell__value";
        private static readonly string _ussValid = "serializable-dictionary__cell__valid";

        private Object _targetObject;
        private Type _keyType;
        private Type _valueType;
        private List<Type> _baseTypes;
        private Dictionary<Type, List<Type>> _derivedTypesByBase;

        private SerializedProperty _dictionaryProperty;
        private SerializedProperty _itemsArrayProperty;
        private SerializedProperty _isReadOnlyProperty;

        private MultiColumnListView _multiColumnListView;
        private Column _keyColumn;
        private Column _valueColumn;
        private Column _validColumn;
        #endregion

        #region Properties

        #endregion

        #region Events / Delegates

        #endregion

        #region Monobehaviour Methods

        #endregion

        #region Public Methods
        public SerializableDictionaryElement()
            : this(null) { }

        public SerializableDictionaryElement(SerializedProperty dictionaryProperty)
            : base()
        {
            styleSheets.Add(AssetDatabase.LoadAssetAtPath<StyleSheet>(_stylePath));
            ParseProperty(dictionaryProperty);
            ParseBaseTypes();
            FindDerivedTypes();
            CreateColumns();
            CreateMultiColumnListView();
            BindData();
            Add(_multiColumnListView);
        }
        #endregion

        #region Private Methods
        private void ParseProperty(SerializedProperty dictionaryProperty)
        {
            if (dictionaryProperty == null)
            {
                return;
            }
            _dictionaryProperty = dictionaryProperty;
            _itemsArrayProperty = _dictionaryProperty.FindPropertyRelative("_items");
            _isReadOnlyProperty = _dictionaryProperty.FindPropertyRelative("_isReadOnly");
            _targetObject = _dictionaryProperty.serializedObject.targetObject;
        }

        private void ParseBaseTypes()
        {
            var dictionaryType = GetFieldType(
                _targetObject.GetType(),
                _dictionaryProperty.propertyPath
            );
            _baseTypes = dictionaryType.GetGenericArguments().ToList();
            _keyType = _baseTypes[0];
            _valueType = _baseTypes[1];
        }

        private void FindDerivedTypes()
        {
            _derivedTypesByBase = new Dictionary<Type, List<Type>>();
            _baseTypes.ForEach(baseType =>
            {
                var derivedTypes = new List<Type>();
                if (!IsBaseTypeValid(baseType))
                {
                    _derivedTypesByBase[baseType] = derivedTypes;
                    return;
                }
                if (!baseType.IsAbstract)
                {
                    derivedTypes.Add(baseType);
                }
                derivedTypes.AddRange(TypeCache.GetTypesDerivedFrom(baseType));
                _derivedTypesByBase[baseType] = derivedTypes;
            });
        }

        private void CreateColumns()
        {
            _keyColumn = CreateColumn("Key", "_key", OnMakeKeyCell, OnBindKeyCell);
            _valueColumn = CreateColumn("Value", "_value", OnMakeValueCell, OnBindValueCell);
            _validColumn = CreateColumn("Valid", "_isValid", OnMakeValidCell);
        }

        private void CreateMultiColumnListView()
        {
            _multiColumnListView = new MultiColumnListView()
            {
                showFoldoutHeader = true,
                showAddRemoveFooter = !_isReadOnlyProperty?.boolValue ?? false,
                showBoundCollectionSize = true,
                headerTitle = _dictionaryProperty?.displayName,
                virtualizationMethod = CollectionVirtualizationMethod.DynamicHeight,
                selectionType = SelectionType.Multiple,
                reorderable = true,
            };
            _multiColumnListView.columns.reorderable = false;
            _multiColumnListView.columns.Add(_keyColumn);
            _multiColumnListView.columns.Add(_valueColumn);
            _multiColumnListView.columns.Add(_validColumn);
            _multiColumnListView.columns["Key"].minWidth = 60;
            _multiColumnListView.columns["Value"].minWidth = 60;
            _multiColumnListView.columns["Valid"].maxWidth = 60;
            _multiColumnListView.columns["Valid"].minWidth = 60;
            _multiColumnListView.columns["Valid"].resizable = false;
        }

        private void BindData()
        {
            if (_itemsArrayProperty == null)
            {
                return;
            }
            _multiColumnListView.bindingPath = _itemsArrayProperty.propertyPath;
        }

        private VisualElement OnMakeKeyCell()
        {
            var isUnityObject = _keyType.IsSubclassOf(typeof(Object));
            return isUnityObject
                ? GetUnityObjectElement(_ussKey)
                : GetManagedObjectElement(_keyType, _ussKey);
        }

        private VisualElement OnMakeValueCell()
        {
            var isUnityObject = _valueType.IsSubclassOf(typeof(Object));
            return isUnityObject
                ? GetUnityObjectElement(_ussValue)
                : GetManagedObjectElement(_valueType, _ussValue);
        }

        private VisualElement OnMakeValidCell()
        {
            var toggle = new Toggle();
            toggle.SetEnabled(false);
            toggle.AddToClassList(_ussValid);
            return toggle;
        }

        private VisualElement GetUnityObjectElement(string ussClass)
        {
            var propertyField = new PropertyField();
            propertyField.AddToClassList(ussClass);
            propertyField.SetEnabled(!_isReadOnlyProperty.boolValue);
            propertyField.label = string.Empty;
            return propertyField;
        }

        private VisualElement GetManagedObjectElement(Type baseType, string ussClass)
        {
            if (!baseType.IsClass)
            {
                return GetUnityObjectElement(ussClass);
            }
            var typeSelector = new TypeSelectorElement(_derivedTypesByBase[baseType]);
            typeSelector.AddToClassList(ussClass);
            return typeSelector;
        }

        private void OnBindKeyCell(VisualElement element, int index)
        {
            BindCell(element, index, "_key");
        }

        private void OnBindValueCell(VisualElement element, int index)
        {
            BindCell(element, index, "_value");
        }

        private void BindCell(VisualElement element, int index, string parameterName)
        {
            var binding = _itemsArrayProperty
                .GetArrayElementAtIndex(index)
                .FindPropertyRelative(parameterName);
            if (element is not TypeSelectorElement typeSelecotr)
            {
                var propertyField = element as PropertyField;
                propertyField.BindProperty(binding);
                return;
            }
            typeSelecotr.Bind(binding);
        }

        private bool IsBaseTypeValid(Type baseType)
        {
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic;
            var constructors = baseType.GetConstructors(bindingFlags);
            return constructors.Length == 1 && constructors[0].GetParameters().Length == 0;
        }

        private Type GetFieldType(Type type, string path)
        {
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic;
            var splitedPath = path.Split('.');
            return splitedPath.Aggregate(
                type,
                (seed, pathPart) => seed.GetField(pathPart, bindingFlags).FieldType
            );
        }

        private Column CreateColumn(
            string title,
            string bindingPath,
            Func<VisualElement> makeCell = null,
            Action<VisualElement, int> bindCell = null
        )
        {
            var column = new Column();
            column.name = title;
            column.title = title;
            column.stretchable = true;
            column.bindingPath = bindingPath;
            column.makeCell = makeCell;
            column.bindCell = bindCell;
            column.optional = false;
            return column;
        }
        #endregion
    }
}
