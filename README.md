# SUper GrA
sorki ale nie chce mi się tego pisać 

# 🎮 SUper GrA

SUper GrA to konsolowa gra typu **"Zgadnij Liczbę"** napisana w języku C#.
Projekt został wykonany w podejściu obiektowym i zawiera między innymi:

* system języków (PL / EN / ES),
* Hall of Fame zapisywany do pliku JSON,
* ustawienia gry,
* tryby trudności,
* własne klasy i obiekty,
* zapis danych do plików,
* elementy OOP.

---

# 📌 Opis gry

Celem gry jest odgadnięcie wylosowanej liczby w jak najmniejszej liczbie prób.

Gracz może wybrać różne poziomy trudności lub stworzyć własny zakres liczb.
Podczas gry program informuje użytkownika, czy podana liczba jest:

* za mała,
* za duża,
* lub poprawna.

Po wygranej wynik może zostać zapisany do Hall of Fame.

---

# ⚙️ Funkcje projektu

## 🎲 Tryby gry

Gra zawiera kilka poziomów trudności:

* Łatwy
* Średni
* Trudny
* Custom

Tryb Custom pozwala użytkownikowi ustawić własny zakres liczb.

---

## 🌍 Obsługa wielu języków

Projekt obsługuje:

* język polski,
* język angielski,
* język hiszpański.

Tłumaczenia przechowywane są w plikach JSON:

```text
JPolski.json
JAngielski.json
JHiszpański.json
```

Program wczytuje je za pomocą `System.Text.Json`.

---

## 🏆 Hall of Fame

Najlepsze wyniki zapisywane są do pliku JSON.

Dzięki temu wyniki pozostają zapisane nawet po zamknięciu programu.

---

## ⚙️ Ustawienia

W ustawieniach użytkownik może:

* zmienić język gry,
* wyczyścić Hall of Fame,
* zmienić wybrane opcje gry.

---

# 🧠 Elementy programowania obiektowego

Projekt wykorzystuje podstawowe filary OOP:

## 🔒 Enkapsulacja

Dane przechowywane są w klasach i obsługiwane za pomocą metod.

---

## 🧬 Dziedziczenie

Wybrane klasy rozszerzają funkcjonalność innych klas.

---

## 🎭 Polimorfizm

Program wykorzystuje różne zachowania metod zależnie od typu obiektu.

---

## 📦 Abstrakcja

Kod został podzielony na klasy odpowiedzialne za konkretne zadania.

---

# 🗂️ Struktura projektu

```text
SUper GrA/
│
├── Program.cs
├── Funkcje.cs
├── SuperOgGraPlus.cs
├── ZwyklaGraFun.cs
├── Jexyczek.cs
├── Wynik.cs
├── Gracze.cs
├── HalaFejmu.cs
│
├── JPolski.json
├── JAngielski.json
├── JHiszpański.json
│
├── Gracze.json
├── HalaFejmu.json
└── NazwaGracza.json
```

---

# 💾 Technologie

Projekt został wykonany przy użyciu:

* C#
* .NET Framework 4.7.2
* System.Text.Json
* Visual Studio

---

# ▶️ Jak uruchomić projekt

## 1. Pobierz projekt

Pobierz repozytorium lub pliki projektu.

---

## 2. Otwórz projekt

Uruchom plik:

```text
SUper GrA.sln
```

w programie Visual Studio.

---

## 3. Uruchom program

Kliknij:

```text
Start
```

lub użyj skrótu:

```text
CTRL + F5
```

---

# 📝 Autor

Projekt wykonany przez:

**Franciszek Budnik**

---

# 🚀 Możliwe rozwinięcia projektu

W przyszłości projekt może zostać rozbudowany o:

* tryb multiplayer,
* GUI zamiast konsoli,
* więcej języków,
* zapis ustawień użytkownika,
* statystyki,
* tryb online.

---

# 📜 Licencja

Projekt edukacyjny wykonany na potrzeby zaliczenia i nauki programowania obiektowego w języku C#.
