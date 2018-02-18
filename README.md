# QuizApp
App for solving quizzes of different genres

Projekt je online aplikacija u kojoj korisnici rje�avaju kvizove te se rangiraju ovisno o
osvojenim bodovima, postotku to�nosti i broju rije�enih kvizova.

Aplikacija zapo�inje u Home View-u gdje se nalaze kratka uputstva za korisnike.
Osim u Home, bez registracije se mo�e oti�i jedino u Rankings dio gdje je rang lista svih
igra�a koji su registrirani.

Za registraciju je potrebno predati sve tra�ene podatke (e-mail, lozinku, Nickname i sliku).
�ifra mora imati malo i veliko, broj i neki interpunkcijski znak (npr. -,. itd)
Prva osoba koja je registrirana na aplikaciji automatski postaje admin (podatke admina �u
ostaviti kasnije), dok svi ostali su automatski korisnici.

Nakon registracije/login-a odmah se ulazi na Main Page gdje se nalaze:
a)svi stvoreni kvizovi kod admina
b)kvizovi dostupni za rje�avanje kod korisnika
obje tablice mogu se sortirati po svakom stupcu tablice

Admin ima opciju stvoriti novi kviz i izbrisati samo one koji su istekli (opcija se
pojavljuje ako se uo�i isteknuti kviz). Kviz se stvara tako da se prvo upisuju osnovni
podaci o kvizu, a zatim unosi pitanje po pitanje u kviz. Zavr�etak izrade kviza se posti�e
ozna�avanjem polja "Last question?"

Korisnik ima opciju rje�avati kviz pritiskom na gumb "solve".
Pitanja se pojavljuju nasumi�nim redosljedom, kao i odgovori na pitanja, koji se biraju iz
padaju�eg izbornika. Va�no je napomenuti da ukoliko korisnik iza�e iz web preglednika,
gre�kom otvori neki drugi link ili izgubi vezu sa internetom NE �E biti u mogu�nosti ponovo
se vratiti na kviz (u tom slu�aju �e se dotad zara�eni bodovi na tom kvizu pribrojiti tek
kada posjeti svoj profil). Nakon cijelog rije�enog kviza korisnik se odmah usmjerava na svoj 
profil gdje mo�e vidjeti svojestatistike te saznati dodatne informacije o pojedinom kvizu 
(npr. koja je pitanja pogrije�iote koji je odgovor to�an u tom slu�aju). Tako�er mo�e 
naknadno promijeniti svoje podatke (Nickname i sliku).
Admin nema svoj profil te ne mo�e sudjelovati u rje�avanju kvizova.

Edit login info je mjesto gdje se mo�e promijeniti lozinka i e-mail adresa koja se koristi.

Rankings prikazuje tablicu svih korisnika sortiranih prvotno prema bodovima, pa prema
postotku to�nosti i kona�no uzlazno po broju rije�enih kvizova. I ova tablica se mo�e
sortirati po svakom stupcu tablice i ima fiksne redne brojeve poretka koji se ne sortiraju.
Trenutno ulogirani korisnik ozna�en je sivom bojom retka.

Aplikaciju je testiralo troje mojih prijatelja te ju najvi�e mogu zamisliti kao dobru
natjecateljsku aplikaciju za jednu manju grupu ljudi (do 30 osoba) ili kao prijateljsku
mini igru.

Na ovu ideju me potaknuo prijatelj kviza� svestranog znanja, te FER-ova stranica "moodle"
na kojoj se rje�avaju ispiti i zada�e za neke predmete te koja me ve� u par navrata navela
na razmi�ljanje "kako li je samo na�injena". Smatram da je aplikacija prili�no user-friendly
i da bi se mogla koristiti kao dobra zabava, ali i provjera znanja (naravno kada bi admin
redovito objavljivao kvizove).

Podaci za admina:		Podaci za korisnika:
email: tk@fer.hr		email:proba@fer.hr	TinK@fer.hr
lozinka: Tiny-555		lozinka:Proba-123	Abc.123




