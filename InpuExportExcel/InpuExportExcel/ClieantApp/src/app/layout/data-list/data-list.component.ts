import { Component, OnInit, OnDestroy } from '@angular/core';
import { ImportService } from '../../_services/import.service';
import { takeUntil } from 'rxjs/operators';
import { ReplaySubject } from 'rxjs';

@Component({
  selector: 'app-data-list',
  templateUrl: './data-list.component.html',
  styleUrls: ['./data-list.component.scss']
})
export class DataListComponent implements OnInit, OnDestroy {  

  $destroy = new ReplaySubject<any>(1);

  isLoadingResults: boolean;

  constructor(
    private importServ: ImportService
  ) { 
    importServ.onRefreshData.subscribe(result => {
      this.onLoadData(); 
    });
  }

  displayedColumns: string[] = ['id', 'name', 'number'];
  dataSource = [];

  ngOnInit() {
    this.onLoadData(); 
  }

  onLoadData() {
    this.isLoadingResults = true;
    this.importServ.getTestObjects()
      .pipe(takeUntil(this.$destroy))
      .subscribe(result => {
        this.dataSource = result;
        this.isLoadingResults = false;
      },() => this.isLoadingResults = false); 
  }

  ngOnDestroy(): void {
    this.$destroy.next(null);
    this.$destroy.complete();
  }

}
