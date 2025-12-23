import { Component } from '@angular/core';
import { EscalasService } from '../../services/escalas.service';
import { Escala } from '../../models/escala.model';
import { CommonModule } from '@angular/common';
import { StatusEscala } from '../../enums/statusEscala';

@Component({
  selector: 'app-escalas-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './escalas-list.component.html',
  styleUrl: './escalas-list.component.css'
})
export class EscalasListComponent {
  constructor(public escalaService: EscalasService) { }

  escalas: Escala[] = [];
  StatusEscala = StatusEscala;

  ngOnInit() {
    this.escalaService.listar()
        .subscribe(data => this.escalas = data);
  }
}
