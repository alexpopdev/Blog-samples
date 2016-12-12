import { Component } from '@angular/core';

@Component({
    selector: 'my-app',
    template: `
    <div class="container text-center">
      <div class="row">
        <div class="col-md-12">
          <div class="page-header">
            <h1>{{title}}</h1>
          </div>
          <p class="lead">{{description}}</p>
        </div>
      </div>
      <div class="row">
        <div class="col-md-6">
          <p>A child component could go here</p>
        </div>
        <div class="col-md-6">
          <p>Another child component could go here</p>
        </div>
      </div>          
    </div>    
    `
})
export class AppComponent { 
  title: string;
  description: string;

  constructor(){
    this.title = 'Angular 2 101 Example';
    this.description = 'This is an example for Angular 2 parent and child components and directives.';
  }
}
