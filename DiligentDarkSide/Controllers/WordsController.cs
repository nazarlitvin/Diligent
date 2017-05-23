using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using DiligentDarkSide.Data;
using DiligentDarkSide.Models;

namespace DiligentDarkSide.Controllers
{
    [Route("api/[controller]")]
    public class WordsController : Controller
    {
        private DiligentContext ctx = new DiligentContext();

        // GET api/words
        [HttpGet]
        public IEnumerable<Word> Get()
        {
            return ctx.Words.ToList();
        }
    }
}