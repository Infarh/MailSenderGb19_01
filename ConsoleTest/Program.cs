using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace ConsoleTest
{
    [Serializable]
    [Description("Класс главной программы")]
    internal class Program
    {
        private const string LibName = "ReflectionTestLib.dll";

        [Description("Точка входа в программу")]
        private static void Main([Description("Аргументы команной строки")] string[] args)
        {
            var lib_path = Path.Combine(Environment.CurrentDirectory, LibName);

            var assembly = Assembly.LoadFile(lib_path);
            //Assembly.ReflectionOnlyLoadFrom()

            Type printer_type = assembly.GetType("ReflectionTestLib.ConsolePrinter");

            var constructors = printer_type.GetConstructors();

            ConstructorInfo contructor1 = constructors[0];
            ConstructorInfo contructor2 = constructors[1];

            var printer1 = contructor1.Invoke(new object[0]);
            var printer2 = contructor2.Invoke(new object[] { ">>" });

            var printer3 = Activator.CreateInstance(printer_type);
            var printer4 = Activator.CreateInstance(printer_type, "--");

            var printer_type2 = printer1.GetType();
            var program_type = typeof(Program);

            var program_instance = Activator.CreateInstance(program_type);

            foreach (var method_info in printer_type.GetMethods())
            {
                Console.WriteLine($"{method_info.ReturnType} {method_info.Name}(");
                foreach (var parameter in method_info.GetParameters())
                {
                    Console.WriteLine("\t{0} {1}", parameter.ParameterType, parameter.Name);
                }
                Console.WriteLine(");");
            }

            var printer_print_method = printer_type.GetMethod("Print");

            printer_print_method.Invoke(printer2, new object[] { "Hello world!!!" });

            var prefix_field = printer_type.GetField("_Prefix", BindingFlags.Instance | BindingFlags.NonPublic);

            var prefix_value = (string)prefix_field.GetValue(printer2);

            prefix_field.SetValue(printer2, "<>");

            printer_print_method.Invoke(printer2, new object[] { "Hello world!!!" });

            var calculator_type = assembly.GetType("ReflectionTestLib.Calculator");

            var calculator = Activator.CreateInstance(calculator_type);

            var sum_method = calculator_type.GetMethod("Sum", BindingFlags.Instance | BindingFlags.NonPublic);
            var result = (double)sum_method.Invoke(calculator, new object[] { 3, 5 });

            var summator = (Func<double, double, double>)Delegate
                .CreateDelegate(typeof(Func<double, double, double>), calculator, sum_method);

            var result2 = summator(3, 10);

            dynamic printer = printer4;

            var pinter_prefix = printer.Prefix;

            Console.WriteLine();
            Console.WriteLine("Описание класса Program");
            //var program_type = typeof(Program);
            var program_attributes = program_type.GetCustomAttributes<DescriptionAttribute>();
            foreach (var description_attribute in program_attributes)
            {
                Console.WriteLine(description_attribute.Description);
            }


            var list = new List<string>
            {
                "Str 1",
                "Str 2",
                "Str 3",
                "Str 4"
            };

            foreach (var s in list)
            {
                if (s.EndsWith("2"))
                {
                    list.Add("Hello World!");
                    var list_type = list.GetType();
                    var list_field_version =
                        list_type.GetField("_version", BindingFlags.Instance | BindingFlags.NonPublic);
                    var version_value = (int)list_field_version.GetValue(list);
                    list_field_version.SetValue(list, version_value - 1);
                }

                Console.WriteLine(s);
            }

            //GC.Collect();

            //XmlSerializer
            //BinaryFormatter

            Expression<Func<string, int>> expr = s => s.Length;

            var p = Expression.Parameter(typeof(string), "str");
            var body = Expression.Property(p, "Length");

            expr = Expression.Lambda<Func<string, int>>(body, p);

            var get_length_method = expr.Compile();

            var str = get_length_method("Hello World");

            Func<string, int> str_to_int = delegate (string s) { return s.Length; };
            str_to_int = s => s.Length;

            var len = StrToInt("QWE");

            int StrToInt(string s)
            {
                return s.Length;
            }

            using (var looger = new Logger("Test.log"))
            {

            }

            var file = new FileInfo("TestText.txt");

            var lines_count = file.GetLines().Count();
            var lines_count2 = file.GetLines().Count(s => s.Length > 4);

            var numbers = file.GetLines()
                .Select(s =>
                {
                    var is_int = int.TryParse(s, out var v);
                    return new {IsNumber = is_int, Value = v};
                })
                .Where(v => v.IsNumber)
                .Select(v => v.Value)
                .ToArray();

            int x = 42;
            Nullable<int> obj_x = x;
            int? obj_x2 = x;
            object obj_x3 = x;

            x = (int) obj_x;
            x = (int) obj_x2;
            x = (int) obj_x3;

            //System.Collections.Concurrent.

            Console.ReadLine();
        }
    }

    internal enum ParameterVariants
    {
        [Description("Значение 1")]
        EnumVal1,
        [Description("Значение 2")]
        EnumVal2,
        [Description("Значение 3")]
        EnumVal3
    }


    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    internal sealed class LocalizableStrAttribute : Attribute
    {
        public LocalizableStrAttribute()
        {

        }
    }

    internal class Logger : IDisposable
    {
        private readonly StreamWriter _Writer;

        public Logger(string FileName)
        {
            _Writer = new StreamWriter(FileName);
        }

        //~Logger() => Dispose(false);

        public virtual void Log(string str) => _Writer.WriteLine("{0}:{1}", DateTime.Now, str);

        protected virtual void Dispose(bool Disposing)
        {
            if (Disposing)
            {
                // Освобождаем управляемые ресурсы
                _Writer.Dispose();
            }

            // Здесь могут быть освобождены неуправляемые ресурсы. На пример COM+, напрямую выделенная память и т.п.
        }

        private bool _Disposed;
        void IDisposable.Dispose()
        {
            if (_Disposed) return;
            Dispose(true);
            _Disposed = true;
            GC.SuppressFinalize(this);
        }
    }

    internal class XmlLogger : Logger
    {
        public XmlLogger(string FileName) : base(FileName) { }

        public override void Log(string str)
        {
            var sb = new StringBuilder();
            using (var writer = XmlWriter.Create(new StringWriter(sb)))
            {
                var xml = new XElement("log",
                    new XAttribute("time", DateTime.Now),
                    new XElement("value", str));
                xml.WriteTo(writer);
            }

            base.Log(sb.ToString());
        }

        protected override void Dispose(bool Disposing)
        {
            base.Dispose(Disposing);
            if (Disposing)
            {
                // Освоождаем ресурсы наледника
            }
        }
    }
}
