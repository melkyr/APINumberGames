using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APINumberGames.Games
{
    public interface IGame
    {
        void CalculateNextTurn();
        bool IsGameFinished();

    }
}
