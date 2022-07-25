using System; // missed "using"
using System.Collections.Generic; //missed a colon
using System.Threading;
//-----------------------------------------------------------------
// Practice Linq
//
// Name: David Zientara
// Date: 7-25-2022
// Comments: An exercise in debugging
// Made modifications per the instructions
//-----------------------------------------------------------------

namespace ProblematicProblem //should be namespace
{
    class Program //Had Program before class; inverted them
    {
        //Put the variables inside the program:
        public bool cont = true;
        public bool seeList;
        // I think this is how you want this List initialized:
        static List<string> activities = new List<string> { "Movies", "Paintball", "Bowling", "Lazer Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting" };
        static int Main(string[] args)
        {
            bool cont = true;
            bool seeList;
            Random rng = new Random();
            string answer;
            // Should be enclosed in a do..while loop:
            //do
            //{
            Console.Write("Hello, welcome to the random activity generator! \nWould you like to generate a random activity? yes/no: "); //added semicolon
            answer = Console.ReadLine(); // Can't declare a variable twice
            //} while (!cont);
            //Not as robust, but it should do:
            if (!answer.ToLower().Substring(0,1).Equals("y"))
                return 0;
            Console.WriteLine();
            Console.Write("We are going to need your information first! What is your name? ");
            string userName = Console.ReadLine();
            Console.WriteLine();
            Console.Write("What is your age? ");
            int userAge;
            // Keep the program in a do..while loop until there's valid input:
            do
            {
                cont = int.TryParse(Console.ReadLine(), out userAge);
                Console.WriteLine();
            } while (!cont);
            seeList = true;
            //do
            
            Console.Write("Would you like to see the current list of activities? Yes/No: ");
            //seeList = bool.Parse(Console.ReadLine());
            answer = Console.ReadLine();
           ///} while (!seeList);
           if (answer.ToLower().Substring(0,1).Equals("y"))
           {
               foreach (string activity in activities)
               {
                  Console.Write($"{activity} ");
                  Thread.Sleep(250);
               }
               Console.WriteLine();
               Console.Write("Would you like to add any activities before we generate one? yes/no: ");
               //bool addToList = bool.Parse(Console.ReadLine());
               //This generated an exception
               //Not really sure what the purpose of the parse was; changed it to reading a string:
               answer = Console.ReadLine();
               Console.WriteLine();
               while (answer.ToLower().Substring(0,1).Equals("y"))
               {
                   Console.Write("What would you like to add? ");
                   string userAddition = Console.ReadLine();
                   activities.Add(userAddition);
                    foreach (string activity in activities) //Added "in" to this line
                    {
                        Console.Write($"{activity} ");
                        Thread.Sleep(250);
                     }
                     Console.WriteLine();
                     Console.WriteLine("Would you like to add more? yes/no: ");
                        //addToList = bool.Parse(Console.ReadLine()); //Took out the definition of addToList; can't declare a variable twice
                        //This generated an exception
                        //Again, not really sure what the purpose of the parse was; changed it to reading a string:
                     answer = Console.ReadLine();
                }
            }

                ///while (cont)
                // Took out while loop and changed it to a do..while loop
            do
            {
                Console.Write("Connecting to the database");
                for (int i = 0; i < 10; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }
                Console.WriteLine(); //Added semicolon
                Console.Write("Choosing your random activity");
                for (int i = 0; i < 9; i++)
                {
                   Console.Write(". ");
                   Thread.Sleep(500);
                 }
                 Console.WriteLine(); //Added semicolon
                 int randomNumber = rng.Next(activities.Count); 
                 string randomActivity = activities[randomNumber]; //Added semicolon
                 if (userAge < 21 && randomActivity == "Wine Tasting") // Changed relational operator from > to <; makes more sense this way
                 {
                     Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivity}");
                     Console.WriteLine("Pick something else!");
                     activities.Remove(randomActivity);
                     randomNumber = rng.Next(activities.Count); //Cannot declate a variable twice
                     randomActivity = activities[randomNumber]; //Cannot declare a variable twice
                 }
                 //Switched userName and randomActivity:
                 Console.Write($"Ah got it! {userName}, your random activity is: {randomActivity}! Is this ok or do you want to grab another activity? Keep/Redo: "); //Added semicolon
                 Console.WriteLine(); //Added period
                 //cont = bool.Parse(Console.ReadLine()); //Cannot define a variable twice
                 //This generated an exception
                 //Again, not really sure what the purpose of the parse was; changed it to reading a string,
                 //and used it to set the bool variable:
                 //Keep the program in a loop until it gets valid input
                 //Used a kludge to keep cont true but break out of the loop
                 do
                 {
                    answer = Console.ReadLine();
                    cont = true;
                    if (answer.ToLower().Substring(0, 1).Equals("r"))
                        break;
                    else if (answer.ToLower().Substring(0, 1).Equals("k"))
                       cont = false;
                    else
                       Console.Write("Please enter Keep or Redo: ");
                } while (cont);
            } while (cont);

                
            
            return 0;
        }
    }
}

//Got rid of a brackets at the end
