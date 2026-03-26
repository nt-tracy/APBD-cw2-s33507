Instrukcja uruchomienia:
- należy upewnić się, że jest zainstalowane .NET SDK 8 (lub nowsze)
- należy sklonować repozytorium zdalne na dysk (git clone <adres>)
- trzeba przejść do folderu projektu, w którym znajduje się plik .csproj i uruchomić komendą - dotnet run

Decyzje projektowe:
W projekcie postawiłam na wysoką kohezją i niski coupling dzieląc odpowiednio całą strukturę projektu na foldery:
- Enums - typy wyliczeniowe umożliwiające jednoznaczne nazewnictwo w systemie
- Exceptions - wyjątki wbudowane, znane informacje, jakie system zwraca w każdym wypadku i jasne nagłówki
- Models - proste klasy danych, nie zawierają logiki biznesowej i innych funkcjonalności
- Services - odpowiadają za logikę biznesową

- wysoka kohezja - podział logiki na dedykowane serwisy
- niski coupling - klasy serwisowe implementują interfejsy

Wprowadziłam też klasy abstrakcyjne - wynika to z modelu domeny, mogą w przyszłości być dodawane inne typy użytkowników i typy sprzętów. 
System jest otwarty na rozszerzenia i aktualizacje. Takie podziały ułatwiają również poruszanie się po projekcie.
