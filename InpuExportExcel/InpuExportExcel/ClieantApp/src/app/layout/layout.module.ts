import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { LayoutRoutingModule } from './layout-routing.module';
import { LayoutComponent } from './layout.component';

import {MatToolbarModule} from '@angular/material/toolbar';
import {MatIconModule} from '@angular/material/icon';
import {MatButtonModule} from '@angular/material/button'
import {MatTableModule} from '@angular/material/table';
import {MatProgressSpinnerModule} from '@angular/material/progress-spinner';

import { ImportFileComponent } from './import-file/import-file.component';
import { DataListComponent } from './data-list/data-list.component';

@NgModule({
  declarations: [
    LayoutComponent, 
    ImportFileComponent, 
    DataListComponent
  ],
  imports: [
    CommonModule,
    LayoutRoutingModule,

    /*material*/
    MatToolbarModule,
    MatIconModule,
    MatButtonModule,
    MatTableModule,
    MatProgressSpinnerModule
  ]
})
export class LayoutModule { }
