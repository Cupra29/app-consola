using System;

string[,] ourAnimals = new string[8, 6];

for (int i = 0; i < ourAnimals.GetLength(0); i++)
{
    ourAnimals[i, 0] = $"ID #: {i + 1}";

    ourAnimals[i, 1] = i switch
    {
        0 => "Species: dog",
        1 => "Species: dog",
        2 => "Species: cat",
        3 => "Species: cat",
        _ => "Species: "
    };

    ourAnimals[i, 2] = i switch
    {
        0 => "Age: 2",
        1 => "Age: 9",
        2 => "Age: 1",
        3 => "Age: ?",
        _ => "Age: "
    };

    ourAnimals[i, 3] = i switch
    {
        0 => "Nickname: lola",
        1 => "Nickname: loki",
        2 => "Nickname: ",
        3 => "Nickname: ",
        _ => "Nickname: "
    };

    ourAnimals[i, 4] = i switch
    {
        0 => "Physical description: medium sized cream colored female golden retriever weighing about 65 pounds. housebroken.",
        1 => "Physical description: large reddish-brown male golden retriever weighing about 85 pounds. housebroken.",
        2 => "Physical description: small white female weighing about 8 pounds. litter box trained.",
        3 => "Physical description: ",
        _ => "Physical description: "
    };

    ourAnimals[i, 5] = i switch
    {
        0 => "Personality: friendly, energetic, loves to play fetch",
        1 => "Personality: calm, gentle, enjoys long walks",
        2 => "Personality: curious, independent, likes to explore",
        3 => "Personality: ",
        _ => "Personality: "
    };

    if (i == 3)
    {
        break;
    }
}

string? menuSelection;

