using System.ComponentModel.DataAnnotations;

namespace InstituoEnsinoSuperior.Models{
    public class Departamento
    {
        public long? DepartamentoId { get; set; } // A interrogação significa que ele pode ser null
        [Required (ErrorMessage ="Necessário nome de algum departamento")]
        public string Nome { get; set; }

        //Constructor 
        public Departamento()
        {
        }

    }
}