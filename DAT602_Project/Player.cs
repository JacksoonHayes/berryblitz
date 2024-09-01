using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAT602_Project
{
    internal class Player
    {
        public static Player CurrentPlayer { get; set; }
        public int player_id { get; set; }
        public string username { get; set; }
        public int score { get; set; }  
    }
}
