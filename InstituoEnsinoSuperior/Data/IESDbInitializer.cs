using InstituoEnsinoSuperior.Models;
using System.Linq;
namespace InstituoEnsinoSuperior.Data
{
    //Classe responsável por popular o banco de dados 
    public class IESDbInitializer
    {
        private IESContext _context;

        public IESDbInitializer(IESContext context)
        {
            this._context = context;
        }
        //Método reponsável por verificar se existe dados no banco de dados e popular o banco quaso não tenha nada
        public  void Initialize()
        {
            if (_context.Departamentos.Any())
            {
                return;
            }
            //Se não tiver dados no BD, iremos popular
            var departamentos = new Departamento[]
            {
            new Departamento{Nome="Ciência da Computação"},
            new Departamento{Nome="Ciência de Alimento"}
            };
            foreach (Departamento d in departamentos)
            {
                _context.Departamentos.Add(d);
            }
            _context.SaveChanges();
        }

    }
}