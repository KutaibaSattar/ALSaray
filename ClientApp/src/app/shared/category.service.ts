import { ModuleMapLoaderModule } from '@nguniversal/module-map-ngfactory-loader';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';



@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  constructor( private http : HttpClient) { }

  getCategory(){

    return this.http.get('/api/category')

  }


}
