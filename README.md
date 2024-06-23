
# WzimTrainingClub Projekt

## Przegląd

WzimTrainingClub to aplikacja webowa zaprojektowana w celu ułatwienia zarządzania treningami i trzymaniem diety. Aplikacja zapewnia funkcje związane z zarządzaniem użytkownikami, harmonogramowaniem wydarzeń oraz utrzymywaniem rekordów treningowych. Projekt został zbudowany przy użyciu ASP.NET Core i obejmuje kilka obszarów funkcjonalności, w tym zarządzanie tożsamością, harmonogramowanie wydarzeń i komunikację z użytkownikami.

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

Po uruchomieniu aplikacji, możesz uzyskać do niej dostęp, przechodząc do `http://localhost:5000` w przeglądarce internetowej.

### Funkcje

- **Rejestracja i logowanie użytkowników**: Użytkownicy mogą rejestrować się i logować do aplikacji.
- **Zarządzanie hasłami**: Użytkownicy mogą resetować i zmieniać swoje hasła.
- **Zarządzanie profilem**: Użytkownicy mogą aktualizować swoje informacje profilowe.
- **Harmonogramowanie wydarzeń**: Użytkownicy mogą planować i przeglądać nadchodzące wydarzenia treningowe.
- **System powiadomień**: Użytkownicy otrzymują powiadomienia o ważnych wydarzeniach i aktualizacjach.

## Technologie

- **ASP.NET Core**: Framework do budowy aplikacji webowych.
- **Entity Framework Core**: ORM do zarządzania danymi.
- **Razor Pages**: Strony do renderowania HTML z użyciem kodu C#.
- **Bootstrap**: Framework CSS do stylowania interfejsu użytkownika.
- **jQuery**: Biblioteka JavaScript do obsługi dynamicznych działań na stronie.

## Rozwój

### Dodawanie nowych funkcji

1. **Utwórz nową gałąź**:
   ```sh
   git checkout -b feature-nowa-funkcja
   ```

2. **Wprowadź swoje zmiany i zatwierdź**:
   ```sh
   git add .
   git commit -m "Dodano nową funkcję"
   ```

3. **Wypchnij zmiany na gałąź**:
   ```sh
   git push origin feature-nowa-funkcja
   ```

4. **Utwórz pull request**: Prześlij pull request do przeglądu.

### Uruchamianie testów

Aby uruchomić testy, użyj następującego polecenia:

```sh
dotnet test
```

## Współtworzenie

Współtworzenie jest mile widziane! Prosimy o zapoznanie się z plikiem [CONTRIBUTING.md](CONTRIBUTING.md) zawierającym wytyczne dotyczące współtworzenia projektu.

## Licencja

Ten projekt jest licencjonowany na warunkach licencji MIT. Zobacz plik [LICENSE](LICENSE) po więcej szczegółów.

## Kontakt

W razie jakichkolwiek pytań lub problemów, prosimy o kontakt na adres [yourname@example.com](mailto:yourname@example.com).

---

Ten README dostarcza kompleksowego przewodnika do zrozumienia, konfiguracji i współtworzenia projektu WzimTrainingClub. Postępuj zgodnie z instrukcjami, aby zapewnić płynne doświadczenie rozwojowe.
