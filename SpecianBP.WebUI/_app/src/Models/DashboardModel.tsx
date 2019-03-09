import { observable, computed, action } from 'mobx';
import { ApiRequest } from 'utils/ApiRequest';
import { DashboardItemModel } from './DashboardItemModel';
import { AveragedParameters } from 'utils/interfaces';
import { DataSettingsModel } from './DataSettingsModel';

//constants defined by actual data state
export const DefaultFromTime: Date = new Date(2018,3,1,0,0,0);
export const DefaultToTime: Date = new Date(2018,4,1,0,0,0);

export class DashboardModel {

    @observable loading: boolean;

    @observable dateFrom: Date;
    @observable dateTo: Date;

    apiRequest: ApiRequest;

    @observable itemModels: DashboardItemModel[];

    @observable canShowCharts: boolean;

    @observable dataSettingsModel: DataSettingsModel;

    constructor(apiRequest: ApiRequest) {
        this.loading = false;
        this.canShowCharts = true;
        this.apiRequest = apiRequest;
        this.dateFrom = DefaultFromTime;
        this.dateTo = DefaultToTime;
        this.itemModels = [];
        this.dataSettingsModel = new DataSettingsModel(apiRequest);
        this.loadDataSettingsModel();
    }

    async loadDataSettingsModel(){
        this.loading = true;
        await this.dataSettingsModel.load().then(() => this.loading = false);
    }

    @action.bound
    fromChanged(value:any){
        this.dateFrom = value;
    }

    @action.bound
    toChanged(value:any){
        this.dateTo = value;
    }

    @action.bound
    AddSeriesChart(){
        const newItem = new DashboardItemModel(this.apiRequest);
        this.itemModels.push(newItem);
        const params: AveragedParameters = {
            from: this.dateFrom.toDateString(),
            to: this.dateTo.toDateString(),
            seriesName: this.dataSettingsModel.selectedSeries ? this.dataSettingsModel.selectedSeries : "P_avg_3Pplus_C",
            step: "1.00:00:00.000",
            chartProps: {
                type: this.dataSettingsModel.selectedChartType,
                xSize: 600, ySize: 300
            },
        };
        newItem.load(params);
    }

    async reloadAllResources() {

        this.loading = true;

        this.itemModels.forEach(async element => {
           await element.load(element.lastUsedParams).then(() => {
                console.log("loaded");
           });
        });
    }
}
