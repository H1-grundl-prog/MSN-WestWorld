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

        public PlayerInput ShowWelcomeScreen(World world)
        {
            Console.Clear();

            ShowGunSlingers(world.GoodGunSlingers);

            // Player input
            PlayerInput playerInput = new PlayerInput();

            playerInput.keyInt = int.Parse(Console.ReadLine());

            ShowGunSlingers(world.BadGunSlingers);

            return playerInput;
        }

        public PlayerInput ShowGameScreen()
        {
            Console.Clear();

            // Player input
            PlayerInput playerInput = new PlayerInput();

            playerInput.keyPress = Console.ReadKey(false);

            return playerInput;
        }

        public void ShowGunSlingers(List<GunSlinger> gunSlingers)
        {
            Console.WriteLine($"Choose your opponent:\n");

            int i = 1;
            foreach (GunSlinger gunSlinger in gunSlingers)
            {
                Console.WriteLine($"({i}) {gunSlinger.Name}, {gunSlinger.Description} ( Precision: {gunSlinger.Precision}, Speed: {gunSlinger.Speed}, Hitpoints: {gunSlinger.HitPoints})");
                i++;
            }
        }

        public Screens ActiveScreen { get; set; }
    }

    public enum Screens
    {
        WelcomeScreen,
        GameScreen
    }
}
