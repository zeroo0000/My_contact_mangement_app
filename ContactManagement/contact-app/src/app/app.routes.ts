import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ContactListComponent } from '../app/contact-list/contact-list.component';
import { ContactFormComponent } from '../app/contact-form/contact-form.component';
export const routes: Routes = [
  { path: 'contacts', component: ContactListComponent },
  { path: 'contact/new', component: ContactFormComponent },
  { path: 'contact/edit/:id', component: ContactFormComponent },
  { path: '', redirectTo: '/contacts', pathMatch: 'full' },
];
 
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }