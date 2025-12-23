import { Routes } from '@angular/router';
import { ManifestosListComponent } from './pages/manifestos-list/manifestos-list.component';
import { EscalasListComponent } from './pages/escalas-list/escalas-list.component';

export const routes: Routes = [
  {path: '', redirectTo: 'manifestos', pathMatch: 'full' },
  { path: 'manifestos', component: ManifestosListComponent },
  { path: 'escalas', component: EscalasListComponent }
];
