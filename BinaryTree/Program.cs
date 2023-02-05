using BinaryTree;

internal class Program
{
    private static void Main(string[] args)
    {
        TreeService tr = new TreeService();
        var tree = tr.BuildTree(10);
        
        foreach (var item in tree)
        {
            Console.WriteLine(item.Name);
            Console.WriteLine(item.Id);
            Console.WriteLine(item.Children);
        }
    }
}