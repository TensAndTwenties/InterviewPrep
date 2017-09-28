using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPrep
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.1
            //DuplicateChars();

            //1.3
            //StringPermutation();

            //1.4
            //StringReplace();
            
            //1.5 
            //StringCompression();

            //2.1
            //LinkedListRemoveDupes();

            //2.2
            //kthToLastElement();
        }

        private static void kthToLastElement()
        {
            Console.WriteLine("Interview Prep: CTCI 2.2 - find the Kth to last element of a singly-linked list");
            Console.WriteLine("Enter string of ints for Linked List Data, ex '9231325': ");
            string input = Console.ReadLine();

            Console.WriteLine("Enter the Kth element to find from the list: ");
            string kthString = Console.ReadLine();

            Node result = kthToLastElementHelper(input);

            Console.WriteLine("Kth to last element: ");
            PrintoutLinkedListContents(result);

            Console.WriteLine("Completed. Press any key to exit.");
            Console.ReadKey();
        }

        private static void LinkedListRemoveDupes()
        {
            Console.WriteLine("Interview Prep: CTCI 2.1 - remove duplicates from an unsorted linked list");
            Console.WriteLine("Enter string of ints for Linked List Data, ex '9231325': ");
            string input = Console.ReadLine();

            Node result = LinkedListRemoveDupes(input);

            Console.WriteLine("New linked list contents: ");
            PrintoutLinkedListContents(result);

            Console.WriteLine("Completed. Press any key to exit.");
            Console.ReadKey();
        }

        private static void StringCompression() {
            Console.WriteLine("Interview Prep: CTCI 1.5 - compress a string such that aabbbccccc becomes a2b3c5");
            Console.WriteLine("Enter String to compress: ");
            string input = Console.ReadLine();

            string result = StringCompressionHelper(input);

            Console.WriteLine("New compressed string: " + result);

            Console.WriteLine("Completed. Press any key to exit.");
            Console.ReadKey();
        }

        private static void StringReplace() {
            Console.WriteLine("Interview Prep: CTCI 1.4 - replace all space chars with %20");
            Console.WriteLine("Enter String to replace spaces with %20: ");
            string input = Console.ReadLine();


            string result = StringReplaceHelper(input);

            Console.WriteLine("new string with replaced spaces: " + result);

            Console.WriteLine("Completed. Press any key to exit.");
            Console.ReadKey();
        }

        private static void StringPermutation() {
            Console.WriteLine("Interview Prep: CTCI 1.3 - Find out if two strings are permutations of each other");
            Console.WriteLine("Enter first string: ");
            string firstString = Console.ReadLine();
            Console.WriteLine("Enter second string: ");
            string secondString = Console.ReadLine();

            bool result = StringPermutationHelper(firstString,secondString);

            if (result) { Console.WriteLine("Given strings ARE permutations of each other!"); } else { Console.WriteLine("Not permutations!"); }

            Console.WriteLine("Completed. Press any key to exit.");
            Console.ReadKey();
        }

        private static void DuplicateChars() {
            Console.WriteLine("Interview Prep: CTCI 1.1 - Are there duplicate characters in entered string?");
            Console.WriteLine("Enter String to test for duplicate chars: ");
            string input = Console.ReadLine();


            bool result = DuplicateCharsHelper(input);

            if (result) { Console.WriteLine("No dupes found!"); } else { Console.WriteLine("Dupes found!"); }

            Console.WriteLine("Completed. Press any key to exit.");
            Console.ReadKey();
        }

        private static Node LinkedListRemoveDupes(string input) {

            Node head = CreateLinkedListFromString(input);
            //list made, now traverse it and look for duplicates

            Dictionary<int, bool> hash = new Dictionary<int, bool>();

            Node currentNode = head;
            Node Previous = null;

            while (currentNode != null)
            {
                if (hash.ContainsKey(currentNode.data))
                {
                    //dupe - remove
                    Previous.next = currentNode.next;
                }
                else
                {
                    //new data - add to dictionary
                    hash.Add(currentNode.data, true);
                    Previous = currentNode;
                }
                currentNode = currentNode.next;
            }

            return head;
            
        }

        private static void PrintoutLinkedListContents(Node head) {
            while (head != null) {
                Console.WriteLine(head.data.ToString());
                head = head.next;
            }
        }

        private static Node CreateLinkedListFromString(string input) {
                //assume given string is only ints. Use these to create an un-sorted LL
                Node currentNode = null;
                Node head = null;

                foreach (char c in input)
                {

                    if (currentNode == null)
                    {
                        currentNode = new Node((int)Char.GetNumericValue(c));
                        head = currentNode;
                    }
                    else
                    {
                        currentNode.AddNode((int)Char.GetNumericValue(c));
                        currentNode = currentNode.next;
                    }
                }

            return head;
            }

        private static string StringCompressionHelper(string input) {
            Dictionary<char, int> dictionary = new Dictionary<char, int>();
            string output = "";

            foreach (char c in input) {
                if (dictionary.ContainsKey(c))
                {
                    dictionary[c] += 1;
                }
                else {
                    dictionary.Add(c, 1);
                }
            }

            foreach (KeyValuePair<char, int> kv in dictionary) {
                output = output + kv.Key;

                if (kv.Value > 0) { 
                    output = output + kv.Value.ToString();
                }
            }

            if (input.Length <= output.Length) {
                output = input;
            }

            return output;
        }

        private static string StringReplaceHelper(string input) {
            //count spaces
            //new string length = old string length + spaceCount*2
            input = input.Trim();

            int spacecount = 0;

            foreach (char c in input) {
                if (c == ' ') { spacecount += 1; }
            }

            if (spacecount == 0) {
                return input;
            }

            char[] outputArr = new char[input.Length + spacecount * 2];
            int outputIndex = outputArr.Length-1;
            char[] inputArr = input.ToCharArray();

            for (int i = input.Length-1; i >=0 ; i--) {
                if (inputArr[i] == ' ')
                {
                    outputArr[outputIndex] = '0';
                    outputArr[outputIndex - 1] = '2';
                    outputArr[outputIndex - 2] = '%';
                    outputIndex -=3;
                }
                else {
                    outputArr[outputIndex] = inputArr[i];
                    outputIndex -= 1;
                }
            }

            string returned = new string(outputArr);
            return returned;
        }

        private static bool DuplicateCharsHelper(string input) {
            //assume ASCII, 128 chars max
            if (input.Length > 128)
            {
                return false;
            }
            else
            {
                bool[] charUsed = new bool[128];

                foreach (char c in input)
                {
                    if (charUsed[(int)c] == true)
                    {
                        //we found a dupe - break!
                        return false;
                    }
                    else
                    {
                        charUsed[(int)c] = true;
                    }
                }
            }

            return true;
        }

        private static bool StringPermutationHelper(string firstString, string SecondString) {
            //assuming ascii, 128 chars

            if (firstString.Length != SecondString.Length) {
                return false;
            }

            int[] charsUsedString1 = new int[128];
            int[] charsUsedString2 = new int[128];

            foreach (char c in firstString) {
                charsUsedString1[(int)c] += 1;
            }

            foreach (char c in SecondString)
            {
                charsUsedString2[(int)c] += 1;
            }

            for (int i=0; i < charsUsedString1.Length; i++) {
                if (charsUsedString1[i] != charsUsedString2[i]) {
                    return false;
                }
            }

            return true;
        }
    }

    class Node {
        public Node next = null;
        public int data;

        public Node(int d) {
            data = d;
        }

        public void AddNode(int data) {
            Node end = new Node(data);
            Node n = this;
            while (n.next != null) {
                n = n.next;
            }

            n.next = end;
        }
    }
}
