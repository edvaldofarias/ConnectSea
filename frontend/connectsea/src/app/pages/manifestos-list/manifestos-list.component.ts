import { Component } from '@angular/core';
import { Manifesto } from '../../models/manifesto.model';
import { ManifestosService } from '../../services/manifestos.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-manifestos-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './manifestos-list.component.html',
  styleUrl: './manifestos-list.component.css'
})
export class ManifestosListComponent {
  constructor(private manifestosService: ManifestosService) { }
  manifestos: Manifesto[] = [];

  ngOnInit() {
    this.manifestosService.listar()
      .subscribe(data => this.manifestos = data);
  }
}
