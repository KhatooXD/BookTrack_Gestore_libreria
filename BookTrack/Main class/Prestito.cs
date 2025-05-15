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
        private int _id;
        private int _idLibro;
        private int _idCliente;
        private DateTime _dataInizio;
        private DateTime _dataFine;

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
        public int IDLibro
        {
            get
            {
                return _idLibro;
            }
            set
            {
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
        public int IDCliente
        {
            get
            {
                return _idCliente;
            }
            set
            {
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

        public DateTime DataInizio
        {
            get
            {
                return _dataInizio;
            }
            set
            {
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

        public DateTime DataFine
        {
            get
            {
                return _dataFine;
            }
            set
            {
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

        public Prestito(int id, int idLibro, int idCliente, DateTime dataInizio, DateTime dataFine)
        {
            ID = id;
            IDLibro = idLibro;
            IDCliente = idCliente;
            DataInizio = dataInizio;
            DataFine = dataFine;
        }
    }
}
