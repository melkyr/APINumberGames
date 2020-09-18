using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APINumberGames.Models
{
    public class GuessTheNumberModel
    {
        public int NumberToGuess { get; set; }
        public int PlayerGuess { get; set; }
        public int[] GuessingInterval { get; set; }
        public int AllowedTurns { get; set; }
        public bool isAWin { get; set; }
        public string GuessResult { get; set; }
    }
}
