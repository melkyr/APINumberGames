using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APINumberGames.Games;
using APINumberGames.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APINumberGames.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuessingResultController : ControllerBase
    {
        public GuessTheNumberModel _model;
        public GuessTheNumberGame _currentGame;
        // POST api/<GuessingResultController>
        /// <summary>
        /// The API to calculate the Guess the number logic.
        /// </summary>
        /// <param name="model">The actual gameModel with all parameters of a generated game</param>
        /// <returns>The model with the hint to the player to a win</returns>
        [HttpPost]
        [ValidateModel]
        public Object Post([FromBody] GuessTheNumberModel model)
        {
            if (model.PlayerGuess<=model.GuessingInterval[1]&& model.PlayerGuess>=model.GuessingInterval[0])
            {
                _model = model;
                _currentGame = new GuessTheNumberGame(_model, new int[] { });

                _currentGame.CalculateNextTurn();
                _currentGame.IsGameFinished();
                return model;
            }
            else
            {
                return BadRequest();
            }
            
        }

    }
}
