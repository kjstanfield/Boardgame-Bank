using System.Collections.Generic;

namespace BoardgameBank.Controllers
{
    public class BoardgameViewModel
    {
        public int Id { get; set; }
        public string GameName { get; set; }
        public string PlayTime { get; set; }
        public string Rating { get; set; }
        public List<int> PlayerCounts { get; set; }
        public List<string> Categories { get; set; }
    }
}