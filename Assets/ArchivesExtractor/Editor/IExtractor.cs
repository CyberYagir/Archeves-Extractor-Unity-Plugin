using UnityEngine;

namespace ArchivesExtractor
{
    public interface IExtractor
    {
        public void Extract(string path);
    }
}