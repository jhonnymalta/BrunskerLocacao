import { Component, Input, OnInit } from '@angular/core';
import { ReplaySubject } from 'rxjs';
import { IImovel } from 'src/app/model/IImovel';
import { DataService } from 'src/app/services/data.service';

@Component({
  selector: 'app-cardimoveis',
  templateUrl: './cardimoveis.component.html',
  styleUrls: ['./cardimoveis.component.css'],
})
export class CardimoveisComponent implements OnInit {
  @Input() imovel: any;
  constructor(private dataService: DataService) {}

  ngOnInit(): void {}
  deletarImovel() {
    console.log('estou apertando');
    this.dataService.deleteImovel(this.imovel.id);
    console.log(this.imovel.id);
  }
}
