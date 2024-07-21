export class Unauthorized extends Error {    

    constructor(status=400, ...params) {
      super(...params);
      this.name = "Unauthorized";
      this.status = status;
    }
  }