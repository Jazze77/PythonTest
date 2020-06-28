using IronPython.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PythonTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Running my IronPythonscript ...");
            MyIronPythonSciprt();

            Console.ReadLine();
        }

        static void MyIronPythonSciprt()
        {
            //Create Engine
            var engine = Python.CreateEngine();

            // Create Python sripti
            var script = @"C:\\testpyt\\IronPythonTest.py";
            var source = engine.CreateScriptSourceFromFile(script);

            //Create command promt arguments
            var argv = new List<string>();
            argv.Add("");

            engine.GetSysModule().SetVariable("argv", argv);

            //Output redirect
            var eIO = engine.Runtime.IO;
            var errors = new MemoryStream();
            eIO.SetErrorOutput(errors, Encoding.Default);

            var results = new MemoryStream();
            eIO.SetOutput(results, Encoding.Default);

            // execute script
            var scope = engine.CreateScope();
            source.Execute(scope);

            //display output
            string str(byte[] x) => Encoding.Default.GetString(x);

            Console.WriteLine("ERRORS");
            Console.WriteLine(str(errors.ToArray()));
            Console.WriteLine("result");
            Console.WriteLine(str(results.ToArray()));

        }
    }
}
