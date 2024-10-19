using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAT602_Project
{
    internal class Game
    {
        public int game_id { get; set; }
        public string status { get; set; }
        public DateTime start_time { get; set; }
        public string current_turn { get; set; }
        public int move_count { get; set; }
    }
}