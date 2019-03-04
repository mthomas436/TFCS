import { SurveyOption } from './surveyoption';

export class SurveyQuestion {
    questionId: number;
    surveyId: number;
    questionName: string;
    shortQuestionName: string;
    questionOrder: number;
    questionType: string;
    surveyOptions: SurveyOption[];
    required: boolean;
}
