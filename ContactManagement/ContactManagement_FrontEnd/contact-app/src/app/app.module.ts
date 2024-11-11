import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';
 
import { AppComponent } from './app.component';
import { ContactFormComponent } from './contact-form/contact-form.component';
import { ContactListComponent } from './contact-list/contact-list.component';  // Assuming you have a contact list component
import { ContactService } from './services/contact.service';  // Assuming your service is in services/contact.service.ts
import { AppRoutingModule } from './app.routes';
 
const appRoutes: Routes = [
  { path: '', component: ContactListComponent },  // Default route - list of contacts
  { path: 'contact-form', component: ContactFormComponent },  // Add new contact
  { path: 'contact-form/:id', component: ContactFormComponent },  // Edit existing contact
  { path: '**', redirectTo: '' }  // Wildcard route for 404
];
 
@NgModule({
  declarations: [
    AppComponent,
    ContactFormComponent,
    ContactListComponent  // Assuming this component exists for listing contacts
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    RouterModule.forRoot(appRoutes)  // Routing configuration
  ],
  providers: [ContactService],  // Register your ContactService here
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AppModule { }
 
 