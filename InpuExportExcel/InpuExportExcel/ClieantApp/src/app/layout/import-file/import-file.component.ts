import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { ImportService } from '../../_services/import.service';

@Component({
  selector: 'app-import-file',
  templateUrl: './import-file.component.html',
  styleUrls: ['./import-file.component.scss']
})
export class ImportFileComponent implements OnInit {

  constructor(
    private importServ: ImportService
  ) { }

  ngOnInit() {
  }

  onPost() {
      
    this.importServ.postTestObjects().subscribe(res => {
      alert("Finish");
    });

  }

  onRefresh() {
    this.importServ.onRefreshData.emit();
  }



}
