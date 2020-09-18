using APINumberGames.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APINumberGames.Games
{
    public class GuessTheNumberGame : IGame
    {
        private GuessTheNumberModel _model { get; set; } = new GuessTheNumberModel();

        public GuessTheNumberGame(GuessTheNumberModel model,int [] interval)
        {
            _model = model;
            if (_model.NumberToGuess==0)
            {
                _model.NumberToGuess = new Random().Next(interval[0], interval[1]);
            }
            if (_model.AllowedTurns==0)
            {
                _model.AllowedTurns = CalculateMaxTurns(interval[1] - interval[0]);
            }
            if (interval.Count()>1)
            {
                _model.GuessingInterval = interval;
            }
            
        }
        public void CalculateNextTurn()
        {
            if (_model.PlayerGuess==_model.NumberToGuess)
            {
                _model.GuessResult = "win";
                _model.isAWin = true;
                _model.AllowedTurns = 0;
            }
            else if(_model.PlayerGuess>_model.NumberToGuess)
            {
                _model.GuessResult="lower";
                _model.isAWin = false;
                _model.AllowedTurns -= 1;
            }
            else
            {
                _model.GuessResult = "higher";
                _model.isAWin = false;
                _model.AllowedTurns -= 1;
            }
        }

        public bool IsGameFinished()
        {
            return _model.AllowedTurns < 1;
        }

        private int CalculateMaxTurns(int interval)
        {
            return (int)Math.Ceiling(Math.Log2(interval)) + 1;
        }
    }
}
