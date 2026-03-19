using System.IO;
using System.IO.Compression;
using SharpCompress.Common;
using SharpCompress.Readers;

namespace ArchivesExtractor.Extractors
{
    public class ExtractorTarGz : ExtractorBase
    {
        protected override void ExtractInternal(string archivePath, string outputDirectory)
        {
            using var fileStream = File.OpenRead(archivePath);

            using var gzipStream = new GZipStream(fileStream, CompressionMode.Decompress);
            using var tarStream = new MemoryStream();

            gzipStream.CopyTo(tarStream);

            tarStream.Position = 0;

            using var reader = ReaderFactory.Open(tarStream);

            int total = 0;
            int written = 0;

            while (reader.MoveToNextEntry())
            {
                total++;

                var entry = reader.Entry;

                if (entry == null || entry.IsDirectory)
                    continue;

                if (string.IsNullOrWhiteSpace(entry.Key))
                {
                    continue;
                }

                reader.WriteEntryToDirectory(
                    outputDirectory,
                    new ExtractionOptions
                    {
                        ExtractFullPath = true,
                        Overwrite = true
                    }
                );

                written++;
            }
        }
    }
}