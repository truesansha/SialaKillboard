import { ErrorHandler, Injectable } from '@angular/core';
import { ErrorService } from './services/error.service'

@Injectable()
export class AppErrorHandler implements ErrorHandler {

    constructor(private errorSerice: ErrorService) { }

    handleError(error: any) {
        let errorText: any;

        if (error && error.statusText) {
            errorText = error.statusText;
        } else {
            errorText = error;
        }

        this.errorSerice.raiseError(errorText);
    }
}