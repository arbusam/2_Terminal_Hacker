using UnityEngine;

public class Hacker : MonoBehaviour
{

    int level;
    string password;
    const string menuHint = "You may type menu at anytime";

    string[][] passwords = { new string[] { "books", "aisle", "self", "password", "font", "borrow" }, new string[] { "technology", "laptop", "virtual", "smartphone", "application", "smartwatch" }, new string[] { "starfield", "telescope", "environment", "exploration", "astronauts" } };
    readonly string[] levels = { "the local library", "an Apple server", "NASA" };

    int hints = 3;

    enum Screen { MainMenu, Password, Win};
    Screen currentScreen;

    // Start is called before the first frame update
    void Start() {
        ShowMainMenu();
    }

    void ShowMainMenu() {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("");
        Terminal.WriteLine("Press 1 for the local library");
        Terminal.WriteLine("Press 2 for an Apple server");
        Terminal.WriteLine("Press 3 for NASA");
    }

    void OnUserInput(string input) {
        if (input == "menu")
        {
            ShowMainMenu();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        } else if (currentScreen == Screen.Password)
        {
            RunPasswordGuessScreen(input);
        }
    }

    void RunPasswordGuessScreen(string input)
    {
        if (input == password)
        {
            ShowLevelReward();
        }
        else if (input == "hint")
        {
            if (hints != 0) {
                hints -= 1;
                Terminal.WriteLine("Hint: " + password.Anagram() + ". You have " + hints + " hints left");
            } else
            {
                Terminal.WriteLine("You have no hints left");
            }
        }
        else
        {
            Terminal.WriteLine("Access Denied");
        }
    }

    private void ShowLevelReward()
    {
        switch(level)
        {
            case 1:
                Terminal.WriteLine("You now have access to " + levels[level-1]);

                Terminal.WriteLine(@"
    _______
   /      /,
  /      //
 /______//
(______(/
          
"
                );

                break;
            case 2:
                Terminal.WriteLine("You now have access to " + levels[level-1] + @"
         .:'
      __ :'__
   .'`__`-'__``.
  :__________.-'
  :_________:
   :_________`-;
    `.__.-.__.'
                ");

                break;
            case 3:
                Terminal.WriteLine("You now have access to " + levels[level - 1] + @"
 _ __   __ _ ___  __ _ 
| '_ \ / _` / __|/ _` |
| | | | (_| \__ \ (_| |
|_| |_|\__,_|___/\__,_|
                ");
                break;

        }
    }

    void RunMainMenu(string input)
    {

        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            AskForPassword();
        }
        else if (input == "Hack100")
        {
            Terminal.WriteLine("Hello Master");
        }
        else
        {
            Terminal.WriteLine("Please enter a valid selection");
            Terminal.WriteLine(menuHint);
        }
    }

    void AskForPassword()
    {
        hints = 3;
        int index;
        currentScreen = Screen.Password;
        Terminal.ClearScreen();

        index = Random.Range(0, passwords[level-1].Length);
        password = passwords[level-1][index];

        Terminal.WriteLine("Enter your password:");
        Terminal.WriteLine(menuHint);
    }


    // Update is called once per frame
    void Update() {

    }
}
