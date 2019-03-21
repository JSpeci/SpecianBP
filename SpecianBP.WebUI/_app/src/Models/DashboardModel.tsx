import { observable, action, computed } from 'mobx';
import { ApiRequest } from 'utils/ApiRequest';
import { DashboardItemModel } from './DashboardItemModel';
import { PlotParameters, rgbColor } from 'utils/interfaces';
import { DataSettingsModel } from './DataSettingsModel';

//constants defined by actual data state
export const DefaultFromTime: Date = new Date(2018, 3, 1, 0, 0, 0);
export const DefaultToTime: Date = new Date(2018, 3, 14, 0, 0, 0);

export enum HoursOrMinutes {
    Hours = 0,
    Minutes = 1,
}

export class DashboardModel {

    readonly infoText: string = "This is your Dasboard";

    @observable loading: boolean;

    @observable dateFrom: Date;
    @observable dateTo: Date;

    apiRequest: ApiRequest;

    @observable private itemModels: DashboardItemModel[];

    @observable canShowCharts: boolean;

    @observable averagingStepHours: number = 1;
    @observable averagingStepMins: number = 0;

    @observable plotWidth: number = 8;
    @observable plotHeight: number = 4;
    @observable lineWidth: number = 2;

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
    indexOfSeriesInsertChanged(value: any) {
        this.dataSettingsModel.insertIntoExistingPlotIndex = parseInt(value);
        if (this.dataSettingsModel.insertIntoExistingPlotIndex <= 0) {
            this.dataSettingsModel.insertIntoExistingPlotIndex = 0;
        }
        if (this.dataSettingsModel.insertIntoExistingPlotIndex >= this.itemModels.length -1) {
            this.dataSettingsModel.insertIntoExistingPlotIndex = this.itemModels.length -1;
        }
    }

    @action.bound
    lineWidthChanged(value: any) {
        this.lineWidth = parseInt(value);
        if (this.lineWidth <= 0) {
            this.lineWidth = 0;
        }
        if (this.lineWidth >= 4) {
            this.lineWidth = 4;
        }
    }

    @action.bound
    clearDash() {
        this.itemModels = [];
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

    @action.bound
    plotHeightChanged(value: any) {
        this.plotHeight = parseInt(value);
        if (this.plotHeight <= 4) {
            this.plotHeight = 4;
        }
        if (this.plotHeight >= 10) {
            this.plotHeight = 10;
        }
    }

    @action.bound
    plotWidthChanged(value: any) {
        this.plotWidth = parseInt(value);
        if (this.plotWidth <= 4) {
            this.plotWidth = 4;
        }
        if (this.plotWidth >= 20) {
            this.plotWidth = 20;
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

    private calculateStep(hours: number, minutes: number = 0): string {
        let minutesString = minutes < 10 ? "0" + minutes.toString() : minutes.toString();
        if (hours < 24) {
            return "0." + hours + ":" + minutesString + ":00.000";
        }
        else if (hours >= 24 && hours < 48) {
            return "1." + (hours - 24) + ":" + minutesString + ":00.000";
        }
        else if (hours >= 48 && hours < 72) {
            return "2." + (hours - 48) + ":" + minutesString + ":00.000";
        }
        else if (hours >= 72 && hours < 96) {
            return "3." + (hours - 72) + ":" + minutesString + ":00.000";
        }
        return "1.00:00:00.000"; // one day
    }

    private removeRemovedItems() {
        this.itemModels = this.ItemModels;
    }

    @action.bound
    async exportButtonClicked() {
        await this.apiRequest.exportClicked();
    }

    @action.bound
    submitParams(newBlock: boolean)
    {
        this.removeRemovedItems();
        let dashboardItem = new DashboardItemModel(this.apiRequest);
        if (newBlock) {
            this.itemModels.push(dashboardItem);
        }
        else if(this.dataSettingsModel.insertIntoExistingPlotIndex < this.itemModels.length ){
            dashboardItem = this.itemModels[this.dataSettingsModel.insertIntoExistingPlotIndex];
        }

        // let dashboardItem = new DashboardItemModel(this.apiRequest);
        // debugger;
        // this.itemModels.push(dashboardItem);

        const params: PlotParameters = {
            seriesParams: {
                from: this.dateFrom.toLocaleString(),
                to: this.dateTo.toLocaleString(),
                line:
                {
                    seriesName: this.dataSettingsModel.selectedSeries ? this.dataSettingsModel.selectedSeries : this.dataSettingsModel.SeriesNames[0],
                    step: this.calculateStep(this.averagingStepHours, this.averagingStepMins),
                    measurementPlaceNumberId: this.dataSettingsModel.selectedMeaserementPlace.numberId,
                }
            },
            chartProps: {
                type: this.dataSettingsModel.selectedChartType,
                xSize: this.plotWidth, ySize: this.plotHeight,
                lineColor: this.lineColor,
                xAxisTitle: "Time",
                yAxisTitle: "",
                lineWidth: this.lineWidth
            },
        };
        this.dataSettingsModel.lastUsedParams = params;
        this.dataSettingsModel.showSettings = false;
        console.log(params);
        dashboardItem.loadSerie(params).then(i => console.log(dashboardItem));
    }

    @action.bound
    showSettingsPanel() {
        this.dataSettingsModel.showSettings = true;
    }

    @action.bound
    hideSettingsPanel() {
        this.dataSettingsModel.showSettings = false;
    }

    async reloadAllResources() {

        this.loading = true;

        this.itemModels.forEach(async element => {
            await element.loadSerie(element.lastUsedParams).then(() => {
                console.log("loaded");
            });
        });
    }
}
