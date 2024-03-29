namespace OOP.Collections.OOP.ForRecords;

public class MethodsRecords
{
    public static CarRecordClass GetCarRecordClass(CarRecordClass car, string name)
    {
        CarRecordClass carRecordClass = car with { CarName = name };
        return carRecordClass;
    }

    public static SuperCarClass GetSuperCarClass(CarRecordClass car)
    {
        SuperCarClass super = new SuperCarClass(car.MaxImmutableSpeed, car.MaxImmutableSpeed*100)
        {
            CarName = car.CarName
        };
        
        return super;
    }
}
