namespace PJ_LV3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Restoran restoran1 = new Restoran("Lepenski Vir");

            restoran1.Insert(new Pice("Rakija", new DateTime(2025, 01, 10), false, 100, 50, true));
            restoran1.Insert(new Jelo("Pica", new DateTime(2024, 09, 11), false, 1100, KVALITET.DOBAR));

            restoran1.Insert(new Pice("Pivo", new DateTime(2025, 02, 20), true, 70, 50, false));
            restoran1.Insert(new Jelo("Pecenje", new DateTime(2023, 04, 30), false, 2000, KVALITET.ODLICAN));

            restoran1.Prikazi();

            Restoran restoran2 = new Restoran("Nebitno");

            String binFile = "restoran.bin";

            restoran1.Upisi(binFile);
            restoran2.Procitaj(binFile);

            restoran2.Prikazi();

            Console.WriteLine("Izbacivanje robe kojoj je isteko rok:");

            restoran2.IzbaciIsteklo();

            restoran2.Prikazi();

            try
            {
                restoran2.CheckVegan();

                Console.WriteLine("Restoran ima veganskih opcija");
            }
            catch (VeganUnfriendly v)
            {
                Console.WriteLine(v);
            }
        }
    }
}
