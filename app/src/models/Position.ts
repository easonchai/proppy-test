import { ErrorObject } from "./Error";

export interface Position {
  code: string;
  description: string;
}

export interface PositionListStore {
  isLoading: boolean;
  isRetrieved: boolean;
  error: ErrorObject;
  positions: Position[];
}
