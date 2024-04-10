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

        throw new ArgumentException("Нет такой операции гнида!");
    }

    public int InvokeReflection()
    {
        #region ass
        // Создаем динамическую сборку и модуль
        AssemblyName assemblyName = new AssemblyName("DynamicAssembly");
        AssemblyBuilder assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
        ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule("DynamicModule");

        //создаём новый тип спермёна
        TypeBuilder typeBuilder = moduleBuilder.DefineType("spermanin");

        //создаём метод
        MethodBuilder methodBuilder = typeBuilder.DefineMethod("InvokeOperation", MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.Virtual, typeof(int), new Type[] { typeof(int), typeof(int), typeof(int) });
        ILGenerator ilGenerator = methodBuilder.GetILGenerator();
        #endregion
        var mulLabel = ilGenerator.DefineLabel();
        Label addLabel = ilGenerator.DefineLabel(); //метка для сложения
        ilGenerator.Emit(OpCodes.Ldarg_3); //загрузка на стек третьего аргумента
        ilGenerator.Emit(OpCodes.Ldc_I4, 1); //загрузка 1
        ilGenerator.Emit(OpCodes.Beq, addLabel); //если равны скачем к лейблу сложения

        //аналогично для вычитания
        Label subLabel = ilGenerator.DefineLabel();
        ilGenerator.Emit(OpCodes.Ldarg_3);
        ilGenerator.Emit(OpCodes.Ldc_I4, 2);
        ilGenerator.Emit(OpCodes.Beq, subLabel);

        ilGenerator.Emit(OpCodes.Ldarg, 3);
        ilGenerator.Emit(OpCodes.Ldc_I4, 3);
        ilGenerator.Emit(OpCodes.Beq, mulLabel);

        //дальше эксепшен ArgumentException
        ilGenerator.Emit(OpCodes.Newobj, typeof(ArgumentException).GetConstructor(Type.EmptyTypes));
        ilGenerator.Emit(OpCodes.Throw);

        //метка для сложения
        ilGenerator.MarkLabel(addLabel);
        ilGenerator.Emit(OpCodes.Ldarg_1);
        ilGenerator.Emit(OpCodes.Ldarg_2);
        ilGenerator.Emit(OpCodes.Add);
        ilGenerator.Emit(OpCodes.Ret);

        //метка для вычитания
        ilGenerator.MarkLabel(subLabel);
        ilGenerator.Emit(OpCodes.Ldarg_1);
        ilGenerator.Emit(OpCodes.Ldarg_2);
        ilGenerator.Emit(OpCodes.Sub);
        ilGenerator.Emit(OpCodes.Ret);

        //умножить
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
        int result = (int)invokeOperationMethod.Invoke(mySemenInstance, new object[] { 5, 112, 2 });
        Console.WriteLine("Результат операции: " + result);

        return result;
    }

    public void InvokeFor()
    {
        #region ass
        // Создаем динамическую сборку и модуль
        AssemblyName assemblyName = new AssemblyName("DynamicAssembly");
        AssemblyBuilder assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
        ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule("DynamicModule");

        //создаём новый тип спермёна
        TypeBuilder typeBuilder = moduleBuilder.DefineType("spermanin");

        //создаём метод
        MethodBuilder methodBuilder = typeBuilder.DefineMethod("InvokeFor", MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.Virtual, typeof(int), new Type[] { typeof(int), typeof(int)});
        ILGenerator ilGenerator = methodBuilder.GetILGenerator();
        #endregion
        // Создание переменных метода
        LocalBuilder result = ilGenerator.DeclareLocal(typeof(int));
        LocalBuilder i = ilGenerator.DeclareLocal(typeof(int));

        // Инициализация переменных
        ilGenerator.Emit(OpCodes.Ldc_I4_0); // Загрузка константы 0 на стек
        ilGenerator.Emit(OpCodes.Stloc, result); // Сохранение значения на стеке в переменной result

        // Начало цикла
        Label loopCheck = ilGenerator.DefineLabel();
        Label loopBody = ilGenerator.DefineLabel();
        ilGenerator.Emit(OpCodes.Ldc_I4_0); // Загрузка константы 0 на стек
        ilGenerator.Emit(OpCodes.Stloc, i); // Сохранение значения на стеке в переменной i
        ilGenerator.Emit(OpCodes.Br, loopCheck); // Безусловный переход к метке loopCheck

        // Часть условия цикла
        ilGenerator.MarkLabel(loopBody);
        ilGenerator.Emit(OpCodes.Ldloc, result); // Загрузка значения переменной result на стек
        ilGenerator.Emit(OpCodes.Ldloc, i); // Загрузка значения переменной i на стек
        ilGenerator.Emit(OpCodes.Add); // Сложение двух верхних значений на стеке
        ilGenerator.Emit(OpCodes.Stloc, result); // Сохранение результата в переменной result

        // Увеличение переменной i
        ilGenerator.Emit(OpCodes.Ldloc, i); // Загрузка значения переменной i на стек
        ilGenerator.Emit(OpCodes.Ldc_I4_1); // Загрузка константы 1 на стек
        ilGenerator.Emit(OpCodes.Add); // Сложение двух верхних значений на стеке
        ilGenerator.Emit(OpCodes.Stloc, i); // Сохранение результата в переменной i

        // Проверка условия цикла
        ilGenerator.MarkLabel(loopCheck);
        ilGenerator.Emit(OpCodes.Ldloc, i); // Загрузка значения переменной i на стек
        ilGenerator.Emit(OpCodes.Ldarg_1); // Загрузка значения параметра a на стек
        ilGenerator.Emit(OpCodes.Blt, loopBody); // Условный переход к метке loopBody, если i < a

        // Загрузка значения result на стек и возврат из метода
        ilGenerator.Emit(OpCodes.Ldloc, result); // Загрузка значения переменной result на стек
        ilGenerator.Emit(OpCodes.Ret); // Возврат значения из метода


        // Создаем тип из построенного TypeBuilder
        Type mySemenType = typeBuilder.CreateType();

        // Создаем экземпляр наследника
        object mySemenInstance = Activator.CreateInstance(mySemenType);

        // Вызываем метод InvokeOperation на экземпляре наследника
        MethodInfo invokeOperationMethod = mySemenType.GetMethod("InvokeFor");

        int asfas = (int)invokeOperationMethod.Invoke(mySemenInstance, new object[] { 15 });

        Console.WriteLine("Результат операции: " + asfas);
    }

    public void InvokeWhile()
    {
        #region ass
        // Создаем динамическую сборку и модуль
        AssemblyName assemblyName = new AssemblyName("testAss");
        AssemblyBuilder assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
        ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule("testModule");

        //создаём новый тип спермёна
        TypeBuilder typeBuilder = moduleBuilder.DefineType("spermanin");

        //создаём метод
        MethodBuilder methodBuilder = typeBuilder.DefineMethod("InvokeFor", MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.Virtual, typeof(int), new Type[] { typeof(int) });
        ILGenerator ilGenerator = methodBuilder.GetILGenerator();
        #endregion

        // Создание переменных метода
        LocalBuilder result = ilGenerator.DeclareLocal(typeof(int));
        LocalBuilder loopVar = ilGenerator.DeclareLocal(typeof(int));

        // Инициализация переменных
        ilGenerator.Emit(OpCodes.Ldc_I4_0); // Загрузка константы 0 на стек
        ilGenerator.Emit(OpCodes.Stloc, result); // Сохранение значения на стеке в переменной result

        // Начало цикла
        Label loopCheck = ilGenerator.DefineLabel();
        Label loopBody = ilGenerator.DefineLabel();
        ilGenerator.Emit(OpCodes.Br, loopCheck); // Безусловный переход к метке loopCheck

        // Тело цикла
        ilGenerator.MarkLabel(loopBody);
        ilGenerator.Emit(OpCodes.Ldloc, result); // Загрузка значения переменной result на стек
        ilGenerator.Emit(OpCodes.Ldloc, loopVar); // Загрузка значения переменной loopVar на стек
        ilGenerator.Emit(OpCodes.Add); // Сложение двух верхних значений на стеке
        ilGenerator.Emit(OpCodes.Stloc, result); // Сохранение результата в переменной result

        // Уменьшение переменной a
        ilGenerator.Emit(OpCodes.Ldloc, loopVar); // Загрузка значения переменной loopVar на стек
        ilGenerator.Emit(OpCodes.Ldc_I4_1); // Загрузка константы 1 на стек
        ilGenerator.Emit(OpCodes.Sub); // Вычитание двух верхних значений на стеке
        ilGenerator.Emit(OpCodes.Stloc, loopVar); // Сохранение результата в переменной loopVar

        // Проверка условия цикла
        ilGenerator.MarkLabel(loopCheck);
        ilGenerator.Emit(OpCodes.Ldloc, loopVar); // Загрузка значения переменной loopVar на стек
        ilGenerator.Emit(OpCodes.Ldc_I4_0); // Загрузка константы 0 на стек
        ilGenerator.Emit(OpCodes.Bgt, loopBody); // Условный переход к метке loopBody, если loopVar > 0

        // Загрузка значения result на стек и возврат из метода
        ilGenerator.Emit(OpCodes.Ldloc, result); // Загрузка значения переменной result на стек
        ilGenerator.Emit(OpCodes.Ret); // Возврат значения из метода


        // Создаем тип из построенного TypeBuilder
        Type mySemenType = typeBuilder.CreateType();

        // Создаем экземпляр наследника
        object mySemenInstance = Activator.CreateInstance(mySemenType);

        // Вызываем метод InvokeOperation на экземпляре наследника
        MethodInfo invokeOperationMethod = mySemenType.GetMethod("InvokeFor");

        int asfas = (int)invokeOperationMethod.Invoke(mySemenInstance, new object[] { 15 });

        Console.WriteLine("Результат операции: " + asfas);
    }

    public void InvokeWhile2args()
    {
        #region ass
        // Создаем динамическую сборку и модуль
        AssemblyName assemblyName = new AssemblyName("testAss");
        AssemblyBuilder assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
        ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule("testModule");

        //создаём новый тип спермёна
        TypeBuilder typeBuilder = moduleBuilder.DefineType("spermanin");

        //создаём метод
        MethodBuilder methodBuilder = typeBuilder.DefineMethod("InvokeFor", MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.Virtual, typeof(int), new Type[] { typeof(int), typeof(int) });
        ILGenerator ilGenerator = methodBuilder.GetILGenerator();
        #endregion


        LocalBuilder result = ilGenerator.DeclareLocal(typeof(int));
        LocalBuilder loopVar = ilGenerator.DeclareLocal(typeof(int));

        Label loopCheck = ilGenerator.DefineLabel();
        Label loopBody = ilGenerator.DefineLabel();
        

        ilGenerator.Emit(OpCodes.Ldarg_1);
        ilGenerator.Emit(OpCodes.Stloc, loopVar);

        ilGenerator.Emit(OpCodes.Ldc_I4, 0);
        ilGenerator.Emit(OpCodes.Stloc, result);

        //сравнение 1 и 2, и если 2 меньше 1, то выход иначе на метку проверки цикла
        ilGenerator.Emit(OpCodes.Ldarg_1);
        ilGenerator.Emit(OpCodes.Ldarg_2);
        ilGenerator.Emit(OpCodes.Ble, loopCheck);
        ilGenerator.Emit(OpCodes.Ldarg_1);
        ilGenerator.Emit(OpCodes.Ldarg_2);
        ilGenerator.Emit(OpCodes.Sub);
        ilGenerator.Emit(OpCodes.Ret);

        //грузим на стек переменную цикла и 2 арг
        ilGenerator.MarkLabel(loopCheck);
        ilGenerator.Emit(OpCodes.Ldloc, loopVar);
        ilGenerator.Emit(OpCodes.Ldarg_2);
        //если ПЦ < 2, то идём в цикл
        ilGenerator.Emit(OpCodes.Ble, loopBody);
        ilGenerator.Emit(OpCodes.Ldloc, result);
        ilGenerator.Emit(OpCodes.Ret);

        ilGenerator.MarkLabel(loopBody);
        //грузим на стек ПЦ и 1
        ilGenerator.Emit(OpCodes.Ldloc, loopVar);
        ilGenerator.Emit(OpCodes.Ldc_I4, 1);
        //отнимаем и пишем в ПЦ
        ilGenerator.Emit(OpCodes.Add);
        ilGenerator.Emit(OpCodes.Stloc, loopVar);

        //грузим result на стек и 1 arg
        ilGenerator.Emit(OpCodes.Ldloc, result);
        ilGenerator.Emit(OpCodes.Ldloc, loopVar);
        ilGenerator.Emit(OpCodes.Add);
        ilGenerator.Emit(OpCodes.Stloc, result);
        ilGenerator.Emit(OpCodes.Br, loopCheck);

        // Создаем тип из построенного TypeBuilder
        Type mySemenType = typeBuilder.CreateType();

        // Создаем экземпляр наследника
        object mySemenInstance = Activator.CreateInstance(mySemenType);

        // Вызываем метод InvokeOperation на экземпляре наследника
        MethodInfo invokeOperationMethod = mySemenType.GetMethod("InvokeFor");

        int asfas = (int)invokeOperationMethod.Invoke(mySemenInstance, new object[] { 12, 15 });

        Console.WriteLine("Результат операции: " + asfas);
    }
}
