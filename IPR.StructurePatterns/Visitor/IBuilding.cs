namespace IPR.StructurePatterns.Visitor;

public interface IBuilding
{
    void Accept(IVisitor visitor);
}

public class House : IBuilding
{
    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}

public class Bar : IBuilding
{
    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}

public class Basement : IBuilding
{
    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}