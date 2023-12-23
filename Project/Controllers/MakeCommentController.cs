using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project.Data;

namespace Project.Controllers
{
    [Route("[controller]")]
    public class MakeCommentController : Controller
    {
         private readonly DataContext _context;

        public MakeCommentController (DataContext context){
            _context = context;
        }
    }
}