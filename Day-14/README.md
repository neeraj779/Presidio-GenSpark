# Task for the Day-14

- [Minimum Depth of Binary Tree](#1-minimum-depth-of-binary-tree)
- [Excel Sheet Column Title](#2-excel-sheet-column-title)
- [Linked List Cycle](#3-linked-list-cycle)

**Note: All code shoud be written in asynchronous manner.**

---

### 1. Minimum Depth of Binary Tree

**Problem Statement:**

<p>Given a binary tree, find its minimum depth.</p>

<p>The minimum depth is the number of nodes along the shortest path from the root node down to the nearest leaf node.</p>

<p><strong>Note:</strong>&nbsp;A leaf is a node with no children.</p>

<p>&nbsp;</p>
<p><strong class="example">Example 1:</strong></p>
<img alt="" src="https://assets.leetcode.com/uploads/2020/10/12/ex_depth.jpg" style="width: 432px; height: 302px;" />
<pre>
<strong>Input:</strong> root = [3,9,20,null,null,15,7]
<strong>Output:</strong> 2
</pre>

<p><strong class="example">Example 2:</strong></p>

<pre>
<strong>Input:</strong> root = [2,null,3,null,4,null,5,null,6]
<strong>Output:</strong> 5
</pre>

<p>&nbsp;</p>
<p><strong>Constraints:</strong></p>

<ul>
	<li>The number of nodes in the tree is in the range <code>[0, 10<sup>5</sup>]</code>.</li>
	<li><code>-1000 &lt;= Node.val &lt;= 1000</code></li>
</ul>

**Solution:**

GitHub Link: [MinimumDepthofBinaryTree.cs](LeetCodeProblemsApp/MinimumDepthOfBinaryTree.cs)

```C#
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
```

---

### 2. Excel Sheet Column Title

**Problem Statement:**

<p>Given an integer <code>columnNumber</code>, return <em>its corresponding column title as it appears in an Excel sheet</em>.</p>

<p>For example:</p>

<pre>
A -&gt; 1
B -&gt; 2
C -&gt; 3
...
Z -&gt; 26
AA -&gt; 27
AB -&gt; 28 
...
</pre>

<p>&nbsp;</p>
<p><strong class="example">Example 1:</strong></p>

<pre>
<strong>Input:</strong> columnNumber = 1
<strong>Output:</strong> &quot;A&quot;
</pre>

<p><strong class="example">Example 2:</strong></p>

<pre>
<strong>Input:</strong> columnNumber = 28
<strong>Output:</strong> &quot;AB&quot;
</pre>

<p><strong class="example">Example 3:</strong></p>

<pre>
<strong>Input:</strong> columnNumber = 701
<strong>Output:</strong> &quot;ZY&quot;
</pre>

<p>&nbsp;</p>
<p><strong>Constraints:</strong></p>

<ul>
	<li><code>1 &lt;= columnNumber &lt;= 2<sup>31</sup> - 1</code></li>
</ul>

**Solution:**

GitHub Link: [ExcelSheetColumnTitle.cs](LeetCodeProblemsApp/ExcelSheetColumnTitle.cs)

```C#
namespace LeetCodeProblemsApp
{
    // Method to convert a column number to an Excel sheet column title.
    public class ExcelSheetColumnTitle
    {
        public async Task<string> ConvertToTitle(int columnNumber)
        {
            string result = "";

            await Task.Run(() =>
            {
                while (columnNumber > 0)
                {
                    columnNumber--;
                    result = (char)('A' + columnNumber % 26) + result;
                    columnNumber /= 26;
                }
            });

            return result;
        }

        static async Task Main(string[] args)
        {
            ExcelSheetColumnTitle excelSheetColumnTitle = new ExcelSheetColumnTitle();
            Console.Write("Enter column number: ");

            int columnNumber;
            while (!int.TryParse(Console.ReadLine(), out columnNumber))
            {
                Console.WriteLine("Invalid input. Please enter a valid column number.");
            }

            string result = await excelSheetColumnTitle.ConvertToTitle(columnNumber);
            Console.WriteLine($"The column title is: {result}");
        }
    }
}
```

---

### 3. Linked List Cycle

**Problem Statement:**

<p>Given <code>head</code>, the head of a linked list, determine if the linked list has a cycle in it.</p>

<p>There is a cycle in a linked list if there is some node in the list that can be reached again by continuously following the&nbsp;<code>next</code>&nbsp;pointer. Internally, <code>pos</code>&nbsp;is used to denote the index of the node that&nbsp;tail's&nbsp;<code>next</code>&nbsp;pointer is connected to.&nbsp;<strong>Note that&nbsp;<code>pos</code>&nbsp;is not passed as a parameter</strong>.</p>

<p>Return&nbsp;<code>true</code><em> if there is a cycle in the linked list</em>. Otherwise, return <code>false</code>.</p>

<p>&nbsp;</p>
<p><strong class="example">Example 1:</strong></p>
<img alt="" src="https://assets.leetcode.com/uploads/2018/12/07/circularlinkedlist.png" style="width: 300px; height: 97px; margin-top: 8px; margin-bottom: 8px;">
<pre><strong>Input:</strong> head = [3,2,0,-4], pos = 1
<strong>Output:</strong> true
<strong>Explanation:</strong> There is a cycle in the linked list, where the tail connects to the 1st node (0-indexed).
</pre>

<p><strong class="example">Example 2:</strong></p>
<img alt="" src="https://assets.leetcode.com/uploads/2018/12/07/circularlinkedlist_test2.png" style="width: 141px; height: 74px;">
<pre><strong>Input:</strong> head = [1,2], pos = 0
<strong>Output:</strong> true
<strong>Explanation:</strong> There is a cycle in the linked list, where the tail connects to the 0th node.
</pre>

<p><strong class="example">Example 3:</strong></p>
<img alt="" src="https://assets.leetcode.com/uploads/2018/12/07/circularlinkedlist_test3.png" style="width: 45px; height: 45px;">
<pre><strong>Input:</strong> head = [1], pos = -1
<strong>Output:</strong> false
<strong>Explanation:</strong> There is no cycle in the linked list.
</pre>

<p>&nbsp;</p>
<p><strong>Constraints:</strong></p>

<ul>
	<li>The number of the nodes in the list is in the range <code>[0, 10<sup>4</sup>]</code>.</li>
	<li><code>-10<sup>5</sup> &lt;= Node.val &lt;= 10<sup>5</sup></code></li>
	<li><code>pos</code> is <code>-1</code> or a <strong>valid index</strong> in the linked-list.</li>
</ul>

**Solution:**

GitHub Link: [LinkedListCycle.cs](LeetCodeProblemsApp/LinkedListCycle.cs)

```C#
using System;

namespace LeetCodeProblemsApp
{
    // Definition for singly-linked list.
    public class ListNode
    {
        public int val;
        public ListNode? next;
        public ListNode(int val = 0, ListNode? next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public class LinkedListCycle
    {
        // Method to create a linked list from user input.
        public async Task<ListNode?> CreateLinkedList()
        {
            Console.Write("Enter the number of elements in the linked list: ");
            if (!int.TryParse(Console.ReadLine(), out int len) || len <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive integer.");
                return null;
            }

            Console.Write("Enter the elements of the linked list: ");
            ListNode? head = null;
            ListNode? temp = null;

            await Task.Run(() =>
            {
                for (int i = 0; i < len; i++)
                {
                    int val;
                    if (!int.TryParse(Console.ReadLine(), out val))
                        Console.WriteLine("Invalid input. Please enter an integer.");

                    if (head == null)
                    {
                        head = new ListNode(val);
                        temp = head;
                    }
                    else
                    {
                        temp!.next = new ListNode(val);
                        temp = temp!.next;
                    }
                }
            });

            Console.Write("Do you want to make the linked list circular? (yes/no): ");
            string? response = Console.ReadLine()?.Trim().ToLower();

            if (response == "yes")
            {
                Console.Write("Enter the position (1-based index) of the node to which you want to connect the last node: ");
                if (!int.TryParse(Console.ReadLine(), out int pos) || pos < 1 || pos > len)
                {
                    Console.WriteLine("Invalid position. The position must be a positive integer within the range of the linked list.");
                    return null;
                }

                ListNode? connectTo = head;
                for (int i = 1; i < pos; i++)
                {
                    connectTo = connectTo!.next;
                }

                temp!.next = connectTo;
            }

            return head;
        }

        // Method to detect a cycle in a linked list using Floyd's Tortoise algorithm.
        public bool HasCycle(ListNode? head)
        {
            if (head == null || head.next == null)
                return false;

            ListNode? slow = head;
            ListNode? fast = head;

            while (fast != null && fast.next != null)
            {
                slow = slow!.next;
                fast = fast.next.next;

                if (slow == fast)
                    return true;
            }

            return false;
        }

        static async Task Main(string[] args)
        {
            LinkedListCycle linkedListCycle = new LinkedListCycle();
            ListNode? head = await linkedListCycle.CreateLinkedList();

            if (head != null)
            {
                bool hasCycle = linkedListCycle.HasCycle(head);
                Console.WriteLine(hasCycle ? "The linked list has a cycle." : "The linked list does not have a cycle.");
            }
        }
    }
}
```
