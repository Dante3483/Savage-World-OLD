namespace SavageWorld.Runtime.UI.MainMenu.SectionHandlers
{
    public abstract class SectionHandlerBase : ISectionHandler
    {
        #region Fields
        protected MainMenuManager _mainMenuManager;
        #endregion

        #region Properties

        #endregion

        #region Events / Delegates

        #endregion

        #region Public Methods
        public void SetManager(MainMenuManager mainMenuManager)
        {
            _mainMenuManager = mainMenuManager;
        }

        public abstract void AddListeners();

        public abstract void RemoveListeners();
        #endregion

        #region Private Methods

        #endregion
    }
}
