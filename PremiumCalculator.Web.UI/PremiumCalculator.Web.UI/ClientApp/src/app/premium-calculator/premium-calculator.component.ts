import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-premium-calculator',
  templateUrl: './premium-calculator.component.html'
})

export class PremiumCalculatorComponent {
  public name: string;
  public age: number;
  public dateOfBirth: Date;
  public deathSumInsured: number;
  public monthlyDeathPremium: number;

  public selectedOccupation: Occupation;
  public occupations: Occupation[];

  //MLEE: Ideally, a service will manage all http communication, and configuration retrieved from appsettings.json
  private api_path: string = "http://localhost:5000/";
  private http: HttpClient;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    this.http.get<Occupation[]>(this.api_path + 'api/Occupations').subscribe(result => {
      this.occupations = result;
    }, error => console.error(error));
  }

  public onOptionsSelected(event) {
    if (this.name == null || this.age == null || this.dateOfBirth == null || this.deathSumInsured == null || this.selectedOccupation == null   ) {
      return;
    }

    var postData: QuoteRequest = {
      occupationId: event,
      deathSumInsured: Number(this.deathSumInsured),
      age: Number(this.age)
    };

    const headers: HttpHeaders = new HttpHeaders();
    headers.set('Accept', 'text/plain');
    headers.set('Content-Type', 'application/json');

    this.http.post<QuoteResponse>(this.api_path + 'api/Rating/CalculateDeathPremium', postData, { headers: headers })
      .subscribe(result => {
        console.log(result);
        this.monthlyDeathPremium = result.deathPremium;
      });

  }
  
}

interface Occupation {
  id: number;
  name: string;
  occupationTypeId: number;
}

interface QuoteRequest {
  occupationId: number;
  deathSumInsured: number;
  age: number;
}

interface QuoteResponse {
  deathPremium: number;
}


