import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TerraTimerComponent } from './terra-timer.component';

@NgModule({
  declarations: [TerraTimerComponent],
  imports: [
    CommonModule
  ],
  exports: [TerraTimerComponent]
})
export class TerraTimerModule { }
