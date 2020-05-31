import { Injectable } from "@angular/core";
import * as signalR from "@microsoft/signalr";
import { connect } from "tls";

@Injectable({
  providedIn: 'root'
})
export class Connection {
  public initialiseSignalRConnection(): void {
    /*const connection = new signalR.HubConnectionBuilder()
      .withUrl("/hardwareInfo", {
        skipNegotiation: true,
        transport: signalR.HttpTransportType.WebSockets
      })
      .build();

    connection.on("getTest", () => {
      console.log("hoba)");
    })

    console.log("start");

    connection.start().then(() => {
      connection.invoke("DD").then((result) => {
        console.log(result);
      })
      console.log("yess");
      connection.invoke("GetMemoryLoad").catch(err => console.log(err));
    }).catch(() => {
      console.log("error");
    });
    console.log("end");*/
  }
}
