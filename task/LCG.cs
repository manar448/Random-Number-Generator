using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace task
{
    class LCG
    {
        ///////////// INPUTS /////////////
        public int seed { get; set; }      // Z
        public int Multiplier     { get; set; }   // a
        public int Increment { get; set; }    // C
        public int Modulus { get; set; }     // M
        public int Number_of_Iterations   { get; set; }

        ///////////// OUTPUTS /////////////

        public List<int> generated { get; set; }

        public int Cycle_length { get; set; }

        //done
        public void systemoutput()
        {
            generated = new List<int>();
            int cycleLength = 0;
            for (int i = 0; i < Number_of_Iterations; ++i)
            {
                int result = 0;

                if (i == 0)
                {
                    result = (seed * Multiplier + Increment) % Modulus;
                }
                else
                {
                    result = (generated[i - 1] * Multiplier + Increment) % Modulus;
                }
                if (!generated.Contains(result)) {

                    cycleLength++;
                }
                Cycle_length= cycleLength;
                generated.Add(result);

            }
        }

        //return true if number is prime
        public bool IsPrime(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            for (int i = 3; i <= Math.Sqrt(number); i += 2)
            {
                if (number % i == 0) return false;
            }

            return true;
        }

        //return false if n not divisible by 2 
        public bool isOfPow(int n)
        {
            if (n == 0) return false;
            while (n != 1)
            {
                if (n % 2 != 0)
                {
                    return false;
                }
                n = n / 2;
            }

            return true;
        }

        //done
        //a->increment b-> modulus
        public bool IsRelativelyPrime(int a, int b)
        {
            if (b > a)
            {
                while (b != 0)
                {
                    int temp = b;
                    b = a % b;
                    a = temp;
                }
                return a == 1;
            }
            else
            {
                while (a != 0)
                {
                    int temp = a;
                    a = b % a;
                    b = temp;
                }
                return b == 1;
            }
        }
        
        public void determinte_cl()
        {
            int val1 = 1 + ((Modulus - 1) * 4);
            int val2 = 5 + ((Modulus - 1) * 8);
            int val3 = 3 + ((Modulus - 1) * 8);
            bool check_1 = true, check_2 = true, check_3 = true;

            //3 cases 
            //case 1 (m of pow 2, c!=0)  ==> cycle length = m   ------------> c and m are both divisible by 1 as biggest divisible ,muliplier = 1 + (m-1)*4  
            if (isOfPow(Modulus) == true && Increment != 0)
            {
                if (IsRelativelyPrime(Increment, Modulus) && Multiplier == val1)
                {
                    Cycle_length = Modulus;
                    check_1 = false;
                }

            }
            //case 2 (mod of pow 2, c=0) ==> cycle length = m/4  ------------> seed odd,muliplier = 5 + (m-1)*8  or 3 + (m-1)*8
            if (isOfPow(Modulus) == true && Increment == 0)
            {
                if ((seed % 2 != 0) && (Multiplier == val2 || Multiplier == val3))
                {
                    Cycle_length = Modulus / 4;
                    check_2 = false;
                }

            }
            //case 3 (modulus prime , c =0) ==> cycle length = m-1  ------------> m divisable by (multiplier pow(m-1) -1) 
            if (IsPrime(Modulus) == true && Increment == 0)
            {
                double num = (Math.Pow(Multiplier, Modulus - 1)) - 1;
                if (num % Modulus == 0)
                {
                    Cycle_length = Modulus - 1;
                    check_3 = false;
                }

            }
            if (check_1 && check_2 && check_3)
                    CalculateCycleLength();
        }
        ///////////////////////////////////////////////////
        public void CalculateCycleLength()
        {
            HashSet<int> seen = new HashSet<int>();
            int current = (Multiplier * seed + Increment) % Modulus; // Start from the first generated number
            int cycleLength = 0;

            // Continue until a generated number repeats
            while (!seen.Contains(current))
            {
                seen.Add(current); // Add the current number to the set of seen numbers
                cycleLength++; // Increment the cycle length count
                current = (Multiplier * current + Increment) % Modulus; // Generate the next number
            }

            Cycle_length= cycleLength;
        }
        

    }
}
