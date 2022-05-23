using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MiniProject001.BLL;

namespace MiniProject001.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorBLLController : ControllerBase
    {
        private readonly IAuthorService repo;
        public AuthorBLLController(IAuthorService r)
        {
            repo = r;
        }
        //GET: api/Authors
       [HttpGet]
        public async Task<ActionResult> getAllAuthors()
        {
           // return Ok();
           return Ok(await repo.getAllAuthors()); 
        }


    }
}


