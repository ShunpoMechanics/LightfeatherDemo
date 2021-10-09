import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Supervisor, Subscriber } from 'src/app/shared/models/models';
import { DataService } from 'src/app/shared/services/data.service';

@Component({
    selector: 'app-update-subscribers',
    templateUrl: './update-subscribers.component.html',
    styleUrls: ['./update-subscribers.component.scss'],
    providers: [DataService]
})

export class UpdateSubscriberFormComponent implements OnInit{

    constructor(private data: DataService, private formBuilder: FormBuilder, private _snackBar: MatSnackBar) {
        this.subscriberForm = this.formBuilder.group({
            name: [null, [Validators.required]],
            email: [null, [Validators.required, Validators.pattern(this.emailRegx)]],
            phoneNumber: [null, [Validators.required, Validators.pattern(this.phoneRegx)]]
          });
    }

    public isLoaded = false;
    subscriberForm: FormGroup;

    public supervisors: Supervisor[] | undefined;
    public subscriber: Subscriber = {};
    public selectedSupervisor: Supervisor = {};
    emailRegx = /^(([^<>+()\[\]\\.,;:\s@"-#$%&=]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,3}))$/;
    phoneRegx = /^([0-9][0-9][0-9](-[0-9][0-9][0-9])(-[0-9][0-9][0-9][0-9]))$/;

    ngOnInit() {
        this.getAllSupervisors();
    }

    getAllSupervisors() {
        this.data.getSupervisors().subscribe(data =>
            {
                this.supervisors = data;
                this.isLoaded = true;
            }
            );
    }

    saveSubscribers() {
        this.subscriber = this.subscriberForm.value;
        this.subscriber.supervisorId = this.selectedSupervisor.id;
        this.data.saveSubscribers(this.subscriber).subscribe(data => 
            {
                // reset form on submit
                this.subscriberForm = this.formBuilder.group({
                    name: [null, [Validators.required]],
                    email: [null, [Validators.required, Validators.pattern(this.emailRegx)]],
                    phoneNumber: [null, [Validators.required, Validators.pattern(this.phoneRegx)]]
                  });
                this._snackBar.open('Subscribed successfully!', 'Dismiss');
            },
            err => {
                this._snackBar.open(err.error.Message, 'Dismiss');
            }
            );
    }

    public resetForm() {
    }
}