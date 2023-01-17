using ExercicioReflection;
using System.Reflection;

Student student = new Student();
Console.WriteLine("Método que mostra as propriedades públicas da classe:");
DisplayPublicProperties(student);


Console.WriteLine("Aperte ENTER para continuar;");
Console.ReadLine();
Console.Clear();

Type type = student.GetType();
object[] parametros = new object[] { "Guilherme", "Universidade de São Paulo", 104154 };
object instanciado = Activator.CreateInstance(type);

PropertyInfo propNome = type.GetProperty("Name");
propNome.SetValue(instanciado, "Guilherme Laranjeira", null);

PropertyInfo propUniversidade = type.GetProperty("University");
propUniversidade.SetValue(instanciado, "USP", null);

PropertyInfo propRollNumber = type.GetProperty("RollNumber");
propRollNumber.SetValue(instanciado, 1234, null);


//PropertyInfo[] propriedades = type.GetProperties();

//foreach(PropertyInfo pi in propriedades)
//{
//    object propValue = pi.GetValue(instanciado);
//    Console.WriteLine($" - {pi.Name} :: {propValue}");
//}


MethodInfo mostrarMetodo = type.GetMethod("DisplayInfo");

Console.WriteLine("Mostrando método DisplayInfo através de reflection:");
object resultado = mostrarMetodo.Invoke(instanciado, null);







void DisplayPublicProperties(object obj)
{
    Type type = obj.GetType();
    Console.WriteLine($"Informações da classe {obj}");
    foreach (PropertyInfo prop in type.GetProperties())
    {
        Console.WriteLine(prop.Name);
    }
}