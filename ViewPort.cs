using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.IO;
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

        public void InitScreen()
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
            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.CursorVisible = false;
            Console.Clear();
        }

        // Methods

        public PlayerInput ShowWelcomeScreen(List<RobotGunSlinger> gunSlingers)
        {
            Console.Clear();

            ShowGunSlingers(gunSlingers);

            // Player input
            PlayerInput playerInput = new PlayerInput();

            playerInput.keyPress = Console.ReadKey(false);

            return playerInput;
        }

        public PlayerInput ShowChooseAttackScreen()
        {
            Console.Clear();

            // Player input
            PlayerInput playerInput = new PlayerInput();

            playerInput.keyPress = Console.ReadKey(false);

            return playerInput;
        }
        public void ShowGunSlingers(List<RobotGunSlinger> gunSlingers)
        {
            Console.WriteLine($"Choose your opponent:");

            int i = 0;
            foreach( GunSlinger gunSlinger in gunSlingers)
            {
                Console.WriteLine($"({i}) {gunSlinger.Name}, {gunSlinger.Precision}, {gunSlinger.Speed}, {gunSlinger.HitPoints}");
                i++;
            }
        }
    }
}
