using System;
using System.Collections.Generic;
using SavageWorld.Editor.Utilities;
using SavageWorld.Runtime.Utilities;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace SavageWorld.Editor.VisualElements
{
    [UxmlElement]
    public partial class TypeSelectorElement : VisualElement
    {
        #region Fields
        private static readonly string _styleName = "TypeSelectorStyle";
        private static readonly string _stylePath = StaticValues.GetStylePath(_styleName);
        private static readonly string _ussContainer = "type-selector__container";
        private static readonly string _ussButton = "type-selector__button";
        private static readonly string _ussPropertyField = "type-selector__property__field";

        private SerializedProperty _property;
        private SearchProvider _searchProvider;

        private VisualElement _container;
        private Button _changeValueBtn;
        private PropertyField _propertyField;
        #endregion

        #region Properties

        #endregion

        #region Events / Delegates

        #endregion

        #region Monobehaviour Methods

        #endregion

        #region Public Methods
        public TypeSelectorElement()
            : this(null) { }

        public TypeSelectorElement(List<Type> availableTypes)
            : base()
        {
            styleSheets.Add(AssetDatabase.LoadAssetAtPath<StyleSheet>(_stylePath));
            _searchProvider = ScriptableObject.CreateInstance<SearchProvider>();
            _searchProvider.Setup("Choose class", availableTypes);
            _searchProvider.EntrySelected = ChangeValue;

            _container = new VisualElement();
            _changeValueBtn = new Button(ShowSearchWindow);
            _propertyField = new PropertyField();

            _container.AddToClassList(_ussContainer);
            _changeValueBtn.AddToClassList(_ussButton);
            _propertyField.AddToClassList(_ussPropertyField);

            _container.Add(_changeValueBtn);
            _container.Add(_propertyField);
            Add(_container);
        }

        public void Bind(SerializedProperty property)
        {
            _property = property;
            if (_property.propertyType == SerializedPropertyType.ManagedReference)
            {
                _propertyField.label = _property.boxedValue?.GetType().Name ?? "EMPTY";
            }
            _propertyField.Unbind();
            _propertyField.BindProperty(_property);
        }
        #endregion

        #region Private Methods
        private void ShowSearchWindow()
        {
            var mousePosition = Event.current.mousePosition;
            SearchWindow.Open(new(GUIUtility.GUIToScreenPoint(mousePosition)), _searchProvider);
        }

        private void ChangeValue(Type type)
        {
            _property.boxedValue = Activator.CreateInstance(type);
            _property.serializedObject.ApplyModifiedProperties();
            Bind(_property);
        }
        #endregion
    }
}
