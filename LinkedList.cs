using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListonly
{

    using System;

    class LinkedList
    {
        public Node head; // head of list

        /* Linked list Node*/
        public class Node
        {
            public int data;
            public Node next;
            public Node(int d) { data = d; next = null; }
        }

        /* Inserts a new Node at front of the list. */
        public void push(int new_data)
        {
            /* 1 & 2: Allocate the Node &
                    Put in the data*/
            Node new_node = new Node(new_data);

            /* 3. Make next of new Node as head */
            new_node.next = head;

            /* 4. Move the head to point to new Node */
            head = new_node;
        }

        /* Inserts a new node after the given prev_node. */
        public void insertAfter(Node prev_node, int new_data)
        {
            /* 1. Check if the given Node is null */
            if (prev_node == null)
            {
                Console.WriteLine("The given previous" +
                                  " node cannot be null");
                return;
            }

            /* 2 & 3: Allocate the Node &
                    Put in the data*/
            Node new_node = new Node(new_data);

            /* 4. Make next of new Node as
                  next of prev_node */
            new_node.next = prev_node.next;

            /* 5. make next of prev_node as new_node */
            prev_node.next = new_node;
        }

        /* Appends a new node at the end. This method is
        defined inside LinkedList class shown above */
        public void append(int new_data)
        {
            /* 1. Allocate the Node &
            2. Put in the data
            3. Set next as null */
            Node new_node = new Node(new_data);

            /* 4. If the Linked List is empty,
            then make the new node as head */
            if (head == null)
            {
                head = new Node(new_data);
                return;
            }

            /* 4. This new node is going to be the last node,
                so make next of it as null */
            new_node.next = null;

            /* 5. Else traverse till the last node */
            Node last = head;
            while (last.next != null)
                last = last.next;

            /* 6. Change the next of last node */
            last.next = new_node;
            return;
        }

        /* This function prints contents of linked list
        starting from the given node */
        public void printList()
        {
            Node tnode = head;
            while (tnode != null)
            {
                Console.Write(tnode.data + " ");
                tnode = tnode.next;
            }
        }

        Node reverseList(Node Dhead)
        {
            Node current = Dhead;
            Node prev = null;
            Node next;
            while (current != null)
            {
                next = current.next;
                current.next = prev;
                prev = current;
                current = next;
            }
            Dhead = prev;
            return Dhead;
        }
        Node mergeList(Node head1, Node head2)
        {
            // Base cases
            if (head1 == null)
                return head2;
            if (head2 == null)
                return head1;

            Node temp = null;
            if (head1.data < head2.data)
            {
                temp = head1;
                head1.next = mergeList(head1.next, head2);
            }
            else
            {
                temp = head2;
                head2.next = mergeList(head1, head2.next);
            }
            return temp;
        }
        void sort()
        {
            /* Create 2 dummy nodes and initialise as
            heads of linked lists */
            Node Ahead = new Node(0), Dhead = new Node(0);

            // Split the list into lists
            splitList(Ahead, Dhead);

            Ahead = Ahead.next;
            Dhead = Dhead.next;

            // reverse the descending list
            Dhead = reverseList(Dhead);

            // merge the 2 linked lists
            head = mergeList(Ahead, Dhead);
        }
        void splitList(Node Ahead, Node Dhead)
        {
            Node ascn = Ahead;
            Node dscn = Dhead;
            Node curr = head;

            // Link alternate nodes

            while (curr != null)
            {
                // Link alternate nodes in ascending order
                ascn.next = curr;
                ascn = ascn.next;
                curr = curr.next;

                if (curr != null)
                {
                    dscn.next = curr;
                    dscn = dscn.next;
                    curr = curr.next;
                }
            }
         

            ascn.next = null;
            dscn.next = null;
        }
        // Driver Code
        public static void Main(String[] args)
        {
            LinkedList llist = new LinkedList();

        
            llist.append(56);

           
            llist.push(30);

            llist.push(40);
            llist.push(70);

      
            Console.Write("Created Linked list is: ");
            llist.printList();
        }
    }
}


