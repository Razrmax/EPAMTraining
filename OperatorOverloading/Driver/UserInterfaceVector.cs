using System;
using OperatorOverloading.exceptions;
using OperatorOverloading.model;

namespace OperatorOverloading.Driver
{
    class UserInterfaceVector
    {
        private static Vector3D _a;
        private static Vector3D _b;
        private static Vector3D _c;

        static void Main()
        {
            
            bool exit = false;

            while (!exit)
            {
                string input = Console.ReadLine();
                switch (input)
                {
                    case "help":
                        DisplayHelp();
                        break;
                    case "exit":
                        exit = true;
                        break;
                    case "?":
                        DisplayValues();
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

        private static void DisplayValues()
        {
            Vector3D[] vectors = {_a, _b, _c};
            foreach (Vector3D v in vectors)
            {
                Console.WriteLine(v == null ? "null" : v.ToString());
            }
        }

        private static void SolveExpression(string input)
        {
            input = input.ToUpper();
            if (input != "")
            {
                string[] args = input.Split(" ");
                
                if (args[1] == "=")
                {
                    SolveAssignmentExpression(args);
                }

                else if (IsMathOperator(args[1]))
                {
                    SolveMathExpression(args);
                }
                else if (IsLogicalOperator(args[1]))
                {
                    SolveLogicalExpression(args);
                }
                else
                {
                    throw new InvalidOperatorException(args[1]);
                }
            }
        }

        private static void SolveLogicalExpression(string[] args)
        {
            VerifyLength(args, 3);
            if (IsValidOperand(args[0]) && IsValidOperand(args[2]))
            {
                if (args[0] == "A")
                {
                    CompareVectors(args[1], ref _a, ref _b);
                }
                else
                {
                    CompareVectors(args[1], ref _b, ref _a);
                }
            }
        }

        private static void CompareVectors(string op, ref Vector3D a, ref Vector3D b)
        {
            switch (op)
            {
                case "==":
                    Console.WriteLine(a == b);
                    break;
                case "!=":
                    Console.WriteLine(a != b);
                    break;
                case ">":
                    Console.WriteLine(a > b);
                    break;
                case "<":
                    Console.WriteLine(a < b);
                    break;
            }
        }

        private static void SolveAssignmentExpression(string[] args)
        {
            if (args.Length != 3 && args.Length != 5)
            {
                throw new InvalidExpressionException("Wrong number of operands");
            }
            if (args.Length == 3)
            {
                if (args[0] == "A" && args[2] == "B")
                {
                    _a = _b;
                }
                else if (args[0] == "B" && args[2] == "A")
                {
                    _b = _a;
                }
                else
                {
                    throw new InvalidOperandException(args[0] + " and " + args[2], "A or B");
                }
            }
            else if (args.Length == 5)
            {
                string str = args[2] + " " + args[3] + " " + args[4];
                double[] temp = GetNumericValue(str);

                if (args[0] == "A")
                {
                    _a = new Vector3D(temp);
                }
                else if (args[0] == "B")
                {
                    _b = new Vector3D(temp);
                }
                else
                {
                    throw new InvalidOperandException(args[0], "A or B");
                }
            }
        }

        private static void SolveMathExpression(string[] args)
        {
            if (args[1] == "*" && IsValidOperand(args[0]) && VerifyNumericOperand(args[2], "A number"))
            {
                double m = Convert.ToDouble(args[2]);
                _c = args[0] == "A" ? _a * m : _b * m;
            }

            else if (args[0] == "A" || args[0] == "B")
            {
                if (args[0] == "A")
                {
                    AddSubstractVector(args[1], ref _a, ref _b);
                }
                else
                {
                    AddSubstractVector(args[1], ref _b, ref _a);
                }
            }
            else 
            {
                throw new InvalidOperandException(args[3], "A or B");
            }

            Console.WriteLine(_c.ToString());
        }

        private static void AddSubstractVector(string op, ref Vector3D a, ref Vector3D b)
        {
            switch (op)
            {
                case "+":
                    _c = a + b;
                    break;
                case "-":
                    _c = a - b;
                    break;
            }
        }

        private static void DisplayHelp()
        {
            Console.WriteLine("Help screen: ");
            Console.WriteLine("Abbreviations: A -> left actual, B -> right actual, C -> result, op. -> Math( or logical) operator");
            Console.WriteLine("Calculations format: A op. B");
            Console.WriteLine("? to display values of A, B and C (if set)");
            Console.WriteLine("\n\nType 'help' for help menu, 'operators' for list of allowed operators, 'exit' to exit");
            Console.WriteLine("Mathematical operators: +, -, *, =");
            Console.WriteLine("Logical operators: ==, !=, >, <");
        }

        private static bool VerifyNumericOperand(string actual, string expected)
        {
            double num = 0;
            if (!double.TryParse(actual, out num))
            {
                throw new InvalidOperandException(actual, expected);
            }

            return true;
        }

        /// <summary>
        /// Verifies _a sequence of potential operands, checks their amount and format
        /// </summary>
        /// <param name="operands"></param>
        /// <param name="lengthRequired"></param>
        private static double[] GetNumericValue(string operands)
        {
            double[] nums = Array.ConvertAll(operands.Split(" "), Double.Parse);
            return nums;
        }

        private static bool IsMathOperator(string actual)
        {
            string expectedOperators = "+ - *";
            if (!expectedOperators.Contains(actual))
            {
                return false;
            }

            return true;
        }

        private static bool IsLogicalOperator(string actual)
        {
            string expectedOperators = "== != > <";
            if (!expectedOperators.Contains(actual))
            {
                throw new InvalidOperatorException(actual);
            }

            return true;
        }

        private static bool IsValidOperand(string actual)
        {
            string expectedOperands = "A B";
            if (!expectedOperands.Contains(actual))
            {
                throw new InvalidOperandException(actual, "A or B");
            }

            return true;
        }

        private static void VerifyLength(string[] args, int expected)
        {
            if (args.Length != expected)
            {
                throw new InvalidExpressionException("Invalid length of parameters");
            }
        }
    }
}
