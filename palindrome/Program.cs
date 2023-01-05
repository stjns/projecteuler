Console.WriteLine("How many digits?");
var numDigits = Console.ReadLine();

var success = int.TryParse(numDigits, out var nd);

if (success && nd < 15)
{
    var timer = new System.Diagnostics.Stopwatch();
    timer.Start();

    static bool IsPalindrome (long number)
    {
        long original = number;
        long reverse = 0;

        while (original != 0)
        {
            reverse = reverse * 10 + original % 10;
            original /= 10;
        }

        return number == reverse;
    }
    
    long start = (long)Math.Pow(10, (nd)) - 1;
    long stop = start / 10;
    long largest = 0; 
    long factor1 = 0; 
    long factor2 = 0; 
        
    for (long i = start; i > stop; i--)
    {
        for (long x = i; x > stop; x--)
        {
            long prod = x * i;
        
            if (prod < largest)
                break;
        
            if (IsPalindrome(prod) && prod > largest)
            {
                largest = prod;
                factor1 = i;
                factor2 = x;
            
                break;
            }
        }
    
        if (i <= factor2)
            break;
    }

    timer.Stop();

    Console.WriteLine($"Largest palindrome is: {largest}");
    Console.WriteLine($"Factor 1 is: {factor1}");
    Console.WriteLine($"Factor 2 is: {factor2}");
    Console.WriteLine($"Elapsed time: {timer.Elapsed.TotalMilliseconds}");
}
else
    Console.WriteLine("Please enter an integer less than 15");