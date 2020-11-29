using System;
namespace copa_filmes_api.Models
{
    public class Filme
    {
        public string Id { get; set; }
        public string Titulo { get; set; }
        public int Ano { get; set; }
        public float Nota { get; set; }
        public bool Campeao { get; set; } = false;
    }
}