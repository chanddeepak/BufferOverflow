import { Injectable } from '@angular/core';

@Injectable()
export class DataSharingService {
  check = false;
  constructor() {}

  set() {
    this.check = true;
  }

  get() {
    return this.check;
  }
}
