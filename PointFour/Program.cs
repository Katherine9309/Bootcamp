// See https://aka.ms/new-console-template for more information
using System;
using System.Net.NetworkInformation;


internal class Program
{
    
    
    
    
    static void Main(string[] args)
    {
        bool statusGame = false;
        char[,] field = new char[6, 10] {
        //{ '5','+', '-', '+', '-', '-', '-', '-', '-', '+' },
        //{ '4','+', '-', '+', '-', '-', '+', '-', '-', '+' }, 
        //{ '3','-', '-', '+', '-', '-', '-', '-', '-', '+' }, 
        //{ '2','+', '-', '+', '-', '-', '+', '-', '-', '+' },
        //{ '1','-', '-', '+', '-', '-', '+', '-', '-', '+' }, 
        //{ '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' } };

        { '5','-', '-', '-', '-', '-', '-', '-', '-', '-' },
        { '4','-', '-', '+', '-', '-', '-', '-', '-', '-' },
        { '3','-', '-', '+', '-', '-', '-', '-', '-', '-' },
        { '2','-', '-', '+', '-', '-', '-', '-', '-', '-' },
        { '1','-', '-', '-', '-', '-', '-', '-', '-', '-' },
        { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' } };
       
        char[,] pastfield = new char[6, 10];
        Console.WriteLine("Task 2, point 4");
        Console.WriteLine();
       

        while (Console.ReadKey().Key == ConsoleKey.Enter)
        {
            Console.Clear();
            char[,] future = new char[6, 10];
            Console.WriteLine("Start Field");
           
             DrawField(field);
           // future = FutureField(pastfield);
            

            Console.WriteLine("Future Field");

            ///////////
            for (int x = 0; x < field.GetLength(0) - 1; x++)
            {
                for (int y = 1; y < field.GetLength(1); y++)
                {

                    int neighbors = CheckNeigbors(field, x, y);
                    future[x, y] = ModifiedField(neighbors, field[x, y]);

                }
            }
            ////////////
            DrawField(future);

            Console.ReadKey();
            Console.WriteLine();
            statusGame = status(field, future);
            if (statusGame)
            {
                break;
            }

            if (statusGame)
            {
                Console.WriteLine("GameOver");
                break;
            }
            else { field = future; 
            
            }

        }
    }

        //Method to print

    public static void DrawField(char[,] gridToPrint)
    {
        for (int i = 0; i < gridToPrint.GetLength(0); i++)
        {

            for (int j = 0; j < gridToPrint.GetLength(1); j++)
            {
                if (j == 0) { Console.Write((gridToPrint.GetLength(0) - i-1) + "\t"); }

                else if (i == 5)
                        Console.Write(j + "\t");

                    else
                    Console.Write(gridToPrint[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }
    


    //Method to calculate the next generation
    static char[,] FutureField(char[,] currenField)
        {

            for (int x = 0; x < currenField.GetLength(0) - 1; x++)
            {
                for (int y = 1; y < currenField.GetLength(1); y++)
                {

                    int neighbors = CheckNeigbors(currenField, x, y);
                    currenField[x, y] = ModifiedField(neighbors, currenField[x, y]);
                    
                }
            }
        return currenField;
    }

        //Method check neigbors
    static int CheckNeigbors(char[,] currenField, int x, int y)
    {
        // int[,] neigbors = new int[];

        int neigbors = 0;
        for (int xn = -1; xn <= 1; xn++)
        {
            for (int yn = -1; yn <= 1; yn++)
            {
                if (!(xn == 0 && yn == 0) && y + yn > 0 && x + xn >= 0 && y + yn < currenField.GetLength(1) && x + xn < currenField.GetLength(0) - 1)
                {
                    neigbors += currenField[x + xn, y + yn] == '+' ? 1 : 0;

                }
            }

        }
        // Console.WriteLine("neigbors " + neigbors);  
        return neigbors;
    }

       static char ModifiedField(int neigbors, char character)
        {

            if (character == '+')
            {

                if (neigbors <= 1 || neigbors >= 4) { return '-'; }
                else { return '+'; }
            }
            else if (character == '-' && neigbors == 3)
            {
                return '+';

            }
            else { return '-'; }
        
    }


        static bool status(char[,] presentField, char[,] FutureField)
        {
            int count = 0;
            int count2 = 0;
            for (int x = 0; x < presentField.GetLength(0) - 1; x++)
            {
                for (int y = 1; y < presentField.GetLength(1); y++)
                {
                    count += FutureField[x, y] == '+' ? 1 : 0;
                    count2 += (FutureField[x, y] == presentField[x, y]) ? 0 : 1;

                }

            }

            Console.WriteLine("cont: " + count);
            Console.WriteLine("cont2: " + count2);
            if (count > 0 || count2 > 0) { return false; }
            else { return true; }
        }
}