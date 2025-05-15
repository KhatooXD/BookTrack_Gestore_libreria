using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookTrack.Classi
{
    public class Libro
    {
        private int _id;
        private string _titolo;
        private string _autore;
        private string _genere;
        private int _anno;
        private bool _diponibile;
        private double _prezzo;

        public int ID
        {
            get
            {
                return _id;
            }
            set
            {
                if (value > 0)
                {
                    _id = value;
                }
                else
                {
                    throw new Exception("ID non valido");
                }
            }
        }

        public double Prezzo
        {
            get
            {
                return _prezzo;
            }
            set
            {
                if (value > 0)
                {
                    _prezzo = value;
                }
                else
                {
                    throw new Exception("Prezzo non valido");
                }
            }
        }
        public string Titolo
        {
            get
            {
                return _titolo;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _titolo = value;
                }
                else
                {
                    throw new Exception("Titolo non valido");
                }
            }
        }
        public string Autore
        {
            get
            {
                return _autore;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _autore = value;
                }
                else
                {
                    throw new Exception("Autore non valido");
                }
            }
        }
        public string Genere
        {
            get
            {
                return _genere;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _genere = value;
                }
                else
                {
                    throw new Exception("Genere non valido");
                }
            }
        }
        public int Anno
        {
            get
            {
                return _anno;
            }
            set
            {
                if (value > 0)
                {
                    _anno = value;
                }
                else
                {
                    throw new Exception("Anno non valido");
                }
            }
        }

        public bool Disponibile
        {
            get
            {
                return _diponibile;
            }
            set
            {
                _diponibile = value;
            }
        }

        public Libro(int id, string titolo, string autore, string genere, int anno, bool disponibile, double prezzo)
        {
            ID = id;
            Titolo = titolo;
            Autore = autore;
            Genere = genere;
            Anno = anno;
            Disponibile = disponibile;
            Prezzo = prezzo;
        }
    }
}