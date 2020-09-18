using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using APINumberGames.Games;
using APINumberGames.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APINumberGames.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewGameController : ControllerBase
    {
        private IshitoriGameModel _model = new IshitoriGameModel();
        private GuessTheNumberModel _modelGuess = new GuessTheNumberModel();
        private int[] interval = new int[2];

        // POST api/<NewGameController>
        /// <summary>
        /// The Endpoint to generate a new game
        /// </summary>
        /// <param name="GameToCreate">The gameModel main parameters to play</param>
        /// <returns>The resulting model of the game Requested in selectedGame</returns>
        [HttpPost]
        [ValidateModel]
        public object Post([FromBody] CreateGameModel GameToCreate)
        {
            Array.Sort(GameToCreate.GameInterval);
            object game = new object();
            if (GameToCreate.SelectedGame=="Ishitori"&&GameToCreate.GameInterval.Count()==2)
            {
                IshitoriGame newGame = new IshitoriGame(_model, GameToCreate.GameInterval);
                game = _model;
            }else if(GameToCreate.SelectedGame=="GuessTheNumber" && GameToCreate.GameInterval.Count() == 2)
            {
                GuessTheNumberGame newGame = new GuessTheNumberGame(_modelGuess,GameToCreate.GameInterval);
                game = _modelGuess;
            }
            else
            {
                return BadRequest();
            }
            return game;
            
        }


    }
}
