# Rentanama

1.1.	Sistemos paskirtis
Projekto tikslas – palengvinti asmenims, susirasti greičiau nuomojamą sodybą ar būstą tam tikram laikotarpiui, priklausomai ar trumpam ar ilgam terminui.
Kiekvienas prisiregistravęs vartotojas galės pats įkelti, peržiūrėti kitus skelbimus, susijusius ar asmuo nori išsinuomoti sodybą arba butą konkrečiam laikotarpiui. Visiems vartotojams (svečiams, prisijungusiems, administratoriui) bus parodytas reprezentacinis puslapis. Prisijungęs vartotojas gali pats sukurti skelbimą apie išnuomojamą būstą (sodybą). Esant reikalui, vartotojas gali koreguoti nuomos kainą ar jame esamą informaciją. Taip pat vartotojas, gali peržiūrėti kitų nuomos skelbimų sąrašą.
Administratorius gali redaguoti nuomos, šalinti nuomos skelbimus.
1.2.	Funkciniai reikalavimai
Neregistruotas sistemos naudotojas galės:

1.	Peržiūrėti platformos pradinį puslapį;
2.	Užsiregistruoti/prisijungti prie sistemos.
3.	Peržiūrėti DUK (Dažniausiai užduodamų klausimų) skiltį.

Registruotas sistemos naudotojas galės:
1.	Prisijungti prie sistemos.
2.	Atsijungti nuo internetinės platformos.
3.	Sukurti skelbimą.
4.	Koreguoti skelbimo informaciją.
5.	Peržiūrėti skelbimų sąrašą.

Administratorius gali:
1.	Redaguoti skelbimą (jei nepažeidžia teisių).
2.	Šalinti skelbimą.


1.3.	API Specifikacija:

API pasiekiama adresu -  http://localhost:5154/

API metodas	Register (POST)
Paskirtis	Registracija
Kelias iki metodo (angl. route)	/api/register
Užklausos struktūra	{
  "userName": "Kebus",
  "email": "Kebas@gmail.com",
  "password": "Kebas1!“
}
Užklausos „Header“ dalis	-
Atsakymo kodas	201 (Created)
{
  "id": "b595d41b-e4c7-4366-839a-e267d1d1629b",
  "userName": "Kebus",
  "email": "Kebas@gmail.com"
}
Galimi klaidų kodai	400 (Invalid Request) – trūksta validacijos

Login
API metodas	Login (POST)
Paskirtis	Prisijungimas
Kelias iki metodo (angl. route)	/api/Login
Užklausos struktūra	{
  "userName": "Kerpimas",
  "password": "Testas1!"
}
Užklausos „Header“ dalis	-
Atsakymo kodas	200 (Success)
{
  "accessToken": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.
eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50a
XR5L2NsYWltcy9uYW1lIjoiS2VycGltYXMiLCJqdGkiOiJiNjZlYzAwOS0wMzA1LT
RmN2YtYmVmOS0yN2JiNGU2ZTY3MDUiLCJzdWIiOiI3NWMxOWY5ZS00
N2NiLTQ2MTktYjJiMy0xZjVmZGEwYTFkNWQiLCJodHRwOi8vc2NoZW
1hcy5taWNyb3NvZnQuY29tL3dzLzIwM
DgvMDYvaWRlbnRpdHkvY2xhaW
1zL3JvbGUiOiJTeXN0ZW1Vc2VyIiwiZXhw
IjoxNzA0Mzg2NjgzLCJpc3MiOiJKaW1teSIsImF1ZCI6IlR
ydXN0ZWRDbGllbnQifQ.PStbRqt_88gExP7y4oQqzus_DTNiycG5s2
ep55Unt0A"
}

Galimi klaidų kodai	400 (Invalid Request)

 

Skelbimų esybė
API metodas	Advertisements (GET)
Paskirtis	Gauti visus skelbimus
Kelias iki metodo (angl. route)	/api/advertisements
Užklausos struktūra	-
Užklausos „Header“ dalis	-
Reikalingas autentifikacija	Ne
Atsakymo struktūra	[
  {
    "id": 19,
    "name": "testikng",
    "creationDate": "2024-01-01T20:06:01.302906Z",
    "description": "new values"
  },
  {
    "id": 18,
    "name": "test",
    "creationDate": "2024-01-01T19:57:00.470666Z",
    "description": "tesrt"
  },
  {
    "id": 20,
    "name": "Butas",
    "creationDate": "2024-01-04T14:59:08.426564Z",
    "description": "Kaunas 25"
  }
]
Atsakymo kodas	200 (OK)
Galimi klaidų kodai	-


API metodas	Advertisements by ID (GET)
Paskirtis	Gauti vieną skelbimą, pagal id
Kelias iki metodo (angl. route)	/api/advertisements/{advertisementId}
Užklausos struktūra	-
Užklausos „Header“ dalis	-
Reikalingas autentifikacija	Ne
Atsakymo struktūra	{
    "id": 19,
    "name": "testikng",
    "creationDate": "2024-01-01T20:06:01.302906Z",
    "description": "new values"
  }
Atsakymo kodas	200 (OK)
Galimi klaidų kodai	404 (Not Found)


