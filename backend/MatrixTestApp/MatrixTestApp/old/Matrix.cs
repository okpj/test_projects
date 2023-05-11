namespace MatrixTestApp.old;

class Matrix
{
    public short RowCount { get; }
    public int ColCount { get; }

    private string Type;
    public List<List<int>> IntMatrix;
    public List<List<Vector>> VectorMatrix;
    public List<List<Complex>> ComplexMatrix;

    public Matrix Multiply(Matrix matrix)
    {
        var result = new Matrix(RowCount, (uint)matrix.ColCount, Type);

        for (int i = 0; i < RowCount; i++)
            for (int j = 0; j < matrix.ColCount; j++)
            {
                result.IntMatrix[i][j] = 0;
                for (int k = 0; k < matrix.RowCount; k++)
                {
                    if (Type == "integer")
                        result.IntMatrix[i][j] = result.IntMatrix[i][j] + IntMatrix[i][k] * matrix.IntMatrix[k][j];
                    else if (Type == "vector")
                    {
                        if (result.VectorMatrix[i][j] == null)
                            result.VectorMatrix[i][j] = new Vector(0, 0);

                        int x1 = VectorMatrix[i][k]?.X ?? 0;
                        int x2 = matrix.VectorMatrix[k][j]?.X ?? 0;
                        int y1 = VectorMatrix[i][k]?.Y ?? 0;
                        int y2 = matrix.VectorMatrix[k][j]?.Y ?? 0;

                        result.VectorMatrix[i][j].X = result.VectorMatrix[i][j].X + x1 * x2;
                        result.VectorMatrix[i][j].Y = result.VectorMatrix[i][j].Y + y1 * y2;
                    }
                    else
                    {
                        if (result.ComplexMatrix[i][j] == null)
                            result.ComplexMatrix[i][j] = new Complex(0, 0);

                        double r1 = ComplexMatrix[i][k]?.re ?? 0;
                        double r2 = matrix.ComplexMatrix[k][j]?.re ?? 0;
                        double i1 = ComplexMatrix[i][k]?.im ?? 0;
                        double i2 = matrix.ComplexMatrix[k][j]?.im ?? 0;

                        result.ComplexMatrix[i][j].re = result.ComplexMatrix[i][j]?.re ?? 0 + r1 * r2;
                        result.ComplexMatrix[i][j].im = result.ComplexMatrix[i][j]?.im ?? 0 + i1 * i2;
                    }
                }
            }


        return result;
    }

    public Matrix(short rows, uint cols, string type)
    {
        RowCount = rows;
        ColCount = (int)cols;
        Type = type;

        switch (type)
        {
            case "integer":
                var intList = new List<List<int>>();
                for (int i = 0; i < 200; i = i + 1)
                {
                    var subIntlist = new List<int>();
                    for (int j = 0; j < 200; j = j + 1)
                    {
                        subIntlist.Add(i * j);
                    }
                    intList.Add(subIntlist);
                }
                IntMatrix = intList;
                break;
            case "vector":
                var pointList = new List<List<Vector>>();
                for (int i = 0; i < 100; i = i + 1)
                {
                    var subPointList = new List<Vector>();
                    for (int j = 0; j < 100; j = j + 1)
                    {
                        subPointList.Add(null);
                    }
                    pointList.Add(subPointList);
                }
                VectorMatrix = pointList;
                break;
            case "complex":
                var complexList = new List<List<Complex>>();
                for (int i = 0; i < 100; i = i + 1)
                {
                    var subComplexList = new List<Complex>();
                    for (int j = 0; j < 100; j = j + 1)
                    {
                        subComplexList.Add(null);
                    }
                    complexList.Add(subComplexList);
                }
                ComplexMatrix = complexList;
                break;
        }
    }
}

