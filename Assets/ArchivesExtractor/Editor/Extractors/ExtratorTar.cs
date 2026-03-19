using SharpCompress.Archives.Tar;

namespace ArchivesExtractor.Extractors
{
    public class ExtractorTar : ExtractorBase
    {
        protected override void ExtractInternal(string archivePath, string outputDirectory)
        {
            using var archive = TarArchive.Open(archivePath);
            ExtractArchiveEntries(archive, outputDirectory);
        }
    }
}