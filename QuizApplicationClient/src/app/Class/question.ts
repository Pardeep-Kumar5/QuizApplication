export class Question {
    id?:number;
    questionText:string;
    option1:string;
    option2:string;
    option3:string;
    option4:string;
    answer:string
    categoryId:number
    constructor(){
        this.id=0;
        this.questionText="";
        this.option1="";
        this.option2="";
        this.option3="";
        this.option4="";
        this.answer="";
        this.categoryId=0
    }
}
