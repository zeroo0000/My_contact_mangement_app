import { Component, OnInit } from '@angular/core';
import { ContactService } from '../services/contact.service';
import { ContactDTO } from '../models/contact.dto';
import { ApiResponse } from '../models/api-response.dto';
 
@Component({
  selector: 'app-contact-list',
  templateUrl: './contact-list.component.html',
  styleUrls: ['./contact-list.component.css']
})
export class ContactListComponent implements OnInit {
  contacts: ContactDTO[] = [];
  errorMessage: string = '';
 
  constructor(private contactService: ContactService) { }
 
  ngOnInit(): void {
    this.getContacts();
  }
 
  getContacts(): void {
    this.contactService.getContacts().subscribe(
      (response: ApiResponse<ContactDTO[]>) => {
        if (response.success) {
          this.contacts = response.data || [];
        } else {
          this.errorMessage = response.message;
        }
      },
      (error) => {
        this.errorMessage = 'Failed to load contacts!';
      }
    );
  }
 
  deleteContact(id: number): void {
    if (confirm('Are you sure you want to delete this contact?')) {
      this.contactService.deleteContact(id).subscribe(
        (response: ApiResponse<any>) => {
          if (response.success) {
            this.getContacts(); // Reload contacts after deletion
          } else {
            this.errorMessage = response.message;
          }
        },
        (error) => {
          this.errorMessage = 'Failed to delete contact!';
        }
      );
    }
  }
}