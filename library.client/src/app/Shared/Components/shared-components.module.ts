import { NgModule } from '@angular/core';

import { HeaderComponent } from './header/header.component';
import { AppComponent } from '../../app.component';
import { SharedMaterialModule } from '../shared-material.module';

@NgModule({
  declarations: [
    HeaderComponent,
  ],
  imports: [
    SharedMaterialModule
  ],
  exports: [
    HeaderComponent,
  ],
  bootstrap: [AppComponent]
})
export class SharedComponentsModule { }
