import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FileUploadComponent } from './file-upload.component';
import { UploadModule } from '@progress/kendo-angular-upload';

@NgModule({
  declarations: [FileUploadComponent],
  imports: [
    CommonModule,
    
    UploadModule
  ],
  exports: [FileUploadComponent]
})
export class FileUploadModule { }
