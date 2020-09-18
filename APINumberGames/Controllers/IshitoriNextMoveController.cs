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
    public class IshitoriNextMoveController : ControllerBase
    {
        private IshitoriGameModel _model;
        private IshitoriGame _currentGame;

        // POST api/<IshitoriNextMoveController>
        /// <summary>
        /// The controller for the Calculating the moving results.
        /// </summary>
        /// <param name="model">The current game in progress variables.</param>
        /// <returns>The same gamemodel modified so you could keep playing.</returns>
        [HttpPost]
        [ValidateModel]
        public object Post([FromBody] IshitoriGameModel model)
        {
            _model = model;
            _currentGame = new IshitoriGame(_model, new int[] { });
            _currentGame.CalculateNextTurn();
            _currentGame.IsGameFinished();
            return model;
        }

    }
}
