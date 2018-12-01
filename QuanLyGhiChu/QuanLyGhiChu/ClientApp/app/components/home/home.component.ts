import { Component, Inject } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Http } from '@angular/http';

@Component({
    selector: 'home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.css']
})
export class HomeComponent {
    http: Http;

    constructor(http: Http, @Inject('BASE_URL') baseurl: string) {
        this.http = http;
    }
    public postCreateNote(f: NgForm) {
        this.http.post('api/GhiChuApi/Create', f.value).subscribe(
            data => {
                if (data.status === 200) {
                    console.log(data.text);
                }
            },
            error => console.log("Error")
        )
    }
}
