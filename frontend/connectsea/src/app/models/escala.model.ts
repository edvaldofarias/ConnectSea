import { StatusEscala } from "../enums/statusEscala";

export interface Escala {
  id: number;
  navio: string;
  porto: string;
  status: StatusEscala;
  eta: string;
  etb: string;
  etd: string;
}
