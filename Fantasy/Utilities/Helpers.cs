using System;

namespace Fantasy.Utilities
{
    public static class Helpers
    {
        public static int GetCurrentSeason() => DateTime.Now.Month >= 9 ? DateTime.Now.Year : DateTime.Now.Year - 1;

    }
}
