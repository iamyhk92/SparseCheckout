import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Contactmaster, Conatactdetais, Contactaddress } from '../../../Models/Loans/Masters/contactmaster';
import { environment } from '../../../../environments/environment';


@Injectable({
  providedIn: 'root'
})
export class ContacmasterService {
  _Contactaddress: Contactaddress[] = [];
  httpHeaders = new HttpHeaders({
    'Content-Type': 'application/json',
    'Cache-Control': 'no-cache'
  });

  lstAdresstype: Contactaddress[] = [
    { pAddressType: "OFFICE" },
    { pAddressType: "HOME" }
  ];


  lstTitle: Contactmaster[] = [
    { pTitle: "Mr" },
    { pTitle: "Ms" },
    { pTitle: "Miss" },
    { pTitle: "Mrs" },
    { pTitle: "Master" },
    { pTitle: "Dr" },
    { pTitle: "Prof" },
  ]

  lstCountry: Contactaddress[] = [
    { pCountryid:'1', pCountry: "INDIA" },
    { pCountryid: '1', pCountry: "USA" },
    { pCountryid: '1', pCountry: "CHINA" },
  ];
  constructor(private http: HttpClient) { }

  saveContactIndividual(_contact: Contactmaster): void {
    //let options = {
    //  headers: this.httpHeaders,
    //  params: HttpParams
    // };
  }

  gettitleDetails(): any {
    return this.lstTitle;
  }

  getAddressTypeDetails(): any {
    debugger;
    ///loans/masters / contact / GetAddressType
    return this.http.get(environment.apiURL + '/loans/masters/contact/GetAddressType');
  }
  getCountryDetails(): any {
    return this.lstCountry;
  }
  getSateDetails(countryid: string): any {

  }
  getDistrictDetails(stateid: string): any {

  }

}
