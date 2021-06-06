using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

// Camera / viewport class

namespace WestWorld
{
    public class ViewPort
    {
        
        // Console window manipulation (prevent resize and close)
        [DllImport("user32.dll")]
        public static extern int DeleteMenu(IntPtr hMenu, int nPosition, int wFlags);

        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();

        #region methods
        public void Init()
        {
            // Console window manipulation (prevent resize and close)
            IntPtr handle = GetConsoleWindow();
            IntPtr sysMenu = GetSystemMenu(handle, false);

            if (handle != IntPtr.Zero)
            {
                //DeleteMenu(sysMenu, Constants.SC_CLOSE, Constants.MF_BYCOMMAND);
                DeleteMenu(sysMenu, Constants.SC_MINIMIZE, Constants.MF_BYCOMMAND);
                DeleteMenu(sysMenu, Constants.SC_MAXIMIZE, Constants.MF_BYCOMMAND);
                DeleteMenu(sysMenu, Constants.SC_SIZE, Constants.MF_BYCOMMAND);
            }

            Console.Title = "WestWorld";

            Console.SetWindowSize(Constants.SCREEN_WIDTH, Constants.SCREEN_HEIGHT);
            Console.SetBufferSize(Constants.SCREEN_WIDTH, Constants.SCREEN_HEIGHT);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.CursorVisible = false;
            Console.Clear();
        }

        #region screen methods

        public Controls WelcomeScreen(World world)
        {
            Controls playerInput = new Controls();

            Console.Clear();

            Console.WriteLine("Welcome to WestWorld!");

            playerInput.inputKeyPress = Console.ReadKey(false);

            return playerInput;
        }

        public Controls ChooseEnemyScreen(World world)
        {
            Controls playerInput = new Controls();

            Console.Clear();

            Console.WriteLine("Choose your enemy:\n");

            ListGunSlingers(world.BadGunSlingers);

            playerInput.inputKeyPress = Console.ReadKey(false);

            return playerInput;
        }

        public Controls ChoosePlayerScreen(World world)
        {
            Controls playerInput = new Controls();

            Console.Clear();

            Console.WriteLine("Choose your player:\n");

            ListGunSlingers(world.GoodGunSlingers);

            playerInput.inputKeyPress = Console.ReadKey(false);

            return playerInput;
        }

        #endregion

        public void ListGunSlingers(List<GunSlinger> gunSlingers)
        {
            int i = 1;
            foreach (GunSlinger gunSlinger in gunSlingers)
            {
                Console.WriteLine($"({i}) {gunSlinger.Name}, {gunSlinger.Description} ( Hit chance {gunSlinger.HitChance} %, Reaction time {gunSlinger.ReactionTime/1000f:n1} seconds)");
                i++;
            }
        }

        #endregion
    }
}
