using System.Linq;

static void FindThemNumberStrings(string input)
{
    string[] substringsSaved = new string[input.Length];
    int[] substringStart = new int[input.Length];
    int[] substringEnd = new int[input.Length];
    int nextIndexInArray = 0;

    //Loopar igenom rad för rad
    for (int row = 0; row < input.Length; row++)
    {
        bool isThereAMatch = false;
        // Console.WriteLine(row); //BARA FÖR ATT SE VILKEN RADEN BÖRJAR PÅ, TA BORT SENARE

        //Loopa igenom tecken för tecken
        for (int chr = row + 1; chr < input.Length; chr++)
        {
            //Om tecknet är en bokstav, bryt
            if (!char.IsDigit(input[chr]) || !char.IsDigit(input[row]))
            {
                break;
            }

            //Om siffran matchar siffran som raden kollar
            if (input[chr] == input[row])
            {
                substringStart[nextIndexInArray] = row;
                substringEnd[nextIndexInArray] = chr;
                substringsSaved[nextIndexInArray] = input.Substring(row, chr - row + 1);
                isThereAMatch = true;
                break;
            }
        }
        nextIndexInArray++;

        //Körs bara om det finns en match den här raden, ksriver ut
        if (isThereAMatch)
        {
            for (int chr = 0; chr < input.Length; chr++)
            {
                
                if (chr >= row && chr <= substringEnd[row])
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write(input[chr]);
                }
                else
                {
                    Console.ResetColor();
                    Console.Write(input[chr]);
                }
            }
        Console.WriteLine(); //Ny rad
        }
    }

    //Clearar färgen efter loopen
    Console.ResetColor();

    //Tar bort nullvärden från arrayen
    substringsSaved = substringsSaved.Where(s => s != null).ToArray();

    long sumOfSubstrings = substringsSaved.Sum(x => long.Parse(x));
    Console.WriteLine("\n" +sumOfSubstrings);
}

//Kollar så strängen inte är null eller tom
string? input = string.Empty;
while (input == "" || input == null)
{
    Console.Write("Skriv in en rad innehållande siffror och bokstäver: ");
    input = Console.ReadLine();
    if (input == "" || input == null)
    {
        Console.Clear();
        Console.WriteLine("Kan inte vara en tom sträng. Försök igen.");
    }
}

FindThemNumberStrings(input);