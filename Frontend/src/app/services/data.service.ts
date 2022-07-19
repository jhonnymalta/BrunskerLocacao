import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IImovel } from '../model/IImovel';

@Injectable({
  providedIn: 'root',
})
export class DataService {
  constructor(private http: HttpClient) {}

  getImoveis() {
    return this.http.get<any[]>('http://localhost:5257/v1/imoveis/');
  }
  getImovel(id: number) {
    return this.http.get<any>('http://localhost:5257/v1/imoveis/' + id);
  }
  postImovel(imovel: any) {
    return this.http.post<any>('http://localhost:5257/v1/imoveis/', imovel);
  }
  putImovel(imovel: IImovel) {
    return this.http.put<IImovel>(
      'http://localhost:5257/v1/imoveis/' + imovel.id,
      imovel
    );
  }
  deleteImovel(imovelID: number) {
    return this.http.delete('http://localhost:5257/v1/imoveis/' + imovelID);
  }
}
