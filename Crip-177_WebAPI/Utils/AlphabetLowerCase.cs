namespace Crip_177_WebAPI.Utils
{
    public class AlphabetLowerCase
    {
        private Dictionary<char, string> Alphabet;

        public AlphabetLowerCase()
        {
            Initialize();
        }

        public void Initialize()
        {
            // Cria o dicionário Alphabet com as chaves correspondentes ao alfabeto minúsculo e valores conforme especificação
            Alphabet = new Dictionary<char, string>();
            for (char c = 'a'; c <= 'z'; c++)
            {
                int value;
                if (c >= 'a' && c <= 'm')
                {
                    value = 26 - (c - 'a');
                }
                else if (c >= 'n' && c <= 'z')
                {
                    value = (c - 'n') + 1;
                }
                else
                {
                    throw new ArgumentException("A chave " + c + " não é uma letra minúscula.");
                }
                Alphabet[c] = value.ToString("D2");
            }

            // Loop sobre cada chave e valor no dicionário
            foreach (var kvp in Alphabet)
            {
                // Obtém o valor atual como um array de caracteres e inverte a ordem dos caracteres
                char[] valueChars = kvp.Value.ToCharArray();
                Array.Reverse(valueChars);

                // Atualiza o valor no dicionário com a string invertida
                Alphabet[kvp.Key] = new string(valueChars);
            }

            // Loop sobre cada chave e valor no dicionário
            foreach (var kvp in Alphabet)
            {
                // Obtém o primeiro algarismo do valor como um número inteiro
                int firstDigit = int.Parse(kvp.Value.Substring(0, 1));

                // Calcula o novo valor subtraindo o primeiro algarismo multiplicado por 2
                int newValue = int.Parse(kvp.Value) - (firstDigit * 2);

                // Atualiza o valor no dicionário com o novo valor calculado
                Alphabet[kvp.Key] = newValue.ToString("D2");
            }

            // Cria um dicionário com chave do tipo int e valor do tipo char
            Dictionary<int, char> numToLetter = new Dictionary<int, char>();

            // Popula o dicionário com os valores de 00 a 25
            for (int i = 0; i < 26; i++)
            {
                char letter = (char)(i + 'a');
                numToLetter[i] = letter;
            }

            // Loop sobre cada chave e valor no dicionário
            foreach (var kvp in Alphabet)
            {
                // Obtém o primeiro algarismo do valor como um número inteiro
                int firstDigit = int.Parse(kvp.Value.Substring(0, 1));

                // Verifica se o primeiro algarismo é par
                bool isFirstDigitEven = (firstDigit % 2 == 0);

                // Obtém a letra correspondente ao primeiro algarismo usando o dicionário numToLetter
                char firstLetter = numToLetter[firstDigit];

                // Substitui o primeiro algarismo no valor pela letra correspondente, maiúscula ou minúscula conforme necessário
                string newValue = "";
                if (isFirstDigitEven)
                {
                    newValue = firstLetter.ToString().ToUpper() + kvp.Value.Substring(1);
                }
                else
                {
                    newValue = firstLetter.ToString() + kvp.Value.Substring(1);
                }

                // Atualiza o valor no dicionário com o novo valor calculado
                Alphabet[kvp.Key] = newValue;
            }

            // Cria seis novos dicionários vazios para armazenar os valores divididos
            Dictionary<char, string> DictAM_AF = new Dictionary<char, string>();
            Dictionary<char, string> DictAM_G = new Dictionary<char, string>();
            Dictionary<char, string> DictAM_HM = new Dictionary<char, string>();
            Dictionary<char, string> DictNZ_NS = new Dictionary<char, string>();
            Dictionary<char, string> DictNZ_T = new Dictionary<char, string>();
            Dictionary<char, string> DictNZ_UZ = new Dictionary<char, string>();

            // Loop sobre cada chave e valor no dicionário original e adiciona cada um no dicionário correspondente
            foreach (var kvp in Alphabet)
            {
                char key = kvp.Key;
                string value = kvp.Value;

                if (key >= 'a' && key <= 'f')
                {
                    DictAM_AF[key] = value;
                }
                else if (key == 'g')
                {
                    DictAM_G[key] = value;
                }
                else if (key >= 'h' && key <= 'm')
                {
                    DictAM_HM[key] = value;
                }
                else if (key >= 'n' && key <= 's')
                {
                    DictNZ_NS[key] = value;
                }
                else if (key == 't')
                {
                    DictNZ_T[key] = value;
                }
                else if (key >= 'u' && key <= 'z')
                {
                    DictNZ_UZ[key] = value;
                }
            }

            // Troca os valores dos dicionários DictAM_AF e DictNZ_UZ
            SwapDictionaryValues(DictAM_AF, DictNZ_UZ);

            // Troca os valores dos dicionários DictAM_HM e DictNZ_NS
            SwapDictionaryValues(DictAM_HM, DictNZ_NS);

            // Loop sobre cada chave e valor no dicionário para atualizar
            foreach (var kvp in Alphabet)
            {
                char key = kvp.Key;
                string value = kvp.Value;

                // Verifica em qual subdicionário a chave se encaixa e atualiza o valor correspondente
                if (key >= 'a' && key <= 'f')
                {
                    Alphabet[key] = DictAM_AF[key];
                }
                else if (key >= 'u' && key <= 'z')
                {
                    Alphabet[key] = DictNZ_UZ[key];
                }
                else if (key >= 'h' && key <= 'm')
                {
                    Alphabet[key] = DictAM_HM[key];
                }
                else if (key >= 'n' && key <= 's')
                {
                    Alphabet[key] = DictNZ_NS[key];
                }
            }
        }

        // Função para trocar os valores de dois dicionários pelos índices
        private void SwapDictionaryValues<TKey, TValue>(Dictionary<TKey, TValue> dict1, Dictionary<TKey, TValue> dict2)
        {
            // Verificação do tamanho dos dicionários
            if (dict1.Count != dict2.Count)
            {
                throw new ArgumentException("Os dicionários devem ter o mesmo número de elementos.");
            }

            // Listas para serem usadas como auxilio
            var listDict1 = dict1.Values.ToList();
            var listDict2 = dict2.Values.ToList();

            int cont = 0;

            // Loop para trocar os valores das chaves correspondentes ao dict1
            foreach (var item in dict1)
            {
                dict1[item.Key] = listDict2[cont];
                cont++;
            }

            cont = 0;

            // Loop para trocar os valores das chaves correspondentes ao dict2
            foreach (var item in dict2)
            {
                dict2[item.Key] = listDict1[cont];
                cont++;
            }
        }

        // Função para obter o valor de uma letra no dicionário
        public string GetValueFromAlphabet(char c)
        {
            if (Alphabet.ContainsKey(c))
            {
                return Alphabet[c];
            }
            else
            {
                throw new ArgumentException("A chave " + c + " não é uma letra minúscula.");
            }
        }

        // Função que recebe um valor do dicionário _alphabet e retorna a letra correspondente
        public char GetLetterFromValue(string value)
        {
            // Busca no dicionário a chave que tem o valor igual ao valor recebido como parâmetro
            char letter = Alphabet.FirstOrDefault(x => x.Value == value).Key;
            // Retorna a letra encontrada
            return letter;
        }
    }
}
