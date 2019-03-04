import { Component, OnInit, Input } from '@angular/core';
import { Survey } from 'src/app/_models/survey';
import {PanelMenuModule} from 'primeng/panelmenu';
import {TreeTableModule} from 'primeng/treetable';
import {TreeNode} from 'primeng/api';
import {MenuItem} from 'primeng/api';

@Component({
  selector: 'app-menuitem',
  templateUrl: './menuitem.component.html',
  styleUrls: ['./menuitem.component.css']
})
export class MenuItemComponent implements OnInit {
  @Input() surveys: Survey[];

  files: TreeNode[] = [];
  data: any;
  treeNodes: any = {};
  constructor() { }

  ngOnInit() {
    this.generateMenuData();
  }

  generateMenuItems() {


   this.surveys.forEach( (item) => {
        this.files = [
            {
                label: item.surveyTypes.description,
                data: 'Documents Folder',
                expandedIcon: 'fa fa-folder-open',
                collapsedIcon: 'fa fa-folder'
            }
        ];
   });

  }


  generateMenuData() {
    this.surveys.forEach( (item, index) => {
      const menunode: TreeNode = {};
      menunode.label = item.surveyTypes.description;
      menunode.collapsedIcon = 'fa fa-folder',
      menunode.expandedIcon = 'fa fa-folder-open';
      this.files.push(menunode);
    });

  }

}
