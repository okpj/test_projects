using System.Text;

namespace MatrixTestApp.NEW;

public static class MatrixExtensions
{
    public static void InitTestMatrix(this Matrix matrix)
    {
        if (matrix.Type == MatrixType.integer)
        {
            for (int i = 0; i < matrix.RowCount; i++)
            {
                for (int j = 0; j < matrix.ColCount; j++)
                {
                    matrix.IntMatrix[i, j] = (i + 1) * (j + 1);
                }
            }
        }
        else if (matrix.Type == MatrixType.vector)
        {
            for (int i = 0; i < matrix.RowCount; i++)
            {
                for (int j = 0; j < matrix.ColCount; j++)
                {
                    matrix.VectorMatrix[i, j] = new Vector((i + 1) * (j + 1), (i + 1) * (j + 1));
                }
            }
        }

        else if (matrix.Type == MatrixType.complex)
        {
            for (int i = 0; i < matrix.RowCount; i++)
            {
                for (int j = 0; j < matrix.ColCount; j++)
                {
                    matrix.ComplexMatrix[i, j] = new Complex((i + 1) * (j + 1), (i + 1) * (j + 1));
                }
            }
        }
    }


    public static string MatrixToString(this Matrix matrix)
    {
        StringBuilder stringBuilder = new StringBuilder();
        if (matrix.Type == MatrixType.integer)
        {
            for (int i = 0; i < matrix.RowCount; i++)
            {
                for (int j = 0; j < matrix.ColCount; j++)
                {
                    stringBuilder.AppendFormat("{0} ", matrix.IntMatrix[i, j]);
                }
                stringBuilder.AppendLine();
            }
        }
        else if (matrix.Type == MatrixType.vector)
        {
            for (int i = 0; i < matrix.RowCount; i++)
            {
                for (int j = 0; j < matrix.ColCount; j++)
                {
                    stringBuilder.AppendFormat("({0}, {1}) ",
                        matrix.VectorMatrix[i, j].X, matrix.VectorMatrix[i, j].Y);
                }
                stringBuilder.AppendLine();
            }
        }
        else if (matrix.Type == MatrixType.complex)
        {
            for (int i = 0; i < matrix.RowCount; i++)
            {
                for (int j = 0; j < matrix.ColCount; j++)
                {
                    stringBuilder.AppendFormat("({0}, {1}) ",
                      matrix.ComplexMatrix[i, j].Re, matrix.ComplexMatrix[i, j].Im);
                }
                stringBuilder.AppendLine();
            }
        }

        return stringBuilder.ToString();
    }
}
