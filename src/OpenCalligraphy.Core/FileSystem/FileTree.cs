namespace OpenCalligraphy.Core.FileSystem
{
    public class FileTree
    {
        public FileTreeNode Root { get; } = new();

        public FileTree(string rootName = "")
        {
            Root.Name = rootName;
        }

        public void AddFile(string path)
        {
            string[] separatedPath = path.Split(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);

            FileTreeNode currentNode = Root;
            for (int i = 0; i < separatedPath.Length; i++)
                currentNode = GetOrCreateNode(currentNode, separatedPath[i]);

            currentNode.FilePath = path;
        }

        public void AddFileList(IReadOnlyList<string> fileList)
        {
            int count = fileList.Count;
            for (int i = 0; i < count; i++)
                AddFile(fileList[i]);
        }

        public void Clear()
        {
            Root.Nodes.Clear();
        }

        private static FileTreeNode GetOrCreateNode(FileTreeNode root, string name)
        {
            foreach (FileTreeNode child in root.Nodes)
            {
                if (child.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                    return child;
            }

            FileTreeNode node = new() { Name = name };
            root.Nodes.Add(node);
            return node;
        }
    }
}
