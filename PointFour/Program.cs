// See https://aka.ms/new-console-template for more information
using System;
using System.Net.NetworkInformation;

   
Console.WriteLine("Task 2, point 4");
Console.WriteLine();


char[,] field = new char[6, 10] { { '5','+', '-', '+', '-', '-', '-', '-', '-', '+' }, { '4','+', '-', '+', '-', '-', '+', '-', '-', '+' }, { '3','-', '-', '+', '-', '-', '-', '-', '-', '+' }, { '2','+', '-', '+', '-', '-', '+', '-', '-', '+' }, { '1','-', '-', '+', '-', '-', '+', '-', '-', '+' } ,{ '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' } };
bool statusGame = false;
char[,] future = new char[6, 10];
char[,] pastfield = new char[6, 10];
for (int x = 0; x < field.GetLength(0)-1; x++)
{
    for (int y = 1; y < field.GetLength(1); y++)
    {
       Console.ReadKey();
       Console.Clear();
       Console.WriteLine("Start Field");
       DrawField(field);
       pastfield = (char[,])field.Clone();
       future = FutureField(field,x,y);
       Console.WriteLine("Future Field");
       DrawField(future);
    
        statusGame = status(pastfield, future);
        if (statusGame)
        {
            break;
        }
    }
    if (statusGame)
    {
        Console.WriteLine("GameOver");
        break;
    }
    else { field = future; }
}

Console.ReadKey();



//Method to print

void DrawField(char[,] gridToPrint)
{
    for (int i = 0; i < gridToPrint.GetLength(0); i++)
    {
        for (int j = 0; j < gridToPrint.GetLength(1); j++)
        { 
            Console.Write(gridToPrint[i, j] + "\t");
        }
        Console.WriteLine();
    }
}


//Method to calculate the next generation
char[,] FutureField(char[,] currenField, int x,int y)
{
    int neighbors = CheckNeigbors(currenField, x,y);
    currenField[x, y]= ModifiedField(neighbors, currenField[x, y]);
    return currenField;
}

//Method check neigbors
int CheckNeigbors(char[,] currenField, int x,int y)
{
    // int[,] neigbors = new int[];

    int neigbors = 0;
    for (int xn= -1; xn <=1; xn++)
    {
        for (int yn = -1; yn <=1; yn++)
        {
            if ((!(xn == 0 && yn == 0))&&(y+yn)>0&& (x+xn)>=0&& (y + yn)<currenField.GetLength(1) && (x + xn)<currenField.GetLength(0)-1) {
                 neigbors += (currenField[x+xn,y+yn]== '+') ? 1 : 0;
                
            }
        }

    }
    Console.WriteLine("neigbors " + neigbors);  
    return neigbors;
}

char ModifiedField(int neigbors,char character) {

    if (character == '+')
    {
        if (neigbors <= 1 || neigbors >= 4) { return '-'; }
        else { return '+'; }
    }
    else
    {
        if (neigbors == 3) { return '+'; }
        else { return '-'; }
    }
}

bool status(char[,] presentField, char[,] FutureField)
{
    int count=0,count2 = 0;
    for (int x = 0; x < field.GetLength(0) - 1; x++)
    {
        for (int y = 1; y < field.GetLength(1); y++)
        {
            count += (FutureField[x , y] == '+') ? 1 : 0;
            count2 += (FutureField[x, y] == presentField[x,y]) ? 0 : 1;

        }

    }
    
    Console.WriteLine("cont: " + count);
    Console.WriteLine("cont2: " + count2);
    if (count > 0 && count2 >0) { return false; }
    else { return true; }
}