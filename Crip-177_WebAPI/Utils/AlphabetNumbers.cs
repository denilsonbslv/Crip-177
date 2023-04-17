namespace Crip_177_WebAPI.Utils
{
    public class AlphabetNumbers
    {
        private Dictionary<int, string> _numeroParaNome;
        private AlphabetLowerCase _alphabetLowerCase;

        // Construtor da classe Numbers
        public AlphabetNumbers()
        {
            // Instanciando e inicializando a classe AlphabetLowerCase
            _alphabetLowerCase = new AlphabetLowerCase();
            _alphabetLowerCase.Initialize();

            // Criando um dicionário com números e seus nomes em português
            _numeroParaNome = new Dictionary<int, string>()
        {
            { 0, "zero" },
            { 1, "um" },
            { 2, "dois" },
            { 3, "três" },
            { 4, "quatro" },
            { 5, "cinco" },
            { 6, "seis" },
            { 7, "sete" },
            { 8, "oito" },
            { 9, "nove" },
        };

            // Atualizando os valores do dicionário
            AtualizarValoresDicionario();
        }

        // Método privado para atualizar os valores do dicionário conforme as regras especificadas
        private void AtualizarValoresDicionario()
        {
            // Copiando as chaves do dicionário para uma lista para evitar problemas de modificação durante a iteração
            List<int> chaves = new List<int>(_numeroParaNome.Keys);

            // Iterando sobre as chaves do dicionário
            foreach (int chave in chaves)
            {
                // Obtendo o valor associado à chave atual
                string valor = _numeroParaNome[chave];

                // Pegando a primeira e a última letra do valor
                valor = valor[0] + valor.Substring(valor.Length - 1);

                // Convertendo a primeira e a última letra usando GetValueFromAlphabet
                string newValor1 = _alphabetLowerCase.GetValueFromAlphabet(valor[0])[0].ToString();
                string newValor2 = _alphabetLowerCase.GetValueFromAlphabet(valor[1])[0].ToString();

                // Atualizando o valor no dicionário
                _numeroParaNome[chave] = newValor1 + newValor2;
            }
        }

        // Método privado para obter o nome associado a um número no dicionário atualizado
        private string GetValue(int numero)
        {
            if (_numeroParaNome.TryGetValue(numero, out string nome))
            {
                return nome;
            }
            else
            {
                throw new ArgumentOutOfRangeException("numero", "O número deve estar entre 0 e 9.");
            }
        }

        // Método público para obter a string referente ao valor de AlphabetLowerCase para um número específico
        public string GetNumberValue(int numero)
        {
            return GetValue(numero);
        }
    }


}
