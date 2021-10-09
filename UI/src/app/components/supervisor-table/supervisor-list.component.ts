import { Component, OnInit } from '@angular/core';
import { Supervisor, Subscriber } from 'src/app/shared/models/models';
import { DataService } from 'src/app/shared/services/data.service';

@Component({
    selector: 'app-supervisor-list',
    templateUrl: './supervisor-list.component.html',
    styleUrls: ['./supervisor-list.component.scss'],
    providers: [DataService]
})

export class SupervisorList implements OnInit{

    constructor(private data: DataService) {

    }

    public isLoaded = false;

    public supervisors: Supervisor[] = [];
    public columnsToDisplay = ['name', 'email', 'phoneNumber', 'specialization', 'subscribers'];
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

    stringifySubscribers(subs: Subscriber[]) {
        if(!subs)
            return null;
        let result = '';
        subs.forEach(sub => {
            result += sub.name += ', '
        })
        return result.substring(0, result.length-2);
    }
}