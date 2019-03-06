import * as React from 'react'
import { observer } from 'mobx-react';
import { DashboardItemModel } from 'Models/DashboardItemModel';


export interface DashboardItemProps {
    name: string;
    model?: DashboardItemModel;
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
