using System.Collections.Generic;
using System;
using System.Threading;


namespace ProblematicProblem
{
    class Program
    {
        // create a (yes, sure, keep / no, redo) to bool method for multi use
        private static bool StringToAnswer(string input)
        {
            if ((input.Equals("yes", StringComparison.OrdinalIgnoreCase)) || (input.Equals("sure" , StringComparison.OrdinalIgnoreCase)) || (input.Equals( "keep", StringComparison.OrdinalIgnoreCase))) 
            { 
                return true;
            } 
            else if ((input.Equals("no", StringComparison.OrdinalIgnoreCase)) || (input.Equals("redo", StringComparison.OrdinalIgnoreCase)) || (input.Equals("no thanks", StringComparison.OrdinalIgnoreCase)))
            {
                return false;
            }
            else
            {
                return false;
            }
        }
        static void Main(string[] args)
        {
            Random rng = new Random();
            bool cont;
            int userAge = 0;
            List<string> activities = new List<string>() { "Movies", "Paintball", "Bowling", "Lazer Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting" };

            Console.Write("Hello, welcome to the random activity generator! /n Would you like to generate a random activity? yes/no: ");
            cont = StringToAnswer(Console.ReadLine());
            if (cont)
            {
                Console.WriteLine();
                Console.Write("We are going to need your information first! What is your name? ");
                string userName = Console.ReadLine();
                Console.WriteLine();
                Console.Write("What is your age? ");
                userAge = int.Parse(Console.ReadLine());
                Console.WriteLine();
                Console.Write("Would you like to see the current list of activities? Sure/No thanks: ");
                bool seeList = StringToAnswer(Console.ReadLine());
                    if (seeList)
                    {
                        foreach (string activity in activities)
                        {
                            Console.Write($"{activity} ");
                            Thread.Sleep(250);
                        }
                        Console.WriteLine();
                        Console.Write("Would you like to add any activities before we generate one? yes/no: ");
                        bool addToList = StringToAnswer(Console.ReadLine());
                        Console.WriteLine();
                        while (addToList)
                        {
                            Console.Write("What would you like to add? ");
                            string userAddition = Console.ReadLine();
                            activities.Add(userAddition);
                            foreach (string activity in activities)
                            {
                                Console.Write($"{activity} ");
                                Thread.Sleep(250);
                            }
                            Console.WriteLine();
                            Console.WriteLine("Would you like to add more? yes/no: ");
                            addToList = StringToAnswer(Console.ReadLine());
                        }
                    }

                do  //swapped to dowhile to always execute 1 time. reversed bool check value to handle user confusion better e.g. "is this okay may be 'yes or no' if someone doesnt fully read.
                {
                    Console.Write("Connecting to the database");
                    for (int i = 0; i < 10; i++)
                    {
                        Console.Write(". ");
                        Thread.Sleep(500);
                    }
                    Console.WriteLine();
                    Console.Write("Choosing your random activity");

                    for (int i = 0; i < 9; i++)
                    {
                        Console.Write(". ");
                        Thread.Sleep(500);
                    }
                    Console.WriteLine();
                    int randomNumber = rng.Next(activities.Count);
                    string randomActivity = activities[randomNumber];
                    if (userAge < 21 && randomActivity == "Wine Tasting")
                    {
                        Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivity}");
                        Console.WriteLine("Pick something else!");
                        activities.Remove(randomActivity);
                        randomNumber = rng.Next(activities.Count);
                        randomActivity = activities[randomNumber];
                    }
                    Console.Write($"Ah got it! {userName}, your random activity is: {randomActivity} ! Is this ok or do you want to grab another activity? Keep/Redo: ");
                    Console.WriteLine();
                    cont = StringToAnswer(Console.ReadLine());
                } while (!cont);
            }
            else
            { Environment.Exit(0); }
           
        }
    }
}