import { Component, OnInit, OnDestroy } from '@angular/core';
import { ImportService } from '../../_services/import.service';
import { takeUntil } from 'rxjs/operators';
import { ReplaySubject } from 'rxjs';
import { GridParams } from 'src/app/_models/grid/GridParams';
import { PageEvent } from '@angular/material/paginator';

@Component({
  selector: 'app-data-list',
  templateUrl: './data-list.component.html',
  styleUrls: ['./data-list.component.scss']
})
export class DataListComponent implements OnInit, OnDestroy {  

  $destroy = new ReplaySubject<any>(1);

  isLoadingResults: boolean;
  displayedColumns: string[] = ['fullName', 'birthDate', 'account', 'businessPhone', 'address', 'email', 'gender', 'jobTitle', 'department'];
  pageSize: number[] = [10, 50, 100, 200];
  dataSource = [];
  countItems: number;
  gridParams = {
    skip: 0,
    take: 10
  };


  constructor(
    private importServ: ImportService
  ) { 
    importServ.onRefreshData.subscribe(result => {
      this.onLoadData(this.gridParams);  
    });
  }
 

  ngOnInit() {
    this.onLoadData(this.gridParams); 
  }

  onLoadData(params: GridParams) {
    this.isLoadingResults = true;
    this.importServ.getTestObjects(params)
      .pipe(takeUntil(this.$destroy))
      .subscribe(result => {
        this.countItems = result.count;
        this.dataSource = result.data;
        this.isLoadingResults = false;
      },() => this.isLoadingResults = false); 
  }

  onRowClicked(row) {
    console.log("Row clicked", row);
  }

  onPageChange(page: PageEvent) {
    this.gridParams.skip = (page.pageIndex * page.pageSize);
    this.gridParams.take = page.pageSize;
    this.onLoadData(this.gridParams);
  }

  ngOnDestroy(): void {
    this.$destroy.next(null);
    this.$destroy.complete();
  }

}
