using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace C_sharp_lesson_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lengthOfArgs = args.Length; // количество аргументов
            double number;            
            Regex regex = new Regex(@"(-){0,1}(\d){1,}([\.\,]\d{1,}){0,}", RegexOptions.IgnoreCase); //[] скобки означают перечисление символов,{} скобки означают количество

            // Program.exe 123.12fdsf21.2 sdass-2165
            int counter = 0;           
            foreach (var item in args)
            {
                string tmp = Regex.Replace(item, @"\.", ",");

                MatchCollection matchCollection = regex.Matches(tmp);

                foreach (var collect in matchCollection)
                {
                    counter++;
                    try
                    {
                        number = Double.Parse(collect.ToString());
                        Console.WriteLine("Совпадение {0} имеет номер {1}", collect, counter);
                    }
                    catch (Exception e00)
                    {
                        Console.WriteLine(e00.Message);
                        Console.WriteLine($"{collect} не удалось преобразовать в double");
                    }
                    
                }


                /*try
                {
                    number = int.Parse(item);
                    Console.WriteLine(number);
                }
                catch 
                {
                    Console.WriteLine($"{item} не является числом");
                }
                finally
                {
                    Console.WriteLine("Этот код выполнится в любом случае");
                }*/                
            }
            
            Console.ReadKey();

        }
    }
}
