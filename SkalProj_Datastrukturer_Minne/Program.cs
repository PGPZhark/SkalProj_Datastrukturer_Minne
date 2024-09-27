using System;
using System.Diagnostics;

namespace SkalProj_Datastrukturer_Minne
{
    /* Frågor:
     * 1. Stacken är som en hög med data där man kan bara komma åt datan som ligger högst, 
     *    man kan ta bort datan som ligger högst upp eller lägga till data på toppen.
     *    Heapen är en form av datastruktur som håller data som man har tillgång till enkelt hursomhelst
     *    till skillnad från stacken. 
     *    Stacken klarar minnesordning själv men det gör dock inte heapen utan hjälp.
     * 2. En value type variabel håller det värdet som tilldelas den som en del av minnet. T.ex. int x = 5;
     *    Value types håller olika värden och lagras där de deklareras och kan lagras både i stacken och i heapen.
     *    Reference types är datatyper som innehåller referenser till datan i heapen. 
     *    Reference types är referenser till objekt som skapas på heapen.
     * 3. Eftersom den första körs allt på stacken medans den andra deklareras i en klass som är en reference type 
     *    så ReturnValue2() kommer returnera en position i heapen.
     */
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
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParenthesis"
                    + "\n0. Exit the application");
                Console.Write("Input: ");
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
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */

            /* 2. Listans kapacitet ökar när listan blir större än kapaciteten. 
             * 3. Den börjar med en kapacitet av 4 men när listan har 5 värden i sig ökar kapaciteten till 8.
             * 4. Kapaciteten ökar bara när det behövs för att inte ta upp onödigt mycket minne. 
             * Så bara när ett element läggs till och det går över listans kapacitet så ökar den.
             * 5. Nej.
             * 6. Vet man redan vad man ska ha i en lista är det bättre att använda en array då det tar upp mindre minne än man kan behöva.
             * Behöver man kunna lägga till saker i listan behöver man använda list.
             * 
             */

            Console.WriteLine("\nEnter input '+' or '-' followed by name/item to add or remove from the List");
            Console.WriteLine("Enter input '0' to exit.");
            
            List<string> theList = new List<string>();
            bool looping = true;
            char nav = ' ';
            string input = " ";
            string value = "";
            do
            {
                Console.Write("\nInput: ");
                input = Console.ReadLine();
                try
                {
                    nav = input[0];
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Please enter some input!");
                    break;
                }
                
                value = input.Substring(1);

                switch (nav)
                {
                    case '+':
                        theList.Add(value);
                        foreach (string item in theList)
                        {
                            //Console.WriteLine($"{item} --- {theList.Capacity}");
                            Console.WriteLine($"{item}");
                        }
                        break;
                    case '-':
                        if (theList.Count == 0)
                        {
                            break;
                        }
                        theList.Remove(value);
                        foreach (string item in theList)
                        {
                            //Console.WriteLine($"{item} --- {theList.Capacity}");
                            Console.WriteLine($"{item}");
                        }
                        break;
                    case '0':
                        looping = false;
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (+, -)");
                        break;
                }


            } while (looping);

        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */
            Queue<string> queue = new Queue<string>();

            Console.WriteLine("\nEnter input '+' followed by name/item to add to the Queue");
            Console.WriteLine("Enter input '-' to dequeue");
            Console.WriteLine("Enter input '0' to exit.");

            bool looping = true;
            char nav = ' ';
            string input = " ";
            string value = "";
            do
            {
                Console.Write("\nInput: ");
                input = Console.ReadLine();
                try
                {
                    nav = input[0];
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Please enter some input!");
                    break;
                }
                value = input.Substring(1);

                switch (nav)
                {
                    case '+':
                        queue.Enqueue(value);
                        foreach (string item in queue)
                        {
                            Console.WriteLine($"{item}");
                        }
                        break;
                    case '-':
                        if (queue.Count == 0)
                        {
                            break;
                        }
                        queue.Dequeue();
                        foreach (string item in queue)
                        {
                            Console.WriteLine($"{item}");
                        }
                        break;
                    case '0':
                        looping = false;
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (+, -)");
                        break;
                }


            } while (looping);

        }

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

            /* 1. I det här fallet så är det dumt att använda en stack för att den är last in first out vilket inte riktigt är passande här.
             * 
             * 
             */

            Stack<string> stack = new Stack<string>();

            Console.WriteLine("\nEnter input '+' followed by name/item to push to the Stack");
            Console.WriteLine("Enter input '-' to pop");
            Console.WriteLine("Enter input 'R' followed by text to Reverse text from input");
            Console.WriteLine("Enter input '0' to exit.");

            bool looping = true;
            char nav = ' ';
            string input = " ";
            string value = "";
            do
            {
                Console.Write("\nInput: ");
                input = Console.ReadLine();
                try
                {
                    nav = input[0];
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Please enter some input!");
                    break;
                }
                value = input.Substring(1);

                switch (nav)
                {
                    case '+':
                        stack.Push(value);
                        foreach (string item in stack)
                        {
                            Console.WriteLine($"{item}");
                        }
                        break;
                    case '-':
                        if (stack.Count == 0)
                        {
                            break;
                        }
                        
                        stack.Pop();
                        foreach (string item in stack)
                        {
                            Console.WriteLine($"{item}");
                        }
                        break;
                    case 'R':
                        if (value.Length == 0)
                        {
                            Console.WriteLine("Please enter text after 'R'. For example: RSample text");
                            break;
                        }
                        value = ReverseText(value);
                        Console.WriteLine(value);
                        break;
                    case '0':
                        looping = false;
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (+, -)");
                        break;
                }


            } while (looping);

        }

        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */
            /* 1. Jag använder en stack eftersom då kan jag kolla efter om det slutar på ) ] } och 
             *  kontrollerar att det finns en { [ eller ( genom en for loop.
             * 
             * 
             */

            Console.WriteLine("\nEnter (, [, {, }, ] or ) in different ways to see if its a correct or incorrect way to write it in code");
            Console.WriteLine("Enter input '0' to exit.");
            bool looping = true;
            string input = " ";
            char nav = ' ';
            string value = "";
            do
            {
                Console.Write("\nInput: ");
                input = Console.ReadLine();
                try
                {
                    nav = input[0];
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Please enter some input!");
                    break;
                }
                value = input;

                if (nav == '{' ||nav == '[' || nav == '(')
                {
                    if (StringCheck(value))
                    {
                        Console.WriteLine("Correct");
                    }
                    else if (!StringCheck(value))
                    {
                        Console.WriteLine("Incorrect");
                    }
                }
                else if (nav == ']' ||nav == ')' ||nav == '}')
                {
                    Console.WriteLine("Incorrect");
                }
                else if (nav == '0')
                {
                    looping = false;
                }
                else
                {
                    Console.WriteLine("Please enter some valid input");
                }
            } while (looping);
        }

        static string ReverseText(string text)
        {
            Stack<char> stack = new Stack<char>();
            var reversedString = "";

            foreach (var c in text)
            {
                stack.Push(c);
            }
            while (stack.Count > 0)
            {
                reversedString += stack.Pop();
            }


            return reversedString;
        }

        static bool StringCheck(String text)
        {
            Stack<char> stack = new Stack<char>();
            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];
                if (c == '[' || c == '{' || c == '(')
                    stack.Push(c);
                else if (c == ']' || c == '}' || c == ')')
                {
                    if (!stack.Any())  
                        return false;
                    switch (c)
                    {
                        case ']':
                            if (stack.Pop() != '[')
                                return false;
                            break;
                        case '}':
                            if (stack.Pop() != '{')
                                return false;
                            break;
                        case ')':
                            if (stack.Pop() != '(')
                                return false;
                            break;
                        default:
                            break;
                    }
                }
            }
            if (!stack.Any())
                return true;
            return false;
        }


    }
}

