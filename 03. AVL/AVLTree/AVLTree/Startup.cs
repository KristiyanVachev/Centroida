namespace AVLTree
{
    public class Startup
    {
        public static void Main()
        {
            var tree = new AVL();


            //Left rotation
            //tree.Add(2);
            //tree.Add(4);
            //tree.Add(1);
            //tree.Add(6);
            //tree.Add(8);

            //Right rotation
            //tree.Add(4);
            //tree.Add(5);
            //tree.Add(3);
            //tree.Add(2);
            //tree.Add(1);

            //LeftRight
            tree.Add(4);
            tree.Add(1);
            tree.Add(8);
            tree.Add(5);
            tree.Add(6);

            //RightLeft
        }
    }
}
