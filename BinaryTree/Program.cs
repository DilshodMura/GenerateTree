using BinaryTree;

internal class Program
{
    private static void Main(string[] args)
    {
        TreeStructureService tr = new();
        var tree = tr.BuildTree(40);
        var stack = new Stack<TreeItems>();
        stack.Push(tree);

        //Prints the values of tree
        while(stack.Count > 0)
        {
            var node = stack.Pop();
            Console.WriteLine(node.Id+ "," +node.Name);
            if(node.Children.Count > 0 )
            {
                foreach(var child in node.Children)
                {
                    stack.Push(child);
                }
            }
        }
    }
}