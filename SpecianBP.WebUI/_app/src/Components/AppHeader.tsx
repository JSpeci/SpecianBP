import * as React from 'react'
import { ApiRequest } from 'utils/ApiRequest';

export interface AppHeaderProps {

}

export class AppHeader extends React.Component<AppHeaderProps> {
    render() {

        const apiReq: ApiRequest = new ApiRequest("");

        let data = apiReq.getValues();


        console.log(data);

        return (
            <div className="header">

            </div>
        );
    }
}
