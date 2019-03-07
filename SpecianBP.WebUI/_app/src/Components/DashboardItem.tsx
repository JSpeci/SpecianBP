import * as React from 'react'
import { observer } from 'mobx-react';
import { DashboardItemModel } from 'Models/DashboardItemModel';
import Plot from 'react-plotly.js';


export interface DashboardItemProps {
    name: string;
    model: DashboardItemModel;
}

@observer
export class DashboardItem extends React.Component<DashboardItemProps> {

    render() {

        
        const model = this.props.model;

        if(!model.loading &&  this.props.model.data)
        {
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
                            { type: "bar", x: xData, y: yData},
                        ]}
                        layout={{ width: 800, height: 300, title: "S_avg_S3_C" }}
                    />
                </div>
            );
        }
        else
        {
            return <span className="loading">Loading ...</span>;
        }
    }
}
