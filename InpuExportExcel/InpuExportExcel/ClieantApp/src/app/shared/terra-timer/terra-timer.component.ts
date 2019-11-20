import { Component, OnInit } from '@angular/core';
import { TerraTimmerService } from './_service/terra-timmer.service';

@Component({
  selector: 'app-terra-timer',
  templateUrl: './terra-timer.component.html',
  styleUrls: ['./terra-timer.component.scss']
})
export class TerraTimerComponent implements OnInit {
 
  constructor(
    public timeServ: TerraTimmerService
  ) { }

  ngOnInit() {
   
  }

 

}
