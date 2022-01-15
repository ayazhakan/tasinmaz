export class Pagination{
    count:number;
    page:number;
    pageSize:number;
    pageSizes :number[];
    
    constructor(count?:number,page?:number,pageSize?:number,pageSizes? :number[]){
    
    this.count=count;
    this.page=page;
    this.pageSize=pageSize;
    this.pageSizes=pageSizes;
    
    
    
    } 
}
