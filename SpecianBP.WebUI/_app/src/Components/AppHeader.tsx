import * as React from 'react'
import { ApiRequest } from '../utils/ApiRequest'
import { observable, flow } from 'mobx';
import { observer } from 'mobx-react';

export interface AppHeaderProps {

}

@observer
export class AppHeader extends React.Component<AppHeaderProps> {

    @observable loading: boolean;
    apiReq: ApiRequest = new ApiRequest("https://localhost:44340");
    @observable data: string[];

    constructor(props: AppHeaderProps) {
        super(props);
        this.loading = false;
        this.load();
    }

    async load() {
        this.loading = true;
        await this.apiReq.getValues().then(data => { this.data = data });
        this.loading = false;
    }

    render() {

        if (this.data) {
            console.log(this.data);
        }
        return (
            <div className="header">
                {
                    this.data 
                    ? this.data.map(i => {
                        return (
                            <span key={i}>{i}</span>
                        );
                    })
                    : ""
                }
            </div>
        );
    }
}