do
{
    Console.Clear();

    Console.WriteLine("Welcome to the Contoso PetFriends app. Your main menu options are:");
    Console.WriteLine(" 1. List all of our current pet information");
    Console.WriteLine(" 2. Add a new animal friend to the ourAnimals array");
    Console.WriteLine(" 3. Ensure animal ages and physical descriptions are complete");
    Console.WriteLine(" 4. Ensure animal nicknames and personality descriptions are complete");
    Console.WriteLine(" 5. Edit an animal’s age");
    Console.WriteLine(" 6. Edit an animal’s personality description");
    Console.WriteLine(" 7. Display all cats with a specified characteristic");
    Console.WriteLine(" 8. Display all dogs with a specified characteristic");
    Console.WriteLine();
    Console.WriteLine("Enter your selection number (or type Exit to exit the program)");

    menuSelection = Console.ReadLine()?.ToLower();

    switch (menuSelection)
    {
        case "1":
            // List all of our current pet information
            for (int i = 0; i < ourAnimals.GetLength(0); i++)
            {
                if (!string.IsNullOrEmpty(ourAnimals[i, 0]))
                {
                    Console.WriteLine();
                    for (int j = 0; j < ourAnimals.GetLength(1); j++)
                    {
                        Console.WriteLine(ourAnimals[i, j]);
                    }
                }
            }
            Console.WriteLine("\nPress the Enter key to continue");
            Console.ReadLine();
            break;

        case "2":
            // Add a new animal friend to the ourAnimals array
            int petCount = 0;
            for (int i = 0; i < ourAnimals.GetLength(0); i++)
            {
                if (!string.IsNullOrEmpty(ourAnimals[i, 0]))
                {
                    petCount++;
                }
            }

            if (petCount < ourAnimals.GetLength(0))
            {
                Console.WriteLine($"We currently have {petCount} pets that need homes. We can manage {ourAnimals.GetLength(0) - petCount} more.");
            }

            string? anotherPet = "y";

            while (anotherPet == "y" && petCount < ourAnimals.GetLength(0))
            {
                string? animalSpecies;
                do
                {
                    Console.WriteLine("\nEnter 'dog' or 'cat' to begin a new entry");
                    animalSpecies = Console.ReadLine()?.ToLower();
                } while (animalSpecies != "dog" && animalSpecies != "cat");

                string animalID = $"{animalSpecies[0]}{petCount + 1}";

                string? animalAge;
                do
                {
                    Console.WriteLine("Enter the pet's age or enter ? if unknown");
                    animalAge = Console.ReadLine();
                    if (string.IsNullOrEmpty(animalAge))
                    {
                        animalAge = "tbd";
                        break;
                    }
                } while (!int.TryParse(animalAge, out _) && animalAge != "?");

                string animalPhysicalDescription;
                do
                {
                    Console.WriteLine("Enter a physical description of the pet (size, color, gender, weight, housebroken)");
                    animalPhysicalDescription = Console.ReadLine()?.ToLower() ?? "";
                    if (string.IsNullOrEmpty(animalPhysicalDescription))
                    {
                        animalPhysicalDescription = "tbd";
                        break;
                    }
                } while (string.IsNullOrEmpty(animalPhysicalDescription));

                string animalPersonalityDescription;
                do
                {
                    Console.WriteLine("Enter a description of the pet's personality (likes or dislikes, tricks, energy level)");
                    animalPersonalityDescription = Console.ReadLine()?.ToLower() ?? "";
                    if (string.IsNullOrEmpty(animalPersonalityDescription))
                    {
                        animalPersonalityDescription = "tbd";
                        break;
                    }
                } while (string.IsNullOrEmpty(animalPersonalityDescription));

                string animalNickname;
                do
                {
                    Console.WriteLine("Enter a nickname for the pet");
                    animalNickname = Console.ReadLine()?.ToLower() ?? "";
                    if (string.IsNullOrEmpty(animalNickname))
                    {
                        animalNickname = "tbd";
                        break;
                    }
                } while (string.IsNullOrEmpty(animalNickname));
                
                ourAnimals[petCount, 0] = $"ID #: {animalID}";
                ourAnimals[petCount, 1] = $"Species: {animalSpecies}";
                ourAnimals[petCount, 2] = $"Age: {animalAge}";
                ourAnimals[petCount, 3] = $"Nickname: {animalNickname}";
                ourAnimals[petCount, 4] = $"Physical description: {animalPhysicalDescription}";
                ourAnimals[petCount, 5] = $"Personality: {animalPersonalityDescription}";

                petCount++;

                if (petCount < ourAnimals.GetLength(0))
                {
                    Console.WriteLine("Do you want to enter info for another pet (y/n)");
                    anotherPet = Console.ReadLine()?.ToLower();
                }
            }

            if (petCount >= ourAnimals.GetLength(0))
            {
                Console.WriteLine("We have reached our limit on the number of pets that we can manage.");
                Console.WriteLine("Press the Enter key to continue.");
                Console.ReadLine();
            }

            break;

        case "3":
            for (int i = 0; i < ourAnimals.GetLength(0); i++)
            {
                if (ourAnimals[i, 2] == "Age: ?" && !string.IsNullOrEmpty(ourAnimals[i, 0]))
                {
                    string? animalAge;
                    do
                    {
                        Console.WriteLine($"Enter an age for {ourAnimals[i, 0]}");
                        animalAge = Console.ReadLine();
                    } while (!int.TryParse(animalAge, out _));

                    ourAnimals[i, 2] = $"Age: {animalAge}";
                }

                if ((ourAnimals[i, 4] == "Physical description: " || ourAnimals[i, 4] == "Physical description: tbd")&& !string.IsNullOrEmpty(ourAnimals[i, 0]))
                {
                    string animalPhysicalDescription;
                    do
                    {
                        Console.WriteLine($"Enter a physical description for {ourAnimals[i, 0]} (size, color, gender, weight, housebroken)");
                        animalPhysicalDescription = Console.ReadLine()?.ToLower() ?? "";
                    } while (string.IsNullOrEmpty(animalPhysicalDescription));

                    ourAnimals[i, 4] = $"Physical description: {animalPhysicalDescription}";
                }
            }

            Console.WriteLine("\nAge and physical description fields are complete for all of our friends.\nPress the Enter key to continue");
            Console.ReadLine();
            break;

        case "4":
            for (int i = 0; i < ourAnimals.GetLength(0); i++)
            {
                if ((ourAnimals[i, 3] == "Nickname: " || ourAnimals[i, 3] == "Nickname: tbd") && !string.IsNullOrEmpty(ourAnimals[i, 0]))
                {
                    string animalNickname;
                    do
                    {
                        Console.WriteLine($"Enter a nickname for ID #: {ourAnimals[i, 0]}");
                        animalNickname = Console.ReadLine()?.ToLower() ?? "";
                    } while (string.IsNullOrEmpty(animalNickname));

                    ourAnimals[i, 3] = $"Nickname: {animalNickname}";
                }

                if ((ourAnimals[i, 5] == "Personality: " || ourAnimals[i, 5] == "Personality: tbd") && !string.IsNullOrEmpty(ourAnimals[i, 0]))
                {
                    string animalPersonalityDescription;
                    do
                    {
                        Console.WriteLine($"Enter a personality description for ID #: {ourAnimals[i, 0]} (likes or dislikes, tricks, energy level)");
                        animalPersonalityDescription = Console.ReadLine()?.ToLower() ?? "";
                    } while (string.IsNullOrEmpty(animalPersonalityDescription));

                    ourAnimals[i, 5] = $"Personality: {animalPersonalityDescription}";
                }
            }

            Console.WriteLine("\nNickname and personality description fields are complete for all of our friends.\nPress the Enter key to continue");
            Console.ReadLine();
            break;

        case "5":
            Console.WriteLine("UNDER CONSTRUCTION - please check back next month to see progress.");
            Console.WriteLine("Press the Enter key to continue.");
            Console.ReadLine();
            break;

        case "6":
            Console.WriteLine("UNDER CONSTRUCTION - please check back next month to see progress.");
            Console.WriteLine("Press the Enter key to continue.");
            Console.ReadLine();
            break;

        case "7":
            Console.WriteLine("UNDER CONSTRUCTION - please check back next month to see progress.");
            Console.WriteLine("Press the Enter key to continue.");
            Console.ReadLine();
            break;

        case "8":
            Console.WriteLine("UNDER CONSTRUCTION - please check back next month to see progress.");
            Console.WriteLine("Press the Enter key to continue.");
            Console.ReadLine();
            break;

        default:
            break;
    }

} while (menuSelection != "exit");
