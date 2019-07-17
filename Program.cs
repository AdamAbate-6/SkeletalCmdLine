using System;
using System.Threading;

namespace SkeletalCmdLine
{
    class Program
    {
        int TableWidth;
        String[] Categories;

        public Program() {
            TableWidth = 77;
            Categories = new String[] { "Music", "Video Games", "Television"  };
        }

        private void SpinWheel(int numTimes)
        {
            String[] wheel = { "|", "/", "-", "\\" };
            int i = 0;
            while (i < numTimes * 4)
            {
                Console.Write(wheel[i % 4]);
                Thread.Sleep(500);
                i++;
                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
            }
        }
        private void PrintLine()
        {
            Console.WriteLine(new string('-', this.TableWidth));
        }

        private void PrintRow(params string[] columns)
        {
            int width = (this.TableWidth - columns.Length) / columns.Length;
            string row = "|";

            foreach (string column in columns)
            {
                row += AlignCentre(column, width) + "|";
            }

            Console.WriteLine(row);
        }

        private string AlignCentre(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }
        private void DisplayTable()
        {
            PrintLine();
            PrintRow(this.Categories);
            PrintLine();
            String[] OneColumns = { "100", "100", "100"};
            PrintRow(OneColumns);
            PrintLine();
            String[] TwoColumns = { "200", "200", "200"};
            PrintRow(TwoColumns);
            PrintLine();
            String[] ThreeColumns = { "300", "300", "300"};
            PrintRow(ThreeColumns);
            PrintLine();
            String[] FourColumns = { "400", "400", "400"};
            PrintRow(FourColumns);
            PrintLine();
            String[] FiveColumns = { "500", "500", "500"};
            PrintRow(FiveColumns);
            PrintLine();
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine("Here are your categories:");
            program.DisplayTable();
            Console.WriteLine("Press enter to spin the wheel.");
            Console.ReadLine();
            program.SpinWheel(3);
            Random rnd = new Random();
            int j = rnd.Next(0, 3);
            Console.WriteLine("The wheel has chosen " + program.Categories[j]);
            Console.WriteLine("Your clue for 200 points is as follows: ");
            String Answer = "";
            switch (j){
                case 0:
                    Console.WriteLine("This baroque, though not very broke, composer wrote 'The Arrival of the Queen of Sheba'.");
                    Answer = "Handel";
                    break;
                case 1:
                    Console.WriteLine("In this game, Rico frees his home country from an evil dictator in a massive open world.");
                    Answer = "Just Cause 3";
                    break;
                case 2:
                    Console.WriteLine("Though the show isn't about the theory itself, its scientist characters might study it.");
                    Answer = "The Big Bang Theory";
                    break;
            }
            Console.WriteLine("Please input your answer.");
            String Response = Console.ReadLine();
            if (Response != Answer)
            {
                Console.WriteLine("Wrong!");
            }
            else
            {
                Console.WriteLine("Right!");
            }


        }

    }
}