API metodas	Advertisements by ID (PUT)
Paskirtis	Koreguoti skelbimą, pagal id
Kelias iki metodo (angl. route)	/api/advertisements/{advertisementId}
Užklausos struktūra	{
  "name": "Butas Vilniuje",
  "description": "Vilniaus Centre būstas"
}
Užklausos „Header“ dalis	-
Reikalinga autentifikacija	Taip
Atsakymo struktūra	{
  "name": "Butas Vilniuje",
  "description": "Vilniaus Centre būstas"
}
Atsakymo kodas	200 (OK)
Galimi klaidų kodai	404 (Not Found)
401 (Unauthorized)


API metodas	Advertisements (POST)
Paskirtis	Sukurti skelbimą
Kelias iki metodo (angl. route)	/api/advertisements
Užklausos struktūra	{
  "name": "string",
  "description": "string"
}
Užklausos „Header“ dalis	-
Reikalinga autentifikacija	Taip
Atsakymo struktūra	{
  "id": 21,
  "name": "Testas",
  "creationDate": "2024-01-04T16:18:46.610624Z",
  "description": "Naujas"
}
Atsakymo kodas	200 (OK)
Galimi klaidų kodai	404 (Not Found)
401 (Unauthorized)

API metodas	Advertisements (DELETE)
Paskirtis	Ištrinti skelbimą pagal id.
Kelias iki metodo (angl. route)	/api/advertisements/{advertisementId}
Užklausos struktūra	
Užklausos „Header“ dalis	-
Reikalinga autentifikacija	Taip
Atsakymo struktūra	{
    "name": "Testas",
    "description": "Naujas"
  }
Atsakymo kodas	204 (No Content)
Galimi klaidų kodai	404 (Not Found)
403 (Forbid)
401 (Unauthorized)
 
	
Butų esybė:
API metodas	Apartment (POST)
Paskirtis	Gauti visus butus
Kelias iki metodo (angl. route)	/api/advertisements/{advertisementId}/apartments
Reikia ID?	Egzistuojantis {advertisementId}
Užklausos struktūra	{
  "squareMeters": 50,
  "cost": 300,
  "floor": 2
}
Užklausos „Header“ dalis	-
Reikalinga autentifikacija	Taip
Atsakymo struktūra	{
  "id": 7,
  "sqaureMeters": 50,
  "cost": 300,
  "creationTime": "0001-01-01T00:00:00",
  "floor": 2
}
Atsakymo kodas	201 (Created)
Galimi klaidų kodai	404 (Not Found)


API metodas	Apartment (Get)
Paskirtis	Gauti visus butus
Kelias iki metodo (angl. route)	/api/advertisements/{advertisementId}/apartments
Reikia ID?	Egzistuojantis {advertisementId}
Užklausos struktūra	{
  "squareMeters": 50,
  "cost": 300,
  "floor": 2
}
Užklausos „Header“ dalis	-
Reikalinga autentifikacija	Ne
Atsakymo struktūra	{
  "id": 7,
  "sqaureMeters": 50,
  "cost": 300,
  "creationTime": "0001-01-01T00:00:00",
  "floor": 2
}
Atsakymo kodas	201 (Created)
Galimi klaidų kodai	404 (Not Found)









API metodas	Apartment (Get)
Paskirtis	Gauti butą pagal id
Kelias iki metodo (angl. route)	/api/advertisements/{advertisementId}/apartments/{apartmentId}
Reikia ID?	Egzistuojantis {advertisementId}, apartmentId
Užklausos struktūra	{
  "squareMeters": 50,
  "cost": 300,
  "floor": 2
}
Užklausos „Header“ dalis	-
Reikalinga autentifikacija	Ne
Atsakymo struktūra	{
  "id": 7,
  "sqaureMeters": 50,
  "cost": 300,
  "creationTime": "0001-01-01T00:00:00",
  "floor": 2
}
Atsakymo kodas	201 (Created)
Galimi klaidų kodai	404 (Not Found)



API metodas	Apartment (PUT)
Paskirtis	Gauti butą pagal id
Kelias iki metodo (angl. route)	/api/advertisements/{advertisementId}/apartments/{apartmentId}
Reikia ID?	Egzistuojantis {advertisementId}, apartmentId
Užklausos struktūra	{
  "squareMeters": 55,
  "cost": 2500,
  "floor": 1
}
Užklausos „Header“ dalis	-
Reikalinga autentifikacija	Taip
Atsakymo struktūra	{
"id": 8,
  "sqaureMeters": 55,
  "cost": 2500,
  "creationTime": "0001-01-01T00:00:00",
  "floor": 1
}
Atsakymo kodas	200 (OK)
Galimi klaidų kodai	404 (Not Found)
401 (Unauthorized)

