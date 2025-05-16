using BookTrack.Classi;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace BookTrack.Management_Class
{
    public static class GestorePrestiti
    {
        #region percorso file JSON
        private static string filePath = "prestiti.json";
        #endregion

        #region metodo per caricare i prestiti
        public static List<Prestito> CaricaPrestiti()
        {
            //se il file non esiste, restituisce lista vuota
            if (!File.Exists(filePath))
            {
                return new List<Prestito>();
            }

            string json = File.ReadAllText(filePath);

            //se il contenuto è vuoto, restituisce lista vuota
            if (string.IsNullOrWhiteSpace(json))
            {
                return new List<Prestito>();
            }

            //prova a deserializzare il contenuto JSON
            List<Prestito> lista = JsonConvert.DeserializeObject<List<Prestito>>(json);

            //se la deserializzazione fallisce, restituisce lista vuota
            if (lista == null)
            {
                return new List<Prestito>();
            }

            return lista;
        }
        #endregion

        #region metodo per salvare i prestiti
        public static void SalvaPrestiti(List<Prestito> prestiti)
        {
            //serializza la lista in formato JSON e la salva nel file
            string json = JsonConvert.SerializeObject(prestiti, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }
        #endregion

        #region metodo per aggiungere un prestito
        public static void AggiungiPrestito(Prestito nuovoPrestito)
        {
            List<Prestito> prestiti = CaricaPrestiti();
            //aggiunge il nuovo prestito alla lista
            prestiti.Add(nuovoPrestito);
            //salva la lista aggiornata
            SalvaPrestiti(prestiti); 
        }
        #endregion

        #region metodo per generare un ID univoco
        public static int GeneraIDPrestito()
        {
            List<Prestito> prestiti = CaricaPrestiti();
            Random random = new Random();
            int id;
            bool esiste;

            //genera un ID finché non è univoco
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
        #endregion
    }
}
