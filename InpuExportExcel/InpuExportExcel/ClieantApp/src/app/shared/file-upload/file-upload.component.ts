import { Component, OnInit } from '@angular/core';
import { ImportService } from 'src/app/_services/import.service';

@Component({
  selector: 'app-file-upload',
  templateUrl: './file-upload.component.html',
  styleUrls: ['./file-upload.component.scss']
})
export class FileUploadComponent implements OnInit {
  
  uploadSaveUrl = 'https://localhost:5001/api/Input/PostAddFile'; // should represent an actual API endpoint
  uploadRemoveUrl = 'https://localhost:5001/api/Input/PostRemoveFiles'; // should represent an actual API endpoint

  constructor (
    private importServ: ImportService
  ){
    
  }
 
  ngOnInit() {
  }


}
