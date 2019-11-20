import { Component, OnInit, Output, EventEmitter, OnDestroy } from '@angular/core';
import { ImportService } from '../../_services/import.service';
import { takeUntil } from 'rxjs/operators';
import { ReplaySubject } from 'rxjs';
import { TerraTimmerService } from 'src/app/shared/terra-timer/_service/terra-timmer.service';
import { TerraTime } from 'src/app/shared/terra-timer/_model/TerraTime';

@Component({
  selector: 'app-import-file',
  templateUrl: './import-file.component.html',
  styleUrls: ['./import-file.component.scss']
})
export class ImportFileComponent implements OnInit, OnDestroy {  

  $destroy = new ReplaySubject<any>(1);

   domTimePars: TerraTime;
   saxTimePars: TerraTime;

  constructor(
    private importServ: ImportService,
    private timeServ: TerraTimmerService
  ) {  }

  ngOnInit() {
  }
 
  onRefresh() {
    this.importServ.onRefreshData.emit();
  }

  onDomParsing() {

  this.timeServ.startTimer();
  this.domTimePars = null;

   this.importServ.postDonParsing()
    .pipe(takeUntil(this.$destroy))
    .subscribe(result => {
      this.domTimePars = this.timeServ.pauseTimer();      
    },error => {alert("Sorry!!! Can't pars file!");this.timeServ.pauseTimerError();});

  }

  onSaxParsing() {
    this.importServ.postSaxParsing()
    .pipe(takeUntil(this.$destroy))
    .subscribe(result => {
      
    });
  }

  ngOnDestroy() {
    this.$destroy.next(null);
    this.$destroy.complete();
  }



  

}
