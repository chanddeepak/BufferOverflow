import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { LoginContainerComponent } from './modules/auth/login-container/login-container.component';
import { RegisterContainerComponent } from './modules/auth/register-container/register-container.component';
import { QuestionListContainerComponent } from './modules/question/question-list-container/question-list-container.component';
import { QuestionInputContainerComponent } from './modules/question/question-input-container/question-input-container.component';
import { QuestionDetailContainerComponent } from './modules/question/question-detail-container/question-detail-container.component';
import { AuthGuard } from './auth-guard.guard';
import { TagsContainerComponent } from './modules/tags/tags-container/tags-container.component';

const routes: Routes = [
  { path: '', component: QuestionListContainerComponent },
  { path: 'login', component: LoginContainerComponent },
  { path: 'register', component: RegisterContainerComponent },
  {
    path: 'question',
    children: [
      { path: 'detail/:id', component: QuestionDetailContainerComponent },
      { path: 'create', component: QuestionInputContainerComponent, canActivate: [AuthGuard] },
      { path: 'edit/:id', component: QuestionInputContainerComponent, canActivate: [AuthGuard] }
    ]
  },
  {
    path: 'tags',
    component: TagsContainerComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
