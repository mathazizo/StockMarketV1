import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { stockListComponent } from './components/stock-list/stock-list.component';
import { StockDetailsComponent } from './components/stock-details/stock-details.component';
import { stockCreateComponent } from './components/stock-create/stock-create.component';

const routes: Routes = [
  { path: '', redirectTo: 'products', pathMatch: 'full' },
  { path: 'stocks', component: stockListComponent },
  { path: 'stocks/:id', component: StockDetailsComponent },
  { path: 'create', component: stockCreateComponent }
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
