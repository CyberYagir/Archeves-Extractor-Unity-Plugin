using System.IO;
using SharpCompress.Archives.Zip;

namespace ArchivesExtractor.Extractors
{
    public class ExtractorZip : ExtractorBase
    {
        protected override void ExtractInternal(string archivePath, string outputDirectory)
        {
            using var stream = File.OpenRead(archivePath);
            using var archive = ZipArchive.Open(stream);

            ExtractArchiveEntries(archive, outputDirectory);
        }
    }
}
