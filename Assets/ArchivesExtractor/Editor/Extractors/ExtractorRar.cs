using SharpCompress.Archives.Rar;

namespace ArchivesExtractor.Extractors
{
    public class ExtractorRar : ExtractorBase
    {
        protected override void ExtractInternal(string archivePath, string outputDirectory)
        {
            using var archive = RarArchive.Open(archivePath);
            ExtractArchiveEntries(archive, outputDirectory);
        }
    }
}
