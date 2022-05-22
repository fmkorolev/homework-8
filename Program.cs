int[,] CreateArray(int rowsAmt, int colsAmt, int minVal, int maxVal)
{
    int[,] array = new int[rowsAmt, colsAmt];
    for (int i = 0; i < rowsAmt; i++)
    {
        for (int j = 0; j < colsAmt; j++)
        {
            array[i, j] = new Random().Next(minVal, maxVal + 1);
        }
    }
    PrintArray(array);
    Console.WriteLine();
    return array;
}


void PrintArray(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write(matrix[i, j] + "\t");
        }
        Console.WriteLine();
    }
}


int[] ArrayParametersInput()
{
    int rows = 0, cols = 0;

    while (true)
    {
        Console.Write("Введите количество строк (начиная с 1): ");
        rows = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите количество столбцов (начиная с 1): ");
        cols = Convert.ToInt32(Console.ReadLine());
        if (rows > 0 && cols > 0)
            break;
        else
            Console.WriteLine("Количество и строк и столбцов должно быть больше 0. Пожалуйста повторите попытку.");
    }

    Console.Write("Введите нижнюю границу диапазона значений: ");
    int lowerValue = Convert.ToInt32(Console.ReadLine());
    Console.Write("Введите верхнюю границу диапазона значений: ");
    int upperValue = Convert.ToInt32(Console.ReadLine());

    int[] paramsOut = { rows, cols, lowerValue, upperValue };
    return paramsOut;

}

//Задача 54
/*
int[,] SortArray(int[,] matrix)
{
    for(int i = 0; i < matrix.GetLength(0); i++)
    {
        for(int j = 0; j < matrix.GetLength(1); j++)
        {
            int minPos = j;
            for(int k = j + 1; k < matrix.GetLength(1); k++)
            {
                if(matrix[i, k] < matrix[i, minPos])
                {
                    minPos = k;
                }
            }
            
            (matrix[i, minPos], matrix[i, j]) = (matrix[i, j], matrix[i, minPos]);  
        }
    }
    return matrix;
}
int[] arrayParameters = ArrayParametersInput();
PrintArray(SortArray(CreateArray(arrayParameters[0],    
                                 arrayParameters[1],    
                                 arrayParameters[2],    
                                 arrayParameters[3]    
                                 )));

*/
//  Задача 56
/*
int LesserStringSum(int[,] matrix)
{
    int stringSum = 0, minStringSum = 0, rowIndex = 1;
    for(int i = 0; i < matrix.GetLength(0); i++)
    {
        stringSum = 0;
        for(int j = 0; j < matrix.GetLength(1); j++)
        {
            if(i == 0)
            {                
                minStringSum += matrix[i, j];
                stringSum += matrix[i, j];
            }
            else
                stringSum += matrix[i, j];
        }
        if(minStringSum > stringSum)
        {
            rowIndex = i + 1;
            minStringSum = stringSum;
        }
     }
    return rowIndex;
}
int[] arrayParameters = ArrayParametersInput();
int result = LesserStringSum(CreateArray(arrayParameters[0],    
                                         arrayParameters[1],    
                                         arrayParameters[2],    
                                         arrayParameters[3]     
                                         ));
Console.WriteLine($"Наименьшая сумма элементов в {result} строке.");
*/


// Задача 62

int[,] CreateSpriralArray(int m, int n)
{
    int[,] array = new int[m, n];
    int row = 0, column = 0, deltaCol = 1, deltaRow = 0, limit = 0, way = 0, tmp = m;
    // way: right (1-4) 0, down (5-7) 1, left (8-10) 2, up (11-12) 3, right(13-14) 4, down(15) 5, left(16) 6
    limit = n;

    for (int i = 0; i < m * n; i++)
    {
        array[row, column] = i + 1;

        limit--;
        if(limit == 0 && way%2 == 0)
        {
            limit = m - way / 2 - 1;
            (deltaCol, deltaRow) = (-deltaRow, deltaCol);   // swap axis
            way++;
        }
        if(limit == 0 && way%2 != 0)
        {
            limit = n - way / 2 -1;
            (deltaCol, deltaRow) = (-deltaRow, deltaCol);
            way++;
        }
        row += deltaRow;
        column += deltaCol;

    }

    return array;
}

int rowsTask3 =0, colsTask3 = 0;
while (true)
{
    Console.Write("Введите количество строк (начиная с 1): ");
    rowsTask3 = Convert.ToInt32(Console.ReadLine());
    Console.Write("Введите количество столбцов (начиная с 1): ");
    colsTask3 = Convert.ToInt32(Console.ReadLine());
    if (rowsTask3 > 0 && colsTask3 > 0)
        break;
    else
        Console.WriteLine("Количество и строк и столбцов должно быть больше 0. Пожалуйста повторите попытку.");
}

PrintArray(CreateSpriralArray(rowsTask3, colsTask3));