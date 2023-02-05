import { Component, OnInit } from '@angular/core';
import { StockService } from 'src/app/services/stock.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-stock-details',
  templateUrl: './stock-details.component.html',
  styleUrls: ['./stock-details.component.css']
})
export class StockDetailsComponent implements OnInit {
  currentstock: { name: any; price: any; id?: any; } = null;
  message = '';

  constructor(
    private stockService: StockService,
    private route: ActivatedRoute,
    private router: Router) { }

  ngOnInit(): void {
    this.message = '';
    this.getstock(this.route.snapshot.paramMap.get('id'));
  }

  getstock(id: string): void {
    this.stockService.read(id)
      .subscribe(
        stock => {
          this.currentstock = stock;
          console.log(stock);
        },
        error => {
          console.log(error);
        });
  }

  setAvailableStatus(status: any): void {
    const data = {
      name: this.currentstock.name,
      price: this.currentstock.price
    };

    this.stockService.update(this.currentstock.id, data)
      .subscribe(
        response => {
          this.currentstock.price = status;
          console.log(response);
        },
        error => {
          console.log(error);
        });
  }

  updatestock(): void {
    this.stockService.update(this.currentstock.id, this.currentstock)
      .subscribe(
        response => {
          console.log(response);
          this.message = 'The stock was updated!';
        },
        error => {
          console.log(error);
        });
  }

  deletestock(): void {
    this.stockService.delete(this.currentstock.id)
      .subscribe(
        response => {
          console.log(response);
          this.router.navigate(['/stocks']);
        },
        error => {
          console.log(error);
        });
  }
}