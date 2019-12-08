import { Injectable, Output, EventEmitter } from '@angular/core';
import { TestObject } from '../_models/TestObject';
import { Observable, of } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
import { HttpClient, HttpErrorResponse, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { MyFile } from '../_models/MyFile';
import { GridParams } from '../_models/grid/GridParams';

@Injectable({
  providedIn: 'root'
})
export class ImportService {

  @Output() onRefreshData = new EventEmitter();

  constructor(
    protected http: HttpClient
  ) { }


  public postDonFromDbParsing(selectedFileName: string): Observable<boolean> {

    const url = environment.localhostApp + environment.urlApi + environment.methodPostDomFromDbParsing;

    var myFile = new MyFile({ fileName: selectedFileName})

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

  public postSaxFromDbParsing(selectedFileName: string): Observable<boolean> {

    const url = environment.localhostApp + environment.urlApi + environment.methodPostSaxFromDbParsing;

    var myFile = new MyFile({ fileName: selectedFileName})

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

  public postDonParsing(selectedFileName: string): Observable<boolean> {

    const url = environment.localhostApp + environment.urlApi + environment.methodPostDomParsing;

    var myFile = new MyFile({ fileName: selectedFileName})

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

  public postSaxParsing(selectedFileName: string): Observable<boolean> {

    const url = environment.localhostApp + environment.urlApi + environment.methodPostSaxParsing;

    var myFile = new MyFile({ fileName: selectedFileName})

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

  public getAbleExcelDocuments(): Observable<string[]> {

    const url = environment.localhostApp + environment.urlApi + environment.methodGetAbleExcelFiles;         

    return this.http.get(url)
    .pipe(
        map((response: string[]) => {
          return response;
      }),
      catchError((error: HttpErrorResponse) => {
        console.error('getAbleExcelDocuments: ', error);       
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

  public getTestObjects(gridParams: GridParams): Observable<any> {
    
    const url = environment.localhostApp + environment.urlApi + environment.methodGetTestContacts;
         

    let httpParams = new HttpParams()  
    .set('skip', gridParams.skip.toString())
    .set('take', gridParams.take.toString());

    return this.http.get(url,{ params: httpParams })
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
