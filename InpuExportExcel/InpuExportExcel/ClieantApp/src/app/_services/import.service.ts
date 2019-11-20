import { Injectable, Output, EventEmitter } from '@angular/core';
import { TestObject } from '../_models/TestObject';
import { Observable, of } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { MyFile } from '../_models/MyFile';

@Injectable({
  providedIn: 'root'
})
export class ImportService {

  @Output() onRefreshData = new EventEmitter();

  constructor(
    protected http: HttpClient
  ) { }


  public postDonParsing(): Observable<boolean> {

    const url = environment.localhostApp + environment.urlApi + environment.methodPostDomParsing;

    var myFile = new MyFile({ fileName: 'TestValue_20000.xlsx'})

    return this.http.post(url, myFile)
    .pipe(
        map((response: any) => {                  
          return true;
      }),
      catchError((error: HttpErrorResponse) => {
        console.error('postSaxParsing: ', error);       
        return Observable.throw(error);
      })
    );
  }

  public postSaxParsing(): Observable<boolean> {

    const url = environment.localhostApp + environment.urlApi + environment.methodPostSaxParsing;

    var myFile = new MyFile({ fileName: 'TestValue_20000.xlsx'})

    return this.http.post(url, myFile)
    .pipe(
        map((response: any) => {                  
          return true;
      }),
      catchError((error: HttpErrorResponse) => {
        console.error('postSaxParsing: ', error);       
        return Observable.throw(error);
      })
    );

  }  

  public postTestObjects(): Observable<TestObject> {
    
    const url = environment.localhostApp + environment.urlApi + environment.methodPostTestObjects;

    var body = {
      value: "Hello"
    };
         
    return this.http.post(url, body)
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
  
  public getTestObjects(): Observable<TestObject[]> {
    
    const url = environment.localhostApp + environment.urlApi + environment.methodGetTestObjects;
         
    return this.http.get(url)
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
