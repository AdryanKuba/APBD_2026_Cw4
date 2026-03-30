using LinqConsoleLab.PL.Data;
using LinqConsoleLab.PL.Models;
using System.Linq;
namespace LinqConsoleLab.PL.Exercises;

public sealed class ZadaniaLinq
{
    /// <summary>
    /// Zadanie:
    /// Wyszukaj wszystkich studentów mieszkających w Warsaw.
    /// Zwróć numer indeksu, pełne imię i nazwisko oraz miasto.
    ///
    /// SQL:
    /// SELECT NumerIndeksu, Imie, Nazwisko, Miasto
    /// FROM Studenci
    /// WHERE Miasto = 'Warsaw';
    /// </summary>
    public IEnumerable<string> Zadanie01_StudenciZWarszawy()
    {
        //query syntax
        var query = from s in DaneUczelni.Studenci 
            where s.Miasto.Equals("Warsaw")
            select $" {s.NumerIndeksu}, {s.Imie}, {s.Nazwisko}, {s.Miasto}";
            // return query;

            //methodSyntax
        var method = DaneUczelni.Studenci.Where(s => s.Miasto.Equals("Warsaw")).Select(s => $"{s.NumerIndeksu}, {s.Imie}, {s.Nazwisko}, {s.Miasto}");
         return method;

        throw Niezaimplementowano(nameof(Zadanie01_StudenciZWarszawy));
    }

    /// <summary>
    /// Zadanie:
    /// Przygotuj listę adresów e-mail wszystkich studentów.
    /// Użyj projekcji, tak aby w wyniku nie zwracać całych obiektów.
    ///
    /// SQL:
    /// SELECT Email
    /// FROM Studenci;
    /// </summary>
    public IEnumerable<string> Zadanie02_AdresyEmailStudentow()
    {
        var method = DaneUczelni.Studenci.Select(s => $"{s.Email}");
        return method;
        throw Niezaimplementowano(nameof(Zadanie02_AdresyEmailStudentow));
    }

    /// <summary>
    /// Zadanie:
    /// Posortuj studentów alfabetycznie po nazwisku, a następnie po imieniu.
    /// Zwróć numer indeksu i pełne imię i nazwisko.
    ///
    /// SQL:
    /// SELECT NumerIndeksu, Imie, Nazwisko
    /// FROM Studenci
    /// ORDER BY Nazwisko, Imie;
    /// </summary>
    public IEnumerable<string> Zadanie03_StudenciPosortowani()
    {
        var method = DaneUczelni.Studenci.OrderBy(s => s.Nazwisko).ThenBy(s => s.Imie).Select(s => $"{s.NumerIndeksu}, {s.Imie}, {s.Nazwisko}");
        return method;
        throw Niezaimplementowano(nameof(Zadanie03_StudenciPosortowani));
    }

    /// <summary>
    /// Zadanie:
    /// Znajdź pierwszy przedmiot z kategorii Analytics.
    /// Jeżeli taki przedmiot nie istnieje, zwróć komunikat tekstowy.
    ///
    /// SQL:
    /// SELECT TOP 1 Nazwa, DataStartu
    /// FROM Przedmioty
    /// WHERE Kategoria = 'Analytics';
    /// </summary>
    public IEnumerable<string> Zadanie04_PierwszyPrzedmiotAnalityczny()
    {
        var method = DaneUczelni.Przedmioty.Where(p => p.Kategoria.Equals("Analytics")).
        Select(p=> $"{p.Nazwa}, {p.DataStartu}").
        DefaultIfEmpty("Taki przedmiot nie istnieje").
        Take(1);
        return method;
        throw Niezaimplementowano(nameof(Zadanie04_PierwszyPrzedmiotAnalityczny));
    }

    /// <summary>
    /// Zadanie:
    /// Sprawdź, czy w danych istnieje przynajmniej jeden nieaktywny zapis.
    /// Zwróć jedno zdanie z odpowiedzią True/False albo Tak/Nie.
    ///
    /// SQL:
    /// SELECT CASE WHEN EXISTS (
    ///     SELECT 1
    ///     FROM Zapisy
    ///     WHERE CzyAktywny = 0
    /// ) THEN 1 ELSE 0 END;
    /// </summary>
    public IEnumerable<string> Zadanie05_CzyIstniejeNieaktywneZapisanie()
    {
        var method = DaneUczelni.Zapisy.Where(z => z.CzyAktywny).Count() > 0;
        return [$"{method}"];
        throw Niezaimplementowano(nameof(Zadanie05_CzyIstniejeNieaktywneZapisanie));
    }

    /// <summary>
    /// Zadanie:
    /// Sprawdź, czy każdy prowadzący ma uzupełnioną nazwę katedry.
    /// Warto użyć metody, która weryfikuje warunek dla całej kolekcji.
    ///
    /// SQL:
    /// SELECT CASE WHEN COUNT(*) = COUNT(Katedra)
    /// THEN 1 ELSE 0 END
    /// FROM Prowadzacy;
    /// </summary>
    public IEnumerable<string> Zadanie06_CzyWszyscyProwadzacyMajaKatedre()
    {
        var method = DaneUczelni.Prowadzacy.All(p => p.Katedra != null);
        return [$"{method}"];
        throw Niezaimplementowano(nameof(Zadanie06_CzyWszyscyProwadzacyMajaKatedre));
    }

    /// <summary>
    /// Zadanie:
    /// Policz, ile aktywnych zapisów znajduje się w systemie.
    ///
    /// SQL:
    /// SELECT COUNT(*)
    /// FROM Zapisy
    /// WHERE CzyAktywny = 1;
    /// </summary>
    public IEnumerable<string> Zadanie07_LiczbaAktywnychZapisow()
    {
        var method = DaneUczelni.Zapisy.Count(z => z.CzyAktywny);
        return [$"{method}"];
        throw Niezaimplementowano(nameof(Zadanie07_LiczbaAktywnychZapisow));
    }

    /// <summary>
    /// Zadanie:
    /// Pobierz listę unikalnych miast studentów i posortuj ją rosnąco.
    ///
    /// SQL:
    /// SELECT DISTINCT Miasto
    /// FROM Studenci
    /// ORDER BY Miasto;
    /// </summary>
    public IEnumerable<string> Zadanie08_UnikalneMiastaStudentow()
    {
        var method = DaneUczelni.Studenci.Select(s => s.Miasto).OrderBy(m => m).Distinct();
        return method;
        throw Niezaimplementowano(nameof(Zadanie08_UnikalneMiastaStudentow));
    }

    /// <summary>
    /// Zadanie:
    /// Zwróć trzy najnowsze zapisy na przedmioty.
    /// W wyniku pokaż datę zapisu, identyfikator studenta i identyfikator przedmiotu.
    ///
    /// SQL:
    /// SELECT TOP 3 DataZapisu, StudentId, PrzedmiotId
    /// FROM Zapisy
    /// ORDER BY DataZapisu DESC;
    /// </summary>
    public IEnumerable<string> Zadanie09_TrzyNajnowszeZapisy()
    {
        var method = DaneUczelni.Zapisy.OrderByDescending(z => z.DataZapisu).Select(z => $"{z.DataZapisu}, {z.StudentId}, {z.PrzedmiotId}").Take(3);
        return method;
        throw Niezaimplementowano(nameof(Zadanie09_TrzyNajnowszeZapisy));
    }

    /// <summary>
    /// Zadanie:
    /// Zaimplementuj prostą paginację dla listy przedmiotów.
    /// Załóż stronę o rozmiarze 2 i zwróć drugą stronę danych.
    ///
    /// SQL:
    /// SELECT Nazwa, Kategoria
    /// FROM Przedmioty
    /// ORDER BY Nazwa
    /// OFFSET 2 ROWS FETCH NEXT 2 ROWS ONLY;
    /// </summary>
    public IEnumerable<string> Zadanie10_DrugaStronaPrzedmiotow()
    {
        var method = DaneUczelni.Przedmioty.OrderBy(p => p.Nazwa).Select(p => $"{p.Nazwa}, {p.Kategoria}").Skip(2).Take(2);
        return method;
        throw Niezaimplementowano(nameof(Zadanie10_DrugaStronaPrzedmiotow));
    }

    /// <summary>
    /// Zadanie:
    /// Połącz studentów z zapisami po StudentId.
    /// Zwróć pełne imię i nazwisko studenta oraz datę zapisu.
    ///
    /// SQL:
    /// SELECT s.Imie, s.Nazwisko, z.DataZapisu
    /// FROM Studenci s
    /// JOIN Zapisy z ON s.Id = z.StudentId;
    /// </summary>
    public IEnumerable<string> Zadanie11_PolaczStudentowIZapisy()
    {
        var method = DaneUczelni.Studenci.Join(DaneUczelni.Zapisy, s => s.Id, z => z.StudentId, (s, z) => $"{s.Imie} {s.Nazwisko} {z.DataZapisu}");
        return method;
        throw Niezaimplementowano(nameof(Zadanie11_PolaczStudentowIZapisy));
    }

    /// <summary>
    /// Zadanie:
    /// Przygotuj wszystkie pary student-przedmiot na podstawie zapisów.
    /// Użyj podejścia, które pozwoli spłaszczyć dane do jednej sekwencji wyników.
    ///
    /// SQL:
    /// SELECT s.Imie, s.Nazwisko, p.Nazwa
    /// FROM Zapisy z
    /// JOIN Studenci s ON s.Id = z.StudentId
    /// JOIN Przedmioty p ON p.Id = z.PrzedmiotId;
    /// </summary>
    public IEnumerable<string> Zadanie12_ParyStudentPrzedmiot()
    {
        var method = DaneUczelni.Zapisy.Join(DaneUczelni.Studenci, z => z.StudentId, s => s.Id, (z, s) => new {z, s}).Join(DaneUczelni.Przedmioty, 
             zs =>  zs.z.PrzedmiotId, p => p.Id, (zs, p) => new
             {
                 imie = zs.s.Imie,
                 nazwisko = zs.s.Nazwisko,
                 przedmiot = p.Nazwa
             }).Select(x => $"{x.imie} {x.nazwisko} - {x.przedmiot}");
             return method;
        throw Niezaimplementowano(nameof(Zadanie12_ParyStudentPrzedmiot));

    }

    /// <summary>
    /// Zadanie:
    /// Pogrupuj zapisy według przedmiotu i zwróć nazwę przedmiotu oraz liczbę zapisów.
    ///
    /// SQL:
    /// SELECT p.Nazwa, COUNT(*)
    /// FROM Zapisy z
    /// JOIN Przedmioty p ON p.Id = z.PrzedmiotId
    /// GROUP BY p.Nazwa;
    /// </summary>
    public IEnumerable<string> Zadanie13_GrupowanieZapisowWedlugPrzedmiotu()
    {
        var method = DaneUczelni.Zapisy.GroupBy(z => z.PrzedmiotId).Join(DaneUczelni.Przedmioty, g => g.Key, p => p.Id, (g, p) => $"{p.Nazwa} - {g.Count()}");
        return method;
        throw Niezaimplementowano(nameof(Zadanie13_GrupowanieZapisowWedlugPrzedmiotu));
    }

    /// <summary>
    /// Zadanie:
    /// Oblicz średnią ocenę końcową dla każdego przedmiotu.
    /// Pomiń rekordy, w których ocena końcowa ma wartość null.
    ///
    /// SQL:
    /// SELECT p.Nazwa, AVG(z.OcenaKoncowa)
    /// FROM Zapisy z
    /// JOIN Przedmioty p ON p.Id = z.PrzedmiotId
    /// WHERE z.OcenaKoncowa IS NOT NULL
    /// GROUP BY p.Nazwa;
    /// </summary>
    public IEnumerable<string> Zadanie14_SredniaOcenaNaPrzedmiot()
    {
        var method = DaneUczelni.Zapisy.Join(DaneUczelni.Przedmioty, z => z.PrzedmiotId, p => p.Id, (z, p) => new
        {
            ocena = z.OcenaKoncowa,
            przedmiot = p.Nazwa
        }).Where(x => x.ocena is not null).GroupBy(x => x.przedmiot).Select(x => $"{x.Key} średnia - {x.Average(x => x.ocena)}");
        return method;
        throw Niezaimplementowano(nameof(Zadanie14_SredniaOcenaNaPrzedmiot));
    }

    /// <summary>
    /// Zadanie:
    /// Dla każdego prowadzącego policz liczbę przypisanych przedmiotów.
    /// W wyniku zwróć pełne imię i nazwisko oraz liczbę przedmiotów.
    ///
    /// SQL:
    /// SELECT pr.Imie, pr.Nazwisko, COUNT(p.Id)
    /// FROM Prowadzacy pr
    /// LEFT JOIN Przedmioty p ON p.ProwadzacyId = pr.Id
    /// GROUP BY pr.Imie, pr.Nazwisko;
    /// </summary>
    public IEnumerable<string> Zadanie15_ProwadzacyILiczbaPrzedmiotow()
    {
        var method = DaneUczelni.Prowadzacy.LeftJoin(DaneUczelni.Przedmioty, prowadzacy => prowadzacy.Id, przedmiot => przedmiot.ProwadzacyId, (prowadzacy, przedmiot) => new {
        id = prowadzacy.Id,
        imie = prowadzacy.Imie,
        nazwisko = prowadzacy.Nazwisko }).GroupBy(p => p.id).Select(g => $"{g.First().imie} {g.First().nazwisko} liczba przedmiotów - {g.Count()}");
        return method;
        throw Niezaimplementowano(nameof(Zadanie15_ProwadzacyILiczbaPrzedmiotow));
    }

    /// <summary>
    /// Zadanie:
    /// Dla każdego studenta znajdź jego najwyższą ocenę końcową.
    /// Pomiń studentów, którzy nie mają jeszcze żadnej oceny.
    ///
    /// SQL:
    /// SELECT s.Imie, s.Nazwisko, MAX(z.OcenaKoncowa)
    /// FROM Studenci s
    /// JOIN Zapisy z ON s.Id = z.StudentId
    /// WHERE z.OcenaKoncowa IS NOT NULL
    /// GROUP BY s.Imie, s.Nazwisko;
    /// </summary>
    public IEnumerable<string> Zadanie16_NajwyzszaOcenaKazdegoStudenta()
    {
        var method = DaneUczelni.Studenci.Join(DaneUczelni.Zapisy, s => s.Id, z => z.StudentId, (s, z) => new
        {
            imie = s.Imie, 
            nazwisko = s.Nazwisko,
            ocena = z.OcenaKoncowa
        }).Where(x => x.ocena is not null).GroupBy(x => new {x.imie, x.nazwisko}).Select(g => $"{g.Key.imie} {g.Key.nazwisko} najwyzsza ocena koncowa - {g.Max(s => s.ocena)}");
        return method;
        throw Niezaimplementowano(nameof(Zadanie16_NajwyzszaOcenaKazdegoStudenta));
    }

    /// <summary>
    /// Wyzwanie:
    /// Znajdź studentów, którzy mają więcej niż jeden aktywny zapis.
    /// Zwróć pełne imię i nazwisko oraz liczbę aktywnych przedmiotów.
    ///
    /// SQL:
    /// SELECT s.Imie, s.Nazwisko, COUNT(*)
    /// FROM Studenci s
    /// JOIN Zapisy z ON s.Id = z.StudentId
    /// WHERE z.CzyAktywny = 1
    /// GROUP BY s.Imie, s.Nazwisko
    /// HAVING COUNT(*) > 1;
    /// </summary>
    public IEnumerable<string> Wyzwanie01_StudenciZWiecejNizJednymAktywnymPrzedmiotem()
    {
        var method = DaneUczelni.Studenci.Join(DaneUczelni.Zapisy, s => s.Id, z => z.StudentId, (s, z) => new
        {
            id = s.Id,
            imie = s.Imie, 
            nazwisko = s.Nazwisko, 
            czyAktywny = z.CzyAktywny
        }).Where(x => x.czyAktywny).GroupBy(x => x.id).Where(g => g.Count() > 1).Select(g => $"{g.First().imie} {g.First().nazwisko} ma aktywnych przedmiotów - {g.Count()} ");
        return method;
        throw Niezaimplementowano(nameof(Wyzwanie01_StudenciZWiecejNizJednymAktywnymPrzedmiotem));
    }

    /// <summary>
    /// Wyzwanie:
    /// Wypisz przedmioty startujące w kwietniu 2026, dla których żaden zapis nie ma jeszcze oceny końcowej.
    ///
    /// SQL:
    /// SELECT p.Nazwa
    /// FROM Przedmioty p
    /// JOIN Zapisy z ON p.Id = z.PrzedmiotId
    /// WHERE MONTH(p.DataStartu) = 4 AND YEAR(p.DataStartu) = 2026
    /// GROUP BY p.Nazwa
    /// HAVING SUM(CASE WHEN z.OcenaKoncowa IS NOT NULL THEN 1 ELSE 0 END) = 0;
    /// </summary>
    public IEnumerable<string> Wyzwanie02_PrzedmiotyStartujaceWKwietniuBezOcenKoncowych()
    {
        var method = DaneUczelni.Przedmioty.Where(p => p.DataStartu.Month == 4 && p.DataStartu.Year == 2026).Join(DaneUczelni.Zapisy, p => p.Id, z => z.PrzedmiotId, (p,z) => new
        {
            przemiot = p.Nazwa,
            ocena = z.OcenaKoncowa
        }).Where(x => x.ocena is null).GroupBy(x => x.przemiot).Select(g => $"{g.Key} nie ma jeszcze ocen");
        return method;
        throw Niezaimplementowano(nameof(Wyzwanie02_PrzedmiotyStartujaceWKwietniuBezOcenKoncowych));
    }

    /// <summary>
    /// Wyzwanie:
    /// Oblicz średnią ocen końcowych dla każdego prowadzącego na podstawie wszystkich jego przedmiotów.
    /// Pomiń brakujące oceny, ale pozostaw samych prowadzących w wyniku.
    ///
    /// SQL:
    /// SELECT pr.Imie, pr.Nazwisko, AVG(z.OcenaKoncowa)
    /// FROM Prowadzacy pr
    /// LEFT JOIN Przedmioty p ON p.ProwadzacyId = pr.Id
    /// LEFT JOIN Zapisy z ON z.PrzedmiotId = p.Id
    /// WHERE z.OcenaKoncowa IS NOT NULL
    /// GROUP BY pr.Imie, pr.Nazwisko;
    /// </summary>
    public IEnumerable<string> Wyzwanie03_ProwadzacyISredniaOcenNaIchPrzedmiotach()
    {
        var method = DaneUczelni.Prowadzacy.LeftJoin(DaneUczelni.Przedmioty, pro => pro.Id, prz => prz.ProwadzacyId, (pro, prz) => new
        {
            imie = pro.Imie, 
            nazwisko = pro.Nazwisko,
            przedmiotId = prz?.Id
        }).LeftJoin(DaneUczelni.Zapisy, x => x.przedmiotId, z => z.PrzedmiotId, (x, z) => new
        {
            imie = x.imie,
            nazwisko = x.nazwisko,
            ocena = z?.OcenaKoncowa
        }).Where(x => x.ocena is not null).GroupBy(x => new {x.imie, x.nazwisko}).Select(g => $"{g.Key.imie} {g.Key.nazwisko} srednia ocen - {g.Average(x => x.ocena)}");
        return method;
        throw Niezaimplementowano(nameof(Wyzwanie03_ProwadzacyISredniaOcenNaIchPrzedmiotach));
    }

    /// <summary>
    /// Wyzwanie:
    /// Pokaż miasta studentów oraz liczbę aktywnych zapisów wykonanych przez studentów z danego miasta.
    /// Posortuj wynik malejąco po liczbie aktywnych zapisów.
    ///
    /// SQL:
    /// SELECT s.Miasto, COUNT(*)
    /// FROM Studenci s
    /// JOIN Zapisy z ON s.Id = z.StudentId
    /// WHERE z.CzyAktywny = 1
    /// GROUP BY s.Miasto
    /// ORDER BY COUNT(*) DESC;
    /// </summary>
    public IEnumerable<string> Wyzwanie04_MiastaILiczbaAktywnychZapisow()
    {
        var method = DaneUczelni.Studenci.Join(DaneUczelni.Zapisy, s => s.Id, z => z.StudentId, (s, z) => new
        {
            czyAktywny = z.CzyAktywny,
            miasto = s.Miasto
        }).Where(x => x.czyAktywny).GroupBy(x => x.miasto).OrderByDescending(g => g.Count()).Select(g => $"{g.Key} liczba aktywnych zapisów - {g.Count()}");
        return method;
        throw Niezaimplementowano(nameof(Wyzwanie04_MiastaILiczbaAktywnychZapisow));
    }

    private static NotImplementedException Niezaimplementowano(string nazwaMetody)
    {
        return new NotImplementedException(
            $"Uzupełnij metodę {nazwaMetody} w pliku Exercises/ZadaniaLinq.cs i uruchom polecenie ponownie.");
    }
}
