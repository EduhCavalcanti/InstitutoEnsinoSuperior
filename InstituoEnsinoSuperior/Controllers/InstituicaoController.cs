using InstituoEnsinoSuperior.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using InstituoEnsinoSuperior.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace InstituoEnsinoSuperior.Controllers
{
    public class InstituicaoController : Controller
    {
        private readonly IESContext _context;

        public InstituicaoController(IESContext context)
        {
            this._context = context;
        }

        // Definição de uma action chamada Index
        //Vai listar as instituições 
        public async Task<IActionResult> Index()
        {
            //Vai retornar as instituições por ordem alfabetica
            List<Instituicao> instituicoes = await _context.Instituições.OrderBy(x => x.Nome).ToListAsync();

            return View(instituicoes);
        }

        //Para pagina de criação(interação) de uma nova instituição, interação com usuário
        public ActionResult Create()
        {
            return View();
        }

        //Método para ciração de uma nova instituição utilizando os dados recebido pela view
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async  Task<ActionResult> Create(Instituicao instituicao)//Vai receber da View os parâmetros (nome, endereço)
        {
            if (ModelState.IsValid)
            {
                //Vai adicionar a instituição 
                _context.Instituições.Add(instituicao);
                await _context.SaveChangesAsync();
                //Vai redirecionar para página Index
                return RedirectToAction(nameof(Index));
            }
            return View(instituicao);
        }

        //Método para interação da tela de edição da instituição com o usuário(vai mostrar a instituição pelo Id)
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //Vai receber o id passado pela view para pegar a instituição e retornar na view
            return View(await _context.Instituições.SingleOrDefaultAsync(i => i.InstituicaoId == id));
        }

        //Método que vai fazer a alteração dos dados
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Instituicao instituicao, long? id)
        {
            //Vai verificar se o id é igual ao que foi passado
            if (id != instituicao.InstituicaoId)
            {
                return NotFound();
            }
           
            if(ModelState.IsValid)
            {
                //Vai Atualizar a instituição editada
                _context.Instituições.Update(instituicao);
                await _context.SaveChangesAsync();
                //Vai redirecionar a página 
                return RedirectToAction(nameof(Index));
            }
            return View(instituicao);
        }
        
        //Método para mostrar o detalhe da instituição 
        public async Task<ActionResult> Details (long id)
        {
            return View(await _context.Instituições.SingleOrDefaultAsync(i => i.InstituicaoId == id));
        }

        //Método para tela de interação delete da instituição
        public async Task<ActionResult> Delete (long id)
        {
            return View(await _context.Instituições.SingleOrDefaultAsync(i => i.InstituicaoId == id));
        }

        //Método para a deletar a instituição do sistema
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete (Instituicao instituto){
             _context.Instituições.Remove(instituto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}