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
