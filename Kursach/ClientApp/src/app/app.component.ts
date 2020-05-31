import { Component } from '@angular/core';
import { Connection } from "./services/connection.service";
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  title = 'app';
  constructor(private connection: Connection) {
    connection.initialiseSignalRConnection();
  }
}
