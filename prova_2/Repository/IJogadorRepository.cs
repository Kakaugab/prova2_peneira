namespace prova_2.Repository
{
    public interface IJogadorRepository
    {
        void Adicionar(Jogador jogador);
        List<Jogador> ListarTodos();
        Jogador? ObterPorCpf(string cpf);
        List<Jogador> ListarAprovados();
    }
}
