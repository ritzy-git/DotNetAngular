import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { UserloginComponent } from './userlogin/userlogin.component';
import { AccountComponent } from './account/account.component';
import { PaymentComponent } from './payment/payment.component';
import { AddAccountComponent } from './add-account/add-account.component';
import { PerformerComponent } from './performer/performer.component';

@NgModule({
  imports: [
    RouterModule.forRoot([
      { path: 'user-login', component: UserloginComponent },
      { path: 'account-details', component: AccountComponent },
      { path: 'make-payment', component: PaymentComponent },
      { path: 'addAccount', component: AddAccountComponent },
      { path: 'getBestPerformer', component: PerformerComponent },
      { path: '', component: UserloginComponent, pathMatch: "full" }
    ]),
    CommonModule
  ],
  exports: [RouterModule]
})
export class RoutingModule { }
