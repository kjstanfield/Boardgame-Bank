using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoardgameBank.Models
{
    public class Boardgame
    {
        public int Id { get; set; }
        public string GameName { get; set; }
        public List<int> Players { get; set; }
        public string PlayTime { get; set; }
        public List<string> Categories { get; set; }
        public int? Rating { get; set; }
        public DateTime Added { get; set; }
    }
}