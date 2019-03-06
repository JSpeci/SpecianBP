import * as React from 'react'
import { observer } from 'mobx-react';
import { DateTimePicker } from 'react-widgets'
import momentLocalizer from 'react-widgets-moment';
import 'react-widgets/dist/css/react-widgets.css';


export interface DataSettingsProps {


}

@observer
export class DataSettings extends React.Component<DataSettingsProps> {

    newName: string = "";
    date: Date = new Date();

    okButtonClicked() {

    }

    dateTimeChanged = (s: any) => this.date = s;


    render() {
        momentLocalizer()
        return (
            <div className="dataSettings">
                <div className="card-body">
                    <div className="newResKeyForm">
                        <h5 >Set up dashboard</h5>
                        <div className="form-group">
                            <label>From</label>
                            <DateTimePicker
                                value={this.date}
                                defaultValue={new Date()}
                                time={true}
                            />
                        </div>
                        <div className="form-group">
                            <label>To</label>
                            <DateTimePicker
                                value={this.date}
                                defaultValue={new Date()}
                                time={true}
                            />
                        </div>
                        <div className="form-group ">
                            <button className="btn btn-success inline-button" onClick={() => this.okButtonClicked()} type="button">Show !</button >
                        </div>
                    </div>
                </div>
            </div>
        );
    }
}
