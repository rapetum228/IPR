using System.Reflection;
using System.Reflection.Emit;
using System.Text;
namespace IPR.MyConsole.Reflection;

/// <summary>
/// Основная задача рефлексии - исследование типов
/// </summary>
public class TypeResearcher
{

    private TypeResearcher(int a)
    {

    }


    public TypeResearcher(string a)
    {

    }

    public static async Task ShowTypeInfo(Type type)
    {
        Console.WriteLine($"Assemply: {type.Assembly.FullName}");

        Console.WriteLine($"===============================================================================================");
        Console.WriteLine($"Метод FindMembers() возвращает массив объектов MemberInfo данного типа");
        Console.WriteLine();
        //foreach (var member in type.FindMembers())
        //{
        //    Console.WriteLine($"{member.Name} : {member.MemberType}");
        //}

        Console.WriteLine($"===============================================================================================");
        Console.WriteLine($"Метод GetConstructors() возвращает все конструкторы данного типа в виде набора объектов ConstructorInfo");
        Console.WriteLine();
        foreach (var member in type.GetConstructors(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Default))
        {
            Console.WriteLine($"{member.Name} : {member.MemberType}");
        }
        Console.WriteLine($"===============================================================================================");
        Console.WriteLine($"Метод GetEvents() возвращает все события данного типа в виде массива объектов EventInfo");
        Console.WriteLine();
        foreach (var member in type.GetEvents())
        {
            Console.WriteLine($"{member.Name} : {member.MemberType}");
        }

        Console.WriteLine($"===============================================================================================");
        Console.WriteLine($"Метод GetFields() возвращает все поля данного типа в виде массива объектов FieldInfo");
        Console.WriteLine();
        foreach (var member in type.GetFields())
        {
            Console.WriteLine($"{member.Name} : {member.MemberType}");
        }

        Console.WriteLine($"===============================================================================================");
        Console.WriteLine($"Метод GetInterfaces() получает все реализуемые данным типом интерфейсы в виде массива объектов Type");
        Console.WriteLine();
        foreach (var member in type.GetInterfaces())
        {
            Console.WriteLine($"{member.Name} : {member.MemberType}");
        }

        Console.WriteLine($"===============================================================================================");
        Console.WriteLine($"Метод GetMembers() возвращает все члены типа в виде массива объектов MemberInfo");
        Console.WriteLine();
        foreach (var member in type.GetMembers())
        {
            Console.WriteLine($"{member.Name} : {member.MemberType}");
        }
        Console.WriteLine($"===============================================================================================");
        Console.WriteLine($"Метод GetMethods() получает все методы типа в виде массива объектов MethodInfo");
        Console.WriteLine();
        foreach (var member in type.GetMethods())
        {
            Console.WriteLine($"{member.Name} : {member.MemberType}");
        }

        Console.WriteLine($"===============================================================================================");
        Console.WriteLine($"Метод GetProperties() получает все свойства в виде массива объектов PropertyInfo ");
        Console.WriteLine();
        foreach (var member in type.GetProperties())
        {
            Console.WriteLine($"{member.Name} : {member.MemberType}");
        }

        Console.WriteLine($"===============================================================================================");
        Console.WriteLine($"Свойство Name возвращает имя типа");
        Console.WriteLine();
        foreach (var member in type.GetConstructors())
        {
            Console.WriteLine($"{member.Name} : {member.MemberType}");
        }

    }

    /*
     
     Type myType = typeof(TypeResearcher);

     var method = myType.GetMethod("GetMore", bindingAttr: BindingFlags.NonPublic|BindingFlags.Static);
     
     var c = myType.GetConstructor(types: new Type[] { typeof(int) }, 
                                   bindingAttr: BindingFlags.Instance | BindingFlags.NonPublic);
     
     var my = c.Invoke(new object[] { 10 });
     
     method.Invoke(obj:my, parameters: new object[] { new List<int> { 1 , 3, 5, 6, 6 }, 5 });
     */

    private static IEnumerable<int> GetMore(IEnumerable<int> list, int more)
    {
        MethodInfo whereMethod = typeof(Enumerable).GetMethods().First(m => m.Name == "Where" && m.GetParameters().Length == 2);

        whereMethod = whereMethod.MakeGenericMethod(typeof(int));

        var p = whereMethod.GetParameters();

        MethodInfo toArrayMethod = typeof(Enumerable).GetMethod(name: "ToArray",
           bindingAttr: BindingFlags.Public | BindingFlags.Static).MakeGenericMethod(typeof(int));

        IEnumerable<int> result = (IEnumerable<int>)whereMethod.Invoke(null, new object[] { list, new Func<int, bool>(i => i > more) });

        int[] array = (int[])toArrayMethod.Invoke(null, new object[] { result });


        return array;
    }

    /*
     
    var method = myType.GetMethod("GetSemenChild", BindingFlags.Public|BindingFlags.Static);

    var c = method.Invoke(null, null);
    
    c.GetType().GetMethod("Show").Invoke(c,null);
     
     */

    public static object? GetSemenChild()
    {
        // Получаем тип базового класса
        Type baseType = typeof(Semen);

        // Создаем динамическую сборку и модуль
        AssemblyName assemblyName = new AssemblyName("DynamicAssembly");
        AssemblyBuilder assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.RunAndCollect);
        ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule("DynamicModule");

