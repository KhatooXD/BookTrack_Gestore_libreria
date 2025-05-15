using BookTrack.Classi;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace BookTrack.Management_Class
{
    public static class GestorePrestiti
    {
        private static string filePath = "prestiti.json";

        public static List<Prestito> CaricaPrestiti()
        {
            if (!File.Exists(filePath))
            {
                return new List<Prestito>();
            }

            string json = File.ReadAllText(filePath);

            if (string.IsNullOrWhiteSpace(json))
            {
                return new List<Prestito>();
            }

            List<Prestito> lista = JsonConvert.DeserializeObject<List<Prestito>>(json);

            if (lista == null)
            {
                return new List<Prestito>();
            }

            return lista;
        }

        public static void SalvaPrestiti(List<Prestito> prestiti)
        {
            string json = JsonConvert.SerializeObject(prestiti, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        public static void AggiungiPrestito(Prestito nuovoPrestito)
        {
            List<Prestito> prestiti = CaricaPrestiti();
            prestiti.Add(nuovoPrestito);
            SalvaPrestiti(prestiti);
        }

        public static int GeneraIDPrestito()
        {
            List<Prestito> prestiti = CaricaPrestiti();
            Random random = new Random();
            int id;
            bool esiste;

            do
            {
                id = random.Next(1000, 9999);
                esiste = false;

                foreach (Prestito prestito in prestiti)
                {
                    if (prestito.ID == id)
                    {
                        esiste = true;
                    }
                }

            } while (esiste);

            return id;
        }
    }
}
