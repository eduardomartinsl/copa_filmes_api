using System;
using System.Collections.Generic;
using System.Linq;
using copa_filmes_api.Models;
using copa_filmes_api.Repository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace copa_filmes_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmesVencedoresController : ControllerBase
    {
        [HttpPost]
        public ActionResult<string> CalculaFilmeVencedor([FromBody] List<Filme> content)
        {
            return JsonConvert.SerializeObject(new
            {
                result = new FilmesRepository(content).Finalistas
            });
        }
    }
}
