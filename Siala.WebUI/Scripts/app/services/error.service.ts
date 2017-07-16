import { Injectable } from '@angular/core';
import { Subject } from 'rxjs/Subject';

@Injectable()
export class ErrorService {

    private errorMessageSource = new Subject<string>();
    errorRaised$ = this.errorMessageSource.asObservable();

    raiseError(errorText: string) {
        this.errorMessageSource.next(errorText);
    }
}