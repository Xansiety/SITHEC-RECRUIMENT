namespace RecruitmentSITHEC.Helpers.Abstracts;

public abstract class BaseCalculation
{
    public abstract double Calculate(double a, double b, double c);
}


public class Addition : BaseCalculation
{
    public override double Calculate(double numberA, double numberB, double numberC)
    {
        return numberA + numberB + numberC;
    }
}


public class Subtraction : BaseCalculation
{
    public override double Calculate(double numberA, double numberB, double numberC)
    {
        return numberA - numberB - numberC;
    }
}


public class Multiplication : BaseCalculation
{
    public override double Calculate(double numberA, double numberB, double numberC)
    {
        return numberA * numberB * numberC;
    }
}


public class Division : BaseCalculation
{
    public override double Calculate(double numberA, double numberB, double numberC)
    {
        return numberA / numberB / numberC;
    }
}