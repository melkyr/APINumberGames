using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APINumberGames.Models
{
    public class CreateGameModel
    {
        [Required]
        public int[] GameInterval { get; set; }
        public string SelectedGame { get; set; } = "";
    }
}
