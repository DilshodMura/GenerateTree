
namespace BinaryTree
{
    public sealed class TreeService
    {
        /// <summary>
        /// Gets array of tree items after creating each tree node with random parent id
        /// </summary>
        public TreeItems[] BuildTree(int amount)
        {
            var tree = new TreeItems[amount];

            for (var i = 0; i < amount; i++)
            {
                var node = new TreeNode
                {
                    Id = i,
                    Name = Guid.NewGuid().ToString(),
                    ParentId = i == 0 ? -1 : new Random().Next(0, i - 1)
                };

                
                var currentNode = new TreeItems
                {
                    Id = node.Id,
                    Name = node.Name
                };

                tree[i] = currentNode;

                if (node.ParentId == -1)
                {
                    continue;
                }

                var parentNode = tree.FirstOrDefault(x => x.Id == node.ParentId);
                if (parentNode == null)
                {
                    throw new Exception("Parent node not found");
                }
                else
                {
                    if (parentNode.Children != null)
                    {
                        var children = new List<TreeItems>(parentNode.Children) { currentNode };
                        parentNode.Children = children.ToArray();
                    }
                    else
                    {
                        parentNode.Children = new[] { currentNode };
                    }
                }
            }

            return tree;
        }
    }
}
