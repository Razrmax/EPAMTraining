using System;
using System.Linq;
using ExceptionsHandling.exceptions;
using ExceptionsHandling.models;

namespace ExceptionsHandling.driver
{
    class UserInterface
    {
        private static Matrix a;
        private static Matrix b;
        private static Matrix c;
        static void Main()
        {
            string input;
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Assign values to vectors: ");
                input = Console.ReadLine();

                switch (input)
                {
                    case "help":
                        DisplayHelp();
                        break;
                    case "exit":
                        exit = true;
                        break;
                    default:
                        try
                        {
                            SolveExpression(input);
                        }
                        catch (InvalidExpressionException)
                        {
                        }
                        catch (InvalidOperatorException)
                        {
                        }
                        catch (InvalidOperandException)
                        {
                        }
                        break;
                }
            }
        }

        private static void SolveExpression(string input)
        {
            input = input.ToUpper();
            string[] args = input.Split(" ");
            if (args[0] == "C")
            {
                SolveMathExpression(input);
            }
            else if (input.Length == 3)
            {
                SolveAssignmentExpression(input);
            }
            else if (input.Length == 4)
            {
                VerifyLogicalExpression(input);
            }
            else
            {
                throw new InvalidExpressionException();
            }
        }

        private static void SolveAssignmentExpression(string input)
        {
            string[] words = input.Split(" ");
            if (words[1] != "=")
            {
                throw new InvalidOperatorException(words[1]);
            }
            if (words[0] != "A" && words[2] != "B" || words[0] != "B" && words[2] != "A")
            {
                throw new InvalidOperandException(words[3], "A or B");
            }
            if (words[0] != "B" && words[2] != "A")
            {
                throw new InvalidOperandException(words[3], "A or B");
            }

            //if (words[0] = )
        }

        private static void SolveMathExpression(string input)
        {
            string[] words = input.Split(" ");
            VerifyMathOperator(words[1]);
            if (words[3] != "=")
            {
                throw new InvalidOperatorException(words[3]);
            }
            if (words[3] != "A" && words[5] != "B")
            {
                throw new InvalidOperandException(words[3], "A or B");
            }
            if (words[3] != "B" && words[5] != "A")
            {
                throw new InvalidOperandException(words[3], "A or B");
            }
        }

        private static void VerifyExpressionLength(string str, int expected)
        {
            int actual = str.Split(" ").Length;
            if (actual != expected)
            {
                throw new InvalidExpressionException(expected, actual);
            }
        }

        private static void VerifyLogicalExpression(string input)
        {

        }

        /// <summary>
        /// Displays help menu with description of all commands and operators
        /// </summary>
        private static void DisplayHelp()
        {
            Console.WriteLine("Help screen: ");
            Console.WriteLine("Abbreviations: A -> left operand, B -> right operand, C -> result, op. -> Math( or logical) operator");
            Console.WriteLine("By default all values of A, B, C are set to 0");
            Console.WriteLine("Mathematical calculations format: C = A op. B");
            Console.WriteLine("Logical calculations format: A op. B");
            Console.WriteLine("\n\nType 'help' for help menu, 'operators' for list of allowed operators, 'exit' to exit");
            Console.WriteLine("Mathematical operators: +, -, *, =");
            Console.WriteLine("Logical operators: ==, !=, >, <, >=, <=");
        }

        /// <summary>
        /// Verifies that potential operand is a valid number, if not - throws InvalidOperandException
        /// </summary>
        /// <param name="operand">operand to be verified</param>
        private static bool VerifyNumericOperand(string operand)
        {
            double num = 0;
            if (!double.TryParse(operand, out num))
            {
                //throw new InvalidOperandException(operand);
            }

            return true;
        }

        private static bool VerifyLiteralOperand(string operand)
        {
            if (operand != "A" || operand != "B")
            {
                //throw new InvalidOperandException(operand);
            }

            return true;
        }

        /// <summary>
        /// Verifies a sequence of potential operands, checks their amount and format
        /// </summary>
        /// <param name="operands"></param>
        /// <param name="lengthRequired"></param>
        private static void VerifyOperand(string[] operands, int lengthRequired)
        {
            double num = 0;
            if (operands.Length != lengthRequired)
            {
                throw new InvalidOperandException("Not enough values in operand", lengthRequired, operands.Length);
            }

            foreach (string s in operands)
            {
                if (!double.TryParse(s, out num))
                {
                    //throw new InvalidOperandException(s);
                }
            }
        }

        private static void VerifyMathOperator(string actual)
        {
            string[] allowedOperators = { "+", "-", "*", "=" };
            if (!allowedOperators.Contains(actual))
            {
                throw new InvalidOperatorException(actual);
            }
        }

        private static void VerifyLogicalOperator(string actual)
        {
            string[] allowedOperators = { "==", "!=", ">", "<", ">=", "<=" };
            if (!allowedOperators.Contains(actual))
            {
                throw new InvalidOperatorException(actual);
            }
        }
    }
}
