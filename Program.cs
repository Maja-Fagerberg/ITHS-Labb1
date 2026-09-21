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
                nextIndexInArray++;
                break;
            }

            //Om siffran matchar siffran som raden kollar
            if (input[chr] == input[row])
            {
                substringStart[nextIndexInArray] = row;
                substringEnd[nextIndexInArray] = chr;
                substringsSaved[nextIndexInArray] = input.Substring(row, chr - row + 1);
                isThereAMatch = true;
                nextIndexInArray++;
                break;
            }
        }

        //Körs bara om det finns en match den här raden
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
}

FindThemNumberStrings("29535123p48723487597645723645");