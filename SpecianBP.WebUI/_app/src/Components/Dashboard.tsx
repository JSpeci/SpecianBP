import * as React from 'react'
import { observer } from 'mobx-react';
import { SourceDataSettings } from './DataSettings';
import { DashboardItem } from './DashboardItem';
import { DashboardModel } from 'Models/DashboardModel';

export interface DashboardProps {
    dashboardModel: DashboardModel;
}

@observer
export class Dashboard extends React.Component<DashboardProps> {

    render() {
        return (
            <div className="dashboard">
                <div className="dashboardHeader">
                    <SourceDataSettings model={this.props.dashboardModel} />
                </div>
                <div className="dashboardBody">
                    <DashboardItem name="first"/>
                    {/* <DashboardItem name="second" />
                    <DashboardItem name="third" /> */}
                </div>
            </div>
        );
    }
}
