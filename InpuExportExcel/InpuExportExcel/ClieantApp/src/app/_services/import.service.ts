import { Injectable, Output, EventEmitter } from '@angular/core';
import { TestObject } from '../_models/TestObject';
import { Observable } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';

const host = "https://localhost:5001/";
const urlApi = "api/Input";

@Injectable({
  providedIn: 'root'
})
export class ImportService {

  @Output() onRefreshData = new EventEmitter();

  constructor(
    protected http: HttpClient
  ) { }

  public postTestObjects(): Observable<TestObject> {
    
    const method = '/PostTestObjects';

    const table = host + urlApi + method;

    var body = {
      value: "Hello"
    };
         
    return this.http.post(table, body)
    .pipe(
        map((response: any) => {
          alert(response);
          return response;
      }),
      catchError((error: HttpErrorResponse) => {
        console.error('getTestObjects: ', error);       
        return Observable.throw(error);
      })
    );
  }


  
  public getTestObjects(): Observable<TestObject[]> {
    
    const method = "/GetTestObjects";

    const table = host + urlApi + method;
         
    return this.http.get(table)
    .pipe(
        map((response: any) => {
          return response;
      }),
      catchError((error: HttpErrorResponse) => {
        console.error('getTestObjects: ', error);       
        return Observable.throw(error);
      })
    );
  }
  
}
