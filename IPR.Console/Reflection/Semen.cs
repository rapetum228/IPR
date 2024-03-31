using System.Reflection.Emit;
using System.Reflection;

namespace IPR.MyConsole.Reflection;

public class Semen
{
    protected string name = "Semen батя";

    public void Show()
    {
        Console.WriteLine("Привет " + name);
    }

    public int InvokeOperation(int a, int b, string operation)
    {
        operation = operation.ToLower();

        if (operation == "add" || operation == "сложить")
        {
            return a + b;
        }
        else if (operation == "sub" || operation == "вычесть")
        {
            return a - b;
        }
        else if (operation == "mul" || operation == "умножить")
        {
            return a * b;
        }

        throw new ArgumentException("Нет такой операции!");
    }

    public int InvokeReflection()
    {
        Type baseType = typeof(Semen);

        // Создаем динамическую сборку и модуль
        AssemblyName assemblyName = new AssemblyName("DynamicAssembly");
        AssemblyBuilder assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
        ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule("DynamicModule");

        // Создаем новый тип (наследника) с помощью TypeBuilder
        TypeBuilder typeBuilder = moduleBuilder.DefineType("MySemen", TypeAttributes.Public | TypeAttributes.Class, baseType);

        // Создаем метод InvokeOperation
        MethodBuilder methodBuilder = typeBuilder.DefineMethod("InvokeOperation", MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.Virtual, typeof(int), new Type[] { typeof(int), typeof(int), typeof(string) });
        ILGenerator ilGenerator = methodBuilder.GetILGenerator();

        // Создаем метки для условий
        Label addLabel = ilGenerator.DefineLabel();
        Label subLabel = ilGenerator.DefineLabel();
        Label mulLabel = ilGenerator.DefineLabel();
        Label defaultLabel = ilGenerator.DefineLabel();

        // Загружаем аргумент operation на стек
        ilGenerator.Emit(OpCodes.Ldarg_3);
        // Преобразуем операцию к нижнему регистру
        ilGenerator.Emit(OpCodes.Call, typeof(string).GetMethod("ToLower", Type.EmptyTypes));

        // Проверяем операцию на равенство с каждым из возможных значений
        ilGenerator.Emit(OpCodes.Ldstr, "add");
        ilGenerator.Emit(OpCodes.Ldstr, "сложить");
        ilGenerator.Emit(OpCodes.Call, typeof(string).GetMethod("op_Equality", new Type[] { typeof(string), typeof(string) }));
        ilGenerator.Emit(OpCodes.Brtrue, addLabel);

        ilGenerator.Emit(OpCodes.Ldstr, "sub");
        ilGenerator.Emit(OpCodes.Ldstr, "вычесть");
        ilGenerator.Emit(OpCodes.Call, typeof(string).GetMethod("op_Equality", new Type[] { typeof(string), typeof(string) }));
        ilGenerator.Emit(OpCodes.Brtrue, subLabel);

        ilGenerator.Emit(OpCodes.Ldstr, "mul");
        ilGenerator.Emit(OpCodes.Ldstr, "умножить");
        ilGenerator.Emit(OpCodes.Call, typeof(string).GetMethod("op_Equality", new Type[] { typeof(string), typeof(string) }));
        ilGenerator.Emit(OpCodes.Brtrue, mulLabel);

        // Если ни одно условие не выполнено, выбрасываем ArgumentException
        ilGenerator.Emit(OpCodes.Newobj, typeof(ArgumentException).GetConstructor(Type.EmptyTypes));
        ilGenerator.Emit(OpCodes.Throw);

        // Метка для операции сложения
        ilGenerator.MarkLabel(addLabel);
        ilGenerator.Emit(OpCodes.Ldarg_1);
        ilGenerator.Emit(OpCodes.Ldarg_2);
        ilGenerator.Emit(OpCodes.Add);
        ilGenerator.Emit(OpCodes.Ret);

        // Метка для операции вычитания
        ilGenerator.MarkLabel(subLabel);
        ilGenerator.Emit(OpCodes.Ldarg_1);
        ilGenerator.Emit(OpCodes.Ldarg_2);
        ilGenerator.Emit(OpCodes.Sub);
        ilGenerator.Emit(OpCodes.Ret);

        // Метка для операции умножения
        ilGenerator.MarkLabel(mulLabel);
        ilGenerator.Emit(OpCodes.Ldarg_1);
        ilGenerator.Emit(OpCodes.Ldarg_2);
        ilGenerator.Emit(OpCodes.Mul);
        ilGenerator.Emit(OpCodes.Ret);

        // Создаем тип из построенного TypeBuilder
        Type mySemenType = typeBuilder.CreateType();

        // Создаем экземпляр наследника
        object mySemenInstance = Activator.CreateInstance(mySemenType);

        // Вызываем метод InvokeOperation на экземпляре наследника
        MethodInfo invokeOperationMethod = mySemenType.GetMethod("InvokeOperation");
        int result = (int)invokeOperationMethod.Invoke(mySemenInstance, new object[] { 5, 3, "сложить" });
        Console.WriteLine("Результат операции: " + result);

        return result;
    }
}
