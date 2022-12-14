using ConsoleAppFramework;
using DataTables.GeneratorCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace DataTables.Generator
{
    public class Program : ConsoleAppBase
    {
        static async Task Main(string[] args)
        {
            await Host.CreateDefaultBuilder()
                .ConfigureLogging(x => x.ReplaceToSimpleConsole())
                .RunConsoleAppFrameworkAsync<Program>(args);
        }

        public void Execute(
            [Option("i", "Input file directory(search recursive).")]string inputDirectory,
            [Option("co", "Code output file directory.")]string codeOutputDir,
            [Option("do", "Data output file directory.")]string dataOutputDir,
            [Option("n", "Namespace of generated files.")]string usingNamespace,
            [Option("p", "Prefix of class names.")]string prefixClassName = "",
            [Option("f", "Overwrite generated files if the content is unchanged.")]bool forceOverwrite = false)
        {
            var sw = Stopwatch.StartNew();
            Console.WriteLine("Start DataTables CodeGeneration");

            new DataTableGenerator().GenerateFile(inputDirectory, codeOutputDir, dataOutputDir, usingNamespace, prefixClassName, forceOverwrite, x => Console.WriteLine(x));

            Console.WriteLine("Complete DataTables CodeGeneration, elapsed:" + sw.Elapsed);
        }
    }
}