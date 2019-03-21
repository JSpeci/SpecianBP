import * as React from 'react'
import { observer } from 'mobx-react';
import { DashboardItemModel } from 'Models/DashboardItemModel';
import Plot from 'react-plotly.js';
import { Loading } from './Loading';

export interface DashboardItemProps {
    name?: string;
    model: DashboardItemModel;
}

@observer
export class DashboardItem extends React.Component<DashboardItemProps> {

    render() {
        const model = this.props.model;

        if (!model.loading && this.props.model.data) {
                        return (
                <div className="dashboardItem">
                    <div className="dashboardItemHeader">
                        <div className="dashboardItemHeaderCancelbutton" >
                            <button className="btn btn-outline-danger btn-sm"
                                onClick={model.removeButtonClicked}
                            >Remove</button>
                        </div>
                    </div>
                    <Plot
                        data={model.plotlyDataObject}
                        layout={{
                            xaxis: {
                                title: model.lastUsedParams.chartProps.xAxisTitle
                            },
                            yaxis: {
                                title: model.lastUsedParams.chartProps.yAxisTitle
                            },
                            width: model.lastUsedParams.chartProps.xSize * 100,
                            height: model.lastUsedParams.chartProps.ySize * 100,
                            title: model.lastUsedParams.seriesParams.line.seriesName  //TO DO
                        }}
                    />
                </div>
            );
        }
        else {
            return (
                <div className="dashboardItem">
                    <Loading />
                </div>
            );
        }
    }
}
