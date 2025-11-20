import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class BusyService {
  loading = false;
  busyRquestCount = 0;

  busy() {
    this.busyRquestCount++;
    this.loading = true;
  }

  idle() {
    this.busyRquestCount--;

    if (this.busyRquestCount <= 0) {
      this.busyRquestCount = 0;
      this.loading = false;
    }
  }
}
