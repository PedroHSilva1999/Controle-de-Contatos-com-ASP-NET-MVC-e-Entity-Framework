using ControleDeContatos.Data;
using ControleDeContatos.Models;

namespace ControleDeContatos.Repositorio
{
    public class ContatoRepositorio: Icontato
    {
       
        private readonly BancoContext _bancoContext;
        public ContatoRepositorio(BancoContext banco)
        {
          
            _bancoContext = banco;
        }

        public ContatoModel Adicionar(ContatoModel contato)
        {

            //Está inserindo no banco
            _bancoContext.Contatos.Add(contato);
            _bancoContext.SaveChanges();
            return contato;
        }

        public bool Apagar(int id)
        {
            ContatoModel contatoDb = ListarEditar(id);

            if (contatoDb == null) throw new System.Exception("Houve um erro");

            _bancoContext.Contatos.Remove(contatoDb);
            _bancoContext.SaveChanges();    
            return true;
        }

        public ContatoModel Atualizar(ContatoModel contato)
        {
            ContatoModel contatoDb = ListarEditar(contato.Id);

            if (contatoDb == null) throw new System.Exception("Houve um erro");

            contatoDb.Nome = contato.Nome;
            contatoDb.Email = contato.Email;
            contatoDb.Celular = contato.Celular;
            _bancoContext.Contatos.Update(contatoDb);
            _bancoContext.SaveChanges();
            return contatoDb;
        }

        public List<ContatoModel> BuscarTodos()
        {
      
          return _bancoContext.Contatos.ToList();
        }

        public ContatoModel ListarEditar(int id)
        {
           return _bancoContext.Contatos.FirstOrDefault(f => f.Id == id);
        }
    }

}
