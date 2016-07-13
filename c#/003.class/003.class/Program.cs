using System;

public class SquareSample
{
    public int CalcSquare(int nSideLength)
    {
        return nSideLength * nSideLength;
    }
}

class SquareApp
{
    public static void Main()
    {
        SquareSample sq = new SquareSample();
        Console.WriteLine(sq.CalcSquare(25).ToString());
    }
}