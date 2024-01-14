using ControleDeContatos.Models;
using ControleDeContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace ControleDeContatos.Controllers
{
    public class ContatoController : Controller
    {
        private readonly Icontato _icontato;
        public ContatoController(Icontato icontato)
        {
            _icontato = icontato;
        }
        public IActionResult Index()
        {
            List<ContatoModel> contatos = _icontato.BuscarTodos();
            return View(contatos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            
            ContatoModel retorno = _icontato.ListarEditar(id);
            return View(retorno);
        }

        public IActionResult Excluir(int Id)
        {
            ContatoModel retorno = _icontato.ListarEditar(Id);
            return View(retorno);
        }
     
        public IActionResult Apagar(int Id)
        {
            try
            {
                bool apagado = _icontato.Apagar(Id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Apagado com Sucesso";
                }
                else
                {
                    TempData["MensagemErro"] = "Erro ao apagar";
                }
                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Erro ao apagar: {erro.Message}";
                return RedirectToAction("Index");
            }




        }
   
        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _icontato.Adicionar(contato);
                    TempData["MensagemSucesso"] = "Contato Cadastrado com sucesso";
                    return RedirectToAction("Index");
                }

                return View(contato);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Não conseguimos cadastrar seu contato:{erro.Message}";
                return RedirectToAction("Index");
            }
          
           
        }
        [HttpPost]
        public IActionResult Alterar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _icontato.Atualizar(contato);
                    TempData["MensagemSucesso"] = "Contato atualizado com sucesso";
                    return RedirectToAction("Index");
                }
                return View("Editar", contato);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Não conseguimos atualizar seu contato:{erro.Message}";
                
                return RedirectToAction("Index");
            }

        }
    }
}
