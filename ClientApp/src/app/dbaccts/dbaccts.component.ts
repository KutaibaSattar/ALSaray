import { MydbaccutService } from './../shared/mydbaccut.service';
import { Component, OnInit } from '@angular/core';
import { Mydbaccut } from '../shared/mydbaccut.model';


@Component({
  selector: 'dbaccts',
  templateUrl: './dbaccts.component.html',
  styleUrls: ['./dbaccts.component.css']
})
export class DbacctsComponent implements OnInit {
  myaccuts: Mydbaccut[]

  constructor(private mydbaccutservice : MydbaccutService) {}

  ngOnInit() {
    this.mydbaccutservice.getMyacctList().then(res => this.myaccuts = res as Mydbaccut[]);
  }

}
