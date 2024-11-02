import {AfterViewInit, Component, ViewChild} from '@angular/core';
import {MatTableDataSource} from '@angular/material/table';
import {IEmailViewModel} from '../shared/models/email-view-model';
import {EmailApiService} from '../shared/services/email-api.service';
import {MatPaginator, PageEvent} from '@angular/material/paginator';
import {AlertNotificationService} from '../shared/services/alert-notification.service';

@Component({
  selector: 'app-history',
  templateUrl: './history.component.html',
  styleUrl: './history.component.scss'
})
export class HistoryComponent implements AfterViewInit{
  displayedColumns: string[] = ['fromEmail', 'toEmail', 'subject', 'content'];
  emails: MatTableDataSource<IEmailViewModel> = new MatTableDataSource<IEmailViewModel>();
  defaultPageIndex = 0;
  defaultPageSize = 5;
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(private readonly emailApiService: EmailApiService,
              private readonly alertNotification: AlertNotificationService) {
  }

  ngAfterViewInit(): void {
    this.loadData();
  }

  loadData(): void {
    const pageEvent = new PageEvent();
    pageEvent.pageIndex = this.defaultPageIndex;
    pageEvent.pageSize = this.defaultPageSize;
    this.getData(pageEvent);
  }

  getData(event: PageEvent){
    this.emailApiService.getEmails(
      event.pageIndex,
      event.pageSize).subscribe({
      next: (result) => {
        this.paginator.length = result.paginationInfo.total;
        this.paginator.pageIndex = result.paginationInfo.page;
        this.paginator.pageSize = result.paginationInfo.pageSize;
        this.emails = new MatTableDataSource<IEmailViewModel>(result.data);
      },
      error: (error) => this.alertNotification.openSnackBar(error.message)
    });
  }
}

