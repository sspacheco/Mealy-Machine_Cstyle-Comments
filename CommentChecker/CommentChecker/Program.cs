using System;

namespace CommentChecker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a comment: ");
            string input = Console.ReadLine() ?? "";

            int state = 0;
            int output = 0;

            for (int i = 0; i < input.Length; i++)
            {
                char ch = input[i];
                output = 0;

                switch (state)
                {
                    case 0:
                        if (ch == '/')
                            state = 1;
                        else
                            state = -1;
                        break;

                    case 1:
                        if (ch == '*')
                            state = 2;
                        else
                            state = -1;
                        break;

                    case 2:
                        if (ch == '*')
                            state = 3;
                        else
                            state = 2;
                        break;

                    case 3:
                        if (ch == '/')
                        {
                            state = 4;
                            output = 1;
                        }
                        else if (ch == '*')
                            state = 3;
                        else
                            state = 2;
                        break;

                    case 4:
                        state = -1;
                        break;
                }

                Console.WriteLine(
                    $"Input: {ch}, Output: {output}, State: {state}");

                if (state == -1)
                    break;
            }

            if (state == 4)
                Console.WriteLine("Valid Comment");
            else
                Console.WriteLine("Invalid Comment");
        }
    }
}
