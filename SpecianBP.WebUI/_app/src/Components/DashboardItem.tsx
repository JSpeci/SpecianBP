import * as React from 'react'
import { observer } from 'mobx-react';


export interface DashboardItemProps {
    name: string;
}

@observer
export class DashboardItem extends React.Component<DashboardItemProps> {

    render() {
        return (
            <div className="dashboardItem">
                <span>{this.props.name}</span>
            </div>
        );
    }
}
