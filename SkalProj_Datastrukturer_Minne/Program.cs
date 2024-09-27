using System;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Drawing;
using System.Numerics;
using Microsoft.VisualBasic;

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 5, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParenthesis"
                    + "\n5. Reverse String"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    case '5':
                        ReverseText();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {

            List<string> theList = new List<string>();

            while (true)
            {
                Console.WriteLine($"Current list count: {theList.Count}, capacity: {theList.Capacity}");
                Console.WriteLine("Enter '+item' to add, '-item' to remove, or 'exit' to quit:");
                string input = Console.ReadLine()?.Trim() ?? string.Empty;

                if (input.ToLower() == "exit")
                    break;

                if (input.Length < 2)
                {
                    Console.WriteLine("Please use '+' or '-' followed by an item.");
                    continue;
                }

                char nav = input[0];
                string value = input.Substring(1);

                switch (nav)
                {
                    case '+':
                        theList.Add(value);
                        Console.WriteLine($"Added '{value}' to the list.");
                        break;
                    case '-':
                        if (theList.Remove(value))
                            Console.WriteLine($"Removed '{value}' from the list.");
                        else
                            Console.WriteLine($"'{value}' not found in the list.");
                        break;
                    default:
                        Console.WriteLine("Please use only '+' or '-'.");
                        break;
                }
            }

            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */

            //List<string> theList = new List<string>();
            //string input = Console.ReadLine();
            //char nav = input[0];
            //string value = input.substring(1);

            //switch(nav){...}

            /*
                När ökar listans kapacitet?
                The capacity of the list increases when the number of elements exceeds its current capacity.

                Med hur mycket ökar kapaciteten?
                The capacity usually doubles when it needs to expand. an example of this would be that it increases from 4 to 8, then to 16, and so on.

                Varför ökar inte listans kapacitet i samma takt som element läggs till?
                To optimize performance and memory usage. Increasing the capacity requires creating a new array and copying elements over, which is an expensive operation. By doubling the capacity, we reduce the frequency of these operations.

                Minskar kapaciteten när element tas bort ur listan?
                No, the capacity does not automatically decrease when elements are removed. It retains the maximum capacity it has reached.

                När är det då fördelaktigt att använda en egendefinierad array istället för en lista?
                - When you know the exact size of the collection in advance.
                - When there is a need to optimize memory usage and avoid extra capacity.
                - When there is no required resizing of the collection.
                - When performance is very critical, where a list could cause unnecessary overload
            */


        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {

            Queue<string> queue = new Queue<string>();

            Console.WriteLine("Choose an option:");
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. Add a person to the queue (Enqueue)");
            Console.WriteLine("2. Serve a person from the queue (Dequeue)");
            Console.WriteLine("3. View the person at the front of the queue (Peek)");

            try
            {
                while (true)
                {
                    Console.WriteLine("\nCurrent queue: " + (queue.Count > 0 ? string.Join(", ", queue) : "empty"));
                    Console.WriteLine("Number of people in queue: " + queue.Count);

                    char choice = Console.ReadLine()![0];

                    switch (choice)
                    {
                        case '1':
                            Console.Write("Enter the name of the person to add to the queue: ");
                            string name = Console.ReadLine()?.Trim() ?? string.Empty;
                            if (string.IsNullOrEmpty(name))
                            {
                                Console.WriteLine("Couldn't add the person to the queue. Please try again.");
                            }

                            queue.Enqueue(name);
                            Console.WriteLine($"{name} has been added to the queue.");
                            break;

                        case '2':
                            if (queue.Count > 0)
                            {
                                string dequeuedPerson = queue.Dequeue();
                                Console.WriteLine($"{dequeuedPerson} has been served and left the queue.");
                            }
                            else
                            {
                                Console.WriteLine("The queue is empty. No one to serve.");
                            }

                            break;

                        case '3':
                            if (queue.Count > 0)
                            {
                                Console.WriteLine($"The person at the front of the queue is: {queue.Peek()}");
                            }
                            else
                            {
                                Console.WriteLine("The queue is empty.");
                            }

                            break;

                        case '0':
                            return;

                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Please try again.");
            }
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */
        }

        /*
           Simulation of the queue at ICA:

           a. The store opens, and the checkout line is empty.
           Current queue: None
           Number of people in the queue: 0

           b. Kalle joins the queue.
           Choose option: 1
           Enter the name of the person: Kalle
           Current queue: Kalle
           Number of people in the queue: 1

           c. Greta joins the queue.
           Choose option: 1
           Enter the name of the person: Greta
           Current queue: Kalle, Greta
           Number of people in the queue: 2

           d. Kalle is served and leaves the queue.
           Choose option: 2
           Current queue: Greta
           Number of people in the queue: 1

           e. Stina joins the queue.
           Choose option: 1
           Enter the name of the person: Stina
           Current queue: Greta, Stina
           Number of people in the queue: 2

           f. Greta is served and leaves the queue.
           Choose option: 2
           Current queue: Stina
           Number of people in the queue: 1

           g. Olle joins the queue.
           Choose option: 1
           Enter the name of the person: Olle
           Current queue: Stina, Olle
           Number of people in the queue: 2
       */


        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */


            // Create a stack to hold string elements
            Stack<string> stack = new Stack<string>();

            // The loop will continue until the user chooses to exit
            while (true)
            {
                // Display the current stack status and options
                Console.WriteLine($"\nCurrent stack: {(stack.Count > 0 ? string.Join(", ", stack) : "empty")}");
                Console.WriteLine($"Number of items in stack: {stack.Count}");
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Push an item onto the stack");
                Console.WriteLine("2. Pop an item from the stack");
                Console.WriteLine("3. Peek at the top item of the stack");
                Console.WriteLine("0. Exit to main menu");

                // Read the user's input
                char input = Console.ReadLine()![0];

                switch (input)
                {
                    case '1':
                        // Push an item onto the stack
                        Console.Write("Enter the item to push onto the stack: ");
                        string item = Console.ReadLine()?.Trim() ?? string.Empty;
                        if (string.IsNullOrEmpty(item))
                        {
                            Console.WriteLine("Invalid input. Please enter a valid item.");
                        }
                        else
                        {
                            stack.Push(item);
                            Console.WriteLine($"{item} has been added to the stack.");
                        }
                        break;

                    case '2':
                        // Pop an item from the stack
                        if (stack.Count > 0)
                        {
                            string poppedItem = stack.Pop();
                            Console.WriteLine($"{poppedItem} has been removed from the stack.");
                        }
                        else
                        {
                            Console.WriteLine("The stack is empty. Nothing to pop.");
                        }
                        break;

                    case '3':
                        // Peek at the top item of the stack without removing it
                        if (stack.Count > 0)
                        {
                            Console.WriteLine($"The top item in the stack is: {stack.Peek()}");
                        }
                        else
                        {
                            Console.WriteLine("The stack is empty.");
                        }
                        break;

                    case '0':
                        // Exit the method, returning to the main menu
                        return;

                    default:
                        // Handle invalid input
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }



        public static void ReverseText()
        {
            Console.Write("Text to be reversed: ");
            string input = Console.ReadLine()?.Trim() ?? string.Empty;

            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Text is empty.");
                return;
            }

            Stack<char> charStack = new Stack<char>();

            // Add each character to the stack
            foreach (char c in input)
            {
                charStack.Push(c);
            }

            // Creating the reversed string and adds the last character from the Stack<char> to reversedString
            string reversedString = string.Empty;
            while (charStack.Count > 0)
            {
                reversedString += charStack.Pop();
            }

            Console.WriteLine("The reversed text is: " + reversedString);
        }


        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */


            Console.WriteLine("Enter a string to check for balanced parentheses, braces, and brackets:");
            string input = Console.ReadLine() ?? string.Empty;

            Stack<char> stack = new Stack<char>();

            foreach (char ch in input)
            {
                if (ch == '(' || ch == '{' || ch == '[')
                {
                    // Push opening brackets onto the stack
                    stack.Push(ch);
                }
                else if (ch == ')' || ch == '}' || ch == ']')
                {
                    // If it's a closing bracket, check if it matches the top of the stack
                    if (stack.Count == 0)
                    {
                        // Stack is empty, so no matching opening bracket
                        Console.WriteLine("The parentheses are unbalanced.");
                        return;
                    }

                    char top = stack.Pop();
                    if (!IsMatchingPair(top, ch))
                    {
                        // Mismatched pair
                        Console.WriteLine("The parentheses are unbalanced.");
                        return;
                    }
                }
            }

            // If the stack is empty, all parentheses are balanced
            if (stack.Count == 0)
            {
                Console.WriteLine("The parentheses are balanced.");
            }
            else
            {
                Console.WriteLine("The parentheses are unbalanced.");
            }


        }

        // Helper function to check if the opening and closing brackets match
        static bool IsMatchingPair(char opening, char closing)
        {
            return (opening == '(' && closing == ')') ||
                   (opening == '{' && closing == '}') ||
                   (opening == '[' && closing == ']');
        }

    }

}







