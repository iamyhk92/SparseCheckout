import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-contact-business',
  templateUrl: './contact-business.component.html',
  styles: []
})
export class ContactBusinessComponent implements OnInit {
  showPage = false;
  constructor() { }

  ngOnInit() {
  }

  ShowLoadPage(pagestatus: boolean): void {
    if (pagestatus == true) {
      this.showPage = true;

    }
    else {
      this.showPage = false;
    }
  }

}
