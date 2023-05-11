namespace MatrixTestApp.NEW;

public struct Complex
{
    public double Re;
    public double Im;

    public Complex(double r, double i)
    {
        Re = r;
        Im = i;
    }

    public static Complex operator +(Complex a, Complex b) => new Complex(a.Re + b.Re, a.Im + b.Im);

    public static Complex operator *(Complex a, Complex b) => new Complex(a.Re * b.Re, a.Im * b.Im);
}