API metodas	Apartment (Delete)
Paskirtis	Gauti butą pagal id
Kelias iki metodo (angl. route)	/api/advertisements/{advertisementId}/apartments/{apartmentId}
Reikia ID?	Egzistuojantis {advertisementId}, apartmentId
Užklausos struktūra	-
Užklausos „Header“ dalis	-
Reikalinga autentifikacija	Taip
Atsakymo struktūra	{
"id": 8,
  "sqaureMeters": 55,
  "cost": 2500,
  "creationTime": "0001-01-01T00:00:00",
  "floor": 1
}
Atsakymo kodas	204 (No content)
Galimi klaidų kodai	404 (Not Found)
401 (Unauthorized)
403 (Forbid)

Miestų esybė:
API metodas	Cities (POST)
Paskirtis	Sukurti miesto duomenis
Kelias iki metodo (angl. route)	/api/advertisements/{advertisementId}/apartments/{apartmentId}/cities
Reikia ID?	Egzistuojantis {advertisementId}, {apartmentId}
Užklausos struktūra	{
  "cityName": "Kaunas",
  "streetAddress": "Daugiakampių al. 5",
  "region": "Gričiupis"
}
Užklausos „Header“ dalis	-
Reikalinga autentifikacija	Ne
Atsakymo struktūra	{
  "id": 3,
  "cityName": "Kaunas",
  "streetAddress": "Daugiakampių al. 5",
  "region": "Gričiupis"
}
Atsakymo kodas	201 (Created)
Galimi klaidų kodai	404 (Not Found)


API metodas	Cities (Get)
Paskirtis	Gauti visus duomenis
Kelias iki metodo (angl. route)	/api/advertisements/{advertisementId}/apartments/{apartmentId}/cities
Reikia ID?	Egzistuojantis {advertisementId}, {apartmentId}(21, 8)
Užklausos struktūra	{
  "cityName": "Kaunas",
  "streetAddress": "Daugiakampių al. 5",
  "region": "Gričiupis"
}
Užklausos „Header“ dalis	-
Reikalinga autentifikacija	Ne
Atsakymo struktūra	[
  {
    "id": 3,
    "cityName": "Kaunas",
    "streetAddress": "Daugiakampių al. 5",
    "region": "Gričiupis"
  },
  {
    "id": 4,
    "cityName": "Vilnius",
    "streetAddress": "Daugiakampių al. 7",
    "region": "Kalnapilio"
  }
]
Atsakymo kodas	201 (Created)
Galimi klaidų kodai	404 (Not Found)


API metodas	Cities (GET)
Paskirtis	Surasti miesto esybės duomenį pagal ID
Kelias iki metodo (angl. route)	/api/advertisements/{advertisementId}/apartments/{apartmentId}/cities/{cityId}
Reikia ID?	Egzistuojantis {advertisementId}, {apartmentId}, {cityId}(21, 8, 3)
Užklausos struktūra	{
  "cityName": "Kaunas",
  "streetAddress": "Vilkyškių pr. 65",
  "region": "Dainava"
}
Užklausos „Header“ dalis	-
Reikalinga autentifikacija	Ne
Atsakymo struktūra	{
  "id": 3,
  "cityName": "Kaunas",
  "streetAddress": "Vilkyškių pr. 65",
  "region": "Dainava"
}
Atsakymo kodas	201 (Created)
Galimi klaidų kodai	404 (Not Found)



API metodas	Cities (PUT)
Paskirtis	Pakeisti miesto esybės duomenį pagal ID
Kelias iki metodo (angl. route)	/api/advertisements/{advertisementId}/apartments/{apartmentId}/cities/{cityId}
Reikia ID?	Egzistuojantis {advertisementId}, {apartmentId}, {cityId}(21, 8, 3)
Užklausos struktūra	{
  "cityName": "Kaunas",
  "streetAddress": "Vilkyškių pr. 65",
  "region": "Dainava"
}
Užklausos „Header“ dalis	-
Reikalinga autentifikacija	Taip
Atsakymo struktūra	{
  "id": 3,
  "cityName": "Kaunas",
  "streetAddress": "Vilkyškių pr. 65",
  "region": "Dainava"
}
Atsakymo kodas	201 (Created)
Galimi klaidų kodai	404 (Not Found)
401 (Unauthorized)

API metodas	Cities (DELETE)
Paskirtis	Ištrinti miesto esybės duomenį pagal ID
Kelias iki metodo (angl. route)	/api/advertisements/{advertisementId}/apartments/{apartmentId}/cities/{cityId}
Reikia ID?	Egzistuojantis {advertisementId}, {apartmentId}, {cityId}(21, 8, 3)
Užklausos struktūra	{
  "cityName": "Kaunas",
  "streetAddress": "Vilkyškių pr. 65",
  "region": "Dainava"
}
Užklausos „Header“ dalis	-
Reikalinga autentifikacija	Taip (Administratoriaus)
Atsakymo struktūra	{
  "id": 3,
  "cityName": "Kaunas",
  "streetAddress": "Vilkyškių pr. 65",
  "region": "Dainava"
}
Atsakymo kodas	204 (No content)
Galimi klaidų kodai	404 (Not Found)
401 (Unauthorized)


2.	Sistemos architektūra
Sistemos sudedamosios dalys:

•	Kliento pusė (ang. Front-End) – naudojant React.js, su MaterialUI;
•	Serverio pusė (angl. Back-End) – ASP.NET Core, duomenų bazė – PostgreSQL.





