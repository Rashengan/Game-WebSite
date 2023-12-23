using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Project.Models;

namespace Project.Data
{
    public class MakeComment
    {
        [Key]
        public int MCID { get; set; }
        public int CommentID { get; set; }
        public int GameID { get; set; }
        public Game? Game{get; set;}
        public DateTime CommentDate{get; set;}

    }
}