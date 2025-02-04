namespace DevoirSD4_AEmond2333742
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("Choose an exercise (1-6) or type 0 to exit:");
                Console.WriteLine("1. Reverse an array");
                Console.WriteLine("2. Check if an array is symmetric");
                Console.WriteLine("3. Find 2x2 submatrix with maximum sum");
                Console.WriteLine("4. Remove elements to make array sorted");
                Console.WriteLine("5. Find all prime numbers up to 1,000,000");
                Console.WriteLine("6. Verify Goldbach's conjecture");
                Console.Write("Your choice: ");
                int choice = int.Parse(Console.ReadLine());

                if (choice == 0)
                {
                    Console.WriteLine("Exiting the program.");
                    break;
                }

                switch (choice)
                {
                    case 1:
                        Exercise1.Run();
                        break;
                    case 2:
                        Exercise2.Run();
                        break;
                    case 3:
                        Exercise3.Run();
                        break;
                    case 4:
                        Exercise4.Run();
                        break;
                    case 5:
                        Exercise5.Run();
                        break;
                    case 6:
                        Exercise6.Run();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine("\n--------------------------------\n");
            }
        }
    }

    class Exercise1
    {
        public static void Run()
        {
            Console.WriteLine("Enter array elements separated by space:");
            int[] array = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            Array.Reverse(array);
            Console.WriteLine("Reversed Array: " + string.Join(" ", array));
        }
    }

    class Exercise2
    {
        public static void Run()
        {
            Console.WriteLine("Enter array elements separated by space:");
            int[] array = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            bool isSymmetric = true;

            for (int i = 0; i < array.Length / 2; i++)
            {
                if (array[i] != array[array.Length - 1 - i])
                {
                    isSymmetric = false;
                    break;
                }
            }

            Console.WriteLine(isSymmetric ? "The array is symmetric." : "The array is not symmetric.");
        }
    }

    class Exercise3
    {
        public static void Run()
        {
            Console.WriteLine("Enter matrix dimensions (rows and columns):");
            string[] dimensions = Console.ReadLine().Split(' ');
            int rows = int.Parse(dimensions[0]);
            int cols = int.Parse(dimensions[1]);

            int[,] matrix = new int[rows, cols];
            Console.WriteLine("Enter matrix elements row by row:");
            for (int i = 0; i < rows; i++)
            {
                int[] row = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = row[j];
                }
            }

            int maxSum = int.MinValue;
            int[,] maxSubMatrix = new int[2, 2];

            for (int i = 0; i < rows - 1; i++)
            {
                for (int j = 0; j < cols - 1; j++)
                {
                    int currentSum = matrix[i, j] + matrix[i, j + 1] + matrix[i + 1, j] + matrix[i + 1, j + 1];
                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        maxSubMatrix[0, 0] = matrix[i, j];
                        maxSubMatrix[0, 1] = matrix[i, j + 1];
                        maxSubMatrix[1, 0] = matrix[i + 1, j];
                        maxSubMatrix[1, 1] = matrix[i + 1, j + 1];
                    }
                }
            }

            Console.WriteLine("2x2 Submatrix with Maximum Sum:");
            Console.WriteLine($"{maxSubMatrix[0, 0]} {maxSubMatrix[0, 1]}");
            Console.WriteLine($"{maxSubMatrix[1, 0]} {maxSubMatrix[1, 1]}");
        }
    }

    class Exercise4
    {
        public static void Run()
        {
            Console.WriteLine("Enter array elements separated by space:");
            int[] array = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            List<int> sorted = new List<int>();
            foreach (int num in array)
            {
                if (sorted.Count == 0 || num >= sorted[^1])
                {
                    sorted.Add(num);
                }
            }

            Console.WriteLine("Minimal removals to make array sorted: " + (array.Length - sorted.Count));
            Console.WriteLine("Sorted Array: " + string.Join(" ", sorted));
        }
    }

    class Exercise5
    {
        public static void Run()
        {
            Console.WriteLine("Finding prime numbers up to 1,000,000...");
            const int limit = 1000000;
            bool[] isPrime = new bool[limit + 1];
            for (int i = 2; i <= limit; i++) isPrime[i] = true;

            for (int i = 2; i * i <= limit; i++)
            {
                if (isPrime[i])
                {
                    for (int j = i * i; j <= limit; j += i)
                    {
                        isPrime[j] = false;
                    }
                }
            }

            Console.WriteLine("Prime numbers:");
            for (int i = 2; i <= limit; i++)
            {
                if (isPrime[i]) Console.WriteLine(i);
            }
        }
    }

    class Exercise6
    {
        public static void Run()
        {
            Console.WriteLine("Enter an even number greater than 2:");
            int n = int.Parse(Console.ReadLine());

            if (n <= 2 || n % 2 != 0)
            {
                Console.WriteLine("Invalid input. Please enter an even number greater than 2.");
                return;
            }

            bool[] isPrime = new bool[n + 1];
            for (int i = 2; i <= n; i++) isPrime[i] = true;

            for (int i = 2; i * i <= n; i++)
            {
                if (isPrime[i])
                {
                    for (int j = i * i; j <= n; j += i)
                    {
                        isPrime[j] = false;
                    }
                }
            }

            for (int i = 2; i <= n / 2; i++)
            {
                if (isPrime[i] && isPrime[n - i])
                {
                    Console.WriteLine($"{n} = {i} + {n - i}");
                    return;
                }
            }

            Console.WriteLine("No valid decomposition found.");
        }
    }
}
