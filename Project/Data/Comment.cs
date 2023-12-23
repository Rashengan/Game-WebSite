using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Data
{
    public class Comment
    {
        [Key]
        public int CommentID { get; set; }
        public string? CommentTitle{ get; set; }
        public string? CommentText { get; set; }
        public DateTime? CommentDate{ get; set; }

        
    }
}