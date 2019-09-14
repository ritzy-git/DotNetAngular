import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DataService } from '../data.service';

@Component({
  selector: 'app-userlogin',
  templateUrl: './userlogin.component.html',
  styleUrls: ['./userlogin.component.css']
})
export class UserloginComponent implements OnInit {

  obj: any;

  constructor(private route: Router, private service: DataService) { }

  ngOnInit() {
  }
  userLogIn(uname, pswrd) {
    this.obj = {
      username: uname,
      password: pswrd
    }
    debugger
    this.service.getLoginInfo(this.obj).subscribe((response) => {
      // console.log(response);
      if (response.data.status === 'False') {
        alert(response.message);
      } else {
        this.route.navigateByUrl('/account-details');
        this.service.setId=response.data.accountId;
      }
    }, (error) => {
      alert(error.message);
    })
    // console.log(this.http.post('/Login',this.obj));

  }
}
