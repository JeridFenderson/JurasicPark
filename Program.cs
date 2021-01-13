using System;
using System.Collections.Generic;
using System.Linq;

namespace JurasicPark
{
    class Program
    {
        class Dinosaur
        {
            public string Name { get; set; }
            public string DietType { get; set; }
            public DateTime WhenAcquired = new DateTime();
            public int Weight { get; set; }
            public int EnclosureNumber { get; set; }
        }


        static void Banner(String message)
        {
            Console.WriteLine("\n\n~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine(message);
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~\n\n");
        }


        static string Menu()
        {
            Console.WriteLine("\nVIEW - View all all dinosaurs in the park");
            Console.WriteLine("ADD - Add a new dinosaur to the park");
            Console.WriteLine("REMOVE - Remove a dinosaur from the park");
            Console.WriteLine("TRANSFER - Transfer a dinosaur to another enclosure");
            Console.WriteLine("SUMMARY - See the total amount of Carnivores and Herbivores in the park");
            Console.WriteLine("EXIT - Leave the park\n");
            Console.Write("What would you like to do? ");
            var selection = Console.ReadLine().Trim().ToUpper();
            Console.WriteLine("");
            return selection;

        }


        static String GetName()
        {
            Console.Write("\nWhat's the dinosaur's name? ");
            return Console.ReadLine();
        }


        static void ViewDinosaurs(IEnumerable<Dinosaur> dinosaursToBeViewed)
        {
            dinosaursToBeViewed.OrderBy(dinosaur => dinosaur.WhenAcquired);
            foreach (var dinosaur in dinosaursToBeViewed)
            {
                Console.WriteLine($"{dinosaur.WhenAcquired} - {dinosaur.Name}...");
                Console.WriteLine($"...a {dinosaur.DietType}, weighing {dinosaur.Weight} lbs...");
                Console.WriteLine($"...was captured and placed in Enclosure {dinosaur.EnclosureNumber}\n");
            }
            // - ### Adventure Mode
            // - create a method for viewing dinosaurs acquired after a certain date
            // - create a method for viewing dinosaurs in a given enclosure number
        }


        static IEnumerable<Dinosaur> AddDinosaurs(List<Dinosaur> dinosaurs)
        {
            var name = GetName();

            Console.Write($"\nIs {name} a carnivore or herbivore? ");
            var diet = Console.ReadLine();

            Console.Write($"\nWhat's {name}'s weight? ");
            var weight = int.Parse(Console.ReadLine());

            Console.Write($"\nWhat's {name}'s enclosure number? ");
            var enclosure = int.Parse(Console.ReadLine());
            var dinosaurToAdd = new Dinosaur
            {
                Name = name,
                DietType = diet,
                Weight = weight,
                EnclosureNumber = enclosure
            };

            dinosaurs.Add(dinosaurToAdd);
            return dinosaurs;
        }


        static IEnumerable<Dinosaur> RemoveDinosaurs(List<Dinosaur> dinosaurs)
        {
            var name = GetName();

            var dinosaursWithThatName = dinosaurs.Where(dinosaur => dinosaur.Name == name);
            ViewDinosaurs(dinosaursWithThatName);

            Console.Write("\nWhich dinosaur would you like to delete? ");
            var dinoNumber = int.Parse(Console.ReadLine());

            while (dinoNumber <= 0 || dinoNumber > dinosaursWithThatName.Count())
            {
                Console.WriteLine("\nThat number is bigger or smaller than the amount of dinosaurs that you opted to delete");
                Console.Write("Please enter a different number: ");
                dinoNumber = int.Parse(Console.ReadLine());
            }
            dinosaurs.Remove(dinosaurs[dinoNumber - 1]);
            Console.WriteLine("\nDinosaur successfully removed\n");
            return dinosaurs;
        }

        // - ask the user for the dinosaur's name
        // - find the dinosaur and display dinosaurs info
        // - have user confirm that the dinosaur info displayed is the dinosaur they are looking for and they want to remove it
        // - ### Adventure Mode
        // - if dinosaur is not what user wants and another exists, repeat all steps above except for asking the dinosaur's name with next dinosaur
        // - remove selected dinosaur from list

        // Create a method for transfer

        // - ask the user for the dinosaur's name
        // - find the dinosaur and display dinosaurs info
        // - have user confirm that the dinosaur info displayed is the dinosaur they are looking for and they want to transfer it
        // - ### Adventure Mode
        // - if dinosaur is not what user wants and another exists, repeat all steps above except for asking the dinosaur's name with next dinosaur
        // - ask the user where they'd like to transfer the dinosaur
        // - transfer the selected dinosaur
        // Create a method for summary

        // - display the number of carnivores and the number of herbivores within the list of dinosaurs
        static void Main(string[] args)
        {
            Banner("Welcome to Jurassic Park!");
            var dinosaurs = new List<Dinosaur>(){
              new Dinosaur{
                Name = "T-Rex",
                DietType = "Carnivore",
                Weight = 20000,
                EnclosureNumber = 1
              },
            };

            var choice = Menu();
            while (choice != "EXIT")
            {
                switch (choice)
                {
                    case "VIEW":
                        ViewDinosaurs(dinosaurs);
                        choice = Menu();
                        break;
                    case "ADD":
                        AddDinosaurs(dinosaurs);
                        choice = Menu();
                        break;
                    case "REMOVE":
                        RemoveDinosaurs(dinosaurs);
                        choice = Menu();
                        break;
                    case "TRANSFER":
                        Console.WriteLine("Testing");
                        choice = Menu();
                        break;
                    case "SUMMARY":
                        Console.WriteLine("Testing");
                        choice = Menu();
                        break;
                    default:
                        Console.WriteLine("Please enter one of the choices above only!");
                        Console.WriteLine("It's not case sensitive, but it is spelling sensitive");
                        choice = Menu();
                        break;
                }
            }
            Banner("I hope you're still alive!");

        }
    }
}
