namespace Crip_177_WebAPI.Utils
{
    public class AlphabetUpperCase
    {
        private Dictionary<char, string> _alphabet;

        public AlphabetUpperCase()
        {
            InitializeAlphabetUppercase();
        }

        private void InitializeAlphabetUppercase()
        {
            // Criação do dicionário _alphabet com os valores iniciais
            _alphabet = new Dictionary<char, string>();
            for (char c = 'A'; c <= 'Z'; c++)
            {
                string value;
                if (c >= 'A' && c <= 'M')
                {
                    value = (26 - (c - 'A')).ToString("D2");
                }
                else
                {
                    value = ((c - 'N') + 1).ToString("D2");
                }
                _alphabet.Add(c, value);
            }

            InvertDigits();
            SubtractFirstDigitTimesTwo();
            ReplaceFirstDigitWithLetter();
            DivideIntoSubdictionaries();
        }

        internal void InvertDigits()
        {
            // Inversão dos algarismos dos valores correspondente a cada letra
            foreach (var kvp in _alphabet)
            {
                string value = kvp.Value;
                value = value[1].ToString() + value[0].ToString();
                _alphabet[kvp.Key] = value;
            }
        }

        internal void SubtractFirstDigitTimesTwo()
        {
            // Subtração do primeiro algarismo do valor da letra multiplicado por 2
            foreach (var kvp in _alphabet)
            {
                string value = kvp.Value;
                int firstDigit = int.Parse(value[0].ToString());
                int newValue = int.Parse(value) - (2 * firstDigit);
                value = newValue.ToString("D2");
                _alphabet[kvp.Key] = value;
            }
        }

        internal void ReplaceFirstDigitWithLetter()
        {
            // Criação do dicionário numToLetter
            Dictionary<int, char> numToLetter = new Dictionary<int, char>();
            for (int i = 0; i <= 25; i++)
            {
                char letter = (char)('A' + i);
                int value = 25 - i;
                numToLetter.Add(value, letter);
            }

            // Substituição do primeiro algarismo dos valores pelas letras do numToLetter
            foreach (var kvp in _alphabet)
            {
                string value = kvp.Value;
                int firstDigit = int.Parse(value[0].ToString());
                if (firstDigit % 2 == 0)
                {
                    char newChar = numToLetter[firstDigit];
                    value = newChar.ToString() + value.Substring(1);
                }
                else
                {
                    char newChar = char.ToLower(kvp.Key);
                    value = newChar.ToString() + value.Substring(1);
                }
                _alphabet[kvp.Key] = value;
            }
        }

        internal void DivideIntoSubdictionaries()
        {
            // Divisão do dicionário em subdicionários
            Dictionary<char, string> DictAM_AF = new Dictionary<char, string>();
            Dictionary<char, string> DictAM_G = new Dictionary<char, string>();
            Dictionary<char, string> DictAM_HM = new Dictionary<char, string>();
            Dictionary<char, string> DictNZ_NS = new Dictionary<char, string>();
            Dictionary<char, string> DictNZ_T = new Dictionary<char, string>();
            Dictionary<char, string> DictNZ_UZ = new Dictionary<char, string>();

            foreach (var entry in _alphabet)
            {
                if (entry.Key >= 'A' && entry.Key <= 'F')
                {
                    DictAM_AF.Add(entry.Key, entry.Value);
                }
                else if (entry.Key == 'G')
                {
                    DictAM_G.Add(entry.Key, entry.Value);
                }
                else if (entry.Key >= 'H' && entry.Key <= 'M')
                {
                    DictAM_HM.Add(entry.Key, entry.Value);
                }
                else if (entry.Key >= 'N' && entry.Key <= 'S')
                {
                    DictNZ_NS.Add(entry.Key, entry.Value);
                }
                else if (entry.Key == 'T')
                {
                    DictNZ_T.Add(entry.Key, entry.Value);
                }
                else if (entry.Key >= 'U' && entry.Key <= 'Z')
                {
                    DictNZ_UZ.Add(entry.Key, entry.Value);
                }
            }

            // Troca dos valores dos subdicionários
            SwapDictionaryValues(DictAM_AF, DictNZ_UZ);
            SwapDictionaryValues(DictAM_HM, DictNZ_NS);

            // Atualização dos valores do dicionário _alphabet usando os subdicionários
            foreach (var entry in DictAM_AF)
            {
                _alphabet[entry.Key] = entry.Value;
            }

            foreach (var entry in DictAM_G)
            {
                _alphabet[entry.Key] = entry.Value;
            }

            foreach (var entry in DictAM_HM)
            {
                _alphabet[entry.Key] = entry.Value;
            }

            foreach (var entry in DictNZ_NS)
            {
                _alphabet[entry.Key] = entry.Value;
            }

            foreach (var entry in DictNZ_T)
            {
                _alphabet[entry.Key] = entry.Value;
            }

            foreach (var entry in DictNZ_UZ)
            {
                _alphabet[entry.Key] = entry.Value;
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

        public string GetValueFromAlphabet(char letter)
        {
            if (!_alphabet.ContainsKey(letter))
            {
                throw new ArgumentException("Letra não encontrada no alfabeto.");
            }

            return _alphabet[letter];
        }

        public void GetValueFromAlphabet()
        {
            // Impressão do dicionário _alphabet
            foreach (var kvp in _alphabet)
            {
                Console.WriteLine(kvp.Key + " " + kvp.Value);
            }
        }

        // Função que recebe um valor do dicionário _alphabet e retorna a letra correspondente
        public char GetLetterFromValue(string value)
        {
            // Busca no dicionário a chave que tem o valor igual ao valor recebido como parâmetro
            char letter = _alphabet.FirstOrDefault(x => x.Value == value).Key;
            // Retorna a letra encontrada
            return letter;
        }
    }
}
