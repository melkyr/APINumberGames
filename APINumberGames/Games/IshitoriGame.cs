using APINumberGames.Games.IshitoriLogic;
using APINumberGames.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APINumberGames.Games
{
    public class IshitoriGame : IGame
    {
        private IshitoriGameModel _model = new IshitoriGameModel();
        public IshitoriGame(IshitoriGameModel model, int[] interval)
        {
            _model = model;
           
            if (_model.InitialPieces==0)
            {
                _model.PiecesLeft = new Random().Next(interval[0], interval[1]);
                _model.InitialPieces = _model.PiecesLeft;
            }
        }
        public void CalculateNextTurn()
        {
            
            if (_model.IsCpTurn==false)
            {
                _model.RecalculatePiecesLeft(_model.PlayerRetrieve);
                _model.CpPreviousRetrieve = _model.CpRetrieve;
                _model.CpRetrieve = 0;
            }
            if (_model.PiecesLeft>0)
            {
                _model.IsCpTurn = true;
                MakeCpMove();
            }
            
            _model.PlayerPreviousRetrieve = _model.PlayerRetrieve;


            
        }

        private void MakeCpMove()
        {
            int piecesTaken = 0;
            if (_model.InitialPieces < 30)
            {
                piecesTaken = _model.DummyComputerRetrieves();
            }
            else
            {
                piecesTaken = _model.SmartComputerRetrieves();
            }
            _model.RecalculatePiecesLeft(piecesTaken);
            _model.CpRetrieve = piecesTaken;

        }

        public bool IsGameFinished()
        {
            
            if( _model.PiecesLeft == 0)
            {
                DeclareWinner();
                return true;
            }
            else
            {
                return false;
            }
        }

        private void DeclareWinner()
        {
            if (_model.IsCpTurn==true)
            {
                _model.isAWin = true;
            }
        }
    }
}
