using OpenCalligraphy.Core.FileSystem;

namespace OpenCalligraphy.Gui.Helpers
{
    /// <summary>
    /// Helper functions for using a <see cref="FileTree"/> as a virtual backend for a <see cref="TreeView"/>.
    /// </summary>
    internal static class FileTreeHelper
    {
        private const string VirtualTreeViewNodeName = "__VIRTUAL_NODE";

        public static void InitializeFileTreeView(TreeView treeView, FileTree fileTree)
        {
            // Build the initially visible nodes of the file tree view
            treeView.BeginUpdate();
            treeView.Nodes.Clear();

            TreeNode root = treeView.Nodes.Add(fileTree.Root.Name);
            root.Tag = fileTree.Root;

            PopulateFileTreeViewNode(root, fileTree.Root);

            root.Expand();
            treeView.EndUpdate();
        }

        public static void TryLoadFileTreeNode(TreeNode treeNode)
        {
            if (treeNode.Tag is not FileTreeNode fileTreeNode)
                return;

            if (treeNode.Nodes.Count != 1 || treeNode.Nodes[0].Text != VirtualTreeViewNodeName)
                return;

            treeNode.TreeView.BeginUpdate();

            PopulateFileTreeViewNode(treeNode, fileTreeNode);

            treeNode.TreeView.EndUpdate();
        }

        public static void FocusNode(TreeView treeView, string path)
        {
            string[] separatedPath = path.Split(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);

            TreeNode currentNode = treeView.Nodes[0];
            for (int i = 0; i < separatedPath.Length; i++)
            {
                currentNode = FindChildNodeWithText(currentNode, separatedPath[i]);
                if (currentNode == null)
                    break;

                if (i < separatedPath.Length - 1)
                    currentNode.Expand();
            }

            treeView.SelectedNode = currentNode;
        }

        private static TreeNode FindChildNodeWithText(TreeNode node, string text)
        {
            foreach (TreeNode child in node.Nodes)
            {
                if (child.Text == text)
                    return child;
            }

            return null;
        }

        private static void PopulateFileTreeViewNode(TreeNode viewNode, FileTreeNode fileNode)
        {
            viewNode.Nodes.Clear();

            foreach (FileTreeNode fileNodeChild in fileNode)
            {
                TreeNode viewNodeChild = viewNode.Nodes.Add(fileNodeChild.Name);
                viewNodeChild.Tag = fileNodeChild;

                // Add a placeholder for children that will be replaced when this node is expanded
                if (fileNodeChild.HasChildren)
                    viewNodeChild.Nodes.Add(VirtualTreeViewNodeName);
            }
        }
    }
}
