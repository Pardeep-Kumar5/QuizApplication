export class StudentScore {
    scoreID :number;
    score :number;
    timeSpent:number;
    registerId:number;
    registerTable:any;
    categoryId:number;
    categoryTable:any;
   constructor()
   {
    this.scoreID=0;
    this.score=0;
    this.timeSpent=0;
    this.registerTable=null;
    this.registerId=0;
    this.categoryId=0;
    this.categoryTable=null;
   }
}

