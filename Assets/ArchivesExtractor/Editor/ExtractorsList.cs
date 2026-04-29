using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ArchivesExtractor.Extractors;

namespace ArchivesExtractor
{
    public static class ExtractorsList
    {
        public class ExtractorData
        {
            public string extension;
            public IExtractor extractor;
        }



        private static List<ExtractorData> extractors = new List<ExtractorData>()
        {
            new ExtractorData()
            {
                extension = ".tar.gz",
                extractor = new ExtractorTarGz(),
            },
            new ExtractorData()
            {
                extension = ".rar",
                extractor = new ExtractorRar(),
            },
            new ExtractorData()
            {
                extension = ".zip",
                extractor = new ExtractorZip(),
            },
            new ExtractorData()
            {
                extension = ".7z",
                extractor = new Extractor7z(),
            },
            new ExtractorData()
            {
                extension = ".tar",
                extractor = new ExtractorTar(),
            },
        };



        public static bool IsArchive(string path)
        {
            return GetExtractor(path) != null;
        }

        public static IExtractor GetExtractor(string path)
        {
            var data = extractors
                .OrderByDescending(x => x.extension.Length)
                .FirstOrDefault(x => path.EndsWith(x.extension, StringComparison.OrdinalIgnoreCase));

            return data?.extractor;
        }
    }
}
