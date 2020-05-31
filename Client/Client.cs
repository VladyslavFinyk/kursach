using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;

namespace Client
{
    public class Client
    {
        HubConnection connection;
        public Client()
        {
            connection = new HubConnectionBuilder()
                .WithUrl("https://localhost:44361/hardwareInfo")
                .Build();
            connection.Closed += async (error) =>
            {
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await connection.StartAsync();
            };
        }

        public void GetSystemInfo()
        {
            connection.On("getSystemInfo", () => {
                HardwareInfo hardwareInfo = new HardwareInfo();
            });

            connection.StartAsync();
            connection.InvokeAsync("GetSystemInfo");
        }
        public HubConnection GetHubConnection()
        {
            return connection;
        }
        public void StartConnection()
        {
            connection.StartAsync().Wait();
        }
        public void InitialiseOnConnection(string clientInfo, int campus, int floor, int room)
        {
            connection.On("getComputerInfo", () =>
            {
                //ClientInfo computerInfo = new ClientInfo();
                //computerInfo.InitialiseAll(clientInfo, campus, floor, room);
                //CollectedData collectedData = new CollectedData();
                //collectedData.InitialiseAll(computerInfo);
                //connection.InvokeAsync<CollectedData>("OnClientData", collectedData);
            });
            connection.On<string>("result", (result) =>
            {
                Console.WriteLine(result);
            });
        }
        public void InvokeConnection(string clientName, int campus, int floor, int room) {
            ClientInfo computerInfo = new ClientInfo();
            computerInfo.InitialiseAll(clientName, campus, floor, room);

            CollectedData collectedData = new CollectedData();
            collectedData.InitialiseAll(computerInfo);

            Task task = connection.InvokeAsync("test", JsonConvert.SerializeObject(collectedData));
            task.Wait();
        }
        /*
        public void JoinGroup(string group)
        {
            connection.InvokeAsync("JoinGroup", group);
        }*/
    }
}