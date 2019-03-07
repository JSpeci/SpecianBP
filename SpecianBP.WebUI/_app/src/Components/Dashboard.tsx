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
        const model = this.props.dashboardModel;
        console.log(model.loading);
        return (
            <div className="dashboard">
                <div className="dashboardHeader">
                    <SourceDataSettings model={this.props.dashboardModel} />
                </div>

                {
                    model.canShowCharts &&
                    <div className="dashboardBody">
                        <DashboardItem name="first" model={model.itemModels[0]} />
                        {/* <DashboardItem name="second" />
    <DashboardItem name="third" /> */}
                    </div>
                }



            </div>
        );
    }
}
