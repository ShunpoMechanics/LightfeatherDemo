import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Supervisor } from '../models/models';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  private apiUrl = environment.apiUrl;
  constructor(private http: HttpClient) { }

  public getSupervisors() : Observable<Supervisor[]> {
    return this.http.get(this.apiUrl + 'Supervisor').pipe(map((data: any) => 
      {
        let vals: Supervisor[] = [];
        data.forEach((item: any) => 
          {
            let supervisor: Supervisor = {
              name: item.Name,
              id: item.Id,
              email: item.Email,
              phoneNumber: item.PhoneNumber,
              subscribers: item.Subscibers,
              specialization: item.Specialization
            }
            vals.push(supervisor);
          })
          return vals;
      }

    ));
  }

  public saveSubscribers(supervisor: Supervisor) : Observable<Supervisor[]> {
    return this.http.put<Supervisor[]>(this.apiUrl + 'Supervisor', supervisor);
  }
}
