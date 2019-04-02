import { observable, action, computed } from 'mobx';
import { ApiRequest } from 'utils/ApiRequest';
import { PlotParameters, MyPlotData } from '../utils/interfaces';
import { Helpers } from '../utils/Helpers';
import { DataSources } from '../utils/DataSources';

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

    @computed get plotlyDataObject() {
        if (!this.loading && this.data) {

            const data = this.data.map((d: MyPlotData) => {
                let obj = {
                    type: d.plotParams.chartProps.type,
                    x: d.data.map(k => k.fromTime),
                    y: d.data.map(k => {
                        switch (d.plotParams.aggrFunc) {
                            case DataSources.aggregationFuncTypes()[0].title:
                                return k.averageValue;
                            case DataSources.aggregationFuncTypes()[1].title:
                                return k.minValue;
                            case DataSources.aggregationFuncTypes()[2].title:
                                return k.maxValue;
                            default:
                                return k.averageValue;
                        }
                    }),
                    line: {
                        color: Helpers.getRgbString(d.plotParams.chartProps.lineColor),
                        width: d.plotParams.chartProps.lineWidth
                    }
                };
                return obj;
            });
            return data;
        }
        return null;
    }

    @action.bound
    removeButtonClicked() {
        this.wasRemoved = true;
    }

    @action.bound
    clearSeries() {
        this.data = [];
    }

    async loadSerie(params: PlotParameters) {
        this.loading = true;
        this.lastUsedParams = params;
        await this.apiRequest.getAveragedSeriesData(params)
            .then(d => { this.data.push({ data: d, plotParams: params}); this.loading = false; })
            .then(d => this.lastUsedParams.chartProps.yAxisTitle = this.data[0].data[0].unit);
        this.canShowChart = true;
    }
}
