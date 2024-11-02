import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {SendEmailRequest} from '../models/send-email.request';
import {Observable} from 'rxjs';
import {environment} from '../../../environments/environment';
import {ApiResult} from '../models/api-result';
import {IEmailViewModel} from '../models/email-view-model';

@Injectable({
  providedIn: 'root'
})
export class EmailApiService {

  constructor(private readonly http: HttpClient) { }


  sendEmail(email: SendEmailRequest): Observable<any> {
    return this.http.post(`${this.getUrl()}/create`, email);
  }

  getEmails(page: number, pageSize: number): Observable<ApiResult<IEmailViewModel>> {
    return this.http.get<ApiResult<IEmailViewModel>>(`${this.getUrl()}?page=${page}&pageSize=${pageSize}`);
  }

  private getUrl() {
    return `${environment.baseUrl}/emails`;
  }
}
