using System.Text.RegularExpressions;
namespace Task1
{
    public class Task1
    {
/*
 * Задание 1.1. Дана строка. Верните строку, содержащую текст "Длина: NN",
 * где NN — длина заданной строки. Например, если задана строка "hello",
 * то результатом должна быть строка "Длина: 5".
 */
        internal static int StringLength(string s)
        {
           Console.WriteLine("Длина: " + s.Length);
        }

/*
 * Задание 1.2. Дана непустая строка. Вернуть коды ее первого и последнего символов.
 * Рекомендуется найти специальные функции для вычисления соответствующих символов и их кодов.
 */
        internal static Tuple<int?, int?> FirstLastCodes(string s)
        {
            Console.WriteLine("{0}, {1}", s[0].ToString(), s[s.Length - 1]);
        }
        
        private static char? First(string s) => throw new NotImplementedException(); 
        private static char? Last(string s) => throw new NotImplementedException();
        private static int? Code(char? c) => throw new NotImplementedException();
       

/*
 * Задание 1.3. Дана строка. Подсчитать количество содержащихся в ней цифр.
 * В решении необходимо воспользоваться циклом for.
 */
        internal static int CountDigits(string s)
        {
        int count = 0;
        for (char ch in s)
            if (Char.IsDigit(ch))
                count++;
            
        Console.WriteLine(count);
        }

/*
 * Задание 1.4. Дана строка. Подсчитать количество содержащихся в ней цифр.
 * В решении необходимо воспользоваться методом Count:
 * https://docs.microsoft.com/ru-ru/dotnet/api/system.linq.enumerable.count?view=net-6.0#system-linq-enumerable-count-1(system-collections-generic-ienumerable((-0))-system-func((-0-system-boolean)))
 * и функцией Char.IsDigit:
 * https://docs.microsoft.com/ru-ru/dotnet/api/system.char.isdigit?view=net-6.0
 */
        internal static int CountDigits2(string s)
        {
            Console.WriteLine(s.Count(x=>char.IsDigit(x)));
        }
        
/*
 * Задание 1.5. Дана строка, изображающая арифметическое выражение вида «<цифра>±<цифра>±…±<цифра>»,
 * где на месте знака операции «±» находится символ «+» или «−» (например, «4+7−2−8»). Вывести значение
 * данного выражения (целое число).
 */
        internal static int CalcDigits(string expr) {
            Regex regex = new Regex(@"(\+|\-|\(|\)|(\d+\.?\d*))");
      
            MatchCollection matches = regex.Matches(expr);
            Operator p = Operator.number;
            if (matches.Count > 0)
            {
                int result = 0;
                foreach (Match match in matches)
                {
                  if ( p == Operator.plus) result += int.Parse(match.Value);
                  if ( p == Operator.minus) result -= int.Parse(match.Value);   
             
                  switch (match.Value)
                  {
                      case "+": p = Operator.plus; 
                                break;
                      case "-": p = Operator.minus;
                                break;
                      default:
                        p = Operator.number;
                        break;
                  }
                          
                }
            
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("Невеный формат");
            }
        }

/*
 * Задание 1.6. Даны строки S, S1 и S2. Заменить в строке S первое вхождение строки S1 на строку S2.
 */
        internal static string ReplaceWithString(string s, string s1, string s2) {
            int IndexFirst = s.IndexOf(s1);
            s = s.Remove(IndexFirst, s1.Length).Insert(IndexFirst, s2);
            Console.WriteLine(s);
        }
        

        public static void Main(string[] args)
        {
            StringLength(string s);
            FirstLastCodes(string s);
            CountDigits(string s);
            CountDigits2(string s);
            CalcDigits(string expr);
            ReplaceWithString(string s, string s1, string s2);

        }
    }
}