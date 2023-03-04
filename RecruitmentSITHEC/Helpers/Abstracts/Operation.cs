namespace RecruitmentSITHEC.Helpers.Abstracts;
public abstract class Operation
{
    public double a { get; set; }
    public double b { get; set; }
    //public double c { get; set; }
    public string Operator { get; set; }
    public abstract double CalculateValue();
}


public class Addition : Operation
{
    public override double CalculateValue()
    {
        return a + b;
    }
}

public class Subtraction : Operation
{
    public override double CalculateValue()
    {
        return a - b;
    }
}

public class Multiplication : Operation
{
    public override double CalculateValue()
    {
        return a * b;
    }
}

public class Division : Operation
{
    public override double CalculateValue()
    {
        return a / b;
    }
}