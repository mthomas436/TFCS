import { SurveyType } from './surveytype';
import { Company } from './company';
import { SurveyQuestion } from './surveyQuestion';

export class Survey {
    surveyId: number;
    companyId: number;
    active: boolean;
    surveyTypeId: number;
    surveyIntro: string;
    surveyFooterText: string;
    surveyTypes: SurveyType;
    company: Company;
    surveyQuestions: SurveyQuestion[];
}