// 1. Hur fungerar stacken och heapen? 

//The stack and heap are two areas of memory used for different purposes in programming.

//Stack:

//    Structure: The stack is a region of memory that operates in a Last In, First Out (LIFO) manner, meaning the last item added is the first one to be removed.
//    Purpose: It is used for storing local variables, function calls, and control flow data.
//    Memory Allocation: Memory allocation on the stack is static and is determined at compile time. When a function is called, its local variables and function parameters are stored on the stack. Once the function returns, the memory is automatically freed (no need for manual deallocation).
//    Fast Access: Since stack memory is small and operates in a fixed-size block, it's very fast to allocate and deallocate.


//Heap:

//    Structure: The heap is a region of memory used for dynamic memory allocation. Unlike the stack, it doesn't have the LIFO structure. Instead, you can allocate and deallocate memory in any order.
//    Purpose: It's used for data that needs to persist beyond the scope of a single function, such as objects or data structures whose size or lifespan aren't known until runtime.
//    Memory Allocation: Memory allocation on the heap is managed at runtime using commands like new in C#. You must explicitly free heap memory (e.g. via the garbage collector which handles this).
//    Slower Access: Accessing heap memory is slower than accessing stack memory because it involves more complex management.



//--------------------------- **************** ------------------------------------

//2. Vad är Value Types respektive Reference Types och vad skiljer dem åt?

