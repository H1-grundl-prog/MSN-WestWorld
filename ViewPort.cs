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
            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.CursorVisible = false;
            Console.Clear();
        }

        // Methods

        public PlayerInput ShowWelcomeScreen(World world)
        {
            PlayerInput playerInput = new PlayerInput();

            Console.Clear();

            Console.WriteLine(" Choose your player:");

            ShowGunSlingers(world.GoodGunSlingers);

            playerInput.inputKeyPress1 = Console.ReadKey();

            Console.WriteLine(" Now, choose your enemy:");

            ShowGunSlingers(world.BadGunSlingers);

            playerInput.inputKeyPress2 = Console.ReadKey();

            return playerInput;
        }

        public void ShowGunSlingers(List<GunSlinger> gunSlingers)
        {
            int i = 1;
            foreach (GunSlinger gunSlinger in gunSlingers)
            {
                Console.WriteLine($"({i}) {gunSlinger.Name}, {gunSlinger.Description} ( Precision: {gunSlinger.Precision}, Reaction time: {gunSlinger.ReactionTime}, Hitpoints: {gunSlinger.HitPoints})");
                i++;
            }
        }
    }
}
