import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgxPaginationModule } from 'ngx-pagination';
import { Ng2SearchPipeModule } from 'ng2-search-filter';
import { NgBootstrapFormValidationModule } from 'ng-bootstrap-form-validation';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginContainerComponent } from './modules/auth/login-container/login-container.component';
import { RegisterContainerComponent } from './modules/auth/register-container/register-container.component';
import { HeaderContainerComponent } from './modules/header/header-container/header-container.component';
import { QuestionInputContainerComponent } from './modules/question/question-input-container/question-input-container.component';
import { QuestionListContainerComponent } from './modules/question/question-list-container/question-list-container.component';
import { QuestionDetailContainerComponent } from './modules/question/question-detail-container/question-detail-container.component';
import { AnswerInputContainerComponent } from './modules/answer/answer-input-container/answer-input-container.component';
import { AnswerListContainerComponent } from './modules/answer/answer-list-container/answer-list-container.component';
import { CommonModule } from '@angular/common';
import { TagsContainerComponent } from './modules/tags/tags-container/tags-container.component';
import { DataSharingService } from './shared/services/data-sharing.service';

@NgModule({
  declarations: [
    AppComponent,
    LoginContainerComponent,
    RegisterContainerComponent,
    HeaderContainerComponent,
    QuestionInputContainerComponent,
    QuestionListContainerComponent,
    QuestionDetailContainerComponent,
    AnswerInputContainerComponent,
    AnswerListContainerComponent,
    TagsContainerComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    CommonModule,
    NgxPaginationModule,
    Ng2SearchPipeModule,
    NgBootstrapFormValidationModule.forRoot(),
    NgBootstrapFormValidationModule
  ],
  providers: [DataSharingService],
  bootstrap: [AppComponent]
})
export class AppModule {}
