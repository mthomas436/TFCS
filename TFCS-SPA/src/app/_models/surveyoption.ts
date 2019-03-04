import { SurveyOptionType } from './surveyoptiontype';

export class SurveyOption {
    optionId: number;
    optionName: string;
    optionTypeId: number;
    optionOrder: number;
    questionId: number;
    optionType: SurveyOptionType;
    optionGroup?: number;
}
