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
            //Se não tiver dados no BD, iremos povoar
            if (_context.Instituições.Any())
            {
                return;
            }
            var instituicoes = new Instituicao[]
            {
                new Instituicao{Nome="FBV", Endereco="Boa viagem"},
                new Instituicao{Nome="UniSanta", Endereco="Santa Catarina"},
                new Instituicao{Nome="UniSãoPaulo", Endereco="São Paulo"},
                new Instituicao{Nome="UniSulgrandense", Endereco="Rio Grande do Sul"},
                new Instituicao{Nome="UniCarioca", Endereco="Rio de Janeiro"},
            };
            foreach(Instituicao i in instituicoes)
            {
                _context.Add(i);
            }
            _context.SaveChanges();

            //Se não tiver dados no BD, iremos popular
            if (_context.Departamentos.Any())
            {
                return;
            }
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