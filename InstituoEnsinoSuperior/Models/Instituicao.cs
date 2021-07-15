
using System;

namespace InstituoEnsinoSuperior.Models
{
    //Classe instituição
    public class Instituicao
    {
        public long? InstituicaoId { get; set; }// A interrogação significa que ele pode ser null
        public string Nome { get; set; }
        public string Endereco { get; set; }


        //Construtores
        public Instituicao()
        {
        }
        public Instituicao (string nome, string endereco)
        {
            nome = Nome;
            endereco = Endereco;
        }
    }
}