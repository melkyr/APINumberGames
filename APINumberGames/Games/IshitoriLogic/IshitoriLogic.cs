using APINumberGames.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APINumberGames.Games.IshitoriLogic
{
    public static class IshitoriLogic
    {
        public static int DummyComputerRetrieves(this IshitoriGameModel currentGame)
        {
            int piecesToGrab = 1;
            if (currentGame.PiecesLeft == 1)
            {
                piecesToGrab = 1;
            }
            else if (currentGame.PiecesLeft > 8)
            {
                piecesToGrab = new Random().Next(1, 4);
            }
            else if (currentGame.PiecesLeft > 4)
            {
                piecesToGrab = currentGame.PiecesLeft - 5;
            }
            else if (currentGame.PiecesLeft <= 4)
            {
                piecesToGrab = currentGame.PiecesLeft - 1;
            }
            return piecesToGrab;
        }

        public static int SmartComputerRetrieves(this IshitoriGameModel currentGame)
        {
            int piecesToGrab = 0;
            if (currentGame.PiecesLeft == 1)
            {
                piecesToGrab = 1;
            }
            //Lets try our best to get into the closer mult*4 integer
            if ((currentGame.PiecesLeft - 1) % 4 == 0 && currentGame.PlayerPreviousRetrieve == 0)
            {
                piecesToGrab = new Random().Next(1, 4);

            }
            //If last turn we were on a special number
            else if ((currentGame.PiecesLeft + currentGame.PlayerPreviousRetrieve + currentGame.CpPreviousRetrieve) % 4 == 0 && currentGame.PiecesLeft > 8)
            {
                piecesToGrab = 4 - currentGame.PlayerPreviousRetrieve;
            }
            else if ((currentGame.PiecesLeft + currentGame.PlayerPreviousRetrieve) % 4 != 0 && currentGame.PiecesLeft > 8)
            {
                piecesToGrab = currentGame.PiecesLeft % 4;
            }
            else if (currentGame.PiecesLeft > 4)
            {
                piecesToGrab = currentGame.PiecesLeft - 4;
            }
            else if (currentGame.PiecesLeft == 4)
            {
                piecesToGrab = 3;
            }
            else if (currentGame.PiecesLeft < 4 && currentGame.PiecesLeft > 1)
            {
                piecesToGrab = currentGame.PiecesLeft - 1;
            }

            if (piecesToGrab == 0 || piecesToGrab == 4)
            {
                piecesToGrab = new Random().Next(1, 4);
            }
            return piecesToGrab;
        }

        public static void RecalculatePiecesLeft(this IshitoriGameModel status, int grabbedPieces )
        {

            status.PiecesLeft -= grabbedPieces;
        }
    }
}
