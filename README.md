# QuizApp
App for solving quizzes of different genres

Projekt je online aplikacija u kojoj korisnici rješavaju kvizove te se rangiraju ovisno o
osvojenim bodovima, postotku toènosti i broju riješenih kvizova.

Aplikacija zapoèinje u Home View-u gdje se nalaze kratka uputstva za korisnike.
Osim u Home, bez registracije se može otiæi jedino u Rankings dio gdje je rang lista svih
igraèa koji su registrirani.

Za registraciju je potrebno predati sve tražene podatke (e-mail, lozinku, Nickname i sliku).
Šifra mora imati malo i veliko, broj i neki interpunkcijski znak (npr. -,. itd)
Prva osoba koja je registrirana na aplikaciji automatski postaje admin (podatke admina æu
ostaviti kasnije), dok svi ostali su automatski korisnici.

Nakon registracije/login-a odmah se ulazi na Main Page gdje se nalaze:
a)svi stvoreni kvizovi kod admina
b)kvizovi dostupni za rješavanje kod korisnika
obje tablice mogu se sortirati po svakom stupcu tablice

Admin ima opciju stvoriti novi kviz i izbrisati samo one koji su istekli (opcija se
pojavljuje ako se uoèi isteknuti kviz). Kviz se stvara tako da se prvo upisuju osnovni
podaci o kvizu, a zatim unosi pitanje po pitanje u kviz. Završetak izrade kviza se postiže
oznaèavanjem polja "Last question?"

Korisnik ima opciju rješavati kviz pritiskom na gumb "solve".
Pitanja se pojavljuju nasumiènim redosljedom, kao i odgovori na pitanja, koji se biraju iz
padajuæeg izbornika. Važno je napomenuti da ukoliko korisnik izaðe iz web preglednika,
greškom otvori neki drugi link ili izgubi vezu sa internetom NE ÆE biti u moguænosti ponovo
se vratiti na kviz (u tom sluèaju æe se dotad zaraðeni bodovi na tom kvizu pribrojiti tek
kada posjeti svoj profil). Nakon cijelog riješenog kviza korisnik se odmah usmjerava na svoj 
profil gdje može vidjeti svojestatistike te saznati dodatne informacije o pojedinom kvizu 
(npr. koja je pitanja pogriješiote koji je odgovor toèan u tom sluèaju). Takoðer može 
naknadno promijeniti svoje podatke (Nickname i sliku).
Admin nema svoj profil te ne može sudjelovati u rješavanju kvizova.

Edit login info je mjesto gdje se može promijeniti lozinka i e-mail adresa koja se koristi.

Rankings prikazuje tablicu svih korisnika sortiranih prvotno prema bodovima, pa prema
postotku toènosti i konaèno uzlazno po broju riješenih kvizova. I ova tablica se može
sortirati po svakom stupcu tablice i ima fiksne redne brojeve poretka koji se ne sortiraju.
Trenutno ulogirani korisnik oznaèen je sivom bojom retka.

Aplikaciju je testiralo troje mojih prijatelja te ju najviše mogu zamisliti kao dobru
natjecateljsku aplikaciju za jednu manju grupu ljudi (do 30 osoba) ili kao prijateljsku
mini igru.

Na ovu ideju me potaknuo prijatelj kvizaš svestranog znanja, te FER-ova stranica "moodle"
na kojoj se rješavaju ispiti i zadaæe za neke predmete te koja me veæ u par navrata navela
na razmišljanje "kako li je samo naèinjena". Smatram da je aplikacija prilièno user-friendly
i da bi se mogla koristiti kao dobra zabava, ali i provjera znanja (naravno kada bi admin
redovito objavljivao kvizove).

Podaci za admina:		Podaci za korisnika:
email: tk@fer.hr		email:proba@fer.hr	TinK@fer.hr
lozinka: Tiny-555		lozinka:Proba-123	Abc.123




