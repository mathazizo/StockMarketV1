import { Component, OnInit } from '@angular/core';
import { StockService } from 'src/app/services/stock.service';

@Component({
  selector: 'app-stock-create',
  templateUrl: './stock-create.component.html',
  styleUrls: ['./stock-create.component.css']
})
export class stockCreateComponent implements OnInit {
  stock = {
    name: '',
    price: ''
  };
  submitted = false;

  constructor(private stockService: StockService) { }

  ngOnInit(): void {
  }

  createstock(): void {
    const data = {
      name: this.stock.name,
      price: this.stock.price
    };

    this.stockService.create(data)
      .subscribe(
        response => {
          console.log(response);
          this.submitted = true;
        },
        error => {
          console.log(error);
        });
  }

  newstock(): void {
    this.submitted = false;
    this.stock = {
      name: '',
      price: ''
    };
  }

}