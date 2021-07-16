namespace InstituoEnsinoSuperior.Models{
    public class Departamento
    {
        public long? DepartamentoId { get; set; } // A interrogação significa que ele pode ser null
        public string Nome { get; set; }

        //Constructor 
        public Departamento()
        {
        }

    }
}