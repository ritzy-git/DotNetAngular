import { Component, OnInit } from '@angular/core';
import { DataService } from '../data.service';

@Component({
  selector: 'app-performer',
  templateUrl: './performer.component.html',
  styleUrls: ['./performer.component.css']
})
export class PerformerComponent implements OnInit {

  obj: any;
  startDate: any;
  endDate: any;
  bestUser: boolean;
  // bestPerformer: any;
  userDetails: any;
  constructor(private service: DataService) { }

  ngOnInit() {

  }
  getUser() {
    this.obj = {
      startDate: this.startDate,
      endDate: this.endDate
    }
    this.service.getPerformer(this.obj).subscribe((response) => {
      this.bestUser = true;
      this.userDetails = response.data;
    }, (error) => {
      alert(error.message);
    })
  }

}
