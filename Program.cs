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
int codeDonation = 6;

// variables that support data entry
int maxPets = 8;
string menuSelection;
int catCount = 0;
int dogCount = 0;

// array used to store runtime data, there is no persisted data
string[,] ourAnimals = new string[maxPets, dataNumber];

// array for loading animation
string[] searchingIcons = [".", ".", "."];

// Generate data for ourAnimals 2D array
for (int row = 0; row < maxPets; row++)
{
    switch (row)
    {
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
    CreateNewPetData(animalSpecies, animalID, animalNickname, animalAge, animalPhysicalDescription, animalPersonalityDescription, suggestedDonation);
}

// Display top-level menu options
do
{
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
    menuSelection = ReadInput();

    switch (menuSelection)
    {
        case "1":
            Console.WriteLine($"You selected menu option {menuSelection}");

            // Display all information of the pets
            for (int row = 0; row < maxPets; row++)
            {
                if (ourAnimals[row, codeID] == "")
                    continue;

                for (int col = 2; col < dataNumber; col++)
                {
                    string dataDisplay = ourAnimals[row, col] == "" ? "(data not yet available)" : ourAnimals[row, col];

                    switch (col)
                    {
                        case 2:
                            Console.WriteLine($"{ourAnimals[row, codeID]} | {dataDisplay} ({ourAnimals[row, codeSpecies]})");
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

            Console.Write("Checking our database");
            LoadingAnimation();

            int currentPets = dogCount + catCount;
            if (currentPets == maxPets)
            {
                Console.WriteLine("Contoso PetFriends currently already have the maximum pets available.");
                Console.WriteLine("Let's work hard to find a home for our little friends first :)");
            }
            else
            {
                Console.WriteLine($"Contoso PetFriends currently have {dogCount + catCount} pets that need homes. We can manage {(maxPets - catCount - dogCount)} more.");
                Console.Write("Enter animal's species: ");
                animalSpecies = ReadInput();

                // Check if the input is either cat or dog
                if (animalSpecies != "cat" && animalSpecies != "dog")
                {
                    Console.WriteLine("Sorry, currently we cannot shelter animals other than cats or dogs");
                }
                else
                {
                    // Determine Animal ID
                    if (animalSpecies == "dog")
                        animalID = "d" + (dogCount + 1);
                    else
                        animalID = "c" + (catCount + 1);

                    // Determine animal's nickname
                    Console.Write("Enter animal's nickname: ");
                    animalNickname = ReadInput();

                    // Determine animal's age
                    Console.Write("Enter animal's age: ");
                    animalAge = ReadInput();

                    // Determine animal's physical description
                    Console.Write("Enter animals's physical description: ");
                    animalPhysicalDescription = ReadInput();

                    // Determine animal's personality
                    Console.Write("Enter animal's personality: ");
                    animalPersonalityDescription = ReadInput();

                    // Determine the suggested donation for the animal
                    Console.Write("Enter the suggested donation for the animal: ");
                    suggestedDonation = ReadInput();

                    // Input the data with the same method we used when generating data
                    CreateNewPetData(animalSpecies, animalID, animalNickname, animalAge, animalPhysicalDescription, animalPersonalityDescription, suggestedDonation);
                    Console.WriteLine("Data has been inputted! Thank you for your help!");
                }
            }

            Console.WriteLine("Press the Enter key to continue");
            _ = Console.ReadLine();
            break;
        case "3":
            Console.WriteLine($"You selected menu option {menuSelection}");
            Console.Write("Checking all animals' age and physical description");
            LoadingAnimation();

            // Check ourAnimals[3] and ourAnimals[4] that contain ""
            int[] animalsEmptyAge = CheckEmptyRows(codeAge);
            int[] animalsEmptyPhys = CheckEmptyRows(codePhysDesc);

            if (animalsEmptyAge.Length == 0)
            {
                Console.WriteLine("All animals have their ages filled!");
            }
            else
            {
                Console.WriteLine("Animals with empty age:");
                PrintEmptyData(animalsEmptyAge);

                foreach (int row in animalsEmptyAge)
                    InputAndCheckAge(row);
            }
            if (animalsEmptyPhys.Length == 0)
            {
                Console.WriteLine("All animals have their physical description filled!");
            }
            else
            {
                Console.WriteLine("Animals with empty physical description:");
                PrintEmptyData(animalsEmptyPhys);

                foreach (int row in animalsEmptyPhys)
                    InputAndCheckData(row, codePhysDesc);
            }
            Console.WriteLine("Age and physical description fields are complete for all of our friends!");

            Console.WriteLine("Press the Enter key to continue");
            _ = Console.ReadLine();
            break;
        case "4":
            Console.WriteLine($"You selected menu option {menuSelection}");
            Console.Write("Checking all animals' nickname and personality description");
            LoadingAnimation();

            // Check ourAnimals[2] and ourAnimals[5] that contain ""
            int[] animalsEmptyName = CheckEmptyRows(codeNickname);
            int[] animalsEmptyPers = CheckEmptyRows(codePersDesc);

            if (animalsEmptyName.Length == 0)
            {
                Console.WriteLine("All animals have their nicknames filled!");
            }
            else
            {
                Console.WriteLine("Animals with no nickname:");
                PrintEmptyDataNoName(animalsEmptyName);

                foreach (int row in animalsEmptyName)
                    InputAndCheckData(row, codeNickname);
            }
            if (animalsEmptyPers.Length == 0)
            {
                Console.WriteLine("All animals have their personality description filled!");
            }
            else
            {
                Console.WriteLine("Animals with empty personality description");
                PrintEmptyData(animalsEmptyPers);

                foreach (int row in animalsEmptyPers)
                    InputAndCheckData(row, codePersDesc);
            }
            Console.WriteLine("Nickname and personality description fields are complete for all of our friends!");

            Console.WriteLine("Press the Enter key to continue");
            _ = Console.ReadLine();
            break;
        case "5":
            Console.WriteLine($"You selected menu option {menuSelection}");

            bool validID = false;
            int IDRow = 0;
            do
            {
                Console.Write("Please enter the animal's ID whose age you want to edit: ");
                string ID = ReadInput();
                
                if (ID == "")
                {
                    Console.WriteLine("The animal's ID cannot be empty. Please try again.");
                    continue;
                }

                (validID, IDRow) = FindIDRow(ID);
                if (!validID)
                    Console.WriteLine("Animal's ID is invalid. Please try again.");
            } while (!validID);

            InputAndCheckAge(IDRow);

            Console.WriteLine("Press the Enter key to continue");
            _ = Console.ReadLine();
            break;
        case "6":
            Console.WriteLine($"You selected menu option {menuSelection}");

            validID = false;
            IDRow = 0;
            do
            {
                Console.Write("Please enter the animal's ID whose personality description you want to edit: ");
                string ID = ReadInput();

                if (ID == "")
                {
                    Console.WriteLine("The animal's ID cannot be empty. Please try again.");
                    continue;
                }

                (validID, IDRow) = FindIDRow(ID);
                if (!validID)
                    Console.WriteLine("Animal's ID is invalid. Please try again.");
            } while (!validID);

            InputAndCheckData(IDRow, codePersDesc, true);

            Console.WriteLine("Press the Enter key to continue");
            _ = Console.ReadLine();
            break;
        case "7":
            Console.WriteLine($"You selected menu option {menuSelection}");

            string[] arrayChars = GetKeywords();

            Console.Write("Searching our cats");
            LoadingAnimation();

            (int matchCharacteristic, int[] matchPhysChar, int[] matchPersChar) = FindMatchDesc(arrayChars, "cat");

            // Display found animals with the given characteristic
            if (matchCharacteristic == 0)
            {
                string characteristic = string.Join(", ", arrayChars);
                Console.WriteLine($"No cat has the characteristic {characteristic}");
            }
            else
            {
                Console.WriteLine($"There are {matchCharacteristic} matching/similar results.");

                if (matchPhysChar.Length != 0)
                    PrintMatchingDesc("physical description", matchPhysChar, arrayChars);
                if (matchPersChar.Length != 0)
                    PrintMatchingDesc("personality description", matchPersChar, arrayChars);
            }

            Console.WriteLine("Press the Enter key to continue");
            _ = Console.ReadLine();
            break;
        case "8":
            Console.WriteLine($"You selected menu option {menuSelection}");

            arrayChars = GetKeywords();

            Console.Write("Searching our dogs");
            LoadingAnimation();

            (matchCharacteristic, matchPhysChar, matchPersChar) = FindMatchDesc(arrayChars, "dog");

            // Display found animals with the given characteristic
            if (matchCharacteristic == 0)
            {
                string characteristic = string.Join(", ", arrayChars);
                Console.WriteLine($"No dog has the characteristic {characteristic}");
            }
            else
            {
                Console.WriteLine($"There are {matchCharacteristic} matching/similar results.");

                if (matchPhysChar.Length != 0)
                    PrintMatchingDesc("physical description", matchPhysChar, arrayChars);
                if (matchPersChar.Length != 0)
                    PrintMatchingDesc("personality description", matchPersChar, arrayChars);
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

void CreateNewPetData(string species, string id, string nickname, string age, string physDesc, string persDesc, string donation)
{
    int index = 0;
    bool isEmpty = false;

    while (!isEmpty && index < maxPets)
    {
        // Check if data is empty
        if (id == "") // If input ID is empty, then all the other data are empty too
        {
            // Generate empty data
            if (ourAnimals[index, codeID] == null)
            {
                for (int col = 0; col < dataNumber; col++)
                    ourAnimals[index, col] = "";
            }
        }
        else
        {
            if (ourAnimals[index, codeID] == null || ourAnimals[index, codeID] == "")
            {
                isEmpty = true;
                if (species == "dog")
                    dogCount++;
                else if (species == "cat")
                    catCount++;

                ourAnimals[index, codeSpecies] = species;
                ourAnimals[index, codeID] = id;
                ourAnimals[index, codeNickname] = nickname;
                ourAnimals[index, codeAge] = age;
                ourAnimals[index, codePhysDesc] = physDesc;
                ourAnimals[index, codePersDesc] = persDesc;
                ourAnimals[index, codeDonation] = donation;
            }
        }
        index++;
    }

    return;
}

void LoadingAnimation()
{
    foreach (string icon in searchingIcons)
    {
        Console.Write($"{icon}");
        Thread.Sleep(500);
    }
    Console.Write($"\r{new String(' ', Console.BufferWidth)}");

    return;
}

string ReadInput()
{
    string? readResult;
    string result;

    do
    {
        readResult = Console.ReadLine();
    } while (readResult == null);
    result = readResult.Trim().ToLower();

    return result;
}

int[] CheckEmptyRows(int code)
{
    /* Check empty or "?" data rows in the ourAnimals array
       for the requested code */
    int[] emptyRows = [];
    for (int row = 0; row < maxPets; row++)
    {
        if (ourAnimals[row, codeID] == "") continue;

        if (ourAnimals[row, code] == "" || ourAnimals[row, code] == "?")
            emptyRows = [.. emptyRows, row];
    }

    return emptyRows;
}

void PrintEmptyData(int[] emptyRows)
{
    int totalLetters = 24;

    Console.WriteLine("ID".PadRight(3) + "|" + "Nickname".PadLeft(16).PadRight(totalLetters) + "|" + "Species".PadLeft(8));
    foreach (int row in emptyRows)
    {
        string noName = "(not yet named)";
        string IDHolder = ourAnimals[row, codeID];
        string nameHolder = ourAnimals[row, codeNickname];
        string speciesHolder = ourAnimals[row, codeSpecies];
        if (ourAnimals[row, codeNickname] == "")
        {
            int paddingLeft = noName.Length + 1;
            Console.WriteLine($"{IDHolder}".PadRight(3) + "|" + $"{noName}".PadLeft(paddingLeft).PadRight(totalLetters) + $"({speciesHolder})".PadLeft(8));
        }
        else
        {
            int paddingLeft = nameHolder.Length + 1;
            Console.WriteLine($"{IDHolder}".PadRight(3) + "|" + $"{nameHolder}".PadLeft(paddingLeft).PadRight(totalLetters) + $"({speciesHolder})".PadLeft(8));
        }
    }

    return;
}

void PrintEmptyDataNoName(int[] emptyRows)
{
    Console.WriteLine("ID".PadRight(3) + "|".PadRight(2) + "Species");
    foreach (int row in emptyRows)
    {
        string IDHolder = ourAnimals[row, codeID];
        string speciesHolder = ourAnimals[row, codeSpecies];
        Console.WriteLine($"{IDHolder} | ({speciesHolder})");
    }

    return;
}

void InputAndCheckAge(int dataRow)
{
    bool isAgeValid;
    string inputAge;
    do
    {
        Console.Write($"Enter a valid age for ID {ourAnimals[dataRow, codeID]}: ");
        inputAge = ReadInput();
        isAgeValid = int.TryParse(inputAge, out int petAge);
        if (!isAgeValid)
        {
            Console.WriteLine("Input is invalid. Please try again.");
        }
        else
        {
            ourAnimals[dataRow, codeAge] = petAge.ToString();
            string ID = ourAnimals[dataRow, codeID];
            string name = ourAnimals[dataRow, codeNickname] != "" ? ourAnimals[dataRow, codeNickname] : "(not yet named)";
            Console.WriteLine($"Your input has been successfully registered to animal with ID {ID} named {name}!");
        }
    } while (!isAgeValid);

    return;
}

void InputAndCheckData(int dataRow, int dataCode, bool enableEmpty = false)
{
    string petData = "";
    string label = "";

    switch (dataCode)
    {
        case 2:
            label = "nickname";
            break;
        case 4:
            label = "physical description";
            break;
        case 5:
            label = "personality description";
            break;
        default:
            return;
    }

    string ID = ourAnimals[dataRow, codeID];
    string name = ourAnimals[dataRow, codeNickname] != "" ? ourAnimals[dataRow, codeNickname] : "(not yet named)";
    if (enableEmpty)
    {
        bool isUpdated = false;
        string option;
        do
        {
            Console.Write($"Enter a {label} for ID {ID}: ");
            petData = ReadInput();
            if (petData == "")
            {
                do
                {
                    Console.Write($"The updated {label} is empty. Are you sure you want to proceed? (y/n) ");
                    option = ReadInput();
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

            isUpdated = true;
        } while (!isUpdated);
    }
    else
    {
        do
        {
            Console.Write($"Enter a {label} for ID {ourAnimals[dataRow, codeID]}: ");
            petData = ReadInput();

            if (petData == "")
                Console.WriteLine("Input cannot be empty.");
        } while (petData == "");
    }

    ourAnimals[dataRow, dataCode] = petData;
    Console.WriteLine($"The {label} has been updated successfully for animal with ID {ID} named {name}!");
}

(bool, int) FindIDRow(string ID)
{
    bool isValid = false;
    int rowIndex = 0;
    int IDRow = 0;
    do
    {
        if (ourAnimals[rowIndex, codeID] == ID)
        {
            isValid = true;
            IDRow = rowIndex;
            continue;
        }
        rowIndex++;
    } while (!isValid && rowIndex < maxPets);

    return (isValid, IDRow);
}

string[] GetKeywords()
{
    string characteristic;
    do
    {
        Console.Write("Please enter the characteristic that you're searching (use comma for multiple characteristics): ");
        characteristic = ReadInput();
        if (characteristic == "")
            Console.WriteLine("The characteristic cannot be empty. Please try again.");
    } while (characteristic == "");

    string[] keywords = [.. characteristic.Split(["or", "and", ",", " "], StringSplitOptions.RemoveEmptyEntries).Distinct()];

    return keywords;
}

(int, int[], int[]) FindMatchDesc(string[] keywords, string label)
{
    int matchCount = 0;
    int[] matchPhysChar = [];
    int[] matchPersChar = [];

    foreach (string keyword in keywords)
    {
        for (int row = 0; row < maxPets; row++)
        {
            if (ourAnimals[row, codeID] == "" || ourAnimals[row, codeID][0] != label[0])
            {
                continue;
            }
            else
            {
                if (ourAnimals[row, codePhysDesc].Contains(keyword))
                {
                    if (!matchPhysChar.Contains(row))
                    {
                        matchPhysChar = [.. matchPhysChar, row];
                        matchCount++;
                    }
                }
                if (ourAnimals[row, codePersDesc].Contains(keyword))
                {
                    if (!matchPersChar.Contains(row))
                    {
                        matchPersChar = [.. matchPersChar, row];
                        matchCount++;
                    }
                }
            }
        }
    }

    return (matchCount, matchPhysChar, matchPersChar);
}

void PrintMatchingDesc(string label, int[] matchRowData, string[] keywords)
{
    int codeDesc;
    int totalLetters = 24;
    string strDesc = "Description";

    switch (label)
    {
        case "physical description":
            codeDesc = codePhysDesc;
            break;
        case "personality description":
            codeDesc = codePersDesc;
            break;
        default:
            return;
    }

    Console.WriteLine($"Matching {label}:");
    Console.WriteLine("ID".PadRight(3) + "|" + "Nickname".PadLeft(16).PadRight(totalLetters) + "|".PadRight(2) + $"{strDesc}");
    foreach (int row in matchRowData)
    {
        string IDHolder = ourAnimals[row, codeID];
        string nameHolder = ourAnimals[row, codeNickname];
        string descHolder = ourAnimals[row, codeDesc];
        string[] matchKeyword = [];
        int paddingLeft = nameHolder.Length + 1;
        foreach (string keyword in keywords)
        {
            if (descHolder.Contains(keyword))
            {
                descHolder = descHolder.Replace(keyword, $"\x1b[4m{keyword}\x1b[24m");
                matchKeyword = [.. matchKeyword, keyword];
            }
        }
        Console.WriteLine($"{IDHolder}".PadRight(3) + "|" + $"{nameHolder}".PadLeft(paddingLeft).PadRight(totalLetters) + "|".PadRight(2) + $"{descHolder}" + $" (Found: {String.Join(", ", matchKeyword)})");
    }
}