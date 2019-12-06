import { Component, OnInit, Output, EventEmitter, OnDestroy } from '@angular/core';
import { ImportService } from '../../_services/import.service';
import { takeUntil } from 'rxjs/operators';
import { ReplaySubject, of, interval } from 'rxjs';
import { TerraTimmerService } from 'src/app/shared/terra-timer/_service/terra-timmer.service';
import { TerraTime } from 'src/app/shared/terra-timer/_model/TerraTime';
import { TerraTimerModule } from 'src/app/shared/terra-timer/terra-timer.module';

@Component({
  selector: 'app-import-file',
  templateUrl: './import-file.component.html',
  styleUrls: ['./import-file.component.scss']
})
export class ImportFileComponent implements OnInit, OnDestroy {  

  $destroy = new ReplaySubject<any>(1);

   domTimePars: TerraTime;
   saxTimePars: TerraTime;
   domFromDbTimePars: TerraTime;
   saxFromDbTimePars: TerraTime;

   excelDocuments: string[];

   selectedDoc: string = "Contact_20k.xlsx";

  constructor(
    private importServ: ImportService,
    private timeServ: TerraTimmerService
  ) {  }

  ngOnInit() {
    this.onLoadListFiles();
  }
 
  onRefresh() {
    this.importServ.onRefreshData.emit();
  }

  onLoadListFiles() {
    this.importServ.getAbleExcelDocuments()
    .pipe(takeUntil(this.$destroy))
    .subscribe(result => {
      this.excelDocuments =result;      
    });
  }

  onDomFromDbParsing() {
    if(this.selectedDoc) {
      this.timeServ.startTimer();
      this.saxFromDbTimePars = null;   
       this.importServ.postDonFromDbParsing(this.selectedDoc)
        .pipe(takeUntil(this.$destroy))
        .subscribe(result => {
          this.saxFromDbTimePars = this.timeServ.pauseTimer();      
        },error => {
          alert("Sorry!!! Can't pars file!");
          this.timeServ.pauseTimerError();
        });
    } else {
      alert("selected doc is null");
    }
  }

  onSaxFromDbParsing() {
    if(this.selectedDoc) {
      this.timeServ.startTimer();
      this.saxFromDbTimePars = null;   
       this.importServ.postSaxFromDbParsing(this.selectedDoc)
        .pipe(takeUntil(this.$destroy))
        .subscribe(result => {
          this.saxFromDbTimePars = this.timeServ.pauseTimer();      
        },error => {
          alert("Sorry!!! Can't pars file!");
          this.timeServ.pauseTimerError();
        });
    } else {
      alert("selected doc is null");
    }     
  }

  onDomParsing() {
    if(this.selectedDoc) {
      this.timeServ.startTimer();
      this.domTimePars = null;   
       this.importServ.postDonParsing(this.selectedDoc)
        .pipe(takeUntil(this.$destroy))
        .subscribe(result => {
          this.domTimePars = this.timeServ.pauseTimer();      
        },error => {
          alert("Sorry!!! Can't pars file!");
          this.timeServ.pauseTimerError();
        });
    } else {
      alert("selected doc is null");
    } 

  }

  onSaxParsing() {
    if(this.selectedDoc) {
      this.timeServ.startTimer();
      this.importServ.postSaxParsing(this.selectedDoc)
      .pipe(takeUntil(this.$destroy))
      .subscribe(result => {
        this.saxTimePars = this.timeServ.pauseTimer();  
      },error => {
        alert("Sorry!!! Can't pars file!");
        this.timeServ.pauseTimerError();
      });
    } else {
      alert("selected doc is null");
    }
    
  }

  ngOnDestroy() {
    this.$destroy.next(null);
    this.$destroy.complete();
  }



  

}
