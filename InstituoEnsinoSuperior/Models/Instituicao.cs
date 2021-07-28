
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InstituoEnsinoSuperior.Models
{
    //Classe instituição
    public class Instituicao
    {
        public long? InstituicaoId { get; set; }// A interrogação significa que ele pode ser null

        [Required(ErrorMessage = "Necessário nome de algum Instituição")]
        public string Nome { get; set; }
        public string Endereco { get; set; }

        //Associação com departamentos, de um para muitos
        public virtual ICollection<Departamento> Departamentos { get; set; } //Coleção de departamentos


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