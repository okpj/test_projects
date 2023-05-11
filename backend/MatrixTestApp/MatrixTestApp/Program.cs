using MatrixTestApp.NEW;
using System.Diagnostics;


var matrix1 = new Matrix(101, 101, MatrixType.integer);
matrix1.InitTestMatrix();


var matrix2 = new Matrix(101, 101, MatrixType.integer);
matrix2.InitTestMatrix();

var resNew = matrix1.Multiply(matrix2);
Console.WriteLine("END");


//Console.WriteLine(resNew.MatrixToString());

Console.ReadLine();