        // Создаем новый тип (наследника) с помощью TypeBuilder
        TypeBuilder typeBuilder = moduleBuilder.DefineType("MySemen", TypeAttributes.Public | TypeAttributes.Class, baseType);

        // Создаем метод в наследнике
        MethodBuilder methodBuilder = typeBuilder.DefineMethod(name:"ShowSemenSon", 
           attributes: MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.Virtual, 
           returnType: typeof(void), 
           parameterTypes: Type.EmptyTypes);
        
        ILGenerator ilGenerator = methodBuilder.GetILGenerator();
        ilGenerator.Emit(OpCodes.Ldstr, "Привет, я пидор!");
        ilGenerator.Emit(OpCodes.Call, typeof(Console).GetMethod("WriteLine", new Type[] { typeof(string) }));
        ilGenerator.Emit(OpCodes.Ret);

        // Создаем тип из построенного TypeBuilder
        Type mySemenType = typeBuilder.CreateType();

        // Создаем экземпляр наследника
        object mySemenInstance = Activator.CreateInstance(mySemenType);

        return mySemenInstance;
    }


    public static void MsdnCodeInvoke()
    {
        Type myType = BuildMyType();

        Console.Write("Enter an integer between 0 and 5: ");
        int theValue = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("---");

        Object myInstance = Activator.CreateInstance(myType, new object[0]);

        Console.WriteLine("Yes, there {0} today!", myType.InvokeMember("SwitchMe",
                                   BindingFlags.InvokeMethod,
                                   null,
                                   myInstance,
                                   new object[] { theValue }));
    }

    public static string ToLower(string str)
    {
        var methods = typeof(string).GetMethods();
        var method = methods.First(x=>x.Name == "ToLower" && x.GetParameters().Length == 0);

        var result = (string)method.Invoke(str, null);

        return result;
    }

    public static Type BuildMyType()
    {
        AssemblyName myAsmName = new AssemblyName();
        
        myAsmName.Name = "MyDynamicAssembly";

        AssemblyBuilder myAsmBuilder = AssemblyBuilder.DefineDynamicAssembly(
                            myAsmName,
                            AssemblyBuilderAccess.Run);

        ModuleBuilder myModBuilder = myAsmBuilder.DefineDynamicModule(
                            "MyJumpTableDemo");

        //создание типа JumpTableDemo
        TypeBuilder myTypeBuilder = myModBuilder.DefineType("JumpTableDemo",
                                TypeAttributes.Public);

        //создание в нём публичного статического метода SwitchMe, который возвращает строку и принимает целое число
        MethodBuilder myMthdBuilder = myTypeBuilder.DefineMethod("SwitchMe",
                                 MethodAttributes.Public |
                                 MethodAttributes.Static,
                                                 typeof(string),
                                                 new Type[] { typeof(int) });

        //написание метода
        ILGenerator myIL = myMthdBuilder.GetILGenerator();

        Label defaultCase = myIL.DefineLabel(); //лейбл метода
        Label endOfMethod = myIL.DefineLabel(); //лейбл выхода из метода

        // инициализация таблицы переходов
        Label[] jumpTable = new Label[] { myIL.DefineLabel(),
                      myIL.DefineLabel(),
                      myIL.DefineLabel(),
                      myIL.DefineLabel(),
                      myIL.DefineLabel() };

        // arg0, the number we passed, is pushed onto the stack.
        // In this case, due to the design of the code sample,
        // the value pushed onto the stack happens to match the
        // index of the label (in IL terms, the index of the offset
        // in the jump table). If this is not the case, such as
        // when switching based on non-integer values, rules for the correspondence
        // between the possible case values and each index of the offsets
        // must be established outside of the ILGenerator.Emit calls,
        // much as a compiler would.

        myIL.Emit(OpCodes.Ldarg_0);
        myIL.Emit(OpCodes.Switch, jumpTable);

        // Branch on default case
        myIL.Emit(OpCodes.Br_S, defaultCase);

        // Case arg0 = 0
        myIL.MarkLabel(jumpTable[0]);
        myIL.Emit(OpCodes.Ldstr, "are no bananas");
        myIL.Emit(OpCodes.Br_S, endOfMethod);

        // Case arg0 = 1
        myIL.MarkLabel(jumpTable[1]);
        myIL.Emit(OpCodes.Ldstr, "is one banana");
        myIL.Emit(OpCodes.Br_S, endOfMethod);

        // Case arg0 = 2
        myIL.MarkLabel(jumpTable[2]);
        myIL.Emit(OpCodes.Ldstr, "are two bananas");
        myIL.Emit(OpCodes.Br_S, endOfMethod);

        // Case arg0 = 3
        myIL.MarkLabel(jumpTable[3]);
        myIL.Emit(OpCodes.Ldstr, "are three bananas");
        myIL.Emit(OpCodes.Br_S, endOfMethod);

        // Case arg0 = 4
        myIL.MarkLabel(jumpTable[4]);
        myIL.Emit(OpCodes.Ldstr, "are four bananas");
        myIL.Emit(OpCodes.Br_S, endOfMethod);

        // Default case
        myIL.MarkLabel(defaultCase);
        myIL.Emit(OpCodes.Ldstr, "are many bananas");

        myIL.MarkLabel(endOfMethod);
        myIL.Emit(OpCodes.Ret);

        return myTypeBuilder.CreateType();
    }
}
