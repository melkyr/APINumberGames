using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APINumberGames.Models
{
    public class IshitoriGameModel
    {
        public int CpRetrieve { get; set; } = 0;
        public int PlayerRetrieve { get; set; } = 0;
        public int CpPreviousRetrieve { get; set; } = 0;
        public int PlayerPreviousRetrieve { get; set; } = 0;
        public int PiecesLeft { get; set; } = 0;
        public bool isAWin { get; set; } = false;
        public int InitialPieces { get; set; } = 0;
        public bool IsCpTurn { get; set; }=false;
    }
}
