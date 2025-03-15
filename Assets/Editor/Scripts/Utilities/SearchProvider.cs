using System;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace SavageWorld.Editor.Utilities
{
    [CreateAssetMenu(fileName = "NewSearchProvider", menuName = "SearchProvider")]
    public class SearchProvider : ScriptableObject, ISearchWindowProvider
    {
        #region Fields
        private string _name;
        private List<Type> _types;
        #endregion

        #region Properties

        #endregion

        #region Events / Delegates
        public Action<Type> EntrySelected;
        #endregion

        #region Monobehaviour Methods

        #endregion

        #region Public Methods
        public void Setup(string name, List<Type> types)
        {
            _name = name;
            _types = types;
        }

        public List<SearchTreeEntry> CreateSearchTree(SearchWindowContext context)
        {
            List<SearchTreeEntry> tree = new()
            {
                new SearchTreeGroupEntry(new GUIContent(_name), 0),
            };
            foreach (Type type in _types)
            {
                if (!type.IsAbstract)
                {
                    GUIContent content = new(type.Name);
                    SearchTreeEntry entry = new(content);
                    entry.level = 1;
                    entry.userData = type;
                    tree.Add(entry);
                }
            }
            return tree;
        }

        public bool OnSelectEntry(SearchTreeEntry SearchTreeEntry, SearchWindowContext context)
        {
            EntrySelected?.Invoke((Type)SearchTreeEntry.userData);
            return true;
        }
        #endregion

        #region Private Methods

        #endregion
    }
}
