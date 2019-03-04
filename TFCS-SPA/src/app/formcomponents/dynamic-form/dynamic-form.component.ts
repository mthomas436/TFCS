import { Component, OnInit, Input } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { QuestionBase } from 'src/app/_models/question-base';
import { QuestionControlService } from 'src/app/_services/question-control.service';

@Component({
  selector: 'app-dynamic-form',
  templateUrl: './dynamic-form.component.html',
  styleUrls: ['./dynamic-form.component.css']
})
export class DynamicFormComponent implements OnInit {

  constructor(private qcs: QuestionControlService) { }

  @Input() questions: QuestionBase<any>[] = [];
  form: FormGroup;
  payLoad = '';

  ngOnInit() {
    if (this.questions) {
      this.form = this.qcs.toFormGroup(this.questions);
    }
  }

  onSubmit() {
    this.payLoad = JSON.stringify(this.form.value);
  }

}
