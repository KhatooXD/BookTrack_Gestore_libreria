using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BookTrack.Classi
{
    public class Prestito
    {
        #region dichiarazione variabili private
        private int _id;
        private int _idLibro;
        private int _idCliente;
        private DateTime _dataInizio;
        private DateTime _dataFine;
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
                //se il valore è maggiore di 0 restituisce il valore dell'utente
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

        #region metodo get e set della variabile di tipo intero IDLibro
        public int IDLibro
        {
            get
            {
                return _idLibro;
            }
            set
            {
                //se il valore è maggiore di 0 restituisce il valore dell'utente
                if (value > 0)
                {
                    _idLibro = value;
                }
                else
                {
                    throw new Exception("ID Libro non valido");
                }
            }
        }
        #endregion

        #region metodo get e set della variabile di tipo intero IDCliente
        public int IDCliente
        {
            get
            {
                return _idCliente;
            }

            set
            {
                //se il valore è maggiore di 0 restituisce il valore dell'utente
                if (value > 0)
                {
                    _idCliente = value;
                }
                else
                {
                    throw new Exception("ID Cliente non valido");
                }
            }
        }
        #endregion

        #region metodo get e set della variabile di tipo DateTime della data di inizio
        public DateTime DataInizio
        {
            get
            {
                return _dataInizio;
            }
            set
            {
                //se il valore è maggiore del valore minimo del datetime procede
                if (value > DateTime.MinValue)
                {
                    _dataInizio = value;
                }
                else
                {
                    throw new Exception("Data Inizio non valida");
                }
            }
        }
        #endregion

        #region metodo get e set della variabile di tipo DateTime della data di fine
        public DateTime DataFine
        {
            get
            {
                return _dataFine;
            }
            set
            {
                //se il valore è maggiore del valore minimo del datetime procede
                if (value > DateTime.MinValue)
                {
                    _dataFine = value;
                }
                else
                {
                    throw new Exception("Data Fine non valida");
                }
            }
        }
        #endregion

        #region Costruttore della classe Prestito
        public Prestito(int id, int idLibro, int idCliente, DateTime dataInizio, DateTime dataFine)
        {
            ID = id;
            IDLibro = idLibro;
            IDCliente = idCliente;
            DataInizio = dataInizio;
            DataFine = dataFine;
        }
        #endregion
    }
}
