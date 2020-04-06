using System;
using ExceptionsHandling.exceptions;
using ExceptionsHandling.models;

namespace ExceptionsHandling.driver
{
    class Program
    {
        private static Matrix _m;
        private static Matrix _n;

        static void Main()
        {
            bool exit = false;

            while (!exit)
            {
                DisplayMainMenu();
                string input = Console.ReadLine();
                

                switch (input)
                {
                    case "1":
                        if (_m == null || _n == null)
                        {
                            Console.WriteLine("Matrices have not been created");
                        }
                        else
                        {
                            while (input != "q")
                            {
                                DisplayExistingMatricesMenu();
                                input = Console.ReadLine();

                                switch (input)
                                {
                                    case "1":
                                        DisplayMatricesValues();
                                        break;
                                    case "2":
                                        DisplayMatricesValues();
                                        Console.WriteLine("Select a matrix to clear: ");
                                        while (true)
                                        {
                                            input = Console.ReadLine();
                                            if (input == "1")
                                            {
                                                Console.WriteLine();
                                                _m.GetEmpty();
                                                break;
                                            }
                                            else if (input == "2")
                                            {
                                                _n.GetEmpty();
                                                break;
                                            }
                                        }

                                        if (input == "1")
                                        {
                                            _m.ClearValues();
                                        }
                                        else
                                        {
                                            _n.ClearValues();
                                        }
                                        break;
                                    case "3":
                                        {
                                            DisplayCalculatorMenu();
                                            Matrix result = null;
                                            try
                                            {
                                                input = Console.ReadLine();
                                                ValidateOperator(input);
                                                if (input == "+")
                                                {
                                                    result = _m + _n;
                                                }
                                                else if (input == "-")
                                                {
                                                    result = _m - _n;
                                                }
                                                else
                                                {
                                                    result = _m * _n;
                                                }
                                            }
                                            catch (InvalidOperatorException)
                                            {
                                            }
                                            Console.WriteLine(result);
                                        }
                                        break;
                                }
                            }
                        }
                        break;
                    case "2":
                        DisplayNewValuesMenu();

                        while (true)
                        {
                            input = Console.ReadLine();
                            if (input == "1" || input == "2")
                            {
                                break;
                            }
                        }

                        Matrix[] matrices = new Matrix[] { _m, _n };
                        for (int i = 0; i < matrices.Length; i++)
                        {
                            if (matrices[i] == null)
                            {
                                matrices[i] = input == "1" ? UserInputValues() : AutoGenerateValues();
                            }
                        }

                        _m = matrices[0];
                        _n = matrices[1];
                        break;

                    case "q":
                        exit = true;
                        break;
                }
            }
        }

        private static void ValidateOperator(string input)
        {
            if (input != "-" && input != "+" && input != "*")
            {
                throw new InvalidOperatorException(input);
            }
        }

        static void DisplayMainMenu()
        {
            Console.WriteLine("Matrix Calculator\n\n1) Select existing matrices\n2) Create new matrices\n\n'q' to quit");
        }

        static void DisplayExistingMatricesMenu()
        {
            Console.WriteLine("Existing matrices Menu:");
            Console.WriteLine("1) Show values in existing matrices\n2) Clear matrix\n3) Perform arithmetic operations with existing matrices\n'q' - back to Main menu");
        }

        static void DisplayCalculatorMenu()
        {
            Console.WriteLine("Please enter the operation for matrices: (+, - or *)");
        }

        static void DisplayNewValuesMenu()
        {
            Console.WriteLine("1) Input values by keyboard\n2) Auto-generate values (from -10 to 10)");
        }


        static void DisplayMatricesValues()
        {
            Console.WriteLine("Matrix A: ");
            Console.WriteLine(_m.ToString());
            Console.WriteLine("Matrix B: ");
            Console.WriteLine(_n.ToString());
        }

        /// <summary>
        /// Asks the user to manually input values for every row of a Matrtix. Values of each row are entered from keyboard and delimited by ", ".
        /// </summary>
        static Matrix UserInputValues()
        {
            Matrix x = SetMatrixSize();
            Console.WriteLine("The Matrix has {0} rows and {1} columns", x.Columns, x.Rows);
            for (int i = 0; i < x.Rows; i++)
            {
                Console.WriteLine("Please input values for row {0}:", i + 1);
                for (int j = 0; j < x.Columns; j++)
                {
                    x.Values[i, j] = GetNumber();
                }
            }

            return x;
        }

        /// <summary>
        /// Automatically generates values for every element of a Matrix.
        /// </summary>
        static Matrix AutoGenerateValues()
        {
            Matrix x = SetMatrixSize();
            Random rand = new Random();
            for (int i = 0; i < x.Rows; i++)
            {
                for (int j = 0; j < x.Columns; j++)
                {
                    x.Values[i, j] = rand.Next(0, 5);
                }
            }

            return x;
        }

        /// <summary>
        /// Gets the dimensions from user and initializes a new Matrix with these dimensions
        /// </summary>
        /// <returns>New matrix with specified length of elements, default values are 0</returns>
        private static Matrix SetMatrixSize()
        {
            Console.WriteLine("Please enter rows: ");
            int rows = GetNumber();
            Console.WriteLine("Please enter columns: ");
            int columns = GetNumber();

            return new Matrix(new int[] { rows, columns});
        }

        private static int GetNumber()
        {
            string str = Console.ReadLine();
            while (int.TryParse(str, out _) == false)
            {
                Console.WriteLine("Error, please enter numeric value!");
                str = Console.ReadLine();
            }

            return int.Parse(str);
        }
    }
}
