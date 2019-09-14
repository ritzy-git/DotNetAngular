import { Component, OnInit } from '@angular/core';
import { DataService } from '../data.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-account',
  templateUrl: './add-account.component.html',
  styleUrls: ['./add-account.component.css']
})
export class AddAccountComponent implements OnInit {

  acntName: any;
  montlhyCL: any;
  obj: any;

  constructor(private service: DataService,private route: Router) { }

  ngOnInit() {
  }
  Add() {
    this.obj = {
      AccountId: 0,
      Name: this.acntName,
      MontlyCl: this.montlhyCL
    }
    this.service.addUser(this.obj).subscribe((response) => {
      alert(response.message);
      this.route.navigateByUrl('/account-details');
    }, (error) => {
      alert(error.message);
    })
  }
}
