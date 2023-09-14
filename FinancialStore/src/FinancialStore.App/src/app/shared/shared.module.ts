import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

@NgModule({
  imports: [
    CommonModule,
    ReactiveFormsModule,
    RouterModule
  ],

  declarations: [
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],

  exports: [
    // shared modules
    CommonModule,
    ReactiveFormsModule,
    RouterModule,

    // shared components
  ]
})
export class SharedModule { }
