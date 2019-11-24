import { Injectable } from '@angular/core';
import { TerraTime } from '../_model/TerraTime';

@Injectable({
  providedIn: 'root'
})
export class TerraTimmerService {

  public start: boolean;

  private currentMinutes: number = 0;  
  private currentSeccontd: number = 0;  
  private currentMiliSeccontd: number = 0;  
  private interval;

  get GetMinutes() {   
    return this.currentMinutes;
  }

  get GetSeccontd() {
    return this.currentSeccontd;
  }

  get GetMiliSeccontd() {
    return this.currentMiliSeccontd;
  }

  constructor() { }


  startTimer() {
    this.start = true;
    this.interval = setInterval(() => {
      if(this.currentMiliSeccontd == 59) {
        if(this.currentSeccontd == 59) {
          this.currentMinutes++;
          this.currentSeccontd = 0;
        } else {
          this.currentSeccontd++;
        }      
        this.currentMiliSeccontd = 0;        
      } else {
        this.currentMiliSeccontd++;
      }
    }, 20)
  }

  pauseTimer(): TerraTime {
    this.start = false; 
    let result = new TerraTime({
      minutes:this.currentMinutes, 
      seconds:this.currentSeccontd,
      miliseconds: this.currentMiliSeccontd});

    this.currentMinutes = 0;  
    this.currentSeccontd = 0;  
    this.currentMiliSeccontd = 0; 

    clearInterval(this.interval);
    return result;
  }

  pauseTimerError() {
    this.start = false; 
    this.currentMinutes = 0;  
    this.currentSeccontd = 0;  
    this.currentMiliSeccontd = 0; 

    clearInterval(this.interval);   
  }
}
