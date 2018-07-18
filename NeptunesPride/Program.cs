﻿using NeptunesWarMachine.Entities.Metadata;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace NeptunesPride
{
    public class Program
    {
        static FullUniverseReport currentUniverse;

        static void Main(string[] args)
        {
            Initialize();
        }

        static void Initialize()
        {
            PrintWelcomeBanner();
            PromptLogin();
            MainLoop();
        }

        static void MainLoop()
        {
            const int ACTION_COUNT = 1;
            PromptGameSelection();

            while (true)
            {
                PrintActions();
                Console.Write("Select an action: ");
                while (!int.TryParse(Console.ReadLine(), out int actionIdx) || actionIdx < 0 || actionIdx > ACTION_COUNT)
                {
                    Console.WriteLine("Invalid Selection. Try again: ");
                }
            }
        }

        static void PrintActions()
        {
            Console.WriteLine("0. Display Universe Information");
        }

        static void PrintWelcomeBanner()
        {
            Console.WriteLine("Welcome to Neptune's War Machine!");
        }

        static void PromptLogin()
        {
            while (true)
            {
                string username, password;

                Console.Write("Username: ");
                username = Console.ReadLine();
                Console.Write("Password: ");
                password = Console.ReadLine();

                LoginResult result = NPClient.Login(username, password);

                switch (result)
                {
                    case LoginResult.Unknown:
                        Console.WriteLine("Unknown error has occurred while attempting login");
                        break;
                    case LoginResult.Success:
                        Console.WriteLine("Login Successful!");
                        return;
                    case LoginResult.AccountNotFound:
                        Console.WriteLine("Account not found");
                        break;
                    case LoginResult.WrongPassword:
                        Console.WriteLine("Wrong password");
                        break;
                }
                Console.WriteLine();
            }            
        }

        static void PromptGameSelection()
        {
            int selectedGameIdx;
            UserInfo userInfo = NPClient.GetUserInfo();

            Console.WriteLine(string.Format("\nSelect a game:"));            
            for (int gameIdx = 0; gameIdx < userInfo.OpenGames.Count; gameIdx++) {
                GameInfo gameInfo = userInfo.OpenGames[gameIdx];
                Console.WriteLine($"{gameIdx}. {gameInfo.Name}");
            }

            Console.WriteLine(string.Format($"\nGame selection (0-{userInfo.OpenGames.Count-1}): "));
            while (!int.TryParse(Console.ReadLine(), out selectedGameIdx) || selectedGameIdx < 0 || selectedGameIdx > userInfo.OpenGames.Count-1)
            {
                Console.WriteLine("Invalid Selection. Try again: ");
            }

            currentUniverse = NPClient.GetFullUniverseReport(userInfo.OpenGames[selectedGameIdx].Id);
            Console.WriteLine(string.Format("Game Data Loaded!\n"));
        }
    } 
}