export class User {
    id:number;
    name:string;
    address:string;
    email:string;
    password:string
    status:boolean
    constructor(){
        this.id=0;
        this.name="";
        this.address="";
        this.email="";
        this.password="";
        this.status=false;
    }
}
