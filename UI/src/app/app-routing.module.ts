import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SupervisorList } from './components/supervisor-table/supervisor-list.component';
import { UpdateSubscriberFormComponent } from './components/update-subscribers/update-subscribers.component';

const routes: Routes = [
  { path: '', redirectTo: '/supervisor-list', pathMatch: 'full' },
  { path: 'subscriber-form', component: UpdateSubscriberFormComponent },
  { path: 'supervisor-list', component: SupervisorList}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
