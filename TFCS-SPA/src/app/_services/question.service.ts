import { Injectable } from '@angular/core';
import { QuestionDropdown } from '../_models/question-dropdown';
import { QuestionBase } from '../_models/question-base';
import { TextboxQuestion } from '../_models/question-textbox';
import { SurveyQuestion } from '../_models/surveyQuestion';
import { RadioQuestion } from '../_models/question-radio';
import { CheckboxQuestion } from '../_models/question-checkbox';

@Injectable()
export class QuestionService {

  // TODO: get from a remote source of question metadata
  // TODO: make asynchronous
  getQuestions() {

    const questions: QuestionBase<any>[] = [

      new QuestionDropdown({
        key: 'brave',
        label: 'Bravery Rating',
        options: [
          {key: 'solid',  value: 'Solid'},
          {key: 'great',  value: 'Great'},
          {key: 'good',   value: 'Good'},
          {key: 'unproven', value: 'Unproven'}
        ],
        order: 3
      }),

      new TextboxQuestion({
        key: 'firstName',
        label: 'First name',
        value: 'Bombasto',
        required: true,
        order: 1
      }),

      new TextboxQuestion({
        key: 'emailAddress',
        label: 'Email',
        type: 'email',
        order: 2
      })
    ];

    return questions.sort((a, b) => a.order - b.order);
  }

  getQuestionFormData(qtns: SurveyQuestion[]) {
    const questions: QuestionBase<any>[] = [];

    qtns.forEach((q, index) => {

      if (q.questionType == 'radiogroup') {

        const rq: RadioQuestion = {
          key: q.questionId.toString(),
          label: q.questionName,
          options: [],
          order: q.questionOrder,
          controlType: 'radio',
          value: '',
          required: q.required
        };


        q.surveyOptions.forEach((o) => {
          const opt: any = {
            key: o.optionId.toString(),
            value: o.optionName,
            optionGroup: o.optionGroup
          };

          rq.options.push(opt);
        });

       // rq.options = options;

        questions.push(rq);

      }

      if (q.questionType == 'checkbox') {

        const rq: CheckboxQuestion = {
          key: q.questionId.toString(),
          label: q.questionName,
          options: [],
          order: q.questionOrder,
          controlType: 'checkbox',
          value: '',
          required: q.required
        };


        q.surveyOptions.forEach((o) => {
          const opt: any = {
            key: o.optionId.toString(),
            value: o.optionName,
            optionGroup: o.optionGroup
          };
          rq.options.push(opt);
        });

       // rq.options = options;

        questions.push(rq);
      }

      if (q.questionType == 'memo') {
        const memo: TextboxQuestion = {
          key: q.questionId.toString(),
          label: q.questionName,
          options: [],
          order: q.questionOrder,
          type: 'memo',
          controlType: 'memo',
          value: '',
          required: q.required
        };

        q.surveyOptions.forEach((o) => {
          const opt: any = {
            key: o.optionId.toString(),
            value: o.optionName
          };
          memo.options.push(opt);
        });
         questions.push(memo);
      }


      if (q.questionType == 'text') {
        const text: TextboxQuestion = {
          key: q.questionId.toString(),
          label: q.questionName,
          options: [],
          type: 'text',
          order: q.questionOrder,
          controlType: 'text',
          value: '',
          required: q.required
        };

        q.surveyOptions.forEach((o) => {
          const opt: any = {
            key: o.optionId.toString(),
            value: o.optionName
          };
          text.options.push(opt);
        });
        questions.push(text);
      }

      if (q.questionType == 'date') {
        const date: TextboxQuestion = {
          key: q.questionId.toString(),
          label: q.questionName,
          options: [],
          type: 'date',
          order: q.questionOrder,
          controlType: 'date',
          value: '',
          required: q.required
        };

        q.surveyOptions.forEach((o) => {
          const opt: any = {
            key: o.optionId.toString(),
            value: o.optionName
          };
          date.options.push(opt);
        });
        questions.push(date);
      }
    });

    return questions.sort((a, b) => a.order - b.order);
  }
}
