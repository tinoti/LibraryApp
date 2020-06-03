Live stranica:

https://algebraknjiznica.azurewebsites.net


Pluginovi:
 - datatable https://datatables.net/
 - typeahead https://twitter.github.io/typeahead.js/
 - toastr https://github.com/CodeSeven/toastr
 - bootbox http://bootboxjs.com/


ANONIMNI KORISNIK

Anonimni korisnik ima opciju pregledavanja knjiga, rezervacije istih te provjeru statusa rezervacija. Moguca je rezervacija do 4 knjige.

/Book
View: /Book/Index
Script: /App/Book.js

Koristi se DataTable plugin za prikaz knjiga. DataTable radi ajax poziv na API /api/books, koji vraca sve knjige iz baze, te ih zatim prikazuje. 

Opcija createdRow izvrši zadanu funkciju na svakom redu u tablici koji se kreira. Parametar "data" je JSON objekt za taj red, u ovom slucaju Book objekt. Provjeravamo je li knjiga dostupna te u slucaju da nije onemogucujemo klik na nju te ju vizualno odvojimo od ostalih. 

Opcija columns je lista kojom odredujemo stupce u tablici. Prima objekte koju mogu imati "data" i "render" parametre. Data je key iz JSON objekta ciji ce se value prikazati, a render je funkcija koja odreduje kako ce se taj parametar prikazati. 

Prvo prikazujemo ime knjige, te dajemo mogucnost da se na to ime klikne što onda korisnika preusmjeri na detalje o toj knjizi. Zatim prikazujemo autora, žanr knjige te koliko knjiga je dostupno za posudbu. 

Kao zadnju opciju prikazujemo gumb koji, kada se klikne, otvara novi div sastrane u kojem se vide rezervacije koje je korisnik napravio (Book.js, linija 76). Rezervacija sa te liste se može ukloniti (linija 119), te se može kliknuti na gumb rezerviraj, koji pomocu URL querya šalje podatke na Reservation controller (linija 153). Takoder, lista rezervacija se mice sukladno sa pomicanjem stranice gore ili dolje (linija 174)


/Book/Details/Id
View: Book/Details
Controller action: BookController/Details

Pomocu Razorove @model funkcije prikazuje sve podatke o knjizi.


/Reservation
View: Reservation/Index
Script: App/Reservation.js


Koristi se typeahead plugin, koji, cim korisnik krene upisivat u input, radi call na API /api/books, koji vraca popis svih knjiga, te traži i prikazuje sve knjige koje odgovaraju korisnikovom upisu.  Za typeahead moramo inicijalizirati Bloodhound objekt (linija 22), koji ima opciju remote (za remote url iz kojeg dobiva podatke), koji onda ima opciju transform (linija 28), te pomocu nje možemo urediti podatke prije nego što se prikažu. U ovom slucaju sortiramo podatke po abecednom redu.

Ukoliko korisnik dolazi iz Book pogleda, na liniji 9 dobivamo sve Id-e iz querya i stavljamo ih u listu, te onda na liniji 56 radimo API call na /api/books, te sve knjige stavljamo u bookList listu. Nakon toga zovemo drawInputs metodu (koju zovemo i ako korisnik ne dolazi iz Book pogleda), koja prikazuje odabrane knjige te prazan input za upis nove knjige, ukoliko korisnik ima manje od 4 izabrane knjige. Input možemo i maknuti (linija 192).

Nakon što korisnik odabere željene knjige i upiše broj clanske iskaznice i pošalje rezervaciju, linija 87 hendla rezervaciju. Šalje se ajax POST na /api/reservations, kontroler koji iz baze provjerava koliko korisnik vec ima rezervacija, je li knjiga koju je rezervirao vec rezervirana kod istog korisnika, te je li knjiga dostupna. Ukoliko je sve u redu, upisuje rezervaciju u bazu podataka te dodaje na successReservation listu. Ukoliko nešto nije u redu, ne upisuje u bazu i dodaje na failReservation listu, i te dvije liste šalje nazad u Ok responsu. Ukoliko su krivo upisani podaci šalje nazad 404 grešku.

Zatim koristimo toastr plugin koji prikazuje sve uspješne i neuspješne rezervacije (linija 101). Ako su krivo unešeni podaci ili je došlo do neke druge greške, prikazuje se odgovarajuca poruka (linija 123).





/Reservation/Status
View: Reservation/Status
Script: App/Status.js


Korisnik ovdje može upisati broj svoje clanske iskanznice i provjeriti status svojih rezervacija. Radi se ajax GET na /api/reservations/MembersipCardNumber, koji vraca sve rezervacije pod tim brojem iskaznice. Zatim pomocu bootbox plugina prikazujemo rezultate (linija 13). Rezervacija može biti u cekanju, potvrdena ili odbijena. Ukoliko je korisnik upisao broj clanske iskaznice koji ne postoji, javlja se greška (linija 32).





ZAPOSLENIK:

Zaposlenik ima mogucnosti pregledavanja knjiga, koje mogu urediti, dodati ili obrisati, te pregled rezervacija koje mogu odbiti, potvrditi ili staviti u pocetni status cekanja obrade.


/Reservation
View: Reservation/EmployeeIndex
Script: App/EmployeeReservation.js

Koristi se DataTable, koji radi AJAX GET na /api/reservations, za prikaz rezervacija. createdRow funkcijom (linija 38) provjeravamo status svake rezervacije te dodajemo boju cijelom redu ovisno o statusu.

Prikazujemo Id rezervacije, ime knjige, clana koji je napravio rezervaciju, vrijeme rezervacije, status rezervacije, te tri gumba, za potvrdu, odbijanje ili stavljanje na pocetni status cekanja obrade.

Svaki od ta tri gumba (linija 113, 137 i 160) prvo preko bootbox plugina traži potvrdu akcije, te zatim radi ajax PUT na /api/reservations, koji ažurira status rezervacije. Nakon toga ponovno osvježava tablicu.

Zaposlenik takoder ima mogucnost sortiranja rezervacija prema statusu, koje dobiva klikom na cetiri gumba ispod liste rezervacija. 



/Book
View: Book/EmployeeIndex
Script: App/EmployeeBook.js

Koristi se DataTable za prikaz svih knjiga. Prikazuje se ime knjige, autor, raspoloživost, te gumb za uredivanje i brisanje knjige.

Linija 63 implementira brisanje knjige. Pomocu bootboxa zaposlenik prvo mora potvrditi brisanje, te se zatim radi AJAX DELETE na /api/books/BookId, koji briše knjigu iz baze. Linija 75 briše knjigu iz tablice.



Ukoliko zaposlenik želi urediti ili dodati novu knjigu, šalje ga se na isti view, Book/AddOrEdit. Koristi se BookController. Akcija New vraca AddOrEdit view sa praznom formom, dok akcija Edit vraca isti taj view sa popunjenom formom knjige koja se želi urediti. U bilo kojem slucaju, kada zaposlenik spremi promjene, zove se Save akcija koja sprema knjigu i vraca zaposlenika na pocetni prikaz tablice knjiga.








ADMIN:


Administrator ima sve iste mogucnosti kao i zaposlenici, sa dodatkom /Employee viewa, koji mu omogucava da vidi sve zaposlenike, te da doda novog zaposlenika ili izbriše vec postojeceg. Dodavanje zaposlenika se radi preko ugradenog ASP .net identity modela, koji je modificiran da dodatno traži ime i prezime zaposlenika te nakon dodavanja zaposlenika admin ostaje ulogiran te ga se vrati na prikaz tablice zaposlenika. 

