import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, AbstractControl, Validators, FormControl } from '@angular/forms';
import { Contactmaster, Conatactdetais, Contactaddress } from './../../../../Models/Loans/Masters/contactmaster';
import { ContacmasterService } from '../../../../Services/Loans/Masters/contacmaster.service'
@Component({
  selector: 'app-contact-individual',
  templateUrl: './contact-individual.component.html',
  styles: []
})
export class ContactIndividualComponent implements OnInit {
  contactForm: FormGroup;

  showPage = true;
  contactSubmitted = false;
  contacAddrSubmitted = false;
  lstaddressdetails = [];
  _contactmaster: Contactmaster;
 titleDetails: any;
  addressTypeDetails: any;
  countryDetails: any;
  stateDetails: any;
  districtDetails: any;
  constructor(private formbuilder: FormBuilder, private _contacmasterservice: ContacmasterService) { }

  contactValidationMessages = {
    'pName': { 'required': 'First Name Required' },
    'pDob': { 'required': 'Date of Birth Required' },
    'pGender': { 'required': ' Required' },

    //'pFatherName': {'required': 'Father Name Required' },
    //'pSpouseName': { 'required': 'Spouse Name Required' },


    'pAge': { 'required': 'Age Required' },
    'pTitle': { 'required': 'First Name Required' },
    'pEmailId1': { 'email': 'Invalid Email Id' },
    'pEmailId2': { 'eami': 'Invalid Email Id' },
    'pContactNo': { 'required': 'Primary Contact Number Required' },

  }

  contactValidationErrors = {
    'pName': '',
    'pContactId': '',
    'pReferenceId': '',
    'pContactType': '',
    'pSurName': '',
    'pDob': '',
    'pGender': '',
    'pGenderCode': '',
    'pFatherName': '',
    'pSpouseName': '',

    'pStatusId': '',
    'pCreatedBy': '',
    'pModifiedBy': '',
    'pAge': '',
    'pTitle': '',
    'pEmailId1': '',
    'pEmailId2': '',
    'pContactNo': '',
    'pAlternativeNo': '',
  }

  contactAddrValidationMessages = {

    'pAddressType': { 'required': 'Address Type Required' },
    //'pAddress1': { 'required': ' Required' },
    //'pAddress2': { 'required': ' Required' },
    'pState': { 'required': 'State Required' },

    'pDistrict': { 'required': 'District Required' },

    'pCity': { 'required': 'City/Village Required' },

    'pCountry': { 'required': 'Country Required' },
    'pPinCode': { 'required': 'Pincode Required' },
  }

  contactAddrValidationErrors = {
    'pAddressType': '',
    'pAddress1': '',
    'pAddress2': '',
    'pState': '',
    'pStateId': '',
    'pDistrict': '',
    'pDistrictId': '',
    'pCity': '',
    'pCityId': '',
    'pCountry': '',
    'pPinCode': '',
  }

  ngOnInit() {

    this.contactForm = this.formbuilder.group({
      pName: ['', Validators.required],
      pContactId: [''],
      pReferenceId: [''],
      pContactType: [''],
      pSurName: [''],
      pDob: ['', Validators.required],
      pGender: ['', Validators.required],
      pGenderCode: [''],
      pFatherName: [''],
      pSpouseName: [''],

      pStatusId: [''],
      pCreatedBy: [''],
      pModifiedBy: [''],
      pAge: ['', Validators.required],
      pTitle: ['', Validators.required],
      pcontactdetailslist: this.formbuilder.array([this.addcontactControls()]),
      pAddressControls: this.addAddressControls(),
      pAddressList: this.formbuilder.array([this.addAddressControls()]),
    })

    this.getAddressTypeDetails();
    this.gettitleDetails();
    this.getCountryDetails();

  }

  gettitleDetails(): void {

    this.titleDetails = this._contacmasterservice.gettitleDetails();
  }
  getAddressTypeDetails(): void {
    debugger;

    this._contacmasterservice.getAddressTypeDetails().subscribe(json => {
      debugger;
      //console.log(json)
      if (json != null) {
        this.addressTypeDetails  = json as string
        this.addressTypeDetails = eval("(" + this.addressTypeDetails  + ')');
        this.addressTypeDetails = this.addressTypeDetails.FT;
      }
    });

    this._contacmasterservice.getAddressTypeDetails().sub
    //this.addressTypeDetails = ;
  }
  getCountryDetails(): void {
    debugger;
    this.countryDetails = this._contacmasterservice.getCountryDetails();
  }

