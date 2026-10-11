namespace prova_2.Repository
{
    public class JogadorRepository : IJogadorRepository
    {
        private readonly List<Jogador> _jogadores = new();

        public void Adicionar(Jogador jogador)
        {
            _jogadores.Add(jogador);
        }

        public List<Jogador> ListarTodos()
        {
            return _jogadores;
        }

        public Jogador? ObterPorCpf(string cpf)
        {
            return _jogadores.FirstOrDefault(j => j.Cpf == cpf);
        }

        public List<Jogador> ListarAprovados()
        {
            return _jogadores.Where(j => j.Aprovado == true).ToList();
        }
    }
}
