namespace RecruitmentSITHEC.Helpers.Abstracts;
 
public class AdditionCalculation
{
    public AdditionCalculation(double numberA, double numberB)
    {
        this.NumberB = numberB;
        this.NumberA = numberA;
    }
    public double NumberA { get; set; }
    public double NumberB { get; set; }
    public virtual double Calculate()
    {
        return this.NumberA + NumberB;
    }
}
public class SubtractionCalculation : AdditionCalculation
{
    public SubtractionCalculation(double numberA, double numberB) : base(numberA, numberB)
    {
    }

    public new double Calculate()
    {
        return NumberA - NumberB;
    }
}


public class MultiplicationCalculation : AdditionCalculation
{
    public MultiplicationCalculation(double numberA, double numberB) : base(numberA, numberB)
    {
    }

    public new double Calculate()
    {
        return NumberA * NumberB;
    }
}

public class DivisionCalculation : AdditionCalculation
{
    public DivisionCalculation(double numberA, double numberB) : base(numberA, numberB)
    {
    }

    public new double Calculate()
    {
        return NumberA / NumberB;
    }
}

//public abstract class BaseCalculation
//{
//    public abstract double Calculate(double a, double b, double c);
//}


//public class Addition : BaseCalculation
//{
//    public override double Calculate(double numberA, double numberB, double numberC)
//    {
//        return numberA + numberB + numberC;
//    }
//}


//public class Subtraction : BaseCalculation
//{
//    public override double Calculate(double numberA, double numberB, double numberC)
//    {
//        return numberA - numberB - numberC;
//    }
//}


//public class Multiplication : BaseCalculation
//{
//    public override double Calculate(double numberA, double numberB, double numberC)
//    {
//        return numberA * numberB * numberC;
//    }
//}


//public class Division : BaseCalculation
//{
//    public override double Calculate(double numberA, double numberB, double numberC)
//    {
//        return numberA / numberB / numberC;
//    }
//}