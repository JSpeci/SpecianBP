import { observable, action, computed } from 'mobx';
import { ApiRequest } from 'utils/ApiRequest';
import { DashboardItemModel } from './DashboardItemModel';
import { AveragedParameters, rgbColor } from 'utils/interfaces';
import { DataSettingsModel } from './DataSettingsModel';

//constants defined by actual data state
export const DefaultFromTime: Date = new Date(2018, 3, 1, 0, 0, 0);
export const DefaultToTime: Date = new Date(2018, 3, 14, 0, 0, 0);

export class DashboardModel {

    @observable loading: boolean;

    @observable dateFrom: Date;
    @observable dateTo: Date;

    apiRequest: ApiRequest;

    @observable private itemModels: DashboardItemModel[];

    @observable canShowCharts: boolean;

    @observable averagingStep: number = 1;
    @observable plotWidth: number = 800;
    @observable plotHeight: number = 400;

    @observable dataSettingsModel: DataSettingsModel;

    lineColor: rgbColor = { r: 50, g: 50, b: 200 };

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

    async loadDataSettingsModel() {
        this.loading = true;
        await this.dataSettingsModel.load().then(() => this.loading = false);
    }

    @computed get ItemModels(): DashboardItemModel[] {
        return this.itemModels.filter(i => !i.wasRemoved);
    }

    @action.bound
    fromChanged(value: any) {
        this.dateFrom = value;
    }


    @action.bound
    averagingStepChanged(value: any) {
        this.averagingStep = parseInt(value);
        if (this.averagingStep <= 1) {
            this.averagingStep = 1;
        }
        if (this.averagingStep >= 96) {
            this.averagingStep = 96;
        }
    }

    @action.bound
    plotHeightChanged(value: any) {
        this.plotHeight = parseInt(value);
        if (this.plotHeight <= 100) {
            this.plotHeight = 100;
        }
        if (this.plotHeight >= 1000) {
            this.plotHeight = 1000;
        }
    }

    @action.bound
    plotWidthChanged(value: any) {
        this.plotWidth = parseInt(value);
        if (this.plotWidth <= 100) {
            this.plotWidth = 100;
        }
        if (this.plotWidth >= 2000) {
            this.plotWidth = 2000;
        }
    }

    @action.bound
    toChanged(value: any) {
        this.dateTo = value;
    }

    @action.bound
    colorChanged(value: any) {
        this.lineColor.r = value.rgb.r;
        this.lineColor.g = value.rgb.g;
        this.lineColor.b = value.rgb.b;
    }

    private calculateStep(input: number): string {
        if (input < 24) {
            return "0." + input + ":00:00.000";
        }
        else if (input >= 24 && input < 48) {
            return "1." + (input - 24) + ":00:00.000";
        }
        else if (input >= 48 && input < 72) {
            return "2." + (input - 48) + ":00:00.000";
        }
        else if (input >= 72 && input < 96) {
            return "3." + (input - 72) + ":00:00.000";
        }
        return  "1.00:00:00.000"; // one day
    }

    private removeRemovedItems(){
        this.itemModels = this.ItemModels;
    }

    @action.bound
    AddSeriesChart() {
        this.removeRemovedItems();
        const newItem = new DashboardItemModel(this.apiRequest);
        this.itemModels.push(newItem);
        const params: AveragedParameters = {
            from: this.dateFrom.toDateString(),
            to: this.dateTo.toDateString(),
            seriesName: this.dataSettingsModel.selectedSeries ? this.dataSettingsModel.selectedSeries : "P_avg_3Pplus_C",
            step: this.calculateStep(this.averagingStep),
            chartProps: {
                type: this.dataSettingsModel.selectedChartType,
                xSize: this.plotWidth, ySize: this.plotHeight
            },
            lineColor: this.lineColor
        };
        console.log(params);
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
