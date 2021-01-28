using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class Hacker : MonoBehaviour
{

    int level;

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

    private void RunPasswordGuessScreen(string input)
    {
        if (level == 1)
        {
            if (input == "books")
            {
                Terminal.WriteLine("You now have access to the local library");
            }
            else
            {
                Terminal.WriteLine("Access Denied");
            }
        }
        else if (level == 2)
        {
            if (input == "technology")
            {
                Terminal.WriteLine("You now have access to an Apple server");
            }
            else
            {
                Terminal.WriteLine("Access Denied");
            }
        }
    }

    void RunMainMenu(string input)
    {
        if (input == "1")
        {
            level = 1;
            StartGame();
        }
        else if (input == "2")
        {
            level = 2;
            StartGame();
        }
        else if (input == "Hack100")
        {
            Terminal.WriteLine("Hello Master");
        }
        else
        {
            Terminal.WriteLine("Please enter a valid selection");
        }
    }

    void StartGame()
    {
        currentScreen = Screen.Password;
        Terminal.WriteLine("You have chosen level " + level);
        Terminal.WriteLine("Please enter your password:");
    }


    // Update is called once per frame
    void Update() {
        
    }
}
