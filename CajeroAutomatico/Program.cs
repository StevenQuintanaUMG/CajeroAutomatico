static void desglose(double CAN)
{

    int billetes = (int)CAN;
    int centavos = (int)(CAN * 100) % 100;

    int B200, B100, B50, B20, B10, B5, C50, C25, C10, C5;
    B200 = B100 = B50 = B20 = B10 = B5 = C50 = C25 = C10 = C5 = 0;

    //Billetes

    if ((billetes >= 200))
    {
        B200 = billetes / 200;
        billetes -= B200 * 200;
    }

    if ((billetes >= 100))
    {
        B100 = billetes / 100;
        billetes -= B100 * 100;
    }

    if ((billetes >= 50))
    {
        B50 = billetes / 50;
        billetes -= B50 * 50;
    }

    if ((billetes >= 20))
    {
        B20 = billetes / 20;
        billetes -= B20 * 20;
    }

    if ((billetes >= 10))
    {
        B10 = billetes / 10;
        billetes -= B10 * 10;
    }

    if ((billetes >= 5))
    {
        B5 = billetes / 5;
        billetes -= B5 * 5;
    }

    //Monedas

    if ((centavos >= 50))
    {
        C50 = centavos / 50;
        centavos -= C50 * 50;
    }

    if ((centavos >= 25))
    {
        C25 = centavos / 25;
        centavos -= C25 * 25;
    }

    if ((centavos >= 10))
    {
        C10 = centavos / 10;
        centavos -= C10 * 10;
    }

    if ((centavos >= 5))
    {
        C5 = centavos / 5;
        centavos -= C5 * 5;
    }

    Console.WriteLine("\n----------Billetes----------");
    Console.WriteLine("\nBilletes de 200: " + B200);
    Console.WriteLine("\nBilletes de 100: " + B100);
    Console.WriteLine("\nBilletes de 50: " + B50);
    Console.WriteLine("\nBilletes de 20: " + B20);
    Console.WriteLine("\nBilletes de 10: " + B10);
    Console.WriteLine("\nBilletes de 5: " + B5);
    Console.WriteLine("\nBilletes de 1: " + billetes);

    Console.WriteLine("\n----------Centavos----------");
    Console.WriteLine("\nMonedas de 50 centavos: " + C50);
    Console.WriteLine("\nMonedas de 25 centavos: " + C25);
    Console.WriteLine("\nMonedas de 10 centavos: " + C10);
    Console.WriteLine("\nMonedas de 5 centavos: " + C5);
    Console.WriteLine("\nMonedas de 1 centavo: " + centavos);
}

static string HideCharacter()
{
    ConsoleKeyInfo key;
    string code = "";

    do
    {
        key = Console.ReadKey(true);
        //Agregue tambien para que aceptara simbolos ya que tambien los abarca el alfanumerico
        //Solo que eso ya no lo explique en el video porque me percate despues
        if ((char.IsNumber(key.KeyChar)) || (char.IsLetter(key.KeyChar)) || (char.IsSymbol(key.KeyChar)))
        {
            Console.Write("*");
        }
        code += key.KeyChar;
    } while (key.Key != ConsoleKey.Enter);


    return code;
}

static void contrasena()
{
    byte OPORTUNIDADES, TienePermiso;
    string CLAVE;
    TienePermiso = 0;
    OPORTUNIDADES = 0;

    do
    {
        Console.Write("DIGITE LA CLAVE: ");
        CLAVE = HideCharacter().Replace("\r", "");
        Console.WriteLine();

        if ((CLAVE.Equals("$Clave567")))
        {
            TienePermiso = 1;
        }
        else
        {
            OPORTUNIDADES++;
        }
    } while (((OPORTUNIDADES < 3) & (TienePermiso == 0)));

    if (TienePermiso == 1)
    {
        menu();
    }
    else
    {
        Console.WriteLine("\n!!OPORTUNIDADES TERMINADAS!!");
    }
}

static void rep()
{
    byte R;

    Console.Write("\nPulse una tecla al finalizar...");
    Console.ReadKey();

    do
    {
        Console.Clear();
        Console.WriteLine("\nDesea ingresar otra cantidad?\n\n1. SI \n2. No");
        Console.Write("\n> ");
    } while (!byte.TryParse(Console.ReadLine(), out R) || R != 1 && R != 2);

    if (R == 2)
    {
        Console.Clear();
        Console.WriteLine("\nGracias por usar el programa");
        Environment.Exit(0);
    }
    else
    {
        menu();
    }
}
static void menu()
{
    byte op;
    string linea;
    double CAN;

    do
    {
        Console.Clear();
        Console.WriteLine("-----------------BIENVENIDO-----------------");
        Console.WriteLine("\nEn que moneda desea hacer la operacion");
        Console.WriteLine("1. Dolares");
        Console.WriteLine("2. Euros");
        Console.WriteLine("3. Quetzales");
        Console.WriteLine("4. Salir\n");

        Console.Write("> ");

    }while(!byte.TryParse(Console.ReadLine(), out op) || (op != 1 && op != 2 && op != 3 && op != 4));

    switch (op)
    {
        case 1:

            Console.Clear();

            do
            {
                Console.Write("\nIngrese la cantidad en Dolares: ");
            } while (!double.TryParse(linea = Console.ReadLine(), out CAN));

            CAN = CAN * 7.79;
            Console.WriteLine("\nSu cantidad en Quetzales es: " + CAN);

            desglose(CAN);
            rep();

            break;

        case 2:

            Console.Clear();

            do
            {
                Console.Write("\nIngrese la cantidad en Euros: ");
            } while (!double.TryParse(linea = Console.ReadLine(), out CAN));

            CAN = CAN * 8.39;
            Console.WriteLine("\nSu cantidad en Quetzales es: " + CAN);

            desglose(CAN);
            rep();

            break;

        case 3:

            Console.Clear();

            do
            {
                Console.Write("\nIngrese la cantidad en Quetzales: ");
            } while (!double.TryParse(linea = Console.ReadLine(), out CAN));

            desglose(CAN);
            rep();

            break;

        case 4:

            Console.Clear();
            Console.WriteLine("\nGracias por utilizar el programa");

            break;
    }
}

contrasena();

