using SavageWorld.Editor.VisualElements;
using SavageWorld.Runtime.Utilities.SerializableDictionary;
using UnityEditor;
using UnityEngine.UIElements;

namespace SavageWorld.Editor.PropertyDrawers
{
    [CustomPropertyDrawer(typeof(SerializableDictionary<,>))]
    public class SerializableDictionaryDrawer : PropertyDrawer
    {
        #region Fields

        #endregion

        #region Properties

        #endregion

        #region Events / Delegates

        #endregion

        #region Monobehaviour Methods

        #endregion

        #region Public Methods
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            return new SerializableDictionaryElement(property);
        }
        #endregion

        #region Private Methods

        #endregion
    }
}
