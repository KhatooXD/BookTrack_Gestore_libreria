using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookTrack.Classi;

namespace BookTrack.Management_Class
{
    internal class Archivio
    {
        private List<Libro> _libri;
        private List<Cliente> _clienti;
        private List<Prestito> _prestiti;

        public List<Libro> Libri
        {
            get
            {
                return _libri;
            }
            set
            {
                _libri = value;
            }
        }
        public List<Cliente> Clienti
        {
            get
            {
                return _clienti;
            }
            set
            {
                _clienti = value;
            }
        }
        public List<Prestito> Prestiti
        {
            get
            {
                return _prestiti;
            }
            set
            {
                _prestiti = value;
            }
        }
        public Archivio()
        {
            _libri = new List<Libro>();
            _clienti = new List<Cliente>();
            _prestiti = new List<Prestito>();
        }

        public void SalvaDati()
        {
            // Implementa la logica per salvare i dati su file o database
        }
        public void CaricaDati()
        {
            // Implementa la logica per caricare i dati da file o database
        }
    }
}
