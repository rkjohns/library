import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { SharedModule  } from './Shared/shared.module';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { LoginScreenComponent } from './Views/login-screen/login-screen.component';
import { RegistrationComponent } from './Views/registration/registration.component';
import { SharedMaterialModule } from './Shared/shared-material.module';
import { HomeComponent } from './Views/home/home.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginScreenComponent,
    RegistrationComponent,
    HomeComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    SharedModule,
    SharedMaterialModule,
    AppRoutingModule
  ],
  providers: [
    provideAnimationsAsync()
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
