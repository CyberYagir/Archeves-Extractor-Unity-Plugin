using System;
using System.IO;
using System.Linq;
using SharpCompress.Archives;
using SharpCompress.Common;
using UnityEditor;

namespace ArchivesExtractor
{
    public abstract class ExtractorBase : IExtractor
    {
        public void Extract(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentException("Path is null or empty", nameof(path));

            if (!File.Exists(path))
                throw new FileNotFoundException($"Archive not found: {path}", path);

            string outputDirectory = Path.Combine(
                Path.GetDirectoryName(path)!,
                GetArchiveFolderName(path)
            );

            Directory.CreateDirectory(outputDirectory);

            ExtractInternal(path, outputDirectory);

            AssetDatabase.Refresh();
        }
    
        private static string GetArchiveFolderName(string path)
        {
            string fileName = Path.GetFileName(path);

            if (fileName.EndsWith(".tar.gz", System.StringComparison.OrdinalIgnoreCase))
                return fileName.Substring(0, fileName.Length - ".tar.gz".Length);

            return Path.GetFileNameWithoutExtension(path);
        }

        protected abstract void ExtractInternal(string archivePath, string outputDirectory);

        protected static void ExtractArchiveEntries(IArchive archive, string outputDirectory)
        {
            foreach (var entry in archive.Entries.Where(e => !e.IsDirectory))
            {
                entry.WriteToDirectory(outputDirectory, new ExtractionOptions
                {
                    ExtractFullPath = true,
                    Overwrite = true
                });
            }
        }
    }
}