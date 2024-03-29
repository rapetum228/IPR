namespace IPR.StructurePatterns.AbstarctFactory;

public abstract class Body
{
    public abstract string GetHead();

    public abstract string GetBody();
}

public  class HumanBody: Body
{
    public override string GetHead() => "😎";

    public override string GetBody() => "💪🏻🤙🏻🥃";
}


public  class PidorBody: Body
{
    public override string GetHead()=> "🥳";

    public override string GetBody()=> "🤸🏻‍";
}
