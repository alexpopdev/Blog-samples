import { Component } from '@angular/core';
import { ChildComponent } from './child.component';
@Component({
  selector: 'div.container.text-center.my-app',
  template: `    
    <div class="row">
      <div class="col-md-12">
        <div class="page-header">
          <h1>{{title}}</h1>
        </div>
        <p class="lead">{{description}}</p>
      </div>
    </div>
    <div class="row">
      <div class="col-md-6" my-child-comp myText="First child component goes here" (onChildMessage)="onChildMessageReceived($event)"></div>      
      <div class="col-md-6" my-child-comp [myText]="secondComponentText" (onChildMessage)="onChildMessageReceived($event)"></div>         
    </div>
    <div class="row">
      <div class="col-md-12">
        <div class="well well-sm">         
          <p>Last message from a child component: <strong>{{lastMessage}}</strong></p>
        </div>
      </div>
    </div>`
})
export class AppComponent {
  title: string;
  description: string;
  secondComponentText: string;
  lastMessage: string;

  constructor() {
    this.title = 'Angular 2 101 example';
    this.description = 'This is an example for Angular 2 parent and child components.';
    this.secondComponentText = 'Second child component goes here';
  }

  onChildMessageReceived($event: string) {
    this.lastMessage = $event;
  }
}
