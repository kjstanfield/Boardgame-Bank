using System.Collections.Generic;

namespace BoardgameBank.Controllers
{
    public class ListViewModel
    {
        public IEnumerable<BoardgameViewModel> Boardgames { get; set; }
    }
}