import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { stockCreateComponent } from './components/stock-create/stock-create.component';
import { StockDetailsComponent } from './components/stock-details/stock-details.component';
import { stockListComponent } from './components/stock-list/stock-list.component';

@NgModule({
  declarations: [
    AppComponent,
    stockCreateComponent,
    StockDetailsComponent,
    stockListComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
