using System;
using System.Collections.Generic;
using System.IO;
using BookTrack.Classi;
using Newtonsoft.Json;

namespace BookTrack.Management_Class
{
    internal class GestoreUtenti
    {
        #region Percorso file JSON
        private static string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "utenti.json");
        #endregion

        #region Metodo per caricare tutti gli utenti
        public static List<Cliente> CaricaUtenti()
        {
            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, "[]");
                return new List<Cliente>();
            }

            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<Cliente>>(json) ?? new List<Cliente>();
        }
        #endregion

        #region Metodo per salvare gli utenti
        public static void SalvaUtenti(List<Cliente> utenti)
        {
            string json = JsonConvert.SerializeObject(utenti, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }
        #endregion

        #region Metodo per aggiungere un utente
        public static bool AggiungiUtente(Cliente nuovo)
        {
            List<Cliente> utenti = CaricaUtenti();

            foreach (Cliente utente in utenti)
            {
                if (utente.Email == nuovo.Email || utente.Telefono == nuovo.Telefono)
                    return false;
            }

            utenti.Add(nuovo);
            SalvaUtenti(utenti);
            return true;
        }
        #endregion

        #region Metodo login
        public static Cliente PrendiUtenteDalleCredenziali(string email, string password)
        {
            List<Cliente> utenti = CaricaUtenti();

            foreach (Cliente clienti in utenti)
            {
                if (clienti.Email == email && clienti.Password == password)
                {
                    return clienti;
                }
                    
            }
            return null;
        }
        #endregion

        #region Metodo per generare ID
        public static int GeneraIDUnivoco()
        {
            List<Cliente> utenti = CaricaUtenti();
            Random random = new Random();
            int nuovoID;
            bool esiste;

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
