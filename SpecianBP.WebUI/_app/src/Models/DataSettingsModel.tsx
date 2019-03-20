import { observable, computed, action } from 'mobx';
import { ApiRequest } from 'utils/ApiRequest';
import { MeasurementPlace } from 'utils/interfaces';

export class DataSettingsModel {

    apiRequest: ApiRequest;

    @observable loading: boolean;

    @observable seriesNames: string[];
    @observable measurementPlaces: MeasurementPlace[];

    public readonly chartTypes: string[] = ["bar", "scatter"];
    public readonly chartColors: string[] = ["bar", "scatter"];

    @observable selectedSeries: string;
    @observable selectedMeaserementPlace: MeasurementPlace;

    @observable selectedChartType: string = this.chartTypes[1];

    @action.bound
    async seriesNameChanged(value: string) {
        this.selectedSeries = value;
    }

    @action.bound
    chartTypeChanged(value: string) {
        this.selectedChartType = value;
    }

    @action.bound
    measurementPlaceChanged(displayName: string) {
        this.selectedMeaserementPlace = this.measurementPlaces.filter((j: MeasurementPlace) => j.displayName === displayName)[0];
    }

    constructor(apiRequest: ApiRequest) {
        this.loading = false;
        this.apiRequest = apiRequest;
        this.seriesNames = [];
        this.measurementPlaces = [];
    }

    @computed get SeriesNames(): string[] {
        if (this.seriesNames && this.seriesNames.length > 0) {
            return this.seriesNames;
        }
        else { return ["P_avg_3Pplus_C"]; }
    }

    @computed get SelectedMeaserementPlace(): MeasurementPlace {
        if (this.selectedMeaserementPlace) {
            return this.selectedMeaserementPlace;
        }
        else { 
            let messPlace : MeasurementPlace = {
                numberId: 1,
                displayName: "Place 1",
                fileName: "", adress: ""
            }
            return  messPlace;
        }
    }

    @computed get MeasurementPlaces(): string[] {
        if (this.measurementPlaces && this.measurementPlaces.length > 0) {
            return this.measurementPlaces.map(i => i.displayName);
        }
        else { return ["empty"]; }
    }

    async load() {
        this.loading = true;
        await this.apiRequest.getPowerSeriesNamesList()
            .then(d => { this.seriesNames = d; this.loading = false; })
            .then(d => this.selectedSeries = "S_avg_S3_C");

        await this.apiRequest.getMeasurementPlaces()
            .then(d => { this.measurementPlaces = d; this.loading = false; })
            .then(d => this.selectedMeaserementPlace = this.measurementPlaces.filter((j: MeasurementPlace) => j.numberId === 1)[0])
            .then(d => console.log(this.selectedMeaserementPlace));

        //await this.apiRequest.getSeriesUnit(this.seriesNames[0]).then(d => this.yAxisUnit = d);
    }
}
