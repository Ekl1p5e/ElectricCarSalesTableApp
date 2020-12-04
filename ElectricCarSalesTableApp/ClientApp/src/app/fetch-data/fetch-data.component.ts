import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public salesdata: SalesTableData;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<SalesTableData>(baseUrl + 'salestabledata').subscribe(result => {
      this.salesdata = result;
    }, error => console.error(error));
  }
}

interface SalesTableData {
  columnNames: string[];
  rows: string[][];
}
