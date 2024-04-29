namespace LeetCodeProblemsApp
{
    // Definition for a binary tree node.
    public class TreeNode
    {
        public int Value;
        public TreeNode? Left;
        public TreeNode? Right;

        public TreeNode(int x) { Value = x; }

        public TreeNode(int x, TreeNode left, TreeNode right)
        {
            Value = x;
            Left = left;
            Right = right;
        }
    }
    public class MinimumDepthofBinaryTree
    {
        // Method to build a binary tree from user input.
        public async Task<TreeNode?> BuildTree(TreeNode? root)
        {
            Console.Write("Enter node value: ");
            int data = Convert.ToInt32(Console.ReadLine());

            if (data == -1)
                return null;

            root = new TreeNode(data);

            Console.WriteLine($"Enter left child of {data}:");
            root.Left = await BuildTree(root.Left);

            Console.WriteLine($"Enter right child of {data}:");
            root.Right = await BuildTree(root.Right);

            return root;
        }

        // Method to find the minimum depth of a binary tree.
        public int MinDepth(TreeNode? root)
        {
            if (root == null)
                return 0;

            if (root.Left == null && root.Right == null)
                return 1;

            if (root.Left == null)
                return 1 + MinDepth(root.Right);

            if (root.Right == null)
                return 1 + MinDepth(root.Left);

            return 1 + Math.Min(MinDepth(root.Left), MinDepth(root.Right));
        }

        static async Task Main(string[] args)
        {
            MinimumDepthofBinaryTree solution = new MinimumDepthofBinaryTree();
            TreeNode? root = null;
            root = await solution.BuildTree(root);
            Console.WriteLine($"Minimum depth of the binary tree: {solution.MinDepth(root)}");
        }
    }
}
