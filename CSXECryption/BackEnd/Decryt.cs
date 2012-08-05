using System;
using System.Linq;

namespace CSXECryption.BackEnd
{
    internal class Decryt
    {
        public static void breakDownMsg(String msgFull)
        {
            String[] splitNumbers = msgFull.Split('.');
            foreach (String value in splitNumbers)
            {
                Console.WriteLine(value);
            }

            int[] numbers = addNumbers(splitNumbers);
            foreach (int num in numbers)
            {
                Console.WriteLine(num);
            }

            int[] keys = mostOccur(numbers);

            decrytMessage(keys, numbers);
        }

        public static int[] addNumbers(String[] splitNumbers)
        {

            Console.WriteLine("Numbers Added Together Here");
            int[] numbers;

            numbers = new int[splitNumbers.Length / 3];
            int runs = 0;
            int j = 0;
            for (int i = 1; i <= splitNumbers.Length; i++)
            {
                runs++;
                if (runs % 3 == 0)
                {
                    Console.WriteLine("yes");
                    Console.WriteLine(splitNumbers[i]);
                    Console.WriteLine(splitNumbers[i - 1]);
                    Console.WriteLine(splitNumbers[i - 2]);
                    Console.WriteLine(int.Parse(splitNumbers[i]) + int.Parse(splitNumbers[i - 1]) + int.Parse(splitNumbers[i - 2]));
                    numbers[j] = (int.Parse(splitNumbers[i]) + int.Parse(splitNumbers[i - 1]) + int.Parse(splitNumbers[i - 2]));
                    j++;
                }
            }

            return numbers;
        }

        public static int[] mostOccur(int[] numbers)
        {
            int[] keys;
            Console.WriteLine("NUMBERS HERE");
            var query = from i in numbers
                        group i by i into g

                        let maxFreq = (from i2 in numbers
                                       group i2 by i2 into g2
                                       orderby g2.Count() descending
                                       select g2.Count()).First()

                        let gCount = g.Count()

                        where gCount == maxFreq

                        select g.Key;

            // Get Number of modes
            int modes = 0;
            foreach (var mode in query)
            {
                Console.WriteLine("HERE");
                Console.WriteLine(mode);
                modes++;
            }

            keys = new int[modes];
            // dump to console
            int currentKeyNum = 0;
            foreach (var mode in query)
            {
                Console.WriteLine("HERE");
                Console.WriteLine(mode);
                keys[currentKeyNum] = mode;
                currentKeyNum++;
            }

            foreach (int numnow in keys)
            {
                Console.WriteLine(numnow);
            }

            return keys;
        }

        public static String decrytMessage(int[] keys, int[] numbers)
        {
            Console.WriteLine("Mess Stuff Here");
            String Message = "";

            for (int i = 0; i < keys.Length; i++)
            {
                for (int j = 0; j < numbers.Length; j++)
                {
                    Message = Message + (decToAscii(numbers[j] - (keys[i]-32)));
                }
                Console.WriteLine(Message);
                Message = "";
            }

            return Message;
        }

        public static char decToAscii(int dec)
        {
            char newChar = (char)dec;

            return newChar;
        }
    }
}