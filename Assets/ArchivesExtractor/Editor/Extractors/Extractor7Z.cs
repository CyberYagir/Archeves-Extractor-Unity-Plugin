using System.IO;
using SharpCompress.Archives.SevenZip;
using SharpCompress.Common;
using SharpCompress.Readers;

namespace ArchivesExtractor.Extractors
{
    public class Extractor7z : ExtractorBase
    {
        protected override void ExtractInternal(string archivePath, string outputDirectory)
        {
            using var stream = File.OpenRead(archivePath);
            using var archive = SevenZipArchive.Open(stream);
            using var reader = archive.ExtractAllEntries();

            while (reader.MoveToNextEntry())
            {
                if (reader.Entry.IsDirectory)
                    continue;

                reader.WriteEntryToDirectory(
                    outputDirectory,
                    new ExtractionOptions
                    {
                        ExtractFullPath = true,
                        Overwrite = true
                    }
                );
            }
        }



    }
}
