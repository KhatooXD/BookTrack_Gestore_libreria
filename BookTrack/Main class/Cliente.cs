using System;
using System.Linq;

namespace BookTrack.Classi
{
    public class Cliente
    {
        private int _id;
        private string _nome;
        private string _cognome;
        private string _email;
        private string _password;
        private string _telefono;

        public int ID
        {
            get
            {
                return _id;
            }
            set
            {
                if (value > 0)
                    _id = value;
                else
                    throw new Exception("ID non valido");
            }
        }

        public string Nome
        {
            get
            {
                return _nome;
            }
            set
            {
                if (!string.IsNullOrEmpty(value) && value.Length >= 2)
                {
                    _nome = value;
                }
                else
                {
                    throw new Exception("Nome non valido, deve avere almeno 2 caratteri.");
                }
            }
        }

        public string Cognome
        {
            get
            {
                return _cognome;

            }
            set
            {
                if (!string.IsNullOrEmpty(value) && value.Length >= 2)
                {
                    _cognome = value;
                }
                else
                {
                    throw new Exception("Cognome non valido, deve avere almeno 2 caratteri.");
                }
            }
        }

        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _email = value;
                }
                else
                {
                    throw new Exception("Email non valida.");
                }
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _password = value;
                }
                else
                {
                    throw new Exception("Password non valida.");
                }
            }
        }

        public string Telefono
        {
            get
            {
                return _telefono;
            }
            set
            {
                //controlla che la stringa non sia vuota e contenga solo cifre
                if (!string.IsNullOrEmpty(value) && value.All(char.IsDigit))
                {
                    _telefono = value;
                }
                else
                {
                    throw new Exception("Telefono non valido, inserisci solo numeri.");
                }
            }
        }

        public Cliente(int id, string nome, string cognome, string email, string telefono, string password)
        {
            ID = id;
            Nome = nome;
            Cognome = cognome;
            Email = email;
            Telefono = telefono;
            Password = password;
        }

        

    }
}
