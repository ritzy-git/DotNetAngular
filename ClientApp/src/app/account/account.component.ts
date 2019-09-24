import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DataService } from '../data.service';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.css']
})
export class AccountComponent implements OnInit {

  transactId: any;
  accountDetails: any;
  admin: boolean;

  constructor(private route: Router, private service: DataService) { }

  ngOnInit() {
    this.transactId = this.service.setId;
    if (this.transactId === 0) {
      this.admin = true;
      this.service.getAllAccountDetails().subscribe((response) => {
        this.accountDetails = response.data;
      }, (error) => {
        alert(error.message);
      })
    } else {
      this.admin = false;
      this.service.getAccountDetails(this.transactId).subscribe((response) => {
        this.accountDetails = response.data;
      }, (error) => {
        alert(error.message);
      })
    }
  }
  makePayment() {
    this.route.navigateByUrl('/make-payment');
    // this.service.accntId = data.actID;
  }
  onLogout() {
    this.route.navigateByUrl('/');
  }
  onAdd() {
    this.route.navigateByUrl('/addAccount');
  }
  getBestUser() {
    this.route.navigateByUrl('/best-performer');
  }
}
