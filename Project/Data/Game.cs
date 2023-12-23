using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Project.Data;

namespace Project.Models
{
    public class Game
    {
        [Key]
        public int GameID { get; set; }
        public string GameName { get; set; }
        public string GameDescription { get; set; }
        public string? GameImage{ get; set; }
        public string? Developer{ get; set; }
        public string? GameScore { get; set; }
        public string? GameTag { get; set; }
        public bool HaveAward { get; set; }

        public ICollection<MakeComment> makeComments{get; set;} = new List<MakeComment>();
    }
}