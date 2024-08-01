import { NgModule } from '@angular/core';
import { SharedMaterialModule } from '../Shared/shared-material.module';
import { SharedComponentsModule } from './Components/shared-components.module';

@NgModule({
  imports: [
    SharedComponentsModule,
    SharedMaterialModule,
  ],
  exports: [
    SharedComponentsModule,
    SharedMaterialModule,
  ],
  providers: [
  ],
})
export class SharedModule { }
