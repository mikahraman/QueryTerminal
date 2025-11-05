using System;
using Microsoft.Data.SqlClient;

namespace QueryTerminal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "QueryTerminal SQL Projesi";
            string connectionString = "Server=.;Database=TestDB;Trusted_Connection=True;TrustServerCertificate=True;";

            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("QueryTerminal SQL Programı");
                Console.ResetColor();
                Console.WriteLine("Çıkmak için 'exit' yazın.");
                Console.Write("SQL Sorgunuzu Girin > ");

                string kullaniciSorgusu = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(kullaniciSorgusu)) continue;
                if (kullaniciSorgusu.ToLower() == "exit") break;

                try
                {
                    Console.WriteLine("\n Çalıştırılıyor...");
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(kullaniciSorgusu, connection))
                        {

                            if (kullaniciSorgusu.Trim().ToUpper().StartsWith("SELECT"))
                            {
                                using (SqlDataReader reader = command.ExecuteReader())
                                {

                                    int sutunSayisi = reader.FieldCount;
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    for (int i = 0; i < sutunSayisi; i++)
                                    {
                                        Console.Write($"{reader.GetName(i)}\t");
                                    }
                                    Console.WriteLine("\n" + new string('-', 50));
                                    Console.ResetColor();


                                    while (reader.Read())
                                    {
                                        for (int i = 0; i < sutunSayisi; i++)
                                        {
                                            Console.Write($"{reader.GetValue(i)}\t");
                                        }
                                        Console.WriteLine();
                                    }
                                }
                            }
                            else
                            {

                                int etkilenenSatir = command.ExecuteNonQuery();
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"\n İşlem Başarılı! Etkilenen satır sayısı: {etkilenenSatir}");
                                Console.ResetColor();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\n HATA: {ex.Message}");
                    Console.ResetColor();
                }

                Console.WriteLine("\nDevam etmek için bir tuşa basın...");
                Console.ReadKey();
            }
        }
    }
}