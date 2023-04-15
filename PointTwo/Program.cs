// See https://aka.ms/new-console-template for more information
using System;

Console.WriteLine("Task 2 - Point 2");
Console.WriteLine("Write the  ");
string number = Console.ReadLine();

SwapsNumber(number);
Console.ReadKey();


//Methods

static void  SwapsNumber(string array) {

    
    string [] splitArray = array.Split(",");
    int length = splitArray.Length - 1;

    for (int i=0;i<splitArray.Length;i++) {

        if (i != (splitArray.Length-1))
            Console.Write(splitArray[length] + ",");
        else
            Console.Write(splitArray[length]);

        length--;
    }
}