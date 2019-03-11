import { observable, action } from 'mobx';
import { ApiRequest } from 'utils/ApiRequest';
import { AveragedParameters, SeriesAveraged } from 'utils/interfaces';

export class DashboardItemModel {

    apiRequest: ApiRequest;

    @observable loading: boolean;

    @observable data: SeriesAveraged[];

    @observable lastUsedParams: AveragedParameters;

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

    async load(params: AveragedParameters) {
        this.loading = true;
        this.lastUsedParams = params;
        await this.apiRequest.getAveragedPowerFromTo(params).then(d => { this.data = d; this.loading = false;});
        this.canShowChart = true;
    }
}
