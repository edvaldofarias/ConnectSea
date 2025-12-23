import { Component, OnInit } from '@angular/core';
import { Manifesto } from '../../models/manifesto.model';
import { ManifestosService } from '../../services/manifestos.service';
import { CommonModule } from '@angular/common';
import { Escala } from '../../models/escala.model';
import { EscalasService } from '../../services/escalas.service';
import { StatusEscala } from '../../enums/statusEscala';

@Component({
  selector: 'app-manifestos-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './manifestos-list.component.html',
  styleUrl: './manifestos-list.component.css'
})
export class ManifestosListComponent implements OnInit {
  constructor(
    private manifestosService: ManifestosService,
    private escalaService: EscalasService) { }
  manifestos: Manifesto[] = [];
  escala: Escala[] = [];
  showModal: boolean = false;
  selectedEscalaId: number | null = null;
  currentManifestoId: number | null = null;
  StatusEscala = StatusEscala;

  ngOnInit() {
    this.manifestosService.listar()
      .subscribe(data => this.manifestos = data);

    this.escalaService.listar()
      .subscribe(data => this.escala = data);
  }
  openModal(manifestoId: number) {
    this.currentManifestoId = manifestoId;
    this.selectedEscalaId = null;
    this.showModal = true;
  }

  closeModal() {
    this.showModal = false;
    this.currentManifestoId = null;
    this.selectedEscalaId = null;
  }

  selectEscala(escalaId: number) {
    this.selectedEscalaId = escalaId;
  }

  confirmVincular() {
    if (this.currentManifestoId == null || this.selectedEscalaId == null) return;
    this.vincularEscala(this.currentManifestoId, this.selectedEscalaId);
    this.closeModal();
  }

  vincularEscala(manifestoId: number, escalaId: number) {
    this.manifestosService.vincularEscala(manifestoId, escalaId)
      .subscribe({
        next: () => {
          alert('Escala vinculada com sucesso!');
        },
        error: (err) => {
          this.errorVincular(err);
        }
      });
  }

  errorVincular(err: any) {
    if (err.status === 400  ) {
      alert('Erro ao vincular escala: ' + err.error);
    }

    if(err.status === 500) {
      alert('Erro no servidor ao vincular escala.');
    }

    if(err.status === 409) {
      alert('Conflito ao vincular escala: ' + err.error);
    }

  }
}
