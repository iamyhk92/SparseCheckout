import { Component, OnInit, ViewChild } from '@angular/core';
import { ContactIndividualComponent } from './contact-individual.component';
import { ContactBusinessComponent } from './contact-business.component'
import { FormGroup, FormBuilder, AbstractControl } from '@angular/forms';

@Component({
  selector: 'app-contact',
  templateUrl: './contact.html',
})
export class ContactComponent implements OnInit {

  contactForm: FormGroup;
  @ViewChild(ContactIndividualComponent, { static: false }) contactindividual: ContactIndividualComponent;
  @ViewChild(ContactBusinessComponent, { static: false }) contactbusiness: ContactBusinessComponent;
  constructor(private formbuilder: FormBuilder) { }

  ngOnInit() {
    this.contactForm = this.formbuilder.group({
      Contacttype: ['individual'],
    })
  }
  contactType_Click(selectedtype: String): void {
    debugger;
    if (selectedtype == 'individual') {
      this.contactindividual.showPage = true;
      this.contactbusiness.showPage = false;
    }
    else {
      this.contactindividual.showPage = false;
      this.contactbusiness.showPage = true;

    }
  }
}
