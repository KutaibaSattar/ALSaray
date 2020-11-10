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

  getAcc(id){

    return this.http.get('/api/mydbaccts/'+id);

  }


  Update(id:number ,dbaccount ){

    console.log(id ,dbaccount)

      return this.http.put('/api/mydbaccts/'+id, dbaccount);

  }

  

  delete(id:number ){

    return this.http.delete('/api/mydbaccts/'+id);

  }

}
