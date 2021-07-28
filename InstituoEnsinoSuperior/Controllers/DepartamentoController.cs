using InstituoEnsinoSuperior.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;
using InstituoEnsinoSuperior.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InstituoEnsinoSuperior.Controllers
{
    public class DepartamentoController : Controller
    {
        private readonly IESContext _context;

        //Contrutor para injeção de dependência
        public DepartamentoController(IESContext context)
        {
            this._context = context;
        }

        //Método para listar os departamentos 
        public async  Task<IActionResult> Index()
        {
            //Implentação tardia,(Sem associação)
            //List<Departamento> departamentos = await _context.Departamentos.ToListAsync();

            //Nova implementação, incluindo a instituição com retorno ordenado por nome
            var departamentos = await _context.Departamentos.Include(i => i.Instituicao).OrderBy(x => x.Nome).ToListAsync();
            return View(departamentos);
        }

        //Método para View da criação do departamento 
        public async Task<IActionResult> Create()
        {
            //Vai pegar o nome da instituição no banco de dados
            var instituicoes = await _context.Instituicoes.OrderBy(x => x.Nome).ToListAsync();
            //Depois, um objeto é inserido na coleção, logo no início,realocando os demais. Isso é feito para que uma mensagem orientativa seja exibida ao  usuário no DropDownList
            instituicoes.Insert(0, new Instituicao() { InstituicaoId = 0, Nome = "selecione uma instituição" });
            //Vai ser armazenado na ViewBag para ser usada no front
            ViewBag.Instituicoes = instituicoes;
            return View();
        }

        //Método para criação do departamento no banco de dados 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Departamento departamento)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(departamento);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Não foi possível inserir os dados.");
            }
            return View(departamento);
        }

        //Método para view de edição 
        public async Task<IActionResult> Edit (long? id)
        {
            //Vai verificar se foi passado algum Id 
            if(id == null)
            {
                return NotFound();
            }
            //Vai verificar no banco de dados o id que foi passado
            var departamento = await _context.Departamentos.SingleOrDefaultAsync(x => x.DepartamentoId == id);
            if (departamento == null)
            {
                return NotFound();
            }
            //Vai armazenar na viewBang
            ViewBag.Instituicoes = new SelectList(_context.Instituicoes.OrderBy(x => x.Nome), "InstituicaoId", "Nome", departamento.InstituicaoId);
            //Se tiver tudo certo vai retornar o departamento 
            return View(departamento);
        }

        //Método para Edição do departamento
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Departamento departamento, long? id)
        {
            //Vai verificar se o id é igual ao que foi passado
            if (id !=   departamento.DepartamentoId) 
            {
                return NotFound();
            }
            //Verifica se foi passado algo na view
            if (ModelState.IsValid) { 
            _context.Departamentos.Update(departamento);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
            }

            return View(departamento);
        }

        //Método para detalhes do departamento
        public async Task<IActionResult> Details(long? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            //var departamento = await _context.Departamentos.SingleOrDefaultAsync(x => x.DepartamentoId == id);
            var departamento = await _context.Departamentos.Include(i => i.Instituicao).OrderBy(x => x.Nome).SingleOrDefaultAsync(x => x.DepartamentoId == id);
            if(departamento == null)
            {
                return NotFound();
            }
            return View(departamento);
        }

        //Método para view de remoção
        public async Task<IActionResult> Delete(long? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var departameto = await _context.Departamentos.SingleOrDefaultAsync(x => x.DepartamentoId == id);
            if (departameto == null)
            {
                return NotFound();
            }
            return View(departameto);
        }

        //Método para deletar o departamento
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(long? id) 
        {
            if (id == null)
            {
                return NotFound();
            }
            var departameto = await _context.Departamentos.SingleOrDefaultAsync(x => x.DepartamentoId == id);
            if (departameto == null)
            {
                return NotFound();
            }
            _context.Departamentos.Remove(departameto);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }



    }
}