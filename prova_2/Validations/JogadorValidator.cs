using prova_2.Models;

namespace prova_2.Validations
{
    public class JogadorValidator
    {
        private static readonly string[] PosicoesValidas =
       { "GL", "ZA", "LD", "LE", "VO", "MD", "AT" };

        public static List<string> Validar(Jogador jogador)
        {
            var erros = new List<string>();

            // Nome
            if (string.IsNullOrWhiteSpace(jogador.Nome))
                erros.Add("O nome é obrigatório.");
            else if (jogador.Nome.Length < 3 || jogador.Nome.Length > 50)
                erros.Add("O nome deve ter entre 3 e 50 caracteres.");

            // CPF
            if (string.IsNullOrWhiteSpace(jogador.Cpf))
                erros.Add("O CPF é obrigatório.");
            else if (jogador.Cpf.Length != 11 || !jogador.Cpf.All(char.IsDigit))
                erros.Add("O CPF deve ter exatamente 11 dígitos numéricos.");

            // Descrição
            if (string.IsNullOrWhiteSpace(jogador.Descricao))
                erros.Add("A descrição é obrigatória.");
            else if (jogador.Descricao.Length > 500)
                erros.Add("A descrição deve ter no máximo 500 caracteres.");

            // Posição
            if (string.IsNullOrWhiteSpace(jogador.Posicao))
                erros.Add("A posição é obrigatória.");
            else if (!PosicoesValidas.Contains(jogador.Posicao))
                erros.Add("Posição inválida. Use: GL, ZA, LD, LE, VO, MD ou AT.");

            return erros;
        }

        public static List<string> ValidarResultado(ResultadoRequest request)
        {
            var erros = new List<string>();

            if (string.IsNullOrWhiteSpace(request.Cpf))
                erros.Add("O CPF é obrigatório.");

            if (request.Aprovado == null)
                erros.Add("O resultado (aprovado) é obrigatório.");

            return erros;
        }
    }
}
