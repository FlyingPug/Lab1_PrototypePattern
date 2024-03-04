using System;

namespace Lab1_DnD_Creator.Core
{
    public static class Rolls
    {
        static Random random = new Random();

        public static int d6()
        {
            return random.Next(1, 7);
        }

        public static int d20()
        {
            return random.Next(1, 21);
        }
    }
}
