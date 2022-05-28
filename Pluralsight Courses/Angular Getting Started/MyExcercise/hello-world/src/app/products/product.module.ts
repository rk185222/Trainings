import { NgModule } from '@angular/core';
import { ProductDetailComponent } from '../product-list/product-detail.component';
import { ProductListComponent } from '../product-list/product-list.component';
import { ConvertToSpacesPipe } from '../shared/convert-to-spaces.pipe';
import { RouterModule } from '@angular/router';
import { ProductDetailGuard } from '../product-list/product-detail.guard';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  declarations: [
    ProductListComponent,
    ProductDetailComponent,
    ConvertToSpacesPipe
  ],
  imports: [
    RouterModule.forChild([
      { path: 'products', component: ProductListComponent },
      { path: 'product/:id', canActivate: [ProductDetailGuard], component: ProductDetailComponent },
    ]),
    SharedModule,
  ]
})
export class ProductModule { }
