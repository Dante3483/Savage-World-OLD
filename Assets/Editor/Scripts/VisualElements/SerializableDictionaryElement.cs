using System;
using SavageWorld.Runtime.Utilities;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace SavageWorld.Editor.VisualElements
{
    [UxmlElement]
    public partial class SerializableDictionaryElement : VisualElement
    {
        #region Fields
        private static readonly string _styleName = "SerializableDictionaryStyle";
        private static readonly string _stylePath = StaticValues.GetStylePath(_styleName);
        private static readonly string _ussValid = "serializable-dictionary__cell__valid";

        private SerializedProperty _dictionaryProperty;
        private SerializedProperty _itemsProperty;
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
            CreateColumns();
            CreateMultiColumnListView();
            BindData();
            Add(_multiColumnListView);
        }
        #endregion

        #region Private Methods
        private void ParseProperty(SerializedProperty dictionaryProperty)
        {
            _dictionaryProperty = dictionaryProperty;
            _itemsProperty = dictionaryProperty.FindPropertyRelative("_items");
        }

        private void CreateColumns()
        {
            _keyColumn = CreateColumn("Key", "_key", null);
            _valueColumn = CreateColumn("Value", "_value", null);
            _validColumn = CreateColumn("Valid", "_isValid", MakeValidCell);
        }

        private void CreateMultiColumnListView()
        {
            _multiColumnListView = new MultiColumnListView();
            _multiColumnListView.columns.Add(_keyColumn);
            _multiColumnListView.columns.Add(_valueColumn);
            _multiColumnListView.columns.Add(_validColumn);
            _multiColumnListView.showFoldoutHeader = true;
            _multiColumnListView.showAddRemoveFooter = true;
            _multiColumnListView.headerTitle = _dictionaryProperty.displayName;
            _multiColumnListView.showBoundCollectionSize = false;
        }

        private void BindData()
        {
            if (_itemsProperty == null)
            {
                return;
            }
            _multiColumnListView.BindProperty(_itemsProperty);
        }

        private Column CreateColumn(string title, string bindingPath, Func<VisualElement> makeCell)
        {
            var column = new Column();
            column.title = title;
            column.stretchable = true;
            column.bindingPath = bindingPath;
            column.makeCell = makeCell;
            return column;
        }

        private VisualElement MakeValidCell()
        {
            var toggle = new Toggle();
            toggle.SetEnabled(false);
            toggle.AddToClassList(_ussValid);
            return toggle;
        }
        #endregion
    }
}
