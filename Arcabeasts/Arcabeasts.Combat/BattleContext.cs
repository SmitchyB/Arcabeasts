using Arcabeasts.DataLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcabeasts.Combat
{
    public class BattleContext
    {
        public ArcabeastInstance PlayerInstance { get; set; }
        public ArcabeastInstance OpponentInstance { get; set; }
        public int TurnNumber { get; set; } = 1;
        public Action<string> Log { get; set; }
        public static BattleContext Current { get; set; }
        public Action<bool> OnBattleEnded { get; set; } // true = win, false = lose
        public UserProfile OriginalProfile { get; set; }
        public int ProfileIndex { get; set; }
        public Guid UserId { get; set; }


    }
}
