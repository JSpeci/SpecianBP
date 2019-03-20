import * as React from 'react'
import { observer } from 'mobx-react';
import { DashboardItemModel } from 'Models/DashboardItemModel';
import { Helpers } from '../utils/Helpers';
import Plot from 'react-plotly.js';
import { Loading } from './Loading';
import { MyPlotData } from 'utils/interfaces';



export interface DashboardItemProps {
    name?: string;
    model: DashboardItemModel;
}

@observer
export class DashboardItem extends React.Component<DashboardItemProps> {

    render() {
        const model = this.props.model;

        if (!model.loading && this.props.model.data) {
            
            const data = model.data.map((d: MyPlotData) => {
                let obj = {
                    type: d.params.chartProps.type,
                    x: d.data.map(k => k.fromTime),
                    y: d.data.map(k => k.averageValue),
                    line: {
                        color: Helpers.getRgbString(d.params.chartProps.lineColor),
                        width: d.params.chartProps.lineWidth
                    }
                };
                return obj;
            });

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
                        data={data}
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
