using System;
using System.Collections.Generic;
using System.IO;
using BookTrack.Classi;
using Newtonsoft.Json;

namespace BookTrack.Management_Class
{
    internal class GestoreUtenti
    {
        #region percorso file JSON
        //dichiaro il percorso file JSON con una variabile di tipo stringa statica privata
        private static string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "utenti.json");
        #endregion

        #region Metodo per caricare tutti gli utenti
        public static List<Cliente> CaricaUtenti()
        {
            //se il file non esiste, lo crea vuoto con una lista JSON
            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, "[]");
                return new List<Cliente>();
            }

            string json = File.ReadAllText(filePath);
            //deserializza la lista oppure restituisce una lista vuota
            return JsonConvert.DeserializeObject<List<Cliente>>(json) ?? new List<Cliente>();
        }
        #endregion

        #region metodo per salvare gli utenti
        public static void SalvaUtenti(List<Cliente> utenti)
        {
            //converte la lista in formato JSON e salva sul file
            string json = JsonConvert.SerializeObject(utenti, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }
        #endregion

        #region metodo per aggiungere un utente
        public static bool AggiungiUtente(Cliente nuovo)
        {
            List<Cliente> utenti = CaricaUtenti();

            //controlla se email o telefono sono già presenti
            foreach (Cliente utente in utenti)
            {
                if (utente.Email == nuovo.Email || utente.Telefono == nuovo.Telefono)
                {
                    return false;
                }          
            }
            // aggiunge il nuovo utente
            utenti.Add(nuovo);
            //salva la lista aggiornata
            SalvaUtenti(utenti); 
            return true;
        }
        #endregion

        #region metodo per prendere l'utente dalle credenziali
        public static Cliente PrendiUtenteDalleCredenziali(string email, string password)
        {
            List<Cliente> utenti = CaricaUtenti();

            //verifica se esiste un utente con email e password corrispondenti
            foreach (Cliente clienti in utenti)
            {
                if (clienti.Email == email && clienti.Password == password)
                {
                    return clienti;
                }
            }
            //ritorna a nullo se non trova delle corrispondenze 
            return null; 
        }
        #endregion

        #region metodo per generare ID
        public static int GeneraIDUnivoco()
        {
            List<Cliente> utenti = CaricaUtenti();
            Random random = new Random();
            int nuovoID;
            bool esiste;

            //genera un ID casuale e verifica che non sia già usato
            do
            {
                nuovoID = random.Next(1000, 9999);
                esiste = false;

                foreach (Cliente clienti in utenti)
                {
                    if (clienti.ID == nuovoID)
                    {
                        esiste = true;
                        break;
                    }
                }
            } while (esiste);

            return nuovoID;
        }
        #endregion
    }
}
