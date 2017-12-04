import { CaseSheetPostModel } from './Models';

export class CaseSheetService {

    postCaseSheet(model: CaseSheetPostModel) {
        return fetch('/CaseSheets/Create', {
            method: 'POST',
            headers: new Headers({
                'Content-Type': 'application/json',
                'Accept': 'application/json'
            }),
            body: JSON.stringify(model)
        }).then(response => {
            if (response.ok)
                return response.json();
        });
    }
}

export default new CaseSheetService();