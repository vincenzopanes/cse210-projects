public class Fraction
{
    private int _top;
    private int _bottom;

    // Constructor 1 (1/1)
    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }

    // Constructor 2 (top/1)
    public Fraction(int top)
    {
        _top = top;
        _bottom = 1;
    }

    // Constructor 3 (top/bottom)
    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }

    //Getters
    public int GetTop()
    {
        return _top;
    }

    public int GetBottom()
    {
        return _bottom;
    }

    // Setters
    public void SetTop(int top)
    {
        _top = top;
    }

    public void SetBottom(int bottom)
    {
        _bottom = bottom;
    }

    //Return the fraction
    public string GetFractionString()
    {
        return $"{_top}/{_bottom}";
    }

    //Return the decimal value
    public double GetDecimalValue()
    {
        return (double)_top / _bottom;
    }
}