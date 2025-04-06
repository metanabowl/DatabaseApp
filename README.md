# Sprawozdanie – Projekt aplikacji bazodanowej .NET

## Cel projektu

Celem projektu było stworzenie aplikacji konsolowej w języku C# z wykorzystaniem .NET 8.0, która umożliwia:
- Pobieranie danych pogodowych z API OpenWeatherMap na podstawie nazwy miasta.
- Wyświetlanie użytkownikowi szczegółowych informacji o pogodzie.
- Rozszerzenie aplikacji o prostą bazę danych SQLite przy użyciu Entity Framework Core.
- Zapis danych pogodowych do bazy oraz unikanie ponownego pobierania danych dla tego samego miasta, jeśli są już dostępne w bazie.
- Implementację podstawowej relacji między tabelami.
- Implementację GUI przy wykorzystaniu technologii MAUI.

## Użyte technologie

- Język programowania: C#
- Platforma: .NET 8.0
- Biblioteka ORM: Entity Framework Core
- Baza danych: SQLite
- API: OpenWeatherMap (REST API)

## Aktualne funkcjonalności aplikacji

- Użytkownik wpisuje nazwę miasta.
- Program pobiera współrzędne geograficzne miasta z API OpenWeatherMap (endpoint Geo).
- Następnie na podstawie współrzędnych pobierane są szczegółowe dane pogodowe (endpoint Weather).
- Dane są prezentowane w czytelnej formie w konsoli.

## Struktura projektu

- `WeatherData`, `MainData`, `WindData`, itd. – klasy do deserializacji danych z API.
- `APITest` – główna klasa odpowiedzialna za logikę pobierania i obsługi danych pogodowych.

## Problemy i ograniczenia

W obecnej wersji projektu **nie udało się w pełni zaimplementować bazy danych w działający sposób**.


## Wnioski i dalszy rozwój

- W celu dokończenia projektu należy zaimplementować prostą bazę danych, oraz interfejs GUI.

## Autor

Imię i nazwisko: Kacper Karkosz  
Grupa: [.NET][CZ 15:15][CZ 17:05]  
