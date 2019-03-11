import { observable, computed, action } from 'mobx';
import { ApiRequest } from 'utils/ApiRequest';

export class DataSettingsModel {

    apiRequest: ApiRequest;

    @observable loading: boolean;

    @observable seriesNames: string[];

    readonly chartTypes: string[] = ["bar","scatter"];
    readonly chartColors: string[] = ["bar","scatter"];

    @observable selectedSeries: string;

    @observable selectedChartType: string = this.chartTypes[0];

    @action.bound
    seriesNameChanged(value: string) {
        this.selectedSeries = value;
    }

    @action.bound
    chartTypeChanged(value: string) {
        this.selectedChartType = value;
    }

    constructor(apiRequest: ApiRequest) {
        this.loading = false;
        this.apiRequest = apiRequest;
        this.seriesNames = [];
    }

    @computed get SeriesNames(): string[] {
        if (this.seriesNames && this.seriesNames.length > 0) {
            return this.seriesNames;
        }
        else { return ["P_avg_3Pplus_C"]; }
    }

    async load() {

        this.loading = true;
        await this.apiRequest.getPowerSeriesNamesList().then(d => { this.seriesNames = d; this.loading = false; });
    }
}
