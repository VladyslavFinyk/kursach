using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Text;
using CommandLine;
namespace Client
{
    class CLIArguments
    {
        [Option('c', "campus", Required = true, HelpText = "Корпус до якого відноситься комп'ютер")]
        public string Campus { get; set; }
        [Option('f', "floor", Required = true, HelpText = "Поверх, на якому знаходиться компёютер")]
        public string Floor { get; set; }
        [Option('r', "room", Required = true, HelpText = "Кымната, в якый знаходиться комп'ютер")]
        public string Room { get; set; }

    }
}
/*using System;
using CommandLine;

namespace ARGUMENTS_TRY
{
    class CLIArguments
    {
        [Option('c', "campus", Required=true, HelpText="Корпус, до якого відноситься комп'ютер")]
        public string Campus { get; set; }

        [Option('а', "floor", Required = true, HelpText = "Поверх, до якого відноситься комп'ютер")]
        public string Floor { get; set; }

        [Option('r', "room", Required = true, HelpText = "Приміщення, до якого відноситься комп'ютер")]
        public string Room { get; set; }
    }
    class Program
    {

        static void Main(string[] args)
        {
            CLIArguments? parsedCLIArguments = null;
            Parser.Default.ParseArguments<CLIArguments>(args).WithParsed<CLIArguments>(cliArguments =>
            {
                parsedCLIArguments = cliArguments;
            });

            if (parsedCLIArguments != null)
            {
                Console.WriteLine($"Campus: {parsedCLIArguments.Campus}\nFloor: {parsedCLIArguments.Floor}\n{parsedCLIArguments.Room}");
            }

            string pcName = Environment.MachineName;
            Console.WriteLine($"PC Name: {pcName}");
        }
    }
}
*/