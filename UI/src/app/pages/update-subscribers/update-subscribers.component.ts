import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Supervisor, Subscriber } from 'src/app/shared/models/models';
import { DataService } from 'src/app/shared/services/data.service';

@Component({
    selector: 'app-update-subscribers',
    templateUrl: './update-subscribers.component.html',
    styleUrls: ['./update-subscribers.component.css'],
    providers: [DataService]
})

export class UpdateSubscriberFormComponent implements OnInit{

    constructor(private data: DataService, private formBuilder: FormBuilder) {
        this.subscriberForm = this.formBuilder.group({
            name: [null, Validators.required],
            email: [null, [Validators.required, Validators.pattern(this.emailRegx)]],
            phoneNumber: [null, Validators.required]
          });
    }

    public isLoaded = false;
    subscriberForm: FormGroup;

    public supervisors: Supervisor[] | undefined;
    public subscriber: Subscriber = {};
    public selectedSupervisor: Supervisor = {};
    emailRegx = /^(([^<>+()\[\]\\.,;:\s@"-#$%&=]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,3}))$/;

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
        this.subscriber.supervisor = this.selectedSupervisor;
        console.log(this.subscriberForm.value);
    }

    public resetForm() {
        this.supervisors;
    }
}