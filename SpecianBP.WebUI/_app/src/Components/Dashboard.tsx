import * as React from 'react'
import { observer } from 'mobx-react';
import { DataSettings } from './DataSettings';
import { DashboardItem } from './DashboardItem';


export interface DashboardProps {

}

@observer
export class Dashboard extends React.Component<DashboardProps> {

    render() {
        return (
            <div className="dashboard">
                <div className="dashboardHeader"><DataSettings /></div>
                <div className="dashboardBody">
                    <DashboardItem name="first" />
                    {/* <DashboardItem name="second" />
                    <DashboardItem name="third" /> */}
                </div>
            </div>
        );
    }
}
