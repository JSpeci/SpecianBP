import * as React from 'react'
import { observer } from 'mobx-react';
import { SourceDataSettings } from './DataSettings';
import { DashboardItem } from './DashboardItem';
import { DashboardModel } from 'Models/DashboardModel';
import { Loading } from './Loading';

export interface DashboardProps {
    dashboardModel: DashboardModel;
}

@observer
export class Dashboard extends React.Component<DashboardProps> {

    render() {
        const model = this.props.dashboardModel;
        return (
            <div className="dashboard">


                {
                    !model.loading && <div className="dashboardHeader">
                        <SourceDataSettings model={this.props.dashboardModel} />
                    </div>
                }
                {
                    model.loading && <div className="dashboardHeader">
                        <Loading />
                    </div>
                }
                {
                    model.canShowCharts &&
                    <div className="dashboardBody">
                        {
                            model.itemModels.map(i => {
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
