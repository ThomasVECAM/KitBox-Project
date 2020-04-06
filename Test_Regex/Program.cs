using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        // Step 1: create new Regex.
        Regex regex = new Regex(@"^\d{4,5}$"); //controls if contains only 4 or 5 digits
        Match match = regex.Match("f43");
        if (match.Success)
        {
            Console.WriteLine("MATCH VALUE: " + match.Value);
        }

        Regex regex2 = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"); //email
        Regex regex3 = new Regex(@"^\d{10}$"); //TVA number
        Regex regex4 = new Regex(@"^[A-Za-z\-]{3,15}( [A-Za-z\-]{1,15}){1,5}$");

        Match match2 = regex4.Match("Jean-Pierre de la  Vandermeersch");
        if (match2.Success)
        {
            Console.WriteLine("MATCH VALUE: " + match2.Value);
        }
        else
            Console.WriteLine("no match");

        Regex regex5 = new Regex(@"^[A-Za-z,\-'0-9 ]{6,30}$");//adresse
        Match match3 = regex5.Match("Thomas2 Van  derme ,-89ersch");

        if (match3.Success)
        {
            Console.WriteLine("MATCH VALUE: " + match3.Value);
        }
        else
            Console.WriteLine("no match");

        Regex regex6 = new Regex(@"^\+{0,1}\d{8,12}$");
        Match match4 = regex6.Match("3223542030");

        if (match4.Success)
        {
            Console.WriteLine("MATCH VALUE: " + match4.Value);
        }
        else
            Console.WriteLine("no match");

    }
}