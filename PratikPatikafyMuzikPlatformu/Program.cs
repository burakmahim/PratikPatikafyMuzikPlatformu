﻿using PratikPatikafyMuzikPlatformu;

public class Program
{
    static void Main(string[] args)
    {
        List<Singer> singers = new List<Singer>()
        {

            new Singer { SingerNameSurname = "Ajda Pekkan", Genre = "Pop", ReleaseYear = 1968, AlbumSales = 20000000 },
            new Singer { SingerNameSurname = "Sezen Aksu", Genre = "Türk Halk Müziği / Pop", ReleaseYear = 1971, AlbumSales = 10000000 },
            new Singer { SingerNameSurname = "Funda Arar", Genre = "Pop", ReleaseYear = 1999, AlbumSales = 3000000 },
            new Singer { SingerNameSurname = "Sertab Erener", Genre = "Pop", ReleaseYear = 1994, AlbumSales = 5000000 },
            new Singer { SingerNameSurname = "Sıla", Genre = "Pop", ReleaseYear = 2009, AlbumSales = 3000000 },
            new Singer { SingerNameSurname = "Serdar Ortaç", Genre = "Pop", ReleaseYear = 1994, AlbumSales = 10000000 },
            new Singer { SingerNameSurname = "Tarkan", Genre = "Pop", ReleaseYear = 1992, AlbumSales = 40000000 },
            new Singer { SingerNameSurname = "Hande Yener", Genre = "Pop", ReleaseYear = 1999, AlbumSales = 7000000 },
            new Singer { SingerNameSurname = "Hadise", Genre = "Pop", ReleaseYear = 2005, AlbumSales = 5000000 },
            new Singer { SingerNameSurname = "Gülben Ergen", Genre = "Pop / Türk Halk Müziği", ReleaseYear = 1997, AlbumSales = 10000000 },
            new Singer { SingerNameSurname = "Neşet Ertaş", Genre = "Türk Halk Müziği / Türk Sanat Müziği", ReleaseYear = 1960, AlbumSales = 2000000 }

        };



        //var nameStartsWithS = singers.Where(s => s.SingerNameSurname.StartsWith("S"));
        var nameStartsWithS = from singer in singers
                              where singer.SingerNameSurname.StartsWith("S")
                              select singer;

        Console.WriteLine("{0,-25}: ", "Adı S ile başlayanlar");
        Console.WriteLine(new string('-', 33));

        foreach (var item in nameStartsWithS)
        {
            Console.WriteLine("{0, -20}: ", string.Join(", ", item.SingerNameSurname, item.Genre, item.ReleaseYear, item.AlbumSales));
        }
        Console.WriteLine(new string('-', 33));




        Console.WriteLine("\n\n");
        Console.WriteLine(new string('-', 33));


        //var over10MSales = singers.Where(s => s.AlbumSales > 10000000);
        var over10MSales = from singer in singers
                           where singer.AlbumSales > 10000000
                           select singer;

        Console.WriteLine("{0,-25}: ", "10 M Üzeri Satanlar");
        Console.WriteLine(new string('-', 33));

        foreach (var item in over10MSales)
        {
            Console.WriteLine("{0, -20}: ", string.Join(", ", item.SingerNameSurname, item.Genre, item.ReleaseYear, item.AlbumSales));
        }
        Console.WriteLine(new string('-', 33));



        Console.WriteLine("\n\n");
        Console.WriteLine(new string('-', 33));



        //var before2000Pop = from singer in singers
        //                    where singer.ReleaseYear < 2000 && singer.Genre.Contains("Pop")
        //                    orderby singer.SingerNameSurname ascending
        //                    group singer by singer.ReleaseYear into groupedByYear
        //                    orderby groupedByYear.Key
        //                    select groupedByYear;
        var before2000Pop = singers.Where(s => s.ReleaseYear < 2000 && s.Genre.Contains("Pop"))
                                  .OrderBy(s => s.SingerNameSurname)
                                  .GroupBy(s => s.ReleaseYear)
                                  .OrderBy(g => g.Key);


        Console.WriteLine("2000 Öncesi Yıla Göre Gruplu - Sıralı");
        Console.WriteLine(new string('-', 33));

        foreach (var item in before2000Pop)
        {
            Console.WriteLine($"Çıkış Yılı: {item.Key}"); // Çıkış yılına göre grup başlığı

            foreach (var singer in item) // Grup içindeki şarkıcılar
            {
                Console.WriteLine($"- {singer.SingerNameSurname}, {singer.Genre}, {singer.ReleaseYear}, {singer.AlbumSales}");
            }
            Console.WriteLine(new string('-', 33)); // Her grup arasında ayırıcı çizgi
        }


        Console.WriteLine("\n\n");
        Console.WriteLine(new string('-', 33));




        //var bestSellerSinger = singers.OrderByDescending(s=>s.AlbumSales).First();
        var bestSellerSinger = (from singer in singers
                                orderby singer.AlbumSales descending
                                select singer).First();

        Console.WriteLine("En çok albüm satan:");
        Console.WriteLine($"Adı: {bestSellerSinger.SingerNameSurname}, \nSatış Adedi: {bestSellerSinger.AlbumSales}");
        Console.WriteLine(new string('-', 33));


        Console.WriteLine("\n\n");
        Console.WriteLine(new string('-', 33));

        //var latestReleseSinger = singers.OrderByDescending(s => s.ReleaseYear).First();
        var latestReleseSinger = (from singer in singers
                                  orderby singer.ReleaseYear descending
                                  select singer).First();
        Console.WriteLine("En yeni çıkış yapan:");
        Console.WriteLine($"Adı: {latestReleseSinger.SingerNameSurname}, \nÇıkış Yılı: {latestReleseSinger.ReleaseYear}");
        Console.WriteLine(new string('-', 33));


        Console.WriteLine("\n\n");
        Console.WriteLine(new string('-', 33));

        var oldestReleseSinger = singers.OrderBy(s => s.ReleaseYear).First();
        //var oldestReleseSinger = (from singer in singers
        //                          orderby singer.ReleaseYear
        //                          select singer).First();
        Console.WriteLine("En Eski çıkış yapan:");
        Console.WriteLine($"Adı: {oldestReleseSinger.SingerNameSurname}, \nÇıkış Yılı: {oldestReleseSinger.ReleaseYear}");
        Console.WriteLine(new string('-', 33));



        Console.ReadKey();
    }
}