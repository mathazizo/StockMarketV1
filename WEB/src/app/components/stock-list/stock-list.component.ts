import { Component, OnInit } from '@angular/core';
import { StockService } from 'src/app/services/stock.service';
import { HubConnection, HubConnectionBuilder, LogLevel } from '@microsoft/signalr';

@Component({
  selector: 'app-stock-list',
  templateUrl: './stock-list.component.html',
  styleUrls: ['./stock-list.component.css']
})
export class stockListComponent implements OnInit {
  private hubConnectionBuilder!: HubConnection;
  stocks: any;
  currentstock: any = null;
  currentIndex = -1;
  name = '';

  constructor(private StockService: StockService) { }

  ngOnInit(): void {
    this.readstocks();
    this.hubConnectionBuilder = new HubConnectionBuilder().withUrl('https://localhost:7214/stocks').configureLogging(LogLevel.Information).build();
    this.hubConnectionBuilder.start().then(() => console.log('Connection started.......!')).catch(err => console.log('Error while connect with server'));
    this.hubConnectionBuilder.on('SendstocksToUser', (result: any) => {
        this.stocks.push(result);
     });
  }

  readstocks(): void {
    this.StockService.readAll()
      .subscribe(
        stocks => {
          this.stocks = stocks;
          console.log(stocks);
        },
        error => {
          console.log(error);
        });
  }

  refresh(): void {
    this.readstocks();
    this.currentstock = null;
    this.currentIndex = -1;
  }

  setCurrentstock(stock: any, index: number): void {
    this.currentstock = stock;
    this.currentIndex = index;
  }

  deleteAllstocks(): void {
    this.StockService.deleteAll()
      .subscribe(
        response => {
          console.log(response);
          this.readstocks();
        },
        error => {
          console.log(error);
        });
  }

  searchByName(): void {
    this.StockService.searchByName(this.name)
      .subscribe(
        stocks => {
          this.stocks = stocks;
          console.log(stocks);
        },
        error => {
          console.log(error);
        });
  }
}
