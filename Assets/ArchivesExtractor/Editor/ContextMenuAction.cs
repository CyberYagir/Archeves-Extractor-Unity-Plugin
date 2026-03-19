using System;
using System.IO;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;


namespace ArchivesExtractor
{
    public static class AssetContextMenu
    {

        [MenuItem("Assets/Extract Archive to Folder", false, 20)]
        private static void PrintSelectedPaths()
        {
            foreach (Object obj in Selection.objects)
            {
                string path = AssetDatabase.GetAssetPath(obj);
                var fullPath = Path.GetFullPath(path);

                try
                {
                    ExtractByPath(fullPath);
                }
                catch (Exception e)
                {
                    Debug.LogException(e);
                    throw;
                }
            }
        }

        private static void ExtractByPath(string fullPath)
        {
            var extractor = ExtractorsList.GetExtractor(fullPath);

            string outputFolder = Path.Combine(
                Path.GetDirectoryName(fullPath)!,
                Path.GetFileNameWithoutExtension(fullPath)
            );

            if (Directory.Exists(outputFolder))
            {
                bool overwrite = EditorUtility.DisplayDialog(
                    "Extract Archive",
                    $"Folder already exists:\n{outputFolder}\n\nOverwrite existing files?",
                    "Extract",
                    "Cancel"
                );

                if (!overwrite)
                    return;
            }

            extractor.Extract(fullPath);
        }

        [MenuItem("Assets/Extract Archive to Folder", true)]
        private static bool PrintSelectedPathsValidate()
        {
            if (Selection.objects == null || Selection.objects.Length == 0)
            {
                return false;
            }



            bool hasArchives = false;
            foreach (Object obj in Selection.objects)
            {
                string path = AssetDatabase.GetAssetPath(obj);

                if (ExtractorsList.IsArchive(path))
                {
                    hasArchives = true;
                    break;
                }
            }

            return hasArchives;
        }
    }
}