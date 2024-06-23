
# WzimTrainingClub Projekt

## Przegląd

WzimTrainingClub to aplikacja webowa zaprojektowana w celu ułatwienia zarządzania treningami i trzymaniem diety. Aplikacja zapewnia funkcje związane z zarządzaniem użytkownikami, harmonogramowaniem wydarzeń oraz utrzymywaniem rekordów treningowych. Projekt został zbudowany przy użyciu ASP.NET Core i obejmuje kilka obszarów funkcjonalności, w tym zarządzanie tożsamością i harmonogramowanie wydarzeń.

## Struktura Katalogów

Oto krótki przegląd głównych katalogów i plików w projekcie:

- **WzimTrainingClub/Areas/Identity/Pages/Account**: Zawiera strony i logikę zarządzania kontami użytkowników (np. logowanie, rejestracja, resetowanie hasła).
- **WzimTrainingClub/Areas/Identity/Pages/Account/Manage**: Zawiera strony i logikę zarządzania ustawieniami konta użytkownika (np. zmiana hasła, aktualizacja profilu).
- **WzimTrainingClub/Controllers**: Zawiera kontrolery, które obsługują przychodzące żądania HTTP i odpowiedzi.
- **WzimTrainingClub/Data**: Zawiera kontekst danych i pliki migracji do zarządzania bazą danych.
- **WzimTrainingClub/Models**: Zawiera modele danych używane w całej aplikacji.
- **WzimTrainingClub/Views**: Zawiera pliki widoków Razor do renderowania stron HTML.
- **WzimTrainingClub/wwwroot**: Zawiera pliki statyczne, takie jak JavaScript, CSS i obrazy.

## Rozpoczęcie Pracy

### Wymagania

Upewnij się, że masz zainstalowane na swoim systemie:

- [.NET Core SDK](https://dotnet.microsoft.com/download)
- [Visual Studio](https://visualstudio.microsoft.com/) lub [Visual Studio Code](https://code.visualstudio.com/)
- [SQL Server](https://www.microsoft.com/pl-pl/sql-server/sql-server-downloads)

### Instalacja

1. **Sklonuj repozytorium**:
   ```sh
   git clone https://github.com/yourusername/WzimTrainingClub.git
   cd WzimTrainingClub
   ```

2. **Przywróć zależności**:
   ```sh
   dotnet restore
   ```

3. **Zastosuj migracje bazy danych**:
   ```sh
   dotnet ef database update
   ```

4. **Uruchom aplikację**:
   ```sh
   dotnet run
   ```

### Konfiguracja

Zaktualizuj plik `appsettings.json` swoimi specyficznymi ustawieniami konfiguracyjnymi, takimi jak ciągi połączeń do bazy danych i inne ustawienia aplikacji.

## Użytkowanie

Po uruchomieniu aplikacji, możesz uzyskać do niej dostęp, przechodząc do `http://localhost:7283` w przeglądarce internetowej.

### Użytkowanie

- **Rejestracja**: Przejdź do strony rejestracji i utwórz nowe konto.
- **Logowanie**: Zaloguj się, używając danych podanych podczas rejestracji.
- **Zmiana hasła**: Przejdź do ustawień profilu i zmień hasło.
- **Edycja profilu**: Zaktualizuj swoje dane profilowe w ustawieniach.
- **Śledzenie wagi**: Dodawaj swoje wagi w odpowiedniej sekcji i monitoruj postępy.
- **Dodawanie posiłków**: Dodaj posiłki i monitoruj spożycie kalorii.
- **Tworzenie planów treningowych**: Twórz plany treningowe i zarządzaj nimi.
- **Tworzenie i śledzenie celów**: Definiuj cele i monitoruj swoje postępy.


## Technologie

- **ASP.NET Core**: Framework do budowy aplikacji webowych.
- **Entity Framework Core**: ORM do zarządzania danymi.
- **Razor Pages**: Strony do renderowania HTML z użyciem kodu C#.
- **Bootstrap**: Framework CSS do stylowania interfejsu użytkownika.
- **jQuery**: Biblioteka JavaScript do obsługi dynamicznych działań na stronie.

## Licencja

Ten projekt jest licencjonowany na warunkach licencji MIT. Zobacz plik [LICENSE](LICENSE) po więcej szczegółów.

---
