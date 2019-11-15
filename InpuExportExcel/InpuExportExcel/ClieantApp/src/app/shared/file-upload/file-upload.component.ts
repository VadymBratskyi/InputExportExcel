import { Component, OnInit } from '@angular/core';
import { ImportService } from 'src/app/_services/import.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-file-upload',
  templateUrl: './file-upload.component.html',
  styleUrls: ['./file-upload.component.scss']
})
export class FileUploadComponent implements OnInit {
  
  uploadSaveUrl = environment.localhostApp + environment.urlApi + 'PostAddFile'; // should represent an actual API endpoint
  uploadRemoveUrl = environment.localhostApp + environment.urlApi + 'PostRemoveFiles'; // should represent an actual API endpoint

  constructor (
    private importServ: ImportService
  ){
    
  }
 
  ngOnInit() {
  }


}
