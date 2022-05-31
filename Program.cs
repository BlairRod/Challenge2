//Blair Rod - 103892145
using System;

namespace Quiz2
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();

        }

        public static void Menu()
        {
            List<int> rolls = new List<int>();
            List<int> savedRolls = Load();
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("Swinburne Caves & Lizards Clubs Dice Roll");
            int selection = 0;


            while (selection != 8)
            {
                Console.WriteLine("----------------------------------------------------------------");

                Console.WriteLine("");
                Console.WriteLine("1.Roll dice");
                Console.WriteLine("2.Average");
                Console.WriteLine("3.Total");
                Console.WriteLine("4.List Rolls");
                Console.WriteLine("5.Saved Rolls");
                Console.WriteLine("6.Total of saved Rolls");
                Console.WriteLine("7.Average of saved Rolls");

                Console.WriteLine("8.Exit");

                Console.WriteLine("");
                Console.WriteLine("----------------------------------------------------------------");
                Console.WriteLine("");
                Console.Write("Select a task: ");
                string? input = Console.ReadLine();
                selection = int.Parse(input);
                if (selection == 1)
                {
                    rolls = RollDice();
                    foreach (int dice in rolls) savedRolls.Add(dice);
                    Save(savedRolls);
                }
                else if (selection == 2) Console.WriteLine("The average of the rolls is: " + Average(rolls));
                else if (selection == 3) Console.WriteLine("The total of the rolls is: " + Total(rolls));
                else if (selection == 4) ListRolls(rolls);
                else if (selection == 5) ListRolls(Load());
                else if (selection == 6) Console.WriteLine("The total of the saved rolls is: " + Total(Load()));
                else if (selection == 7) Console.WriteLine("The average of the saved rolls is: " + Average(Load()));

                else if (selection == 8) Console.WriteLine("Thanks for playing");

                else
                {
                    Console.WriteLine("Incorrect selection");
                    Menu();
                }

            }

        }


        //asks how many dice to roll and rolls that amount, saves the rolls to a List
        public static List<int> RollDice()
        {
            List<int> rolls = new List<int>();
            int count = 0;
            int num = 0;
            Console.WriteLine("How many dice do you want to roll from 1 to 6 dice?");
            int diceNum = int.Parse(Console.ReadLine());

            if (diceNum > 6)
            {
                diceNum = 6;
                Console.WriteLine("I said 1 to 6 dice! rolling 6 dice");
            }
            else if (diceNum <= 0)
            {
                Console.WriteLine("I said 1 to 6 dice! rolling no dice");
            }
            while (count < diceNum)
            {
                var rand = new Random();
                num = rand.Next(1, 11);
                rolls.Add(num);
                count++;
            }
            return rolls;
        }

        //writes to console the given List
        public static void ListRolls(List<int> rolls)
        {
            rolls.ForEach(Console.WriteLine);
        }

        //calculates and returns the average of the given List
        public static int Average(List<int> rolls)
        {
            int average = 0;
            int count = 0;

            for (int i = 0; i < rolls.Count; i++)
            {
                average = average + rolls[i];
                count++;
                //Console.WriteLine("dice " + rolls[i]);
            }


            return average / count;
        }

        //calculates and returns the total of the given List
        public static int Total(List<int> rolls)
        {
            int total = 0;

            for (int i = 0; i < rolls.Count; i++)
            {
                total = total + rolls[i];
                //Console.WriteLine("total " + total);
            }

            return total;
        }

        //saves the given List to a .csv file
        public static void Save(List<int> rolls)
        {
            using (StreamWriter writer = new StreamWriter("./rollData.csv"))
            {
                foreach (int dice in rolls)
                {
                    writer.WriteLine(dice);
                }
            }
        }

        //loads from .csv file to a returned List
        public static List<int> Load()
        {
            List<int> dice = new List<int>();
            if (File.Exists("./rollData.csv"))
            {
                string[] lines = File.ReadAllLines("./rollData.csv");
                foreach (string line in lines)
                {
                    string values = line;
                    dice.Add(int.Parse(values[0].ToString()));
                }
            }
            return dice;
        }

    }
}