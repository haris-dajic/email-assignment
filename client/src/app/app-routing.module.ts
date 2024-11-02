import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {AddEmailComponent} from './add-email/add-email.component';
import {HistoryComponent} from './history/history.component';

const routes: Routes = [
  {
    path: '', component: AddEmailComponent, pathMatch: 'full',
  },
  { path: 'history', component: HistoryComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
