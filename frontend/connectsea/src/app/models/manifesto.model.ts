import { TipoManifesto } from "../enums/tipoManifesto";

export interface Manifesto {
  id: number;
  numero: string;
  tipo: TipoManifesto;
  navio: string;
  portoOrigem: string;
  portoDestino: string;
}
