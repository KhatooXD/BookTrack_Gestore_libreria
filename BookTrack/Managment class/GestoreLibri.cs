using System;
using System.Collections.Generic;
using System.IO;
using BookTrack.Classi;
using Newtonsoft.Json;

namespace BookTrack.Management_Class
{
    public static class GestoreLibri
    {
        #region percorso file JSON
        private static string filePath = "libri.json";
        #endregion

        #region metodo per caricare i libri
        public static List<Libro> CaricaLibri()
        {
            //se il file non esiste, lo crea con una lista vuota
            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, "[]");
                return new List<Libro>();
            }

            string json = File.ReadAllText(filePath);

            //se il contenuto è vuoto, restituisce lista vuota
            if (string.IsNullOrWhiteSpace(json))
            {
                return new List<Libro>();
            }

            //prova a deserializzare il contenuto JSON
            List<Libro> lista = JsonConvert.DeserializeObject<List<Libro>>(json);

            //se fallisce la deserializzazione, restituisce lista vuota
            if (lista == null)
            {
                return new List<Libro>();
            }

            return lista;
        }
        #endregion

        #region metodo per salvare i libri
        public static void SalvaLibri(List<Libro> libri)
        {
            //serializza la lista dei libri e la salva nel file
            string json = JsonConvert.SerializeObject(libri, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }
        #endregion

        #region metodo per aggiungere un nuovo libro
        public static bool AggiungiLibro(Libro libro)
        {
            List<Libro> libri = CaricaLibri();

            //verifica se esiste già un libro con stesso titolo e autore
            foreach (Libro l in libri)
            {
                if (l.Titolo == libro.Titolo && l.Autore == libro.Autore)
                {
                    return false;
                }
            }
            //aggiunge il libro alla lista
            libri.Add(libro);
            //salva la lista aggiornata
            SalvaLibri(libri); 
            return true;
        }
        #endregion

        #region metodo per aggiornare un libro esistente
        public static void AggiornaLibro(Libro modificato)
        {
            List<Libro> libri = CaricaLibri();

            //sostituisce il libro con lo stesso ID con quello modificato
            for (int i = 0; i < libri.Count; i++)
            {
                if (libri[i].ID == modificato.ID)
                {
                    libri[i] = modificato;
                    break;
                }
            }

            SalvaLibri(libri); //salva la lista aggiornata
        }
        #endregion

        #region metodo per generare ID univoco
        public static int GeneraIDUnivoco()
        {
            List<Libro> libri = CaricaLibri();
            Random random = new Random();
            int id;
            bool esiste;

            //genera un ID casuale non presente nella lista
            do
            {
                id = random.Next(1000, 9999);
                esiste = false;

                foreach (Libro libro in libri)
                {
                    if (libro.ID == id)
                    {
                        esiste = true;
                        break;
                    }
                }

            } while (esiste);

            return id;
        }
        #endregion
    }
}
