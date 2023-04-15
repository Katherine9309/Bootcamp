// See https://aka.ms/new-console-template for more information
using System;

Console.WriteLine("Taks 2 point 3");


int[,] matriz1 = new [,] { {2,4,5,6 } , {3,5,5,5}, { 3, 5, 5, 5 } , { 3, 5, 5, 5 } };
int[,] matriz2 = new int[matriz1.GetLength(0), matriz1.GetLength(1)];

Console.WriteLine("Matrix changed");
for (int i = 0; i < matriz1.GetLength(0); i++)
{
    for (int j = 0; j < matriz1.GetLength(1);j++) {

        if (j > i)
        {
            matriz2[i, j] = 1;
        }

        else if (i > j)
        {
            matriz2[i, j] = 0;
        }
        else
            matriz2[i, j] = matriz1[i, j];

        Console.Write(matriz2[i, j] + "\t");
    }
    Console.WriteLine();
}

Console.WriteLine("Original Matrix");

for (int i = 0; i < matriz1.GetLength(0); i++)
{
    for (int j = 0; j < matriz1.GetLength(1); j++)
    { Console.Write(matriz1[i, j] + "\t"); }
    Console.WriteLine();
}

Console.ReadKey();
