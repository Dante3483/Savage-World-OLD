namespace SavageWorld.Runtime.Utilities
{
    public static class StaticValues
    {
        #region Fields
        public static readonly string AssetsPath = "Assets/";
        public static readonly string EditorPath = AssetsPath + "Editor/";
        public static readonly string ProjectPath = AssetsPath + "Project/";
        public static readonly string StylesPath = EditorPath + "Styles/";

        public static readonly string StyleExtension = ".uss";
        #endregion

        #region Properties

        #endregion

        #region Events / Delegates

        #endregion

        #region Public Methods
        public static string GetStylePath(string styleName)
        {
            return StylesPath + styleName + StyleExtension;
        }
        #endregion

        #region Private Methods

        #endregion
    }
}
