namespace OpenCalligraphy.Core.FileSystem
{
    public class FileTreeNode
    {
        public string Name { get; set; }
        public string FilePath { get; set; }
        public List<FileTreeNode> Nodes { get; } = new();

        public bool IsFile { get => string.IsNullOrWhiteSpace(FilePath) == false; }
        public bool HasChildren { get => Nodes.Count > 0; }

        public FileTreeNode()
        {
        }

        public override string ToString()
        {
            return Name;
        }

        public List<FileTreeNode>.Enumerator GetEnumerator()
        {
            return Nodes.GetEnumerator();
        }
    }
}
