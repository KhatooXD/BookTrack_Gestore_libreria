- BookTrack
  
BookTrack è un applicazione progettata per la gestione di una libreria. 
consente la registrazione e il login degli utenti.
permette anche la visualizzazione dei libri all'interno di una libreria (disponibili e non disponibili per il prestito).
permette anche la cronologia dei prestiti, e  infine permette a chi è admin la funzionalità di eliminare o aggiungere un libro.

- Funzionalità
  
  Gestione utenti:
  - Possibilità di registrarsi all'interno della libreria (inserendo nome,cognome,email,password e numero di telefono)
  - Se l'utente ha gia un account può tranquillamente registrarsi

  Gestione Libri:

  - Possibilità di visualizzare la lista completa dei libri (con nome libro,autore del libro, genere del libro, anno di pubblicazione del libro e infine se è disponibile per il prestito)
  - Possibilità di aggiungere o rimuovere un libro (solo se l'utente è admin)

  Ricerca Libri:
  
  - Possibilità di ricercare il libro tramite il nome del libro
  - Visualizzazione delle informazioni del libro senza andare direttamente nella libreria
  
  Gestione Prestiti:
  
  - I libri presi in prestito richiedono la firma digitale dell'utente (semplice input all'interno di una textbox)
  - Il programma da la scadenza del prestito di 30 giorni
  - Finestra con storico dei prestiti dell'utente con il contatore dei giorni rimasti per il prestito
  - Possibilità di restituire successivamente letto il libro e disponibilità subito immediata dopo il ritorno del libro in bibloteca

- Struttura del progretto:
BookTrack/

 Classi: Cliente,Libro,Prestito

 Forms: LoginForm,Register,MenuForm,LibriForm,AggiuntaLibro,InfoLibroForm,StoricoPrestitiForm,RicercaLibro

 Classi di gestione: GestoreUtenti,GestoreLibri,GestorePrestiti,Validazione

 File JSON (simulatore di un database): utenti,libri,prestiti


- Requisiti:
  
  - Visual studio 2017 (oppure superiore) installato nel pc
  - Windows 10


