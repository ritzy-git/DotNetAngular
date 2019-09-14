import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  accntId: any;
  obj: any;

  constructor(private http: HttpClient) { }

  getLoginInfo(data): Observable<any> {
    return this.http.post('http://localhost:8111/Login', data);
  }

  set setId(data) {
    this.accntId = data;
  }
  get setId() {
    return this.accntId;
  } 
  getAccountDetails(data): Observable<any> {
    this.obj = {
      'id': data
    }
    return this.http.post('http://localhost:8111/getAccounts', this.obj);
  }
  makePayment(data): Observable<any>{
    return this.http.post('http://localhost:8111/AddPayment', data);
  }
  getAllAccountDetails(): Observable<any>{
    return this.http.get('http://localhost:8111/getAccountdetails');
  }
  addUser(data): Observable<any>{
    return this.http.post('http://localhost:8111/AddAccount',data);
  }
  getPerformer(data): Observable<any>{
    return this.http.post('http://localhost:8111/getBestPerformer',data);
  }
}
