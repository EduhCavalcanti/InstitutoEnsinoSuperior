using Microsoft.EntityFrameworkCore;
using InstituoEnsinoSuperior.Models;

namespace InstituoEnsinoSuperior.Data
{
    //Classe que vai fazer a integração da aplicação com o banco de dados
    public class IESContext : DbContext
    {
        //Construtor que vai receber opções de configuração para o contexto
        public IESContext(DbContextOptions<IESContext> options) : base(options)
        {
        }

        //Mapeando as classes para o banco de dados
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Instituicao> Instituicoes { get; set; }


    }
}