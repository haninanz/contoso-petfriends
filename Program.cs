// See https://aka.ms/new-console-template for more information
// the ourAnimals array will store the following: 
using System.Data;

string animalSpecies = "";
string animalID = "";
string animalAge = "";
string animalPhysicalDescription = "";
string animalPersonalityDescription = "";
string animalNickname = "";

// variables that support data entry
int maxPets = 8;
string? readResult;
string menuSelection = "";
int catCount = 0;
int dogCount = 0;

// array used to store runtime data, there is no persisted data
string[,] ourAnimals = new string[maxPets, 6];

// Generate data for ourAnimals 2D array
for (int row = 0; row < maxPets; row++) {
    switch (row) {
        case 0:
            animalSpecies = "dog";
            animalID = "d1";
            animalAge = "2";
            animalPhysicalDescription = "medium sized cream colored female golden retriever weighing about 65 pounds. housebroken.";
            animalPersonalityDescription = "loves to have her belly rubbed and likes to chase her tail. gives lots of kisses.";
            animalNickname = "lola";
            break;
        case 1:
            animalSpecies = "dog";
            animalID = "d2";
            animalAge = "9";
            animalPhysicalDescription = "large reddish-brown male golden retriever weighing about 85 pounds. housebroken.";
            animalPersonalityDescription = "loves to have his ears rubbed when he greets you at the door, or at any time! loves to lean-in and give doggy hugs.";
            animalNickname = "loki";
            break;
        case 2:
            animalSpecies = "cat";
            animalID = "c1";
            animalAge = "1";
            animalPhysicalDescription = "small white female weighing about 8 pounds. litter box trained.";
            animalPersonalityDescription = "friendly";
            animalNickname = "puss";
            break;
        case 3:
            animalSpecies = "cat";
            animalID = "c2";
            animalAge = "?";
            animalPhysicalDescription = "";
            animalPersonalityDescription = "";
            animalNickname = "";
            break;
        default:
            animalSpecies = "";
            animalID = "";
            animalAge = "";
            animalPhysicalDescription = "";
            animalPersonalityDescription = "";
            animalNickname = "";
            break;
    }
    for (int col = 0; col < 6; col++) {
        switch (col) {
            case 0:
                if (animalSpecies == "dog") {
                    dogCount++;
                } else if (animalSpecies == "cat") {
                    catCount++;
                }
                ourAnimals[row, col] = animalSpecies;
                break;
            case 1:
                ourAnimals[row, col] = animalID;
                break;
            case 2: 
                ourAnimals[row, col] = animalNickname;
                break;
            case 3:
                ourAnimals[row, col] = animalAge;
                break;
            case 4:
                ourAnimals[row, col] = animalPhysicalDescription;
                break;
            case 5:
                ourAnimals[row, col] = animalPersonalityDescription;
                break;
        }
    }   
}

