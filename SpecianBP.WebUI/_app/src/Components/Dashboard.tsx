import * as React from 'react'
import { observer } from 'mobx-react';
import { SourceDataSettings } from './DataSettings';
import { DashboardItem } from './DashboardItem';
import { DashboardModel } from 'Models/DashboardModel';
import { Loading } from './Loading';
import { ActionButtons } from './ActionButtons';

export interface DashboardProps {
    dashboardModel: DashboardModel;
}

@observer
export class Dashboard extends React.Component<DashboardProps> {

    render() {
        const model = this.props.dashboardModel;
        return (
            <div className="dashboard">
                <ActionButtons model={this.props.dashboardModel} />
                {
                    !model.loading && model.dataSettingsModel.showSettings && <div className="dashboardHeader">
                        <SourceDataSettings model={this.props.dashboardModel} />
                    </div>
                }
                {
                    model.loading && <div className="dashboardHeader">
                        <Loading />
                    </div>
                }
                {
                    model.canShowCharts && !model.dataSettingsModel.showSettings &&
                    <div className="dashboardBody">
                        {
                            model.ItemModels.map(i => {
                                return (
                                    <DashboardItem key={Math.random()} model={i} />
                                );
                            })
                        }
                    </div>
                }
            </div>
        );
    }
}
