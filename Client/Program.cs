using OpenHardwareMonitor.Hardware;
using System;
using System.Threading;
using System.Management;
using CommandLine;
namespace Client
{
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
                Console.WriteLine($"Campus: {parsedCLIArguments.Campus}\nFloor: {parsedCLIArguments.Floor}\nRoom: {parsedCLIArguments.Room}");
                
            }
            string pcName = Environment.MachineName;
            //ClientInfo test = new ClientInfo(pcName, 1, 3, 12);
            //CollectedData collectedData = new CollectedData(test);
            /*ClientInfo clientInfo = new ClientInfo(pcName, Convert.ToInt32(parsedCLIArguments.Campus),
                    Convert.ToInt32(parsedCLIArguments.Floor),
                    Convert.ToInt32(parsedCLIArguments.Room));
            CollectedData collectedData = new CollectedData(clientInfo);*/
            //Console.WriteLine(collectedData.ToString());
            Client client = new Client();
            client.InitialiseOnConnection(pcName, 1, 3, 12);
            client.StartConnection();
            client.InvokeConnection(pcName, 1, 3, 12);
            //client.JoinGroup("1");

        }
    }
}