//Key Differences:

//Lifetime:
//Stack memory is automatically freed once the function exits, whereas heap memory persists until explicitly freed (or garbage collected in managed languages like C#).
//Size:
//Stack is typically much smaller and limited in size, whereas the heap is larger and more flexible.
//Performance:
//Stack operations(allocation and deallocation) are faster because of the LIFO nature, while heap operations are slower because memory needs to be dynamically allocated and deallocated.

//--------------------------- **************** -----------------------------------

//3.Följande metoder(se bild nedan) genererar olika svar. Den första returnerar 3, den andra returnerar 4, varför?

// In the First Method:
//integers(int) are value types. When you assign a value type to another variable, it creates a copy of the value.
//In the first method, x = 3 sets x to 3. When y = x, it copies the value of x into y, so y now holds the value 3 independently of x.
//Then, y = 4 changes the value of y to 4, but since x and y are independent, this does not affect x.
//Therefore, the method returns the value of x, which is still 3.

// In the Second Method:
//MyInt is a reference type(like a class). When you assign one reference type variable to another (y = x), both y and x now point to the same object in memory.
//After x.MyValue = 3, x refers to an object where MyValue is 3. When y = x, y starts pointing to the same object as x.
//When y.MyValue = 4, it modifies the object that both x and y refer to. Since they reference the same object, x.MyValue is now also 4.
//Therefore, the method returns 4.


