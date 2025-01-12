using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_ForeachLoop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Foreach Döngüsü

            //Foreach(1;2;3;4)

            //1:Değişken Türü
            //2:Değişken Adı
            //3:in
            //4: Liste, Koleksiyon, Dizi


            //string[] cities = { "milano", "roma", "budapeşte", "ankara", "istanbul", "varşova" };
            //foreach (string x in cities) 
            //{
            //Console.WriteLine(x);
            //}

            //int[] numbers = { 45, 78, 985, 635, 74, 11, 22, 33, 41, 205, 6578, 10394 };
            //foreach (int number in numbers)
            //{
            //Console.WriteLine(number);  
            //}

            //int[] numbers = { 45, 78, 985, 635, 74, 11, 22, 33, 41, 205, 6578, 10394 };
            //foreach (int number in numbers)
            //{
            //    if (number % 2 == 0)
            //    {
            //        Console.WriteLine(number);
            //    }
            //}

            //int[] numbers = { 45, 78, 985, 635, 74, 11, 22, 33, 41, 205, 6578, 10394 };
            //int total = 0;
            //foreach (int i in numbers) 
            //{
            //total += i; 
            //}

            //Console.WriteLine(total);

            //List<int> numbers = new List<int>()
            //{
            //    1,2,3,4,5,6,7,8
            //};
            //Console.WriteLine(numbers);

            //foreach (int i in numbers) 
            //{
            //Console.WriteLine(i);   
            //}

            //string word = "Merhaba";
            //foreach (char c in word)
            //{ 
            //Console.WriteLine(c);
            //}  
            #endregion

            #region Örnek Sınav Sistemi Uygulaması

            //Console.WriteLine("***** C# Eğitim Kampı Sınav Uygulaması *****");
            //Console.WriteLine();
            //Console.WriteLine();

            //// Sınıftaki Öğrenci Sayısını Alma
            //Console.WriteLine("------------------------------");
            //Console.Write("Sınıfınızda Kaç Öğrenci Var: ");
            //int studentCount = int.Parse(Console.ReadLine());
            //Console.WriteLine("------------------------------");

            //// Öğrenci İsimlerini ve Not Ortalamasını Saklayacak Diziler
            //string[] studentName = new string[studentCount];
            //double[] studentExamAvg = new double[studentCount];

            //for (int i = 0; i < studentCount; i++)
            //{
            //    Console.Write($"{i + 1}. Öğrencinin ismini giriniz: ");
            //    studentName[i] = Console.ReadLine();

            //    double totalExamResult = 0;

            //    //Her Öğrenci İçin 3 Sınav Notu Girişi

            //    for (int j = 0; j < 3; j++)
            //    {
            //        Console.Write($"{studentName[i]} adli öğrecinin {j + 1}. Sıanv notunu giriniz: ");
            //        double value = double.Parse(Console.ReadLine());
            //        totalExamResult += value;//notları topluyoruz
            //    }
            //    Console.WriteLine();
            //    studentExamAvg[i] = totalExamResult / 3;
            //}

            ////Öğrencilerin Sınav Ortalaması

            //for (int i = 0; i < studentCount; i++)
            //{
            //    Console.WriteLine($"{studentName[i]} adlı öğrencinin ortalaması: {studentExamAvg[i]}");

            //    //Öğrencilerin Geçip Kalma Durumları

            //    if (studentExamAvg[i]>=50)
            //    {
            //        Console.WriteLine($"{studentName[i]} adlı öğrenci dersi geçti");
            //    }
            //    else 
            //    {
            //        Console.WriteLine($"{studentName[i]} adlı öğrenci dersten kaldı");
            //    }
            //    Console.WriteLine("--------------------------------------------------");

            //}

            #endregion

            Console.Read();
        }
    }
}
