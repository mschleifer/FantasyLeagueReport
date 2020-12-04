using Fantasy.Models;
using System.Collections.Generic;

namespace Fantasy.Utilities
{
    /// <summary>
    /// Using a simple app state class primarily to provide basic caching for API calls
    /// </summary>
    public class SimpleAppState
    {
        public int? CurrentNFLSeasonWeek { get; private set; }

        public void SetCurrentNFLSeasonWeek(int week)
        {
            CurrentNFLSeasonWeek = week;
        }
    }
}
