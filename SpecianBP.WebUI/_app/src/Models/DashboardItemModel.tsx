import { observable, action } from 'mobx';
import { ApiRequest } from 'utils/ApiRequest';
import { PlotParameters, MyPlotData } from 'utils/interfaces';

export class DashboardItemModel {

    apiRequest: ApiRequest;

    @observable loading: boolean;

    @observable data: MyPlotData[];

    @observable lastUsedParams: PlotParameters;

    @observable canShowChart: boolean;

    @observable wasRemoved: boolean = false;

    constructor(apiRequest: ApiRequest) {
        this.loading = false;
        this.apiRequest = apiRequest;
        this.canShowChart = false;
        this.data = [];
    }

    @action.bound
    removeButtonClicked(){
        this.wasRemoved = true;
    }

    @action.bound
    clearSeries(){
        this.data = [];
    }

    async loadSerie(params: PlotParameters) {
        this.loading = true;
        this.lastUsedParams = params;
        await this.apiRequest.getAveragedSeriesData(params)
        .then(d => { this.data.push({data:d, params: params}); this.loading = false;})
        .then(d => this.lastUsedParams.chartProps.yAxisTitle = this.data[0].data[0].unit);
        this.canShowChart = true;
    }
}