// Display top-level menu options
do {
    Console.WriteLine("Welcome to Contoso PetFriends app :)");
    Console.WriteLine("What do you want to do today?");
    Console.WriteLine("1. List all of our current pet information");
    Console.WriteLine("2. Add a new animal friend");
    Console.WriteLine("3. Ensure animal ages and physical descriptions are complete");
    Console.WriteLine("4. Ensure animal nicknames and personality descriptions are complete");
    Console.WriteLine("5. Edit an animal's age");
    Console.WriteLine("6. Edit an animal's personality description");
    Console.WriteLine("7. Display all cats with a specified characteristic");
    Console.WriteLine("8. Display all dogs with a specified characteristic");

    Console.WriteLine("Enter your selection number or type \"Exit\": ");
    do {
        readResult = Console.ReadLine();
    } while (readResult == null);
    menuSelection = readResult.Trim().ToLower();

    switch (menuSelection) {
        case "1":
            Console.WriteLine($"You selected menu option {menuSelection}");

            // Display all information of the pets
            for (int row = 0; row < maxPets; row++) {
                if (ourAnimals[row, 1] == "") continue;
                for (int col = 2; col < 6; col++) {
                    string dataDisplay;
                    if (ourAnimals[row, col] == "") {
                        dataDisplay = "(data not yet available)";
                    } else {
                        dataDisplay = ourAnimals[row, col];
                    }
                    switch (col) {
                        case 2:
                            Console.WriteLine($"{ourAnimals[row, 1]} | {dataDisplay} ({ourAnimals[row, 0]})");
                            break;
                        case 3:
                            Console.WriteLine($"Age: {dataDisplay}");
                            break;
                        case 4:
                            Console.WriteLine($"Physical Description: {dataDisplay}");
                            break;
                        case 5:
                            Console.WriteLine($"Personality Description: {dataDisplay}");
                            break;
                        default:
                            break;
                    }
                }
            }

            Console.WriteLine("Press the Enter key to continue");
            readResult = Console.ReadLine();
            break;
        case "2":
            Console.WriteLine($"You selected menu option {menuSelection}");

            int currentPets = dogCount + catCount;
            if (currentPets == maxPets) {
                Console.WriteLine("Contoso PetFriends currently already have the maximum pets available.");
                Console.WriteLine("Let's work hard to find a home for our little friends first :)");
            } else {
                Console.WriteLine($"Contoso PetFriends currently have {dogCount + catCount} pets that need homes. We can manage {(maxPets - catCount - dogCount)} more.");
                Console.WriteLine("Enter animal's species: ");
                do {
                    readResult = Console.ReadLine();
                } while (readResult == null);
                animalSpecies = readResult.Trim().ToLower();
                
                // Check if the input is either cat or dog
                if (animalSpecies != "cat" && animalSpecies != "dog") {
                    Console.WriteLine("Sorry, currently we cannot shelter animals other than cats or dogs");
                } else {
                    // Determine Animal ID
                    if (animalSpecies == "dog") {
                        animalID = "d" + (dogCount + 1);
                    } else {
                        animalID = "c" + (catCount + 1);
                    }
                    // Determine animal's nickname
                    Console.WriteLine("Enter animal's nickname: ");
                    do {
                        readResult = Console.ReadLine();
                    } while (readResult == null);
                    animalNickname = readResult.Trim().ToLower();

                    // Determine animal's age
                    Console.WriteLine("Enter animal's age: ");
                    do {
                        readResult = Console.ReadLine();
                    } while (readResult == null);
                    animalAge = readResult.Trim();

                    // Determine animal's physical description
                    Console.WriteLine("Enter animals's physical description: ");
                    do {
                        readResult = Console.ReadLine();
                    } while (readResult == null);
                    animalPhysicalDescription = readResult.Trim().ToLower();

                    // Determine animal's personality
                    Console.WriteLine("Enter animal's personality: ");
                    do {
                        readResult = Console.ReadLine();
                    } while (readResult == null);
                    animalPersonalityDescription = readResult.Trim().ToLower();
                    
                    // Check which row is empty and input the data
                    for (int row = 0; row < maxPets; row++) {
                        if (ourAnimals[row, 1] == "") {
                            for (int col = 0; col < 6; col++) {
                                switch (col) {
                                    case 0:
                                        if (animalSpecies == "dog") {
                                            dogCount++;
                                        } else if (animalSpecies == "cat") {
                                            catCount++;
                                        }
                                        ourAnimals[row, col] = animalSpecies;
                                        break;
                                    case 1:
                                        ourAnimals[row, col] = animalID;
                                        break;
                                    case 2: 
                                        ourAnimals[row, col] = animalNickname;
                                        break;
                                    case 3:
                                        ourAnimals[row, col] = animalAge;
                                        break;
                                    case 4:
                                        ourAnimals[row, col] = animalPhysicalDescription;
                                        break;
                                    case 5:
                                        ourAnimals[row, col] = animalPersonalityDescription;
                                        break;
                                }
                            }
                            break;
                        } else {
                            continue;
                        }
                    }
                    Console.WriteLine("Data has been inputted! Thank you for your help!");
                }
            }

            Console.WriteLine("Press the Enter key to continue");
            readResult = Console.ReadLine();
            break;
        case "3":
            Console.WriteLine($"You selected menu option {menuSelection}");
            Console.WriteLine("Checking all animals' age and physical description...");

            // Check ourAnimals[3] and ourAnimals[4] that contain ""
            int petAge = 0;
            string petPhysDesc;
            string[] animalsEmptyAge = [];
            string[] animalsEmptyPhys = [];
            for (int row = 0; row < maxPets; row++) {
                if (ourAnimals[row, 1] == "") continue;

                if (ourAnimals[row, 3] == "" || ourAnimals[row, 3] == "?")
                    animalsEmptyAge = [.. animalsEmptyAge, ourAnimals[row, 1]];
                if (ourAnimals[row, 4] == "")
                    animalsEmptyPhys = [.. animalsEmptyPhys, ourAnimals[row, 1]];
            }

            if (animalsEmptyAge.Length == 0) {
                Console.WriteLine("All animals have their ages filled!");
            }
            else {
                Console.WriteLine("Animals with empty age:");
                Console.WriteLine("ID |     Nickname     | Species");
                foreach (string ID in animalsEmptyAge) {
                    for (int row = 0; row < maxPets; row++) {
                        if (ourAnimals[row, 1] == ID) {
                            string noName = "(not yet named)";

                            if (ourAnimals[row, 2] == "")
                                Console.WriteLine($"{ourAnimals[row, 1]} | {noName}\t ({ourAnimals[row, 0]})");
                            else
                                Console.WriteLine($"{ourAnimals[row, 1]} | {ourAnimals[row, 2]}\t\t ({ourAnimals[row, 0]})");
                        } 
                    }
                }
                foreach (string ID in animalsEmptyAge) {
                    bool validAge = false;
                    do {
                        Console.Write($"Enter an age for ID {ID}: ");
                        do {
                            readResult = Console.ReadLine();
                        } while (readResult == null);

                        validAge = int.TryParse(readResult.Trim(), out petAge);
                    } while (validAge == false);
                    
                    for (int row = 0; row < maxPets; row++) {
                        if (ourAnimals[row, 1] == ID)
                            ourAnimals[row, 3] = petAge.ToString();
                    }
                }
            }
            if (animalsEmptyPhys.Length == 0) {
                Console.WriteLine("All animals have their physical description filled!");
            } else {
                Console.WriteLine("Animals with empty physical description:");
                Console.WriteLine("ID |     Nickname     | Species");
                foreach (string ID in animalsEmptyPhys) {
                    for (int row = 0; row < maxPets; row++) {
                        if (ourAnimals[row, 1] == ID) {
                            string noName = "(not yet named)";
                            if (ourAnimals[row, 2] == "")
                                Console.WriteLine($"{ourAnimals[row, 1]} | {noName}\t ({ourAnimals[row, 0]})");
                            else
                                Console.WriteLine($"{ourAnimals[row, 1]} | {ourAnimals[row, 2]}\t\t ({ourAnimals[row, 0]})");
                        }
                    }
                }
                foreach (string ID in animalsEmptyPhys) {
                    do {
                        Console.Write($"Enter a physical description for ID {ID}: ");
                        do {
                            readResult = Console.ReadLine();
                        } while (readResult == null);

                        petPhysDesc = readResult.Trim().ToLower();
                    } while (petPhysDesc == "");

                    for (int row = 0; row < maxPets; row++) {
                        if (ourAnimals[row, 1] == ID)
                            ourAnimals[row, 4] = petPhysDesc;
                    }
                }
            }

            Console.WriteLine("Age and physical description fields are complete for all of our friends!");
            Console.WriteLine("Press the Enter key to continue");
            readResult = Console.ReadLine();
            break;
        case "4":
            Console.WriteLine($"You selected menu option {menuSelection}");
            Console.WriteLine("Checking all animals' nickname and personality description...");

            // Check ourAnimals[2] and ourAnimals[5] that contain ""
            string petNickname;
            string petPersDesc;
            string[] animalsEmptyName = [];
            string[] animalsEmptyPers = [];
            for (int row = 0; row < maxPets; row++) {
                if (ourAnimals[row, 1] == "") continue;

                if (ourAnimals[row, 2] == "")
                    animalsEmptyName = [.. animalsEmptyName, ourAnimals[row, 1]];
                if (ourAnimals[row, 5] == "")
                    animalsEmptyPers = [.. animalsEmptyPers, ourAnimals[row, 1]];
            }

            if (animalsEmptyName.Length == 0) {
                Console.WriteLine("All animals have their nicknames filled!");
            }
            else {
                Console.WriteLine("Animals with no nickname:");
                Console.WriteLine("ID | Species");
                foreach (string ID in animalsEmptyName) {
                    for (int row = 0; row < maxPets; row++) {
                        if (ourAnimals[row, 1] == ID) {
                            Console.WriteLine($"{ourAnimals[row, 1]} | ({ourAnimals[row, 0]})");
                        } 
                    }
                }
                foreach (string ID in animalsEmptyName) {
                    do {
                        Console.Write($"Enter a nickname for ID {ID}: ");
                        do {
                            readResult = Console.ReadLine();
                        } while (readResult == null);

                        petNickname = readResult.Trim().ToLower();
                    } while (petNickname == "");

                    for (int row = 0; row < maxPets; row++) {
                        if (ourAnimals[row, 1] == ID)
                            ourAnimals[row, 2] = petNickname;
                    }
                }
            }
            if (animalsEmptyPers.Length == 0) {
                Console.WriteLine("All animals have their personality description filled!");
            } else {
                Console.WriteLine("Animals with empty personality description");
                Console.WriteLine("ID |     Nickname     | Species");
                foreach (string ID in animalsEmptyPers) {
                    for (int row = 0; row < maxPets; row++) {
                        if (ourAnimals[row, 1] == ID) {
                            string noName = "(not yet named)";
                            if (ourAnimals[row, 2] == "")
                                Console.WriteLine($"{ourAnimals[row, 1]} | {noName}\t ({ourAnimals[row, 0]})");
                            else
                                Console.WriteLine($"{ourAnimals[row, 1]} | {ourAnimals[row, 2]}\t\t ({ourAnimals[row, 0]})");
                        }
                    }
                }
                foreach (string ID in animalsEmptyPers) {
                    do {
                        Console.Write($"Enter a personality description for ID {ID}: ");
                        do {
                            readResult = Console.ReadLine();
                        } while (readResult == null);

                        petPersDesc = readResult.Trim().ToLower();
                    } while (petPersDesc == "");

                    for (int row = 0; row < maxPets; row++) {
                        if (ourAnimals[row, 1] == ID)
                            ourAnimals[row, 5] = petPersDesc;
                    }
                }
            }

            Console.WriteLine("Nickname and personality description fields are complete for all of our friends!");
            Console.WriteLine("Press the Enter key to continue");
            readResult = Console.ReadLine();
            break;
        case "5":
            Console.WriteLine($"Feature no. {menuSelection} is coming soon! Stay tune!");
            Console.WriteLine("Press the Enter key to continue");
            readResult = Console.ReadLine();
            break;
        case "6":
            Console.WriteLine($"Feature no. {menuSelection} is coming soon! Stay tune!");
            Console.WriteLine("Press the Enter key to continue");
            readResult = Console.ReadLine();
            break;
        case "7":
            Console.WriteLine($"Feature no. {menuSelection} is coming soon! Stay tune!");
            Console.WriteLine("Press the Enter key to continue");
            readResult = Console.ReadLine();
            break;
        case "8":
            Console.WriteLine($"Feature no. {menuSelection} is coming soon! Stay tune!");
            Console.WriteLine("Press the Enter key to continue");
            readResult = Console.ReadLine();
            break;
        case "exit":
            Console.WriteLine("See you then!");
            continue;
        default:
            Console.WriteLine("Instruction unclear; press the Enter key to restart");
            readResult = Console.ReadLine();
            break;
    }
    
} while (menuSelection != "exit");