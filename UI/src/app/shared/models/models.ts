export interface User {
    id?: number;
    name?: string;
    email?: string;
    phoneNumber?: string;
}

export interface Supervisor extends User {
    subscribers?: Subscriber[];
    subscriberString?: string;
    specialization?: string;
}

export interface Subscriber extends User {
    supervisorId?: number;
}