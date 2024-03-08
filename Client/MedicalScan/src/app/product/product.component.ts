import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Product } from './product';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.scss'],
})
export class ProductComponent {
  http: HttpClient;
  products: Array<Product>;
  selectedProduct: Product;
  newProduct: Product;
  snackBar: MatSnackBar;
  id: number | undefined;

  constructor(http: HttpClient, snackBar: MatSnackBar) {
    this.http = http;
    this.snackBar = snackBar;
    this.products = [];
    this.getAllProducts;
    this.getAllProducts();
    this.selectedProduct = new Product();
    this.newProduct = new Product();
  }

  getAllProducts() {
    this.http
      .get<Product[]>('https://localhost:7045/Product/getAllProducts')
      .subscribe((resp) => {
        console.log(resp);
        resp.map((x: Product) => {
          let p = new Product();
          p.id = x.id;
          p.name = x.name;
          p.description = x.description;
          p.price = x.price;
          p.quantity = x.quantity;
          this.products.push(p);
        });
      });
  }

  updateProduct() {
    this.http
      .put<Product>(
        'https://localhost:7045/Product/updateProduct',
        this.selectedProduct
      )
      .subscribe(
        (success) => {
          let i = this.products.findIndex(
            (x) => x.id == this.selectedProduct.id
          );
          this.products[i] = this.selectedProduct;
          this.snackBar.open('Product has been updated successfully!', 'Close', {
            duration: 2500,
          });
        },
        (error) => {
          this.snackBar.open('Update was unsuccessful!', 'Close', {
            duration: 2500,
          });
        }
      );
  }

  addProduct() {
    this.http
      .post<Product>(
        'https://localhost:7045/Product/addProduct',
        this.newProduct
      )
      .subscribe(
        (success) => {
          this.products.push(success);
          this.snackBar.open(
            'New product has been added successfully!',
            'Close',
            {
              duration: 2500,
            }
          );
        },
        (error) => {
          this.snackBar.open('Adding new product was unsuccessful!', 'Close', {
            duration: 2500,
          });
        }
      );
  }

  startEdit(p: Product) {
    this.selectedProduct = Object.assign({}, p);
  }

  deletProduct(p: Product) {
    this.http
      .delete('https://localhost:7045/Product/deleteProduct/' + p.id)
      .subscribe(
        (success) => {
          let i = this.products.findIndex((x) => x.id === p.id);
          this.products.splice(i, 1);
        },
        (error) => {}
      );
  }

  getProduct() {
    this.http
      .get<Product>('https://localhost:7045/Product/getProduct/' + this.id)
      .subscribe((success) => {
        this.products = [];
        this.products.push(success);
      }, (error) => {
        this.snackBar.open('Product not found!', 'Close', {
          duration: 2500,
        });
      });
  }
}
