import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class MydbaccutService {

  constructor(private http:HttpClient) { }

  getMyacctList(){

    return this.http.get('/api/mydbaccts').toPromise();


  }

  Create(dbaccount) {

    return this.http.post('/api/mydbaccts', dbaccount);

  }

}
