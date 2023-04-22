/*
Задача 47. Задайте двумерный массив размером m×n, заполненный случайными вещественными числами.
m = 3, n = 4.
0,5 7 -2 -0,2
1 -3,3 8 -9,9
8 7,8 -7,1 9
*/

Console.WriteLine("Введите размер двумерного массива");

Console.WriteLine("Введите количество строк");
bool isParsevasizerow = int.TryParse(Console.ReadLine(), out int sizeRow);

Console.WriteLine("Введите количество столбцов");
bool isParsesizecolumn = int.TryParse(Console.ReadLine(), out int sizeColumn);

if (!isParsevasizerow || !isParsesizecolumn) { Console.WriteLine("Ошибка ввода размености, введено не число"); return; }


double[,] array = FillingArrayToConsole(sizeRow, sizeColumn);
Console.WriteLine();
Print2DArray(array);



double[,] FillingArrayToConsole(int sizeRow, int sizeColumn)
{
    double[,] array = new double[sizeRow, sizeColumn];

    for (int i = 0; i < sizeRow; i++)
    {
        for (int j = 0; j < sizeColumn; )
        {
            Console.WriteLine($"Введите значение элемента массива с индексами [{i}, {j}]");
            bool isParsed = double.TryParse(Console.ReadLine(), out double value);
            
            if(!isParsed) {Console.WriteLine($"Ошибка ввода элемента, повторите ввод"); continue; }

            array[i,j] = value;
            j++;
        }
    }
    return array;
}



void Print2DArray(double[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write(array[i,j]);
            Console.Write(" ");
        }

        Console.WriteLine();
    }
}

/*
Задача 50. Напишите программу, которая на вход принимает позиции элемента в двумерном массиве, и возвращает значение этого элемента или же указание, что такого элемента нет.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
1, 7 -> такого числа в массиве нет
*/

Console.WriteLine("Введите размер двумерного массива");

Console.WriteLine("Введите количество строк");
bool isParsevasizerow = int.TryParse(Console.ReadLine(), out int sizeRow);

Console.WriteLine("Введите количество столбцов");
bool isParsesizecolumn = int.TryParse(Console.ReadLine(), out int sizeColumn);

if (!isParsevasizerow || !isParsesizecolumn) { Console.WriteLine("Ошибка ввода размености, введено не число"); return; }

Console.WriteLine("Введите индекс строки искомого элемента");
bool isParseindexrow = int.TryParse(Console.ReadLine(), out int indexRow);

Console.WriteLine("Введите индекс столбца искомого элемента");
bool isParseindexcolumn = int.TryParse(Console.ReadLine(), out int indexColumn);

int[,] array = Generate2DArray(sizeRow, sizeColumn);
Print2DArray(array);

Console.WriteLine($"Значение искомого элемента равно: {FindElemetToArray(array, indexRow, indexColumn)}");



int[,] Generate2DArray(int sizeRow, int sizeColumn)
{
    int[,] array = new int[sizeRow, sizeColumn];

    Random random = new Random();

    for (int i = 0; i < sizeRow; i++)
    {
        for (int j = 0; j < sizeColumn; j++)
        {
            array[i, j] = random.Next(0, 10);
        }
    }
    return array;
}



void Print2DArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write(array[i, j]);
            Console.Write(" ");
        }

        Console.WriteLine();
    }
}



string FindElemetToArray(int[,] array, int i, int j)
{
    string result = string.Empty;

    if (i >= array.GetLength(0) && j >= array.GetLength(1))
    {
        result = "Искомого элемента не существует";
        return result;
    }

    result = $"{array[i,j]}";
    return result;

}

/*
Задача 52. Задайте двумерный массив из целых чисел. Найдите среднее арифметическое элементов в каждом столбце.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
Среднее арифметическое каждого столбца: 4,6; 5,6; 3,6; 3.
*/

Console.WriteLine("Введите размер двумерного массива");

Console.WriteLine("Введите количество строк");
bool isParsevasizerow = int.TryParse(Console.ReadLine(), out int sizeRow);

Console.WriteLine("Введите количество столбцов");
bool isParsesizecolumn = int.TryParse(Console.ReadLine(), out int sizeColumn);

if (!isParsevasizerow || !isParsesizecolumn) { Console.WriteLine("Ошибка ввода размености, введено не число"); return; }

int[,] array = Generate2DArray(sizeRow, sizeColumn);
Print2DArray(array);

PrintArray(FindArithmeticMeanColumnToArray(array));



int[,] Generate2DArray(int sizeRow, int sizeColumn)
{
    int[,] array = new int[sizeRow, sizeColumn];

    Random random = new Random();

    for (int i = 0; i < sizeRow; i++)
    {
        for (int j = 0; j < sizeColumn; j++)
        {
            array[i, j] = random.Next(0, 10);
        }
    }
    return array;
}



double[] FindArithmeticMeanColumnToArray (int[,] array)
{
    double[] resultArray = new double[array.GetLength(1)];
    double result = 0;
    
    for (int j = 0; j < array.GetLength(1); j++)
    {
        result = 0;

        for (int i = 0; i < array.GetLength(0); i++)
        {
            result += array[i,j];
        }
        
        resultArray[j] = Math.Round(result / array.GetLength(1), 2);
    }

    return resultArray;

}



void Print2DArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write(array[i, j]);
            Console.Write(" ");
        }

        Console.WriteLine();
    }
}



void PrintArray(double[] array)
{
    Console.WriteLine($"Среднеарифметическое столбцов: [{string.Join(", ", array)}]"); 
}