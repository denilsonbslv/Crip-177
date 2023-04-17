using Crip_177_WebAPI.IServices;
using Crip_177_WebAPI.Utils;

namespace Crip_177_WebAPI.Services
{
    public class EncryptionService : IEncryptionService
    {
        AlphabetUpperCase _alphabetUpperCase;
        AlphabetLowerCase _alphabetLowerCase;
        AlphabetNumbers _alphabetNumbers;

        public EncryptionService()
        {
            _alphabetLowerCase = new AlphabetLowerCase();
            _alphabetUpperCase = new AlphabetUpperCase();
            _alphabetNumbers = new AlphabetNumbers();
        }

        public string Encrypt(string plainText)
        {
            // Cria uma string que sera retornada como resultado.
            string encryptedText = string.Empty;

            // Cria uma nova lista vazia de caracteres
            List<char> charList = new List<char>(plainText);

            foreach (char c in charList)
            {
                if (char.IsLower(c))
                {
                    encryptedText += _alphabetLowerCase.GetValueFromAlphabet(c);
                }else if (char.IsUpper(c))
                {
                    encryptedText += _alphabetUpperCase.GetValueFromAlphabet(c);
                }
                else if (char.IsDigit(c))
                {
                    encryptedText += _alphabetNumbers.GetNumberValue(c - '0');
                }
                else if (c == ' ')
                {
                    encryptedText += "‘g";
                }
            }
             
            return encryptedText;
        }

        public string Decrypt(string encryptedText)
        {
            // Implemente sua lógica de descriptografia personalizada aqui
            // Exemplo: string decryptedText = MyCustomDecrypt(encryptedText);

            string decryptedText = encryptedText; // Substitua esta linha pela lógica de descriptografia personalizada
            return decryptedText;
        }


    }
}
