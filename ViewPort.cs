using Microsoft.Win32.SafeHandles;
using System;
using System.IO;
using System.Runtime.InteropServices;

// Camera / viewport class

namespace WestWorld
{
    public class ViewPort
    {
        public ViewPort(int width, int height)
        {
            Width = width;
            Height = height;
        }

        // Console window manipulation (prevent resize and close)
        [DllImport("user32.dll")]
        public static extern int DeleteMenu(IntPtr hMenu, int nPosition, int wFlags);

        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();

        [DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern SafeFileHandle CreateFile(
            string fileName,
            [MarshalAs(UnmanagedType.U4)] uint fileAccess,
            [MarshalAs(UnmanagedType.U4)] uint fileShare,
            IntPtr securityAttributes,
            [MarshalAs(UnmanagedType.U4)] FileMode creationDisposition,
            [MarshalAs(UnmanagedType.U4)] int flags,
            IntPtr template);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool WriteConsoleOutput(
          SafeFileHandle hConsoleOutput,
          CharInfo[,] lpBuffer,
          Coord dwBufferSize,
          Coord dwBufferCoord,
          ref SmallRect lpWriteRegion);



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

            h = CreateFile("CONOUT$", 0x40000000, 2, IntPtr.Zero, FileMode.Open, 0, IntPtr.Zero);

            buf = new CharInfo[Constants.SCREEN_WIDTH, Constants.SCREEN_HEIGHT];

            rect = new SmallRect() { Left = 0, Top = 0, Right = Constants.SCREEN_WIDTH, Bottom = Constants.SCREEN_HEIGHT };

            topLeft = new Coord() { X = 0, Y = 0 };
            btmRight = new Coord() { X = Constants.SCREEN_WIDTH, Y = Constants.SCREEN_HEIGHT };

            Console.Title = "WestWorld";

            Console.SetWindowSize(Constants.SCREEN_WIDTH, Constants.SCREEN_HEIGHT);
            Console.SetBufferSize(Constants.SCREEN_WIDTH, Constants.SCREEN_HEIGHT);

            Console.CursorVisible = false;
        }

        // Methods
        public void DrawWorldToScreen(World world)
        {
            Console.Clear();

            if (!h.IsInvalid)
            {
                for (byte character = 0; character < 220 + 26; ++character)
                {
                    for (short attribute = 0; attribute < 15; ++attribute)
                    {
                        for (int i = 0; i < buf.GetLength(0); ++i)
                        {
                            for (int j = 0; j < buf.GetLength(1); ++j)
                            {
                                buf[i, j].Attributes = attribute;
                                buf[i, j].Char.AsciiChar = character;
                            }
                        }

                        bool b = WriteConsoleOutput(h, buf, btmRight, topLeft, ref rect);
                    }
                }
            }

            //bool b = WriteConsoleOutput(h, buf, btmRight, topLeft, ref rect);
        }

        // Properties
        public int Width { get; set; }
        public int Height { get; set; }
        public Vec2 CameraPosition { get; set; }
        public SafeFileHandle h { get; set; }

        CharInfo[,] buf;

        SmallRect rect;

        public static Coord topLeft;
        public static Coord btmRight;
    }
}
