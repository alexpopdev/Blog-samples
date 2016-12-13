import { Component, Input, Output, EventEmitter, OnInit } from '@angular/core';

@Component({
    selector: 'div[my-child-comp]',
    template: `
        <p>{{myText}}</p>
        <p>
          <label for="child-component-input-{{myId}}">Override component message:</label>
          <input id="child-component-input-{{myId}}" type="text" [(ngModel)]="message">
        </p>
        <p><button class="btn btn-default" type="button" (click)="onClick()">Send message</button></p>`
})
export class ChildComponent { 
  @Input() myId: number;
  @Input() myText: string;
  @Output() onChildMessage = new EventEmitter<string>();
  message: string; 

  constructor() {
  } 
  
  ngOnInit(){
   this.message = `Hello from child with id ${this.myId}`;
  }

  onClick(){
    this.onChildMessage.emit(this.message);
  }
}
