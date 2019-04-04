import * as React from 'react'
import { observer } from 'mobx-react';
import { observable, action } from 'mobx';
import { DropdownList } from 'react-widgets';
import { HoursOrMinutes } from '../utils/interfaces';
import { DataSources } from '../utils/DataSources';

export interface AggregationFuncSelectrorProps {
    aggregationFuncModel: AggregationFuncSelectrorModel
}

export class AggregationFuncSelectrorModel {
    @observable selectedFuncType: string;

    @observable averagingStepHours: number = 1;
    @observable averagingStepMins: number = 0;

    aggregationFuncTypesKeywords: string[];

    constructor(){
        this.aggregationFuncTypesKeywords = DataSources.aggregationFuncTypes().map(i => i.title);
        this.selectedFuncType = this.aggregationFuncTypesKeywords[0];
    }

    @action.bound
    funcTypeChanged(value: string) {
        this.selectedFuncType = value;
    }

    @action.bound
    averagingStepChanged(value: any, hoursMins: HoursOrMinutes = HoursOrMinutes.Hours) {
        if (hoursMins === HoursOrMinutes.Hours) {
            this.averagingStepHours = parseInt(value);
            if (this.averagingStepHours <= 0) {
                this.averagingStepHours = 0;
            }
            if (this.averagingStepHours >= 96) {
                this.averagingStepHours = 96;
            }
        }
        if (hoursMins === HoursOrMinutes.Minutes) {
            this.averagingStepMins = parseInt(value);
            if (this.averagingStepMins <= 0) {
                this.averagingStepMins = 0;
            }
            if (this.averagingStepMins >= 59) {
                this.averagingStepMins = 59;
            }
        }
    }
}

@observer
export class AggregationFuncSelectror extends React.Component<AggregationFuncSelectrorProps> {

    render() {

        const model = this.props.aggregationFuncModel;

        return (
            <React.Fragment>
                <div className="form-group settingsItem">
                    <label>Aggregation function</label>
                    <DropdownList
                        data={model.aggregationFuncTypesKeywords}
                        defaultValue={model.selectedFuncType}
                        onChange={model.funcTypeChanged}
                    />
                </div>
                
                <br />
                <div className="form-group settingsItem">
                    <label>select period (h)</label>
                    <input type="number"
                        className={"form-control"}
                        value={model.averagingStepHours}
                        onChange={(e) => model.averagingStepChanged(e.target.value)} />
                </div>
                <div className="form-group settingsItem">
                    <label>select period (min)</label>
                    <input type="number"
                        className={"form-control"}
                        value={model.averagingStepMins}
                        onChange={(e) => model.averagingStepChanged(e.target.value, HoursOrMinutes.Minutes)} />
                </div>


            </React.Fragment>
        );
    }
}
