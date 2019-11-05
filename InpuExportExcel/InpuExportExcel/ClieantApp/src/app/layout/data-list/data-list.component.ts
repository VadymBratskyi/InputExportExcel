import { Component, OnInit } from '@angular/core';
import { ImportService } from '../../_services/import.service';

@Component({
  selector: 'app-data-list',
  templateUrl: './data-list.component.html',
  styleUrls: ['./data-list.component.scss']
})
export class DataListComponent implements OnInit {

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
    this.importServ.getTestObjects().subscribe(result => {
      this.dataSource = result;
      this.isLoadingResults = false;
    }); 
  }

}
