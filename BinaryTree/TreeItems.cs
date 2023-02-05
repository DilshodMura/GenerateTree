
namespace BinaryTree
{
    public sealed class TreeItems
    {
        /// <summary>
        /// Gets or sets the id of tree item
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the tree item
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets array of tree items
        /// </summary>
        public TreeItems[] Children { get; set; }
    }
}
