var timer = new System.Diagnostics.Stopwatch();

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

Console.WriteLine("How many digits?");
var numDigits = Console.ReadLine();

var success = int.TryParse(numDigits, out var nd);

if (!success || nd > 15)
{
    Console.WriteLine("Please enter an integer less than 15");
}
else
{
    timer.Start();
    
    long start = (long)Math.Pow(10, (nd)) - 1;
    long stop = start / 10;
    long largest = 0; 
    long factor1 = 0; 
    long factor2 = 0; 
        
    for (long f1 = start; f1 > stop && f1 > factor2; f1--)
    {
        for (long f2 = f1; f2 > stop; f2--)
        {
            long prod = f2 * f1;
        
            if (prod < largest)
                break;
        
            if (IsPalindrome(prod) && prod > largest)
            {
                largest = prod;
                factor1 = f1;
                factor2 = f2;
            
                break;
            }
        }
    }

    timer.Stop();

    Console.WriteLine($"Largest palindrome is: {largest}");
    Console.WriteLine($"Factor 1 is: {factor1}");
    Console.WriteLine($"Factor 2 is: {factor2}");
    Console.WriteLine($"Elapsed time: {timer.Elapsed.TotalMilliseconds}");
}