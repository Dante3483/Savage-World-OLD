using System.IO;
using System.Linq;
using UnityEditor;
using UnityEditor.Compilation;

namespace SavageWorld.Editor
{
    public class ScriptNamespaceReplacer : AssetModificationProcessor
    {
        #region Fields

        #endregion

        #region Properties

        #endregion

        #region Events / Delegates

        #endregion

        #region Public Methods
        public static void OnWillCreateAsset(string path)
        {
            if (!path.EndsWith(".cs.meta"))
            {
                return;
            }
            var originalFilePath = AssetDatabase.GetAssetPathFromTextMetaFilePath(path);
            ReplaceNamespaceKeyword(originalFilePath);
            AssetDatabase.Refresh();
        }

        public static AssetMoveResult OnWillMoveAsset(string sourcePath, string destinationPath)
        {
            var result = AssetMoveResult.DidNotMove;
            if (!destinationPath.EndsWith(".cs"))
            {
                return result;
            }
            UpdateNamespace(sourcePath, destinationPath);
            return result;
        }
        #endregion

        #region Private Methods
        private static void ReplaceNamespaceKeyword(string path)
        {
            var correctNamespace = GetCorrectNamespace(path);
            var allText = File.ReadAllText(path);
            allText = allText.Replace("#NAMESPACE#", correctNamespace);
            File.WriteAllText(path, allText);
        }

        private static void UpdateNamespace(string path, string destinationPath)
        {
            var allText = File.ReadAllText(path);
            var oldNamespace = ExtractNamespace(allText);
            var newNamespace = string.Concat("namespace ", GetCorrectNamespace(destinationPath));
            if (oldNamespace == null)
            {
                return;
            }
            allText = allText.Replace(oldNamespace, newNamespace);
            File.WriteAllText(path, allText);
        }

        private static string GetCorrectNamespace(string path)
        {
            var asmdefNamespace = GetNamespaceFromAssemblyDefinition(path);
            var rootNamespace = EditorSettings.projectGenerationRootNamespace;
            var additionalNamespace = GetAdditionalNamespace(path);
            var fullNamespace = "";
            if (!string.IsNullOrWhiteSpace(asmdefNamespace))
            {
                fullNamespace = asmdefNamespace;
            }
            else if (!string.IsNullOrWhiteSpace(rootNamespace))
            {
                fullNamespace = rootNamespace;
            }
            else
            {
                fullNamespace = "SavageWorld";
            }
            if (!string.IsNullOrWhiteSpace(additionalNamespace))
            {
                fullNamespace = string.Concat(fullNamespace, ".", additionalNamespace);
            }
            return fullNamespace;
        }

        private static string GetNamespaceFromAssemblyDefinition(string assetPath)
        {
            return CompilationPipeline.GetAssemblyRootNamespaceFromScriptPath(assetPath);
        }

        private static string GetAdditionalNamespace(string path)
        {
            var directoryPath = Path.GetDirectoryName(path);
            var pathSegments = directoryPath.Split(Path.DirectorySeparatorChar);
            return string.Join(".", pathSegments.Skip(3));
        }

        private static string ExtractNamespace(string scriptContent)
        {
            var start = scriptContent.IndexOf("namespace ");
            if (start == -1)
            {
                return null;
            }
            //var start = namespaceStartIndex + "namespace ".Length;
            var end = scriptContent.IndexOf("{", start);
            if (end == -1)
            {
                return null;
            }
            return scriptContent[start..end].Trim();
        }
        #endregion
    }
}
