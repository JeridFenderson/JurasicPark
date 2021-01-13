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
            Console.WriteLine("SUMMARY - See the total amount of carnivores and herbivores in the park");
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


        static Dinosaur GetDinosaur(List<Dinosaur> dinosaurs, String action)
        {
            var name = GetName();

            var dinosaursWithThatName = dinosaurs.Where(dinosaur => dinosaur.Name == name);
            ViewDinosaurs(dinosaursWithThatName);

            Console.Write($"\nThe dinosaurs are numbered. What dinosaur number would you like to {action}? ");
            var dinoNumber = int.Parse(Console.ReadLine());
            while (dinoNumber <= 0 || dinoNumber > dinosaursWithThatName.Count())
            {
                Console.WriteLine($"\nThat number is bigger or smaller than the amount of dinosaurs that you opted to {action}");
                Console.WriteLine("The dinosaurs are numbered!");
                Console.Write("Please enter a different number: ");
                dinoNumber = int.Parse(Console.ReadLine());
            }
            Console.WriteLine($"\nAre you sure that you want to {action} {dinosaurs[dinoNumber - 1].Name}, the {dinosaurs[dinoNumber - 1].DietType} weighing {dinosaurs[dinoNumber - 1].Weight} lbs...");
            Console.Write($"...in enclosure {dinosaurs[dinoNumber - 1].EnclosureNumber} from the park? Please enter 'YES': ");
            return dinosaurs[dinoNumber - 1];
        }


        static void ViewDinosaurs(IEnumerable<Dinosaur> dinosaursToBeViewed)
        {
            dinosaursToBeViewed.OrderBy(dinosaur => dinosaur.WhenAcquired);
            foreach (var dinosaur in dinosaursToBeViewed)
            {
                var index = 1;
                Console.WriteLine($"{index}. {dinosaur.Name} found on {dinosaur.WhenAcquired}...");
                Console.WriteLine($"...a {dinosaur.DietType}, weighing {dinosaur.Weight} lbs...");
                Console.WriteLine($"...was captured and placed in Enclosure {dinosaur.EnclosureNumber}\n");
                index++;
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


        static IEnumerable<Dinosaur> RemoveDinosaur(List<Dinosaur> dinosaurs)
        {
            var dinosaur = GetDinosaur(dinosaurs, "remove");
            if (Console.ReadLine().Trim().ToUpper() == "YES")
            {
                dinosaurs.Remove(dinosaur);
                Console.WriteLine("\nDinosaur successfully removed from the park\n");
            }
            else
            {
                Console.WriteLine("\nNo dinosaurs were removed from the park\n");
            }
            return dinosaurs;
        }


        static IEnumerable<Dinosaur> TransferDinosaur(List<Dinosaur> dinosaurs)
        {
            var dinosaur = GetDinosaur(dinosaurs, "transfer");
            if (Console.ReadLine().Trim().ToUpper() == "YES")
            {
                Console.Write($"Which enclosure would you like to move {dinosaur.Name} to? ");
                dinosaur.EnclosureNumber = int.Parse(Console.ReadLine());
                Console.WriteLine("\nDinosaur successfully transferred to Enclosure {}\n");
            }
            else
            {
                Console.WriteLine("\nNo dinosaurs were transferred\n");
            }
            return dinosaurs;

        }


        static void ViewSummary(List<Dinosaur> dinosaurs)
        {
            var carnivores = dinosaurs.Where(dinosaur => dinosaur.DietType.ToLower() == "carnivore");
            Console.WriteLine($"\nThere are {carnivores.Count()} carnivores and {dinosaurs.Count() - carnivores.Count()} herbivores in the park\n");
        }


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
                        RemoveDinosaur(dinosaurs);
                        choice = Menu();
                        break;
                    case "TRANSFER":
                        TransferDinosaur(dinosaurs);
                        choice = Menu();
                        break;
                    case "SUMMARY":
                        ViewSummary(dinosaurs);
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
