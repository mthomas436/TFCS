import { Component, OnInit, Input } from '@angular/core';
import { SurveyQuestion } from 'src/app/_models/surveyQuestion';
import { SurveyOptionType } from 'src/app/_models/surveyoptiontype';
import { SurveyBuilderService } from 'src/app/_services/surveybuilder.service';
import { ToastrService } from 'ngx-toastr';
import { SurveyOption } from 'src/app/_models/surveyoption';

@Component({
  selector: 'app-options',
  templateUrl: './options.component.html',
  styleUrls: ['./options.component.css']
})
export class OptionsComponent implements OnInit {
  @Input() question: SurveyQuestion;
  @Input() showNewOption: boolean;
  surveyQuestion: SurveyQuestion;
  optionTypes: SurveyOptionType[];
  newOption: boolean;
  showSaveIcon: boolean;

  newOptionName: string;
  newOptionTypeId: number;
  newOptionOrder: number;
  newOptionGroup: number;

  constructor(private surveyBuilderService: SurveyBuilderService, private toastr: ToastrService) { }

  ngOnInit() {
    this.newOption = this.showNewOption;
    this.showSaveIcon = false;
    this.surveyQuestion = this.question;
    this.getOptionTypes();
  }

  getOptionTypes() {
    this.surveyBuilderService.getOptionTypes().subscribe((optionTypes: SurveyOptionType[]) => {
      this.optionTypes = optionTypes;
    }, error => {
      this.toastr.error(error);
    });
  }

  addNew() {
    this.newOption = true;
  }

  saveChanges(e, option: SurveyOption) {
    this.showSaveIcon = true;
    let einfo: any  = {};
    einfo.value = e.srcElement.value;
    einfo.type = e.srcElement.attributes['attr.data-property'].value;


    console.log(einfo);

    if (einfo.type === 'optionorder') {
      option.optionOrder = einfo.value;
    }
    if (einfo.type === 'optionname') {
      option.optionName = einfo.value;
    }
    if (einfo.type === 'optiontype') {
      option.optionType = einfo.value;
    }
    if (einfo.type === 'optiongroup') {
      option.optionGroup = einfo.value;
    }

    console.log(option);

    this.surveyBuilderService.saveOption(option).subscribe((surveyOption: SurveyOption) => {

      this.showSaveIcon = false;
    }, error => {
      this.toastr.error(error);
    });
  }

  addNewOption() {
    this.showSaveIcon = true;
    const newOption: any = {
      optionName: this.newOptionName,
      optionTypeId: this.newOptionTypeId,
      optionOrder: this.newOptionOrder,
      optionGroup: this.newOptionGroup,
      questionId: this.question.questionId
    };

    this.surveyBuilderService.addOption(newOption).subscribe((surveyOption: SurveyOption) => {
      this.showSaveIcon = false;
      this.newOption = false;
      this.question.surveyOptions.push(newOption);
    }, error => {
      this.toastr.error(error);
    });
  }

  deleteOption(option: SurveyOption) {
    this.surveyBuilderService.deleteOption(option).subscribe((surveyOption: SurveyOption) => {
      this.showSaveIcon = false;
      this.newOption = false;

      // Delete the table row
      for(let i = 0; i < this.question.surveyOptions.length; ++i){
        if (this.question.surveyOptions[i].optionId === option.optionId) {
            this.question.surveyOptions.splice(i, 1);
        }
    }
    }, error => {
      this.toastr.error(error);
    });
  }

}
