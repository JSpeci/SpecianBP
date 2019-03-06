import * as React from 'react'
import { observer } from 'mobx-react';
import { DateTimePicker } from 'react-widgets'
import momentLocalizer from 'react-widgets-moment';
import 'react-widgets/dist/css/react-widgets.css';
import { DashboardModel } from 'Models/DashboardModel';

export interface SourceDataSettingsProps {
    model: DashboardModel
}

@observer
export class SourceDataSettings extends React.Component<SourceDataSettingsProps> {

    newName: string = "";

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
                            <button className="btn btn-success inline-button" onClick={model.fromToConfirmed} type="button">Show !</button >
                        </div>
                    </div>
                </div>
            </div>
        );
    }
}
