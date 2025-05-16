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
        #region dichiarazione variabili private
        private int _id;
        private string _titolo;
        private string _autore;
        private string _genere;
        private int _anno;
        private bool _diponibile;
        private double _prezzo;
        #endregion

        #region metodo get e set della variabile di tipo intero ID
        public int ID
        {
            get
            {
                return _id;
            }
            set
            {
                //se il valore è maggiore di 0 procede
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
        #endregion

        #region metodo get e set della variabile di tipo double prezzo
        public double Prezzo
        {
            get
            {
                return _prezzo;
            }
            set
            {
                //se il valore è maggiore di 0 continua
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
        #endregion

        #region metodo get e set della variabile di tipo stringa titolo
        public string Titolo
        {
            get
            {
                return _titolo;
            }
            set
            {
                //se il valore è diverso da nullo continua
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
        #endregion

        #region metodo get e set della variabile di tipo stringa autore
        public string Autore
        {
            get
            {
                return _autore;
            }
            set
            {
                //se il valore è diverso da nullo continua
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
        #endregion

        #region metodo get e set della variabile di tipo stringa genere
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
        #endregion

        #region metodo get e set della variabile di tipo intero anno
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
        #endregion

        #region metodo get e set della variabile di tipo bool disponibile
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
        #endregion

        #region costruttore della classe Libro

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
        #endregion
    }
}