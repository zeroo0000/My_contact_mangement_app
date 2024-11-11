import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ContactDTO } from '../models/contact.dto';
import { ApiResponse } from '../models/api-response.dto';
 
@Injectable({
  providedIn: 'root',
})
export class ContactService {
  private apiUrl = 'https://localhost:7214/api/contacts';
 
  constructor(private http: HttpClient) { }
 
  // Get all contacts
  getContacts(): Observable<ApiResponse<ContactDTO[]>> {
    return this.http.get<ApiResponse<ContactDTO[]>>(this.apiUrl);
  }
 
  // Create a new contact
  createContact(contact: ContactDTO): Observable<ApiResponse<ContactDTO>> {
    return this.http.post<ApiResponse<ContactDTO>>(this.apiUrl, contact);
  }
 
  // Update an existing contact
  updateContact(id: number, contact: ContactDTO): Observable<ApiResponse<ContactDTO>> {
    return this.http.put<ApiResponse<ContactDTO>>(`${this.apiUrl}/${id}`, contact);
  }
 
  // Delete a contact
  deleteContact(id: number): Observable<ApiResponse<any>> {
    return this.http.delete<ApiResponse<any>>(`${this.apiUrl}/${id}`);
  }
 
  // Get a specific contact by ID
  getContactById(id: number): Observable<ApiResponse<ContactDTO>> {
    return this.http.get<ApiResponse<ContactDTO>>(`${this.apiUrl}/${id}`);
  }
}