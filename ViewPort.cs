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

        // Methods

        public Controls WelcomeScreen(World world)
        {
            Controls playerInput = new Controls();

            Console.Clear();

            Console.WriteLine(" Choose your player:");

            playerInput.inputKeyPress2 = Console.ReadKey();

            return playerInput;
        }

        public Controls ChoosePlayerScreen(World world)
        {
            Controls playerInput = new Controls();

            Console.Clear();

            Console.WriteLine(" Choose your player:");

            ListGunSlingers(world.GoodGunSlingers);

            playerInput.inputKeyPress1 = Console.ReadKey();

            return playerInput;
        }

        public Controls ChooseEnemyScreen(World world)
        {
            Controls playerInput = new Controls();

            Console.Clear();

            Console.WriteLine(" Now, choose your enemy:");

            ListGunSlingers(world.BadGunSlingers);

            playerInput.inputKeyPress2 = Console.ReadKey();

            return playerInput;
        }

        public void ListGunSlingers(List<GunSlinger> gunSlingers)
        {
            int i = 1;
            foreach (GunSlinger gunSlinger in gunSlingers)
            {
                Console.WriteLine($"({i}) {gunSlinger.Name}, {gunSlinger.Description} ( Precision: {gunSlinger.HitChance}, Reaction time: {gunSlinger.ReactionTicks})");
                i++;
            }
        }
    }
}
