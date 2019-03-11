import * as React from 'react'
import { observer } from 'mobx-react';
import { DashboardItemModel } from 'Models/DashboardItemModel';
import { Helpers } from '../utils/Helpers';
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
            const xData = model.data.map(i => i.fromTime);
            const yData = model.data.map(i => i.averageValue);


            return (
                <div className="dashboardItem">
                    <Plot
                        data={[
                            // {
                            //     x: xData,
                            //     y: yData,
                            //     type: "scatter",
                            //     mode: "lines+points",
                            //     marker: { color: "red" },
                            // },
                            {
                                type: model.lastUsedParams.chartProps.type,
                                x: xData,
                                y: yData,
                                marker: {
                                    color:  Helpers.getRgbString(model.lastUsedParams.lineColor),
                                },
                                // marker: {
                                // //     color: 'rgb(17, 157, 255)',
                                // //     size: 60,
                                //     line: {
                                //         color: 'rgb(231, 99, 250)',
                                //         width: 6
                                //     }
                                // },
                            },
                        ]}
                        layout={{
                            width: model.lastUsedParams.chartProps.xSize,
                            height: model.lastUsedParams.chartProps.ySize,
                            title: model.lastUsedParams.seriesName
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
