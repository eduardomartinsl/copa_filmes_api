using System;
using System.Collections.Generic;
using System.Linq;
using copa_filmes_api.Models;

namespace copa_filmes_api.Repository
{
    public class FilmesRepository
    {
        public List<Filme> Finalistas { get; set; }

        private readonly List<Filme> _filmes;

        public FilmesRepository(List<Filme> filmes)
        {
            _filmes = filmes.OrderBy(x => x.Titulo).ToList();
            Finalistas = new List<Filme>();

            var segundoLugar = new Filme();

            //Primeira rodada de eliminatórias
            var primeiraEliminatoria = CreatePartida(_filmes[0], _filmes[7]);
            var SegundaEliminatoria = CreatePartida(_filmes[1], _filmes[6]);
            var TerceiraEliminatoria = CreatePartida(_filmes[2], _filmes[5]);
            var QuartaEliminatoria = CreatePartida(_filmes[3], _filmes[4]);

            //segunda rodada de eliminatorias
            var quintaEliminatoria = CreatePartida(primeiraEliminatoria, SegundaEliminatoria);
            var SextaEliminatoria = CreatePartida(TerceiraEliminatoria, QuartaEliminatoria);

            //finais
            var primeiroLugar = CreatePartida(quintaEliminatoria, SextaEliminatoria);

            if(primeiroLugar == quintaEliminatoria)
            {
                segundoLugar = SextaEliminatoria;
            }
            else
            {
                segundoLugar = quintaEliminatoria;
            }

            primeiroLugar.Posicao = 1;
            segundoLugar.Posicao = 2;

            Finalistas.Add(primeiroLugar);
            Finalistas.Add(segundoLugar);

        }

        private Filme CreatePartida(Filme filme1, Filme filme2)
        {
            return FilmeVencedor(new List<Filme> { filme1, filme2 });
        }

        public Filme FilmeVencedor(List<Filme> filmes)
        {
           if(filmes[0].Nota == filmes[1].Nota)
            {
                return filmes.OrderBy(x => x.Titulo).First();
            }
            if (filmes[0].Nota > filmes[1].Nota)
            {
                return filmes[0];
            }
            return filmes[1];
        }
    }
}
