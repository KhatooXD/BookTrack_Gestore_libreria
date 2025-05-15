using System;

namespace BookTrack.Management_Class
{
    public static class Validazione
    {
        public static bool ValidaAnno(string input, out int anno)
        {
            return int.TryParse(input, out anno) && anno > 1000;
        }
        public static bool ValidaPrezzo(string input, out double prezzo)
        {
            return double.TryParse(input, out prezzo) && prezzo > 0;
        }

        public static bool ValidaEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }
                

            bool verificaChiocciola = false;
            bool verificaPunto = false;

            for (int i = 0; i < email.Length; i++)
            {
                if (email[i] == '@')
                    verificaChiocciola = true;

                if (email[i] == '.' && verificaChiocciola)
                    verificaPunto = true;
            }

            return verificaChiocciola && verificaPunto;
        }
        public static bool ValidaPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password) || password.Length < 8)
            {
                return false;
            }
               
            bool verificaMaiuscola = false;
            bool verificaMinuscola = false;
            bool verificaNumero = false;
            bool verificaSpeciale = false;


            for (int i = 0; i < password.Length; i++)
            {
                char c = password[i];

                if (c >= 'A' && c <= 'Z')
                {
                    verificaMaiuscola = true;
                }
                    
                else if (c >= 'a' && c <= 'z')
                {
                    verificaMinuscola = true;
                }
                   
                else if (c >= '0' && c <= '9')
                {
                    verificaNumero = true;
                }
                   
                else
                {
                    verificaSpeciale = true;
                }
                   
            }

            return verificaMaiuscola && verificaMinuscola && verificaNumero && verificaSpeciale;
        }
        public static bool ValidaTelefono(string telefono)
        {
            if (string.IsNullOrWhiteSpace(telefono))
            {
                return false;
            }              
            if (telefono.Length < 10 || telefono.Length > 12)
            {
                return false;
            }                
            for (int i = 0; i < telefono.Length; i++)
            {
                if (telefono[i] < '0' || telefono[i] > '9')
                    return false;
            }
            return true;
        }
    }
}
