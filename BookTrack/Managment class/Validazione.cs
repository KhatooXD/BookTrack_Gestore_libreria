using System;

namespace BookTrack.Management_Class
{
    public static class Validazione
    {
        #region metodo per validare l'anno inserito
        public static bool ValidaAnno(string input, out int anno)
        {
            return int.TryParse(input, out anno) && anno > 1000;
        }
        #endregion

        #region metodo per validare il prezzo inserito
        public static bool ValidaPrezzo(string input, out double prezzo)
        {
            return double.TryParse(input, out prezzo) && prezzo > 0;
        }
        #endregion

        #region metodo per validare l'email inserita
        public static bool ValidaEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }

            bool verificaChiocciola = false;
            bool verificaPunto = false;
            //ciclo for per controllare se la stringa dell'email ha all'interno almeno una @ ed almeno un .
            for (int i = 0; i < email.Length; i++)
            {
                if (email[i] == '@')
                    verificaChiocciola = true;

                if (email[i] == '.' && verificaChiocciola)
                    verificaPunto = true;
            }

            return verificaChiocciola && verificaPunto;
        }
        #endregion

        #region metodo per validare la password 

        public static bool ValidaPassword(string password)
        {
            //se il campo è nullo oppure la lunghezza della password è minore di 8, ritorna all'inserimento della password
            if (string.IsNullOrWhiteSpace(password) || password.Length < 8)
            {
                return false;
            }

            bool verificaMaiuscola = false;
            bool verificaMinuscola = false;
            bool verificaNumero = false;
            bool verificaSpeciale = false;


            //ciclo for per controllare i caratteri della password
            for (int i = 0; i < password.Length; i++)
            {
                char c = password[i];

                //se ha una maiuscola ritorna a true
                if (c >= 'A' && c <= 'Z')
                {
                    verificaMaiuscola = true;
                }

                //se ha una minuscola ritorna a true
                else if (c >= 'a' && c <= 'z')
                {
                    verificaMinuscola = true;
                }
                // se ha un numero all'interno della password ritorna a true   
                else if (c >= '0' && c <= '9')
                {
                    verificaNumero = true;
                }
                //se ha un carattere speciale ritorna a true
                else
                {
                    verificaSpeciale = true;
                }

            }
            //deve ritornare tutto a true
            return verificaMaiuscola && verificaMinuscola && verificaNumero && verificaSpeciale;
        }
        #endregion

        #region metodo per validare il telefono scelto dall'utente
        public static bool ValidaTelefono(string telefono)
        {
            //se l'utente non imette nulla nel campo ritorna all'inserimento della password
            if (string.IsNullOrWhiteSpace(telefono))
            {
                return false;
            }
            //se il numero è minore di 10 caratteri o maggiore di 12 caratteri  ritorna all'inserimento
            if (telefono.Length < 10 || telefono.Length > 12)
            {
                return false;
            }
            //ciclo for per controllare se la stringa del numero è formata solo da numero
            for (int i = 0; i < telefono.Length; i++)
            {
                if (telefono[i] < '0' || telefono[i] > '9')
                {
                    return false;
                }
            }
            return true;
        }
        #endregion
    }
}