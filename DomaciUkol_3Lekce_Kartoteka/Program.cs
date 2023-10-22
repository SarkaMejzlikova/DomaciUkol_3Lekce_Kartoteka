//Zadání
//Úkol je obdobou úkolu zápisu do souboru.
//Jen zde se nebudou zadávat řádky, ale údaje o osobě(případně o knize a podobně) jako jméno, příjměné, rok narození apod. (opět dle fantazie a kreativity)
//Každá osoba se takto uloží do souboru. Co osoba to řádek v souboru.
//Uživatel by v minimálním provedení měl mít možnost přidat osobu a vypsat všechny osoby. Pokud si budeš chtít vyhrát jde udělat mnoho dalších funkcí jako vypsat
//jen osoby nějakého roku narození apod. Tedy lze dát velký prostor kreativitě.

using System.IO;

string cesta = @"C:\text.txt";

List<string> listTextu = new List<string>();

Console.WriteLine("Chcete zadat novou osobu do kartotéky nebo vypsat informace z kartotéky?\nOdpovězte zadat/vypsat");
string input = Console.ReadLine();

if (input == "zadat")
{
    do
    {
        Console.Write("Jméno: ");
        string jmeno = (Console.ReadLine()).ToUpper();
        Console.Write("Příjmení: ");
        string prijmeni = (Console.ReadLine()).ToUpper();
        Console.Write("Rok narození: ");
        string rokNarozeni = Console.ReadLine();
        int rok;

        while (!int.TryParse(rokNarozeni, out rok) || rok < 1900)
        {
            Console.WriteLine("Zřejmě jste zadali špatný letopočet, zkuste to znovu:");
            rokNarozeni = Console.ReadLine();
        }

        listTextu.Add(jmeno + " " + prijmeni + " " + rokNarozeni);

        Console.WriteLine("Chcete přidat další osobu?\nOdpovězte ano/ne");
        input = Console.ReadLine();

    } while (input == "ano");

    string[] poleTextu = listTextu.ToArray();
    File.WriteAllLines(cesta, poleTextu);
    Console.WriteLine("Ukončili jste zadávání osob.");
}
else if (input == "vypsat")
{
    Console.WriteLine("Od jakého roku narození chcete osoby vypsat?");
    string vyberRokuNarozeni = Console.ReadLine();
    int vyberRokuNarozeni2;

    while (!int.TryParse(vyberRokuNarozeni, out vyberRokuNarozeni2) || vyberRokuNarozeni2 < 1900)
    {
        Console.WriteLine("Zřejmě jste zadali špatný letopočet, zkuste to znovu:");
        vyberRokuNarozeni = Console.ReadLine();
    }

    string[] vypisSouboru = File.ReadAllLines(cesta);
    int pocitadlo = 0;
    foreach (string vs in vypisSouboru)
    {
        int vypisRoku = Int32.Parse(vs.Substring(vs.Length - 5));
        if (vypisRoku >= vyberRokuNarozeni2)
        {
            Console.WriteLine(vs);
            pocitadlo++;
        }
    }
    if (pocitadlo == 0)
    {
        Console.WriteLine("V kartotéce se nenachází osoby dle vašeho výběru roku narození.");
    }
}
else
{
    Console.WriteLine("Nevybrali jste z uvedených možností. Program bude ukončen.");
}

Console.ReadLine();