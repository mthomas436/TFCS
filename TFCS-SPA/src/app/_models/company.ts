import { Survey } from './survey';

export class Company {
    companyId: number;
    name: string;
    logoImagePath: string;
    active: boolean;
    surveys: Survey[];
}
