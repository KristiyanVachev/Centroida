namespace AVLTree
{
    public class Startup
    {
        public static void Main()
        {
            var tree = new AVL();

            tree.Add(2);
            tree.Add(4);
            tree.Add(1);
            tree.Add(6);
            tree.Add(8);
        }
    }
}
