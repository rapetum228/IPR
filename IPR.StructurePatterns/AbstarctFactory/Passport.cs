namespace IPR.StructurePatterns.AbstarctFactory;

public abstract class Passport
{
    public abstract string GetName();

    public abstract string GetSurname();
}

public class GeteroPassport : Passport
{
    public override string GetName() => "Волк";


    public override string GetSurname() => "Змеедав";
}

public class PidorPassport : Passport
{
    public override string GetName() => "Semen";

    public override string GetSurname() => "Спермахлеб";
}