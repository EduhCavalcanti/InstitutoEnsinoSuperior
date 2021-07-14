
using InstituoEnsinoSuperior.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace InstituoEnsinoSuperior.Controllers
{
    public class InstituicaoController : Controller
    {
        //Provisório, para simular banco de dados
        private static IList<Instituicao> instituicoes = new List<Instituicao>() {
            new Instituicao()
            {
                InstituicaoID = 1,
                Nome = "FBV",
                Endereco = "Boa viagem"
            },
            new Instituicao()
            {
                InstituicaoID = 2,
                Nome = "UniSanta",
                Endereco = "Santa Catarina"
            },
            new Instituicao()
            {
                InstituicaoID = 3,
                Nome = "UniSãoPaulo",
                Endereco = "São Paulo"
            },
            new Instituicao() 
            {

                InstituicaoID = 4,
                Nome = "UniSulgrandense",
                Endereco = "Rio Grande do Sul"
            },
            new Instituicao() 
            {
                InstituicaoID = 5,
                Nome = "UniCarioca",
                Endereco = "Rio de Janeiro"
            }
        };

        // Definição de uma action chamada Index
        //Vai listar as instituições 
        public IActionResult Index()
        {
            return View(instituicoes);
        }

        //Para pagina de criação(interação) de uma nova instituição
        public ActionResult Create()
        {
            return View();
        }

        //Método para ciração de uma nova instituição utilizando os dados recebido pela view
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Instituicao instituicao)//Vai receber da View os parâmetros (nome, endereço)
        {
            //Vai adicionar a instituição 
            instituicoes.Add(instituicao);
            //Provisório, vai inserir manual o Id da instituição
            instituicao.InstituicaoID = instituicoes.Select(i => i.InstituicaoID).Max() + 1;
            //Vai redirecionar para página Index
            return RedirectToAction(nameof(Index));
        }

        //Método para interação da tela de edição da instituição (vai mostrar a instituição pelo Id)
        public ActionResult Edit(long id)
        {
            //Vai receber o id passado pela view para pegar a instituição e retornar na view
            return View(instituicoes.Where(i => i.InstituicaoID == id).First());
        }

        //Método que vai fazer a alteração 
        //[HttpGet]
        /*public ActionResult Edit(Instituicao instituicao)
        {
            //var instituto = instituicoes.Where(i => i.InstituicaoID == instituicao.id);
            return RedirectToAction(nameof(Index));
        }
        */
    }
}