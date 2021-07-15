
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
                InstituicaoId = 1,
                Nome = "FBV",
                Endereco = "Boa viagem"
            },
            new Instituicao()
            {
                InstituicaoId = 2,
                Nome = "UniSanta",
                Endereco = "Santa Catarina"
            },
            new Instituicao()
            {
                InstituicaoId = 3,
                Nome = "UniSãoPaulo",
                Endereco = "São Paulo"
            },
            new Instituicao() 
            {

                InstituicaoId = 4,
                Nome = "UniSulgrandense",
                Endereco = "Rio Grande do Sul"
            },
            new Instituicao() 
            {
                InstituicaoId = 5,
                Nome = "UniCarioca",
                Endereco = "Rio de Janeiro"
            }
        };

        // Definição de uma action chamada Index
        //Vai listar as instituições 
        public IActionResult Index()
        {
            //Vai retornar as instituições por ordem alfabetica
            return View(instituicoes.OrderBy(i => i.Nome));
        }

        //Para pagina de criação(interação) de uma nova instituição, interação com usuário
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
            instituicao.InstituicaoId = instituicoes.Select(i => i.InstituicaoId).Max() + 1;
            //Vai redirecionar para página Index
            return RedirectToAction(nameof(Index));
        }

        //Método para interação da tela de edição da instituição com o usuário(vai mostrar a instituição pelo Id)
        public ActionResult Edit(long id)
        {
            //Vai receber o id passado pela view para pegar a instituição e retornar na view
            return View(instituicoes.Where(i => i.InstituicaoId == id).First());
        }

        //Método que vai fazer a alteração dos dados
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Instituicao instituicao)
        {
            //Vai buscar a instituição pela Id que foi passado no parametro instituicao.InstituicaoId
            instituicoes.Remove(instituicoes.Where(i => i.InstituicaoId == instituicao.InstituicaoId).First());
            //Vai adicionar a instituição editada
            instituicoes.Add(instituicao);
            //Vai redirecionar a página 
            return RedirectToAction(nameof(Index));
        }
        
        //Método para mostrar o detalhe da instituição 
        public ActionResult Details (long id)
        {
            return View(instituicoes.Where(i => i.InstituicaoId == id).First());
        }

        //Método para tela de interação delete da instituição
        public ActionResult Delete (long id)
        {
            return View(instituicoes.Where(i => i.InstituicaoId == id).First());
        }

        //Método para a deletar a instituição do sistema
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete (Instituicao instituto){
            instituicoes.Remove(instituicoes.Where(i => i.InstituicaoId == instituto.InstituicaoId).First());
            return RedirectToAction(nameof(Index));
        }
    }
}