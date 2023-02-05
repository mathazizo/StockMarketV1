import { Component } from '@angular/core';
import { HubConnection, HubConnectionBuilder, LogLevel } from '@microsoft/signalr';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent {
    title = 'SignalRClient';
    private hubConnectionBuilder!: HubConnection;
    stocks: any[] = [];
    constructor() {}
    ngOnInit(): void {
   
    }
}
