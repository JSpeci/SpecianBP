import { observable, action } from 'mobx';
import { ApiRequest } from 'utils/ApiRequest';
import { PlotParameters, SeriesAveraged } from 'utils/interfaces';

export class DashboardItemModel {

    apiRequest: ApiRequest;

    @observable loading: boolean;

    @observable data: SeriesAveraged[];

    @observable lastUsedParams: PlotParameters;

    @observable canShowChart: boolean;

    @observable wasRemoved: boolean = false;

    constructor(apiRequest: ApiRequest) {
        this.loading = false;
        this.apiRequest = apiRequest;
        this.canShowChart = false;
    }

    @action.bound
    removeButtonClicked(){
        this.wasRemoved = true;
    }

    async load(params: PlotParameters) {
        this.loading = true;
        this.lastUsedParams = params;
        await this.apiRequest.getAveragedPowerFromTo(params)
        .then(d => { this.data = d; this.loading = false;})
        .then(d => this.lastUsedParams.chartProps.yAxisTitle = this.data[0].unit);
        this.canShowChart = true;
    }
}
