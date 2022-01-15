export class PageRequest<T>{
count:number;
PageIndex:number;
PageSize:number;
items :T[];

constructor(count?:number,PageIndex?:number,PageSize?:number,items? :T[]){

this.count=count;
this.PageIndex=PageIndex;
this.PageSize=PageSize;
this.items=items;



}




}
