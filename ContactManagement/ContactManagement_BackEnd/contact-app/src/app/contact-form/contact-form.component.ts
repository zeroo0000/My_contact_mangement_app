import { Component, OnInit } from '@angular/core';
 
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
 
import { ActivatedRoute, Router } from '@angular/router';
 
import { ContactService } from '../services/contact.service';
 
import { ContactDTO } from '../models/contact.dto';
 
import { ApiResponse } from '../models/api-response.dto';
 
@Component({
 
  selector: 'contact-form',
 
  templateUrl: './contact-form.component.html',
 
  styleUrls: ['./contact-form.component.css']
 
})
 
export class ContactFormComponent implements OnInit {
 
  contactForm: FormGroup;
 
  contactId: number | null = null;
 
  errorMessage: string | null = null;
 
  constructor(
 
    private fb: FormBuilder,
 
    private contactService: ContactService,
 
    private route: ActivatedRoute,
 
    private router: Router
 
  ) {
 
    this.contactForm = this.fb.group({
 
      firstName: ['', Validators.required],
 
      lastName: ['', Validators.required],
 
      email: ['', [Validators.required, Validators.email]]
 
    });
 
  }
 
 
 
  ngOnInit(): void {
 
    this.route.paramMap.subscribe(params => {
 
      this.contactId = +params.get('id')!;
 
      if (this.contactId) {
 
        this.getContactById(this.contactId);
 
      }
 
    });
 
  }
 
  getContactById(id: number): void {
 
    this.contactService.getContactById(id).subscribe(
 
      (response: ApiResponse<ContactDTO>) => {
 
        if (response.success && response.data) {
 
          const contact = response.data;
 
          this.contactForm.patchValue({
 
            firstName: contact.firstName,
 
            lastName: contact.lastName,
 
            email: contact.email
 
          });
 
        }
 
      },
 
      (error) => {
 
        this.errorMessage = 'Failed to load contact details!';
 
      }
 
    );
 
  }
 
  onSubmit(): void {
 
    if (this.contactForm.invalid) {
 
      return;
 
    }
 
    const contactData: ContactDTO = this.contactForm.value;
 
    if (this.contactId) {
 
      // Update the contact
 
      this.contactService.updateContact(this.contactId, contactData).subscribe(
 
        (response) => {
 
          if (response.success) {
 
            this.router.navigate(['/contacts']);
 
          } else {
 
            this.errorMessage = 'Failed to update contact!';
 
          }
 
        },
 
        (error) => {
 
          this.errorMessage = 'Error updating contact!';
 
        }
 
      );
 
    } else {
 
      // Create new contact
 
      this.contactService.createContact(contactData).subscribe(
 
        (response) => {
 
          if (response.success) {
 
            this.router.navigate(['/contacts']);
 
          } else {
 
            this.errorMessage = 'Failed to create contact!';
 
          }
 
        },
 
        (error) => {
 
          this.errorMessage = 'Error creating contact!';
 
        }
 
      );
 
    }
 
  }
 
}