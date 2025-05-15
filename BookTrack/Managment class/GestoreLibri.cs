using System;
using System.Collections.Generic;
using System.IO;
using BookTrack.Classi;
using Newtonsoft.Json;

namespace BookTrack.Management_Class
{
    public static class GestoreLibri
    {
        private static string filePath = "libri.json";

        public static List<Libro> CaricaLibri()
        {
            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, "[]");
                return new List<Libro>();
            }

            string json = File.ReadAllText(filePath);
            if (string.IsNullOrWhiteSpace(json))
            {
                return new List<Libro>();
            }

            List<Libro> lista = JsonConvert.DeserializeObject<List<Libro>>(json);
            if (lista == null)
            {
                return new List<Libro>();
            }

            return lista;
        }

        public static void SalvaLibri(List<Libro> libri)
        {
            string json = JsonConvert.SerializeObject(libri, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        public static bool AggiungiLibro(Libro libro)
        {
            List<Libro> libri = CaricaLibri();

            foreach (Libro l in libri)
            {
                if (l.Titolo == libro.Titolo && l.Autore == libro.Autore)
                {
                    return false;
                }
            }

            libri.Add(libro);
            SalvaLibri(libri);
            return true;
        }

        public static void AggiornaLibro(Libro modificato)
        {
            List<Libro> libri = CaricaLibri();

            for (int i = 0; i < libri.Count; i++)
            {
                if (libri[i].ID == modificato.ID)
                {
                    libri[i] = modificato;
                    break;
                }
            }

            SalvaLibri(libri);
        }

        public static int GeneraIDUnivoco()
        {
            List<Libro> libri = CaricaLibri();
            Random random = new Random();
            int id;
            bool esiste;

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
    }
}
