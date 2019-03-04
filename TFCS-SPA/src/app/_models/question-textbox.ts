import { QuestionBase } from './question-base';

export class TextboxQuestion extends QuestionBase<string> {
    controlType = 'textbox';
    type: string;
    options: {key: string, value: string}[] = [];

    constructor(options: {} = {}) {
        super(options);
        this.type = options['options'] || [];
      }
}
