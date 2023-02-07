using System.Text;

namespace BinaryTree
{
    public sealed class TreeStructureService
    {
        private static readonly Random random = new();
        private static readonly string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        /// <summary>
        /// Return root node.
        /// </summary>
        public TreeItems BuildTree(int amount)
        {
            Dictionary<int, TreeNode> nodes = GenerateNodes(amount);

            Dictionary<int, TreeItems> tree = BuildTreeStructure(nodes);

            return tree[0];
        }

        /// <summary>
        /// Genereate nodes
        /// </summary>
        private Dictionary<int, TreeNode> GenerateNodes(int amount)
        {
            Dictionary<int, TreeNode> nodes = new Dictionary<int, TreeNode>();

            nodes[0] = new TreeNode { Id = 0, Name = "Root", ParentId = -1 };
            for (int i = 1; i < amount; i++)
            {
                nodes[i] = new TreeNode
                {
                    Id = i,
                    Name = GenerateRandomString(10),
                    ParentId = random.Next(0, i - 1)
                };
            }
            return nodes;
        }

        /// <summary>
        /// Build tree structure.
        /// </summary>
        private Dictionary<int, TreeItems> BuildTreeStructure(Dictionary<int, TreeNode> nodes)
        {
            Dictionary<int, TreeItems> tree = new Dictionary<int, TreeItems>();
            foreach (var node in nodes.Values)
            {
                if (!tree.ContainsKey(node.Id))
                    tree[node.Id] = new TreeItems { Id = node.Id, Name = node.Name, Children = new List<TreeItems>() };
                if (node.ParentId != -1 && tree.ContainsKey(node.ParentId))
                    tree[node.ParentId].Children.Add(tree[node.Id]);
            }

            return tree;
        }

        /// <summary>
        /// Generate random string for name field in nodes
        /// </summary>
        private string GenerateRandomString(int length)
        {
            StringBuilder result = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                result.Append(characters[random.Next(characters.Length)]);
            }
            return result.ToString();
        }
    }
}
