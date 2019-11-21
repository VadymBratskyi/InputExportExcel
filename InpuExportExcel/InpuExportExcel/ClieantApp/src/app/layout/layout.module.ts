import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { LayoutRoutingModule } from './layout-routing.module';
import { LayoutComponent } from './layout.component';

import {MatToolbarModule} from '@angular/material/toolbar';
import {MatIconModule} from '@angular/material/icon';
import {MatButtonModule} from '@angular/material/button'
import {MatPaginatorModule} from '@angular/material/paginator';
import {MatTableModule} from '@angular/material/table';

import {MatProgressSpinnerModule} from '@angular/material/progress-spinner';
import {MatButtonToggleModule} from '@angular/material/button-toggle';
import { ImportFileComponent } from './import-file/import-file.component';
import { DataListComponent } from './data-list/data-list.component';
import { FileUploadModule } from '../shared/file-upload/file-upload.module';
import { TerraTimerModule } from '../shared/terra-timer/terra-timer.module';

@NgModule({
  declarations: [
    LayoutComponent, 
    ImportFileComponent, 
    DataListComponent
  ],
  imports: [
    CommonModule,
    LayoutRoutingModule,
    FileUploadModule,
    TerraTimerModule,

    /*material*/
    MatToolbarModule,
    MatIconModule,
    MatButtonModule,
    MatButtonToggleModule,
    MatTableModule,
    MatProgressSpinnerModule,
    MatPaginatorModule    
  ]
})
export class LayoutModule { }
