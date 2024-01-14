using ControleDeContatos.Models;

namespace ControleDeContatos.Repositorio
{
    public interface Icontato
    {
        bool Apagar(int id);
        ContatoModel Atualizar(ContatoModel contato);
        ContatoModel ListarEditar(int id);
        List<ContatoModel>BuscarTodos();

      
        ContatoModel Adicionar(ContatoModel contato);
    }
}
