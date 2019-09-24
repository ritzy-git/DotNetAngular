import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DataService } from '../data.service';

@Component({
  selector: 'app-payment',
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.css']
})
export class PaymentComponent implements OnInit {

  transactDate: any;
  accntID: any;
  obj: any;
  payableAmount: any;
  constructor(private route: Router, private service: DataService) { }

  ngOnInit() {
    this.accntID = this.service.accntId;
    var today = new Date();
    var dd = today.getDate();
    var mm = today.getMonth();
    var yyyy = today.getFullYear();

    if (dd < 10) {
      dd = 0 + dd
    }
    if (mm < 10) {
      mm = 0 + mm
    }
    // this.transactDate = dd + '/' + (mm + Number(0o1)) + '/' + yyyy;
    this.transactDate = yyyy + '-' + (mm + Number(0o1)) + '-' + dd
  }
  onPay() {
    this.obj = {
      AccountId: this.accntID,
      TransactionDate: this.transactDate,
      TransactionAmount: this.payableAmount
    }
    // alert(JSON.stringify('Paid Successfull'));
    this.service.makePayment(this.obj).subscribe((response) => {
      if (response.message === 'Minimum amount should be greater than 0.') {
        alert(response.message);
      } else {
        this.route.navigateByUrl('/account-details');
      }
    }, (error) => {
      alert(error.message);
    })

  }
}
