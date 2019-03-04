import { QuestionBase } from './question-base';

export class CheckboxQuestion extends QuestionBase<string>{
    controlType = 'checkbox';
    options: {key: string, value: string, required: boolean}[] = [];

    constructor(options: {} = {}) {
      super(options);
      this.options = [];
    }
}
