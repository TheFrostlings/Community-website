import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'sortName'
})
export class SortNamePipe implements PipeTransform {

    transform(array: any[], attributes: any): any[] {
        array.sort((member: any, member2: any) => {
            if (member[attributes].name < member2[attributes].name) {
                return -1;
            } else if (member[attributes].name > member2[attributes].name) {
                return 1;
            } else {
                return 0;
            }
        });
        return array;
    }

}
