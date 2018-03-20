import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'sortOnline'
})
export class SortOnlinePipe implements PipeTransform {
    transform(array: any[], relationship: any): any[] {
        array.sort((member: any, member2: any) => {
            if (member[relationship].servers.data[0].meta.online > member2[relationship].servers.data[0].meta.online) {
                return -1;
            } else if (member[relationship].servers.data[0].meta.online < member2[relationship].servers.data[0].meta.online) {
                return 1;
            } else {
                return 0;
            }
        });
        return array;
    }
}