  pCountry_Change(): void {
    this.stateDetails = this._contacmasterservice.getSateDetails('');

  }
  pState_Change(): void {
    alert('State Changed');
  }

  addcontactControls(): FormGroup {
    return this.formbuilder.group({
      pEmailId1: ['', Validators.email],
      pEmailId2: ['', Validators.email],
      pContactNo: ['', Validators.required],
      pAlternativeNo: [''],
    })
  }
  addAddressControls(): FormGroup {
    return this.formbuilder.group({
      pAddressType: ['', Validators.required],
      pAddress1: [''],
      pAddress2: [''],
      pState: ['', Validators.required],
      pStateId: ['', Validators.required],
      pDistrict: ['', Validators.required],
      pDistrictId: ['', Validators.required],
      pCity: ['', Validators.required],
      pCityId: ['', Validators.required],
      pCountry: ['', Validators.required],
      pPinCode: ['', Validators.required],
    })
  }
  checkContactValidations(group: FormGroup = this.contactForm): void {
    try {

      Object.keys(group.controls).forEach((key: string) => {
        this.GetContactValidationByControl(key);
      })

    }
    catch (e) {
      alert(e);
    }
  }
  GetContactValidationByControl(key: string): void {

    const formcontrol = this.contactForm.get(key);
    this.checkContactValidationByControl(formcontrol, key)
  }
  checkContactValidationByControl(formcontrol: AbstractControl, key: string): void {
    try {
      if (formcontrol instanceof FormGroup) {
        this.checkContactValidations(formcontrol)
      }
      else {
        this.contactValidationErrors[key] = '';
        if (formcontrol && formcontrol.invalid && (formcontrol.touched || formcontrol.dirty || this.contactSubmitted)) {
          const controldetails = this.contactValidationMessages[key];


          for (const errorkey in formcontrol.errors) {
            if (errorkey) {
              const errmsg = controldetails[errorkey];
              this.contactValidationErrors[key] += errmsg + ' ';
            }
          }
        }
      }
    }
    catch (e) {
      alert(e);
    }
  }

  ///////////////////////////////////

  checkContactAddrValidations(group: FormGroup = this.contactForm): void {
    try {

      Object.keys(group.controls).forEach((key: string) => {
        this.GetContactAddrValidationByControl(key);
      })

    }
    catch (e) {
      alert(e);
    }
  }
  GetContactAddrValidationByControl(key: string): void {

    const formcontrol = this.contactForm.get(key);
    this.checkContactAddrValidationByControl(formcontrol, key)
  }
  checkContactAddrValidationByControl(formcontrol: AbstractControl, key: string): void {
    try {
      if (formcontrol instanceof FormGroup) {
        this.checkContactAddrValidations(formcontrol)
      }
      else {
        this.contactAddrValidationErrors[key] = '';
        if (formcontrol && formcontrol.invalid && (formcontrol.touched || formcontrol.dirty || this.contacAddrSubmitted)) {
          const controldetails = this.contactAddrValidationMessages[key];


          for (const errorkey in formcontrol.errors) {
            if (errorkey) {
              const errmsg = controldetails[errorkey];
              this.contactAddrValidationErrors[key] += errmsg + ' ';
            }
          }
        }
      }
    }
    catch (e) {
      alert(e);
    }
  }



  addAddressDeatails(): void {

    this.contacAddrSubmitted = true;
    this.checkContactAddrValidations(this.contactForm);
    const control = <FormGroup>this.contactForm['controls']['pAddressControls'];
    this.lstaddressdetails.push(control.value);

  }



  saveContactDetails(): void {
    debugger;
    try {
      this.contactSubmitted = true;
      this.checkContactValidations(this.contactForm);
      this._contactmaster = this.contactForm.value;
      this._contactmaster.pAddressList = this.lstaddressdetails;
      this.contactForm['controls']['pAddressList'].setValue(this.lstaddressdetails);
    }
    catch (e) {
      alert(e);
    }
    //this.contactForm  pAddressList

  }
}
