import { ErrorObject } from "./Error";
import { Position } from "./Position";

export interface EmployeeBody {
  name: string;
  email: string;
  phoneNo: string;
  gender: string;
  positionCode: string;
  salary: number;
  photo: string;
  dob: Date;
  remarks: string;
}

export interface EmployeeResponse {
  id: number;
  name: string;
  email: string;
  phone_No: string;
  gender: string;
  position: Position;
  salary: number;
  photo: string;
  dob: Date;
  remarks: string;
}

export interface EmployeeQueryResponse {
  totalItems: number;
  items: EmployeeResponse[];
}

export interface EmployeeListStore {
  isLoading: boolean;
  isRetrieved: boolean;
  error: ErrorObject;
  employees: EmployeeQueryResponse;
}

export interface EmployeeDetailStore {
  isLoading: boolean;
  isRetrieved: boolean;
  error: ErrorObject;
  employees: Employee[];
}

export interface EmployeeCreateStore {
  isLoading: boolean;
  error: ErrorObject;
  employee: EmployeeBody;
}
