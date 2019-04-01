using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*****************************************************************************************************************************
Objecctive: write a program to check the acceptance of a given string in a give DFA(Transition Table)
*****************************************************************************************************************************/

namespace ToCS_Assignment_5
{
    class Program
    {
        //This function returns the row number(i.e if str=a, it returns 0 and if str=c it returns 2)
        public static int returnRowNumber(string str)       
        {
            int c=0;
            while ( (char)(97 + c) != (char)str[0] )
                c++;
            return c;
        }
        //This Function prints the Transition Table
        public static void printTransitionTable(string[,] arr)
        {
            Console.WriteLine();
            Console.WriteLine("State | 0  1 ");
            for (int r = 0; r < arr.GetLength(0); r++)
            {
                Console.Write((char)(97 + r)+"     |");
                for (int c = 0; c < arr.GetLength(1); c++)
                {
                    Console.Write(" "+arr[r,c]+" ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            int noOfStates, noOfFinalStates, i = 0, r = 0, rowNumber;
            string str, charr, chr, nextState;

            Console.Write("Enter No. of States : ");
            noOfStates = Convert.ToInt32(Console.ReadLine());       //Input number of States
            Console.WriteLine("States are a,b,c,......\n");

            string[,] transitionTable = new string[noOfStates, 3];  //Initialize the matrix of noOfStates by 3

            while (i < noOfStates)                                  //This while loop fills the matrix/Transition Table with states to move to
            {
                Console.Write("on '" + (char)(97 + i) + "' move to __ by 0 : ");
                transitionTable[i, 0] = Console.ReadLine();         //This ask user where to move from curent state when input is 0
                Console.Write("on '" + (char)(97 + i) + "' move to __ by 1 : ");
                transitionTable[i, 1] = Console.ReadLine();         //This ask user where to move from curent state when input is 1
                i++;
            }

            Console.Write("\nEnter No. of Final States : ");
            noOfFinalStates = Convert.ToInt32(Console.ReadLine());  //Input Number Of final states

            for (i = 0; i < noOfFinalStates; i++)                   //This loop declare which states is/are final state(s)
            {
                Console.Write("\nEnter # " + (i + 1) + " final state : ");
                charr = Console.ReadLine();                         //Input final state
                rowNumber = returnRowNumber(charr);                 //Depending on this final state we find the row number(i.e if 'b' is final state then row number is 1)
                transitionTable[rowNumber, 2] = "+";                //Then we assign '+' to that row in 3rd cell to show that it is final state
            }

            printTransitionTable(transitionTable);                  //To print the Transition table

            while (true)
            {
                Console.Write("\nEnter a string {0,1} : ");
                str = Console.ReadLine();                           //Input string to check

                i = 0;
                while (i < str.Length)                              //This Loop traverse the Nodes/Transition Table and reaches the end of the string
                {
                    chr = Convert.ToString(str[i]);                 //chr contains the i'th character of string
                    nextState = transitionTable[r, Convert.ToInt32(chr)];   //element of (r,i'th character) is moved to nextState (i.e if (0,0)element is c, and if r=0 and chr=0 then nextState contains c )
                    r = returnRowNumber(nextState);                 //r contains the row number of next state(i.e if nextState=c the r=2)
                    i++;
                }
                Console.WriteLine();

                if (transitionTable[r, 2] == "+")                   //Here we see if (r,2) is final state or not(i.e if b is final state, and r=1 then this condition is true)
                    Console.WriteLine(str + " is acceptable");
                else
                    Console.WriteLine(str + " is not acceptable");

                Console.ReadKey();
            }
        }
    }
}
