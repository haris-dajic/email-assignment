import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormArray, FormControl, FormGroup, Validators } from '@angular/forms';
import { EmailImportance } from '../shared/enums/email-importance';
import { EmailApiService } from '../shared/services/email-api.service';
import { MatChipInputEvent } from '@angular/material/chips';
import {MatDialog} from '@angular/material/dialog';
import {ConfirmationDialogComponent} from '../confirmation-dialog/confirmation-dialog.component';
import {AlertNotificationService} from '../shared/services/alert-notification.service';

@Component({
  selector: 'app-add-email',
  templateUrl: './add-email.component.html',
  styleUrls: ['./add-email.component.scss']
})
export class AddEmailComponent implements OnInit {
  form!: FormGroup;

  constructor(
    private readonly emailApiService: EmailApiService,
    private readonly dialog: MatDialog,
    private readonly alertNotificationService: AlertNotificationService
  ) {}

  ngOnInit(): void {
    this.form = new FormGroup({
      fromEmail: new FormControl('', [Validators.required, Validators.email]),
      toEmail: new FormControl('', [Validators.required, Validators.email]),
      ccEmails: new FormArray([], Validators.required),
      subject: new FormControl(''),
      importance: new FormControl(null, Validators.required),
      content: new FormControl('')
    });
  }

  addCcEmail(event: MatChipInputEvent): void {
    const value = (event.value || '').trim();
    const emailPattern = /^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$/;

    if (value && emailPattern.test(value)) {
      const ccEmails = this.form.get('ccEmails') as FormArray;
      ccEmails.push(new FormControl(value));
    }
    event.chipInput!.clear();
  }

  removeCcEmail(index: number): void {
    const ccEmails = this.form.get('ccEmails') as FormArray;
    ccEmails.removeAt(index);
  }

  get emailImportanceOptions() {
    return Object.values(EmailImportance).filter(value => typeof value === 'number');
  }

  getEmailImportanceLabel(value: number) {
    return EmailImportance[value];
  }

  onSubmit(): void {
    this.emailApiService.sendEmail(this.form.value).subscribe(
      () => this.alertNotificationService.openSnackBar("Email is successfully sent."),
      error => this.alertNotificationService.openSnackBar(error.message)
    );
  }

  getErrors(control: AbstractControl, displayName: string, customMessages: { [key: string]: string } | null = null): string[] {
    return Object.keys(control.errors || {}).map((key) => {
      switch (key) {
        case 'required':
          return `${displayName} ${customMessages?.[key] ?? "is required."}`;
        case 'pattern':
          return `${displayName} ${customMessages?.[key] ?? "contains invalid characters."}`;
        default:
          return `${displayName} is invalid.`;
      }
    });
  }

  openConfirmationDialog(): void {
    const dialogRef = this.dialog.open(ConfirmationDialogComponent);

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.form.reset();
      } else {
        dialogRef.close();
      }
    });
  }
}
