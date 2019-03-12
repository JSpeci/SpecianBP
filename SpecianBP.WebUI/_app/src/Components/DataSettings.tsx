import * as React from 'react'
import { observer } from 'mobx-react';
import { DateTimePicker, DropdownList } from 'react-widgets'
import momentLocalizer from 'react-widgets-moment';
import 'react-widgets/dist/css/react-widgets.css';
import { DashboardModel } from 'Models/DashboardModel';
import { GithubPicker } from 'react-color';

export interface SourceDataSettingsProps {
    model: DashboardModel
}

@observer
export class SourceDataSettings extends React.Component<SourceDataSettingsProps> {

    constructor(props: SourceDataSettingsProps) {
        super(props);
    }

    render() {

        const model = this.props.model;

        momentLocalizer();
        return (
            <div className="dataSettings">
                <div className="card-body">
                    <div className="dataSettingsForm">
                        <h5 >Set up dashboard</h5>
                        <div className="form-group settingsItem">
                            <label>From</label>
                            <DateTimePicker
                                value={model.dateFrom}
                                time={true}
                                onChange={model.fromChanged}
                            />
                        </div>
                        <div className="form-group settingsItem">
                            <label>To</label>
                            <DateTimePicker
                                value={model.dateTo}
                                time={true}
                                onChange={model.toChanged}
                            />
                        </div>
                        <div className="form-group settingsItem">
                            <label>Series</label>
                            <DropdownList
                                data={model.dataSettingsModel.SeriesNames}
                                defaultValue={model.dataSettingsModel.selectedSeries}
                                onChange={model.dataSettingsModel.seriesNameChanged}
                            />
                        </div>
                        <div className="form-group settingsItem">
                            <label>Chart Type</label>
                            <DropdownList
                                data={model.dataSettingsModel.chartTypes}
                                defaultValue={model.dataSettingsModel.chartTypes[1]}
                                onChange={model.dataSettingsModel.chartTypeChanged}
                            />
                        </div>
                        <div className="form-group settingsItem">
                            <label>Averaging period (h)</label>
                            <input type="number" 
                            className={"form-control"} 
                            value={model.averagingStep}
                            onChange={(e) => model.averagingStepChanged(e.target.value)}/>
                        </div>
                        <div className="form-group settingsItem">
                            <label>Plot Width (*100px)</label>
                            <input type="number" 
                            className={"form-control"} 
                            value={model.plotWidth}
                            onChange={(e) => model.plotWidthChanged(e.target.value)}/>
                        </div>
                        <div className="form-group settingsItem">
                            <label>Plot height (*100px)</label>
                            <input type="number" 
                            className={"form-control"} 
                            value={model.plotHeight}
                            onChange={(e) => model.plotHeightChanged(e.target.value)}/>
                        </div>
                        <div className="form-group settingsItem">
                            <label>Line color</label>
                            <GithubPicker 
                                onChange={model.colorChanged}
                            />
                        </div>
                        <div className="form-group settingsItem">
                            <button className="btn btn-success inline-button" onClick={model.addSeriesChart} type="button">Add !</button >
                        </div>
                        <div className="form-group settingsItem">
                            <button className="btn btn-warn inline-button" onClick={model.exportButtonClicked} type="button">Export</button >
                        </div>
                    </div>
                </div>
            </div>
        );
    }
}
