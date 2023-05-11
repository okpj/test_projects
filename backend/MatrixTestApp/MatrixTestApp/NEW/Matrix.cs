namespace MatrixTestApp.NEW;

public class Matrix
{
    public uint RowCount { get; }
    public uint ColCount { get; }

    public MatrixType Type { get; }

    public int[,] IntMatrix { get; }
    public Vector[,] VectorMatrix { get; }
    public Complex[,] ComplexMatrix { get; }


    public Matrix(uint rows, uint cols, MatrixType type)
    {
        RowCount = rows;
        ColCount = cols;
        Type = type;

        switch (type)
        {
            case MatrixType.integer:
                IntMatrix = new int[rows, cols];
                break;
            case MatrixType.vector:
                VectorMatrix = new Vector[rows, cols];
                break;
            case MatrixType.complex:
                ComplexMatrix = new Complex[rows, cols];
                break;
        }
    }


    public Matrix Multiply(Matrix matrix)
    {
        if (ColCount != matrix.RowCount)
            throw new Exception("Число столбцов первой матрицы должно совпадать с числом строк второй матрицы");

        return Type switch
        {
            MatrixType.integer => MultiplyInteger(matrix),
            MatrixType.vector => MultiplyVector(matrix),
            MatrixType.complex => MultiplyComplex(matrix),
            _ => throw new ArgumentException("Тип элементов матрицы не поддерживается"),
        };
    }


    private Matrix MultiplyInteger(Matrix matrix)
    {
        var result = new Matrix(RowCount, matrix.ColCount, Type);
        for (int i = 0; i < RowCount; i++)
        {
            for (int j = 0; j < matrix.ColCount; j++)
            {
                for (int k = 0; k < matrix.RowCount; k++)
                {
                    result.IntMatrix[i, j] += IntMatrix[i, k] * matrix.IntMatrix[k, j];
                }
            }
        }
        return result;
    }

    private Matrix MultiplyVector(Matrix matrix)
    {
        var result = new Matrix(RowCount, matrix.ColCount, Type);
        for (int i = 0; i < RowCount; i++)
        {
            for (int j = 0; j < matrix.ColCount; j++)
            {
                for (int k = 0; k < matrix.RowCount; k++)
                {
                    result.VectorMatrix[i, j] += VectorMatrix[i, k] * matrix.VectorMatrix[k, j];
                }
            }
        }
        return result;
    }

    private Matrix MultiplyComplex(Matrix matrix)
    {
        var result = new Matrix(RowCount, matrix.ColCount, Type);
        for (int i = 0; i < RowCount; i++)
        {
            for (int j = 0; j < matrix.ColCount; j++)
            {
                for (int k = 0; k < matrix.RowCount; k++)
                {
                    result.ComplexMatrix[i, j] += ComplexMatrix[i, k] * matrix.ComplexMatrix[k, j];
                }
            }
        }
        return result;
    }

}
