// Contoso PetFriends
// the ourAnimals array will store the following: 
using System.Data;
using System.Linq.Expressions;

string animalSpecies;
string animalID;
string animalAge;
string animalPhysicalDescription;
string animalPersonalityDescription;
string animalNickname;
string suggestedDonation;

// code number for each data of ourAnimals array
int dataNumber = 7;
int codeSpecies = 0;
int codeID = 1;
int codeNickname = 2;
int codeAge = 3;
int codePhysDesc = 4;
int codePersDesc = 5;
// int codeDonation = 6;

// variables that support data entry
int maxPets = 8;
string? readResult;
string menuSelection;
int catCount = 0;
int dogCount = 0;

// array used to store runtime data, there is no persisted data
string[,] ourAnimals = new string[maxPets, 7];

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
            suggestedDonation = "85.00";
            break;
        case 1:
            animalSpecies = "dog";
            animalID = "d2";
            animalAge = "9";
            animalPhysicalDescription = "large reddish-brown male golden retriever weighing about 85 pounds. housebroken.";
            animalPersonalityDescription = "loves to have his ears rubbed when he greets you at the door, or at any time! loves to lean-in and give doggy hugs.";
            animalNickname = "loki";
            suggestedDonation = "49.99";
            break;
        case 2:
            animalSpecies = "cat";
            animalID = "c1";
            animalAge = "1";
            animalPhysicalDescription = "small white female weighing about 8 pounds. litter box trained.";
            animalPersonalityDescription = "friendly";
            animalNickname = "puss";
            suggestedDonation = "40.00";
            break;
        case 3:
            animalSpecies = "cat";
            animalID = "c2";
            animalAge = "?";
            animalPhysicalDescription = "";
            animalPersonalityDescription = "";
            animalNickname = "";
            suggestedDonation = "";
            break;
        case 4:
            animalSpecies = "cat";
            animalID = "c3";
            animalAge = "3";
            animalPhysicalDescription = "male tabby cat brimming with masculinity";
            animalPersonalityDescription = "alpha male cat that likes to assert dominance and meow loudly";
            animalNickname = "impostor";
            suggestedDonation = "12.99";
            break;
        default:
            animalSpecies = "";
            animalID = "";
            animalAge = "";
            animalPhysicalDescription = "";
            animalPersonalityDescription = "";
            animalNickname = "";
            suggestedDonation = "";
            break;
    }
    for (int col = 0; col < dataNumber; col++) {
        switch (col) {
            case 0:
                if (animalSpecies == "dog") {
                    dogCount++;
                }
                else if (animalSpecies == "cat") {
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
            case 6:
                ourAnimals[row, col] = suggestedDonation;            
                break;
        }
    }   
}

// Display top-level menu options
do {
    Console.WriteLine("Welcome to \x1b[4mContoso PetFriends\x1b[24m app :)");
    Console.WriteLine("What do you want to do today?");
    Console.WriteLine("1. List all of our current pet information");
    Console.WriteLine("2. Add a new animal friend");
    Console.WriteLine("3. Ensure animal ages and physical descriptions are complete");
    Console.WriteLine("4. Ensure animal nicknames and personality descriptions are complete");
    Console.WriteLine("5. Edit an animal's age");
    Console.WriteLine("6. Edit an animal's personality description");
    Console.WriteLine("7. Display all cats with a specified characteristic");
    Console.WriteLine("8. Display all dogs with a specified characteristic");

    Console.Write("Enter your selection number or type \"Exit\": ");
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
                for (int col = 2; col < dataNumber; col++) {
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
                        case 6:
                            if (!decimal.TryParse(dataDisplay, out decimal petDonation)) 
                                petDonation = 45.00m;

                            if (!dataDisplay.Contains("data"))
                                Console.WriteLine($"Suggested Donation: {petDonation:C2}");
                            else
                                Console.WriteLine($"Suggested Donation: {dataDisplay}");
                            break;
                        default:
                            break;
                    }
                }
            }

            Console.WriteLine("Press the Enter key to continue");
            _ = Console.ReadLine();
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
                    if (animalSpecies == "dog")
                        animalID = "d" + (dogCount + 1);
                    else
                        animalID = "c" + (catCount + 1);
            
                    // Determine animal's nickname
                    Console.Write("Enter animal's nickname: ");
                    do {
                        readResult = Console.ReadLine();
                    } while (readResult == null);
                    animalNickname = readResult.Trim().ToLower();

                    // Determine animal's age
                    Console.Write("Enter animal's age: ");
                    do {
                        readResult = Console.ReadLine();
                    } while (readResult == null);
                    animalAge = readResult.Trim();

                    // Determine animal's physical description
                    Console.Write("Enter animals's physical description: ");
                    do {
                        readResult = Console.ReadLine();
                    } while (readResult == null);
                    animalPhysicalDescription = readResult.Trim().ToLower();

                    // Determine animal's personality
                    Console.Write("Enter animal's personality: ");
                    do {
                        readResult = Console.ReadLine();
                    } while (readResult == null);
                    animalPersonalityDescription = readResult.Trim().ToLower();

                    // Determine the suggested donation for the animal
                    Console.Write("Enter the suggested donation for the animal: ");
                    do {
                        readResult = Console.ReadLine();
                    } while (readResult == null);
                    suggestedDonation = readResult.Trim().ToLower();
                    
                    // Check which row is empty and input the data
                    for (int row = 0; row < maxPets; row++) {
                        if (ourAnimals[row, 1] == "") {
                            for (int col = 0; col < dataNumber; col++) {
                                switch (col) {
                                    case 0:
                                        if (animalSpecies == "dog")
                                            dogCount++;
                                        else if (animalSpecies == "cat")
                                            catCount++;
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
                                    case 6:
                                        ourAnimals[row, col] = suggestedDonation;
                                        break;
                                }
                            }
                            break;
                        }
                        else {
                            continue;
                        }
                    }
                    Console.WriteLine("Data has been inputted! Thank you for your help!");
                }
            }

            Console.WriteLine("Press the Enter key to continue");
            _ = Console.ReadLine();
            break;
        case "3":
            Console.WriteLine($"You selected menu option {menuSelection}");
            Console.WriteLine("Checking all animals' age and physical description...");

            // Check ourAnimals[3] and ourAnimals[4] that contain ""
            int petAge;
            string petPhysDesc;
            int[] animalsEmptyAge = [];
            int[] animalsEmptyPhys = [];
            for (int row = 0; row < maxPets; row++) {
                if (ourAnimals[row, codeID] == "") continue;

                if (ourAnimals[row, codeAge] == "" || ourAnimals[row, codeAge] == "?")
                    animalsEmptyAge = [.. animalsEmptyAge, row];
                if (ourAnimals[row, codePhysDesc] == "")
                    animalsEmptyPhys = [.. animalsEmptyPhys, row];
            }

            if (animalsEmptyAge.Length == 0) {
                Console.WriteLine("All animals have their ages filled!");
            }
            else {
                int totalLetters = 24;

                Console.WriteLine("Animals with empty age:");
                Console.WriteLine("ID".PadRight(3) + "|" + "Nickname".PadLeft(16).PadRight(totalLetters) + "|" + "Species".PadLeft(8));
                foreach (int row in animalsEmptyAge) {
                    string noName = "(not yet named)";
                    string IDHolder = ourAnimals[row, codeID];
                    string nameHolder = ourAnimals[row, codeNickname];
                    string speciesHolder = ourAnimals[row, codeSpecies];

                    if (ourAnimals[row, codeNickname] == "") {
                        int paddingLeft = noName.Length + 1;
                        Console.WriteLine($"{IDHolder}".PadRight(3) + "|" + $"{noName}".PadLeft(paddingLeft).PadRight(totalLetters) + $"({speciesHolder})".PadLeft(8));
                    }                        
                    else {
                        int paddingLeft = nameHolder.Length + 1;
                        Console.WriteLine($"{IDHolder}".PadRight(3) + "|" + $"{nameHolder}".PadLeft(paddingLeft).PadRight(totalLetters) + $"({speciesHolder})".PadLeft(8));
                    }
                }
                foreach (int row in animalsEmptyAge) {
                    bool validAge = false;
                    do {
                        Console.Write($"Enter an age for ID {ourAnimals[row, codeID]}: ");
                        do {
                            readResult = Console.ReadLine();
                        } while (readResult == null);

                        validAge = int.TryParse(readResult.Trim(), out petAge);
                    } while (validAge == false);
                    
                    ourAnimals[row, codeAge] = petAge.ToString();
                }
            }
            if (animalsEmptyPhys.Length == 0) {
                Console.WriteLine("All animals have their physical description filled!");
            } else {
                int totalLetters = 24;

                Console.WriteLine("Animals with empty physical description:");
                Console.WriteLine("ID".PadRight(3) + "|" + "Nickname".PadLeft(16).PadRight(totalLetters) + "|" + "Species".PadLeft(8));
                foreach (int row in animalsEmptyPhys) {
                    string noName = "(not yet named)";
                    string IDHolder = ourAnimals[row, codeID];
                    string nameHolder = ourAnimals[row, codeNickname];
                    string speciesHolder = ourAnimals[row, codeSpecies];


                    if (ourAnimals[row, codeNickname] == "") {
                        int paddingLeft = noName.Length + 1;
                        Console.WriteLine($"{IDHolder}".PadRight(3) + "|" + $"{noName}".PadLeft(paddingLeft).PadRight(totalLetters) + $"({speciesHolder})".PadLeft(8));
                    }
                    else {
                        int paddingLeft = nameHolder.Length + 1;
                        Console.WriteLine($"{IDHolder}".PadRight(3) + "|" + $"{nameHolder}".PadLeft(paddingLeft).PadRight(totalLetters) + $"({speciesHolder})".PadLeft(8));
                    }
                        
                }
                foreach (int row in animalsEmptyPhys) {
                    do {
                        Console.Write($"Enter a physical description for ID {ourAnimals[row, codeID]}: ");
                        do {
                            readResult = Console.ReadLine();
                        } while (readResult == null);

                        petPhysDesc = readResult.Trim().ToLower();
                    } while (petPhysDesc == "");

                    ourAnimals[row, codePhysDesc] = petPhysDesc;
                }
            }
            Console.WriteLine("Age and physical description fields are complete for all of our friends!");

            Console.WriteLine("Press the Enter key to continue");
            _ = Console.ReadLine();
            break;
        case "4":
            Console.WriteLine($"You selected menu option {menuSelection}");
            Console.WriteLine("Checking all animals' nickname and personality description...");

            // Check ourAnimals[2] and ourAnimals[5] that contain ""
            string petNickname;
            string petPersDesc;
            int[] animalsEmptyName = [];
            int[] animalsEmptyPers = [];
            for (int row = 0; row < maxPets; row++) {
                if (ourAnimals[row, codeID] == "") continue;

                if (ourAnimals[row, codeNickname] == "")
                    animalsEmptyName = [.. animalsEmptyName, row];
                if (ourAnimals[row, codePersDesc] == "")
                    animalsEmptyPers = [.. animalsEmptyPers, row];
            }

            if (animalsEmptyName.Length == 0) {
                Console.WriteLine("All animals have their nicknames filled!");
            }
            else {
                Console.WriteLine("Animals with no nickname:");
                Console.WriteLine("ID".PadRight(3) + "|".PadRight(2) + "Species");
                foreach (int row in animalsEmptyName) {
                    string IDHolder = ourAnimals[row, codeID];
                    string speciesHolder = ourAnimals[row, codeSpecies];
                    
                    Console.WriteLine($"{IDHolder} | ({speciesHolder})");
                }
                foreach (int row in animalsEmptyName) {
                    do {
                        Console.Write($"Enter a nickname for ID {ourAnimals[row, codeID]}: ");
                        do {
                            readResult = Console.ReadLine();
                        } while (readResult == null);

                        petNickname = readResult.Trim().ToLower();
                    } while (petNickname == "");

                    ourAnimals[row, codeNickname] = petNickname;
                }
            }
            if (animalsEmptyPers.Length == 0) {
                Console.WriteLine("All animals have their personality description filled!");
            } else {
                int totalLetters = 24;

                Console.WriteLine("Animals with empty personality description");
                Console.WriteLine("ID".PadRight(3) + "|" + "Nickname".PadLeft(16).PadRight(totalLetters) + "|" + "Species".PadLeft(8));
                foreach (int row in animalsEmptyPers) {
                    string noName = "(not yet named)";
                    string IDHolder = ourAnimals[row, codeID];
                    string nameHolder = ourAnimals[row, codeNickname];
                    string speciesHolder = ourAnimals[row, codeSpecies];

                    if (ourAnimals[row, codeNickname] == "") {
                        int paddingLeft = noName.Length + 1;
                        Console.WriteLine($"{IDHolder}".PadRight(3) + "|" + $"{noName}".PadLeft(paddingLeft).PadRight(totalLetters) + $"({speciesHolder})".PadLeft(8));
                    }
                    else {
                        int paddingLeft = nameHolder.Length + 1;
                        Console.WriteLine($"{IDHolder}".PadRight(3) + "|" + $"{nameHolder}".PadLeft(paddingLeft).PadRight(totalLetters) + $"({speciesHolder})".PadLeft(8));
                    }
                }
                foreach (int row in animalsEmptyPers) {
                    do {
                        Console.Write($"Enter a personality description for ID {ourAnimals[row, codeID]}: ");
                        do {
                            readResult = Console.ReadLine();
                        } while (readResult == null);

                        petPersDesc = readResult.Trim().ToLower();
                    } while (petPersDesc == "");

                    ourAnimals[row, codePersDesc] = petPersDesc;
                }
            }
            Console.WriteLine("Nickname and personality description fields are complete for all of our friends!");

            Console.WriteLine("Press the Enter key to continue");
            _ = Console.ReadLine();
            break;
        case "5":
            Console.WriteLine($"You selected menu option {menuSelection}");

            bool validID = false;
            int IDRow = 0;
            do {
                Console.Write("Please enter the animal's ID whose age you want to edit: ");
                do {
                    readResult = Console.ReadLine();
                } while (readResult == null);

                string ID = readResult.Trim().ToLower();
                if (ID == "") {
                    Console.WriteLine("The animal's ID cannot be empty. Please try again.");
                    continue;
                }
                
                int rowIndex = 0;
                do {
                    if (ourAnimals[rowIndex, codeID] == ID) {
                        validID = true;
                        IDRow = rowIndex;
                        continue;
                    }
                    rowIndex++;
                } while (validID == false && rowIndex < maxPets);
                if (!validID)
                    Console.WriteLine("Animal's ID is invalid. Please try again.");
            } while (validID == false);

            bool isAgeValid = false;
            do {
                Console.Write("Please enter a valid age for the animal: ");
                do {
                    readResult = Console.ReadLine();
                } while (readResult == null);

                isAgeValid = int.TryParse(readResult.Trim(), out int inputAge);
                if (!isAgeValid) {
                    Console.WriteLine("Input is invalid. Please try again.");
                } else {
                    ourAnimals[IDRow, codeAge] = inputAge.ToString();
                    string ID = ourAnimals[IDRow, codeID];
                    string name = ourAnimals[IDRow, codeNickname];
                    Console.WriteLine($"Your input has been successfully registered to animal with ID {ID} named {name}!");
                }
            } while (isAgeValid == false);
            
            Console.WriteLine("Press the Enter key to continue");
            _ = Console.ReadLine();
            break;
        case "6":
            Console.WriteLine($"You selected menu option {menuSelection}");

            validID = false;
            IDRow = 0;
            do {
                Console.Write("Please enter the animal's ID whose personality description you want to edit: ");
                do {
                    readResult = Console.ReadLine();
                } while (readResult == null);

                string ID = readResult.Trim().ToLower();
                if (ID == "") {
                    Console.WriteLine("The animal's ID cannot be empty. Please try again.");
                    continue;
                }

                int rowIndex = 0;
                do {
                    if (ourAnimals[rowIndex, codeID] == ID) {
                        validID = true;
                        IDRow = rowIndex;
                        continue;
                    }
                    rowIndex++;
                } while (validID == false && rowIndex < maxPets);
                if (!validID)
                    Console.WriteLine("Animal's ID is invalid. Please try again.");

            } while (validID == false);

            bool isUpdated = false;
            string option;
            do {
                Console.WriteLine("Please enter the updated animal's personality description: ");
                do {
                    readResult = Console.ReadLine();
                } while (readResult == null);

                string updatedPersDesc = readResult.Trim().ToLower();
                if (updatedPersDesc == "") {
                    do {
                        Console.Write("The updated description is empty. Are you sure you want to proceed? (y/n) ");
                        do {
                            readResult = Console.ReadLine();
                        } while (readResult == null);
                            
                        option = readResult.Trim().ToLower();
                        if (option == "")
                            option = "y"; // To ensure that if option is empty, there is no unhandled exception
                        if (option[0] == 'y' || option[0] == 'n')
                                break;
                            else
                                Console.WriteLine("Your input is not a valid option. Please try again.");
                    } while (option[0] != 'y' && option[0] != 'n');

                    if (option[0] == 'n')
                        continue; 
                }

                string ID = ourAnimals[IDRow, codeID];
                string name = ourAnimals[IDRow, codeNickname];
                ourAnimals[IDRow, codePersDesc] = updatedPersDesc;
                isUpdated = true;
                Console.WriteLine($"Description has been updated successfully for animal with ID {ID} named {name}!");
            } while (!isUpdated);

            Console.WriteLine("Press the Enter key to continue");
            _ = Console.ReadLine();
            break;
        case "7":
            Console.WriteLine($"You selected menu option {menuSelection}");

            string catCharacteristic;
            do {
                Console.Write("Please enter the characteristic of a cat that you're searching (use comma for multiple characteristics): ");
                do {
                    readResult = Console.ReadLine();
                } while (readResult == null);

                catCharacteristic = readResult.Trim().ToLower();
                if (catCharacteristic == "") {
                    Console.WriteLine("The characteristic cannot be empty. Please try again.");
                    continue;
                }
            } while (catCharacteristic == "");

            int matchCharacteristic = 0;
            int[] matchPhysChar = [];
            int[] matchPersChar = [];
            string[] arrayChars = [.. catCharacteristic.Split(["or", "and", ",", " "], StringSplitOptions.RemoveEmptyEntries).Distinct()];
            foreach (string keyword in arrayChars) {
                for (int row = 0; row < maxPets; row++) {
                    if (ourAnimals[row, codeID] == "" || ourAnimals[row, codeID][0] == 'd') {
                        continue;
                    } else {
                        if (ourAnimals[row, codePhysDesc].Contains(keyword)) {
                            if (!matchPhysChar.Contains(row)) {
                                matchPhysChar = [.. matchPhysChar, row];
                                matchCharacteristic++;
                            }
                        }
                        if (ourAnimals[row, codePersDesc].Contains(keyword)) {
                            if (!matchPersChar.Contains(row)) {
                                matchPersChar = [.. matchPersChar, row];
                                matchCharacteristic++;
                            }
                        }
                    } 
                }    
            }

            // Display found animals with the given characteristic
            if (matchCharacteristic == 0) {
                Console.WriteLine($"No cat has the characteristic {catCharacteristic}");
            } else {
                int totalLetters = 24;
                string strDesc = "Description";
                int paddingLeft;

                Console.WriteLine($"There are {matchCharacteristic} matching/similar results.");

                if (matchPhysChar.Length != 0) {
                    Console.WriteLine($"Matching physical description:");
                    Console.WriteLine("ID".PadRight(3) + "|" + "Nickname".PadLeft(16).PadRight(totalLetters) + "|".PadRight(2) + $"{strDesc}");
                    foreach (int row in matchPhysChar) {
                        string IDHolder = ourAnimals[row, codeID];
                        string nameHolder = ourAnimals[row, codeNickname];
                        string descHolder = ourAnimals[row, codePhysDesc];
                        paddingLeft = nameHolder.Length + 1;

                        foreach (string keyword in arrayChars) {
                            if (descHolder.Contains(keyword))
                                descHolder = descHolder.Replace(keyword, $"\x1b[4m{keyword}\x1b[24m");    
                        }
                        Console.WriteLine($"{IDHolder}".PadRight(3) + "|" + $"{nameHolder}".PadLeft(paddingLeft).PadRight(totalLetters) + "|".PadRight(2) + $"{descHolder}");
                    }
                }
                if (matchPersChar.Length != 0) {
                    Console.WriteLine($"Matching personality description:");
                    Console.WriteLine("ID".PadRight(3) + "|" + "Nickname".PadLeft(16).PadRight(totalLetters) + "|".PadRight(2) + $"{strDesc}");
                    foreach (int row in matchPersChar) {
                        string IDHolder = ourAnimals[row, codeID];
                        string nameHolder = ourAnimals[row, codeNickname];
                        string descHolder = ourAnimals[row, codePersDesc];
                        paddingLeft = nameHolder.Length + 1;

                        foreach (string keyword in arrayChars) {
                            if (descHolder.Contains(keyword))
                                descHolder = descHolder.Replace(keyword, $"\x1b[4m{keyword}\x1b[24m");    
                        }
                        Console.WriteLine($"{IDHolder}".PadRight(3) + "|" + $"{nameHolder}".PadLeft(paddingLeft).PadRight(totalLetters) + "|".PadRight(2) + $"{descHolder}");
                    }
                }
            }

            Console.WriteLine("Press the Enter key to continue");
            _ = Console.ReadLine();
            break;
        case "8":
            Console.WriteLine($"You selected menu option {menuSelection}");

            string dogCharacteristic;
            do {
                Console.Write("Please enter the characteristic of a dog that you're searching (use comma for multiple characteristics): ");
                do {
                    readResult = Console.ReadLine();
                } while (readResult == null);

                dogCharacteristic = readResult.Trim().ToLower();
                if (dogCharacteristic == "") {
                    Console.WriteLine("The characteristic cannot be empty. Please try again.");
                    continue;
                }
            } while (dogCharacteristic == "");

            matchCharacteristic = 0;
            matchPhysChar = [];
            matchPersChar = [];
            arrayChars = [.. dogCharacteristic.Split(["or", "and", ",", " "], StringSplitOptions.RemoveEmptyEntries).Distinct()];
            foreach (string keyword in arrayChars) {
                for (int row = 0; row < maxPets; row++) {
                    if (ourAnimals[row, codeID] == "" || ourAnimals[row, codeID][0] == 'c') {
                        continue;
                    } else {
                        if (ourAnimals[row, codePhysDesc].Contains(keyword)) {
                            if (!matchPhysChar.Contains(row)) {
                                matchPhysChar = [.. matchPhysChar, row];
                                matchCharacteristic++;
                            }
                        }
                        if (ourAnimals[row, codePersDesc].Contains(keyword)) {
                            if (!matchPersChar.Contains(row)) {
                                matchPersChar = [.. matchPersChar, row];
                                matchCharacteristic++;
                            }
                        }
                    } 
                }
            }
            
            // Display found animals with the given characteristic
            if (matchCharacteristic == 0) {
                Console.WriteLine($"No dog has the characteristic {dogCharacteristic}");
            } else {
                int totalLetters = 24;
                string strDesc = "Description";
                int paddingLeft;

                Console.WriteLine($"There are {matchCharacteristic} matching/similar results.");

                if (matchPhysChar.Length != 0) {
                    Console.WriteLine($"Matching physical description:");
                    Console.WriteLine("ID".PadRight(3) + "|" + "Nickname".PadLeft(16).PadRight(totalLetters) + "|".PadRight(2) + $"{strDesc}");
                    foreach (int row in matchPhysChar) {
                        string IDHolder = ourAnimals[row, codeID];
                        string nameHolder = ourAnimals[row, codeNickname];
                        string descHolder = ourAnimals[row, codePhysDesc];
                        paddingLeft = nameHolder.Length + 1;

                        foreach (string keyword in arrayChars) {
                            if (descHolder.Contains(keyword))
                                descHolder = descHolder.Replace(keyword, $"\x1b[4m{keyword}\x1b[24m");    
                        }
                        Console.WriteLine($"{IDHolder}".PadRight(3) + "|" + $"{nameHolder}".PadLeft(paddingLeft).PadRight(totalLetters) + "|".PadRight(2) + $"{descHolder}");
                    }
                }
                if (matchPersChar.Length != 0) {
                    Console.WriteLine($"Matching personality description:");
                    Console.WriteLine("ID".PadRight(3) + "|" + "Nickname".PadLeft(16).PadRight(totalLetters) + "|".PadRight(2) + $"{strDesc}");
                    foreach (int row in matchPersChar) {
                        string IDHolder = ourAnimals[row, codeID];
                        string nameHolder = ourAnimals[row, codeNickname];
                        string descHolder = ourAnimals[row, codePersDesc];
                        paddingLeft = nameHolder.Length + 1;

                        foreach (string keyword in arrayChars) {
                            if (descHolder.Contains(keyword))
                                descHolder = descHolder.Replace(keyword, $"\x1b[4m{keyword}\x1b[24m");    
                        }
                        Console.WriteLine($"{IDHolder}".PadRight(3) + "|" + $"{nameHolder}".PadLeft(paddingLeft).PadRight(totalLetters) + "|".PadRight(2) + $"{descHolder}");
                    }
                }
            }

            Console.WriteLine("Press the Enter key to continue");
            _ = Console.ReadLine();
            break;
        case "exit":
            Console.WriteLine("See you then!");
            continue;
        default:
            Console.WriteLine("Instruction unclear; press the Enter key to restart");
            _ = Console.ReadLine();
            break;
    }
    
} while (menuSelection != "exit");