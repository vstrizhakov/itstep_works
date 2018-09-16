import { Component } from '@angular/core';
import { NgModel } from '@angular/forms';
import { FormsModule } from '@angular/forms';

@Component(
{
  selector: 'app-root',
  template: `<div class="page-header">
  				<h1>Список продуктов</h1>
  			</div>
			<table class="table table-striped">
				<thead>
					<tr>
						<th>Название</th>
						<th>Цена</th>
						<th>Вес</th>
					</tr>
				</thead>
				<tbody>
					<tr *ngFor="let p of products">
						<td>{{ p.name }}</td>
						<td>{{ p.price }}</td>
						<td>{{ p.weight }}</td>
					</tr>
				</tbody>
			</table>
			<button class="btn btn-default" (click)="testMethod()">Кнопка</button>
			<div class="form-inline">
				<div class="form-group">
					<div class="col-md-8">
						<input type="text" [(ngModel)]="myname" placeholder="Название" class="form-control">
					</div>
				</div>
				<div class="form-group">
					<div class="col-md-6">
						<input type="number" class="form-control" [(ngModel)]="myprice" placeholder="Цена">
					</div> 
				</div>
				<div class="form-group">
					<div class="col-md-6">
						<input type="number" class="form-control" [(ngModel)]="myweight" placeholder="Вес">
					</div>
				</div>
				<div class="from-group">
					<div class="col-mg-offset-2 col-md-8">
						<button class="btn btn-default" (click)="addProduct(myname, myprice, myweight)">Добавить</button>
					</div>
				</div>
			</div>`
  			
})
export class AppComponent
{
  title = 'First App';

  products: Product[] =
  [
  	{ name: "Snickers", price 12.5, weight: 45 },
  	{ name: "Mars", price 13.9, weight: 55 },
  	{ name: "Bounty", price 15.1, weight: 65 }
  ];

  testMethod() : void
  {
  	alert("Hello, World!");
  }

  addProduct(myname : string, myprice : number, myweight : number) : void
  {
  	if (myname == null || myname == undefined || myname.trim() == "") return;
  	if (myprice == null || myprice == undefined) return;
  	if (myweight == null || myweight == undefined) return;

  	this.products.push(new Product(myname, myprice, myweight));
  }
}

class Product
{
	name : string;
	price : number;
	weight : number;

	constructor (name : string, price : number, weight : number)
	{
		this.name = name;
		this.price = price;
		this.weight = weight;
	}	
}