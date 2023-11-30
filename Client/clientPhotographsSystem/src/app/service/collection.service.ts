import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Collection } from '../models/collection'


@Injectable({
  providedIn: 'root',
})
export class CollectionService {
  private apiUrl = 'https://localhost:7050/api/Collection'; // Adjust to your server URL 


  constructor(private http: HttpClient) { }
  Collection?: Collection;
  getCollectionName(collectionNumber: string): Observable<Collection> {
    const url = `${this.apiUrl}/${collectionNumber}`;
    console.log(`😁😁${url}`)
    return this.http.get<Collection>(url);
  }
  saveCollection(collections: Collection) {
    return this.http.post(this.apiUrl, collections);
  }
}