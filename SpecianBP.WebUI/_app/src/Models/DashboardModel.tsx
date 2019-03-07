import { observable, computed, action } from 'mobx';
import { ApiRequest } from 'utils/ApiRequest';
import { DashboardItemModel } from './DashboardItemModel';
import { AveragedParameters } from 'utils/interfaces';

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


    constructor(apiRequest: ApiRequest) {
        this.loading = false;
        this.canShowCharts = false;
        this.apiRequest = apiRequest;
        this.dateFrom = DefaultFromTime;
        this.dateTo = DefaultToTime;
        this.itemModels = [];

        this.establishItemModels();
    }

    establishItemModels(){
        this.itemModels.push(new DashboardItemModel(this.apiRequest));
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
    fromToConfirmed(){
        this.canShowCharts = true;
        this.loadAllResources().then(() => {this.loading = false;});
    }

    async loadAllResources() {

        this.loading = true;

        const params: AveragedParameters = {
            from: this.dateFrom.toDateString(),
            to: this.dateTo.toDateString(),
            seriesName: "S_avg_S3_C",
            step: "1.00:00:00.000",
        };

        console.log(params);

        this.itemModels.forEach(async element => {
           await element.load(params).then(() => {
                console.log("loaded");
           });
        });

        // this.countOfResourcesForShowing = 20;

        // if (this.langSelectedId != "" && this.projectSelectedId != "") {
        //     const lang = this.langSelectedId;
        //     await this.apiRequest.getResourcesByProjectIdAndLangId(this.projectSelectedId, this.langSelectedId)
        //         .then(data => {
        //             this.resources = [];
        //             for (let i = 0; i < data.length; i++) {

        //                 this.resources.push(new ResourceKeyTranslationModel(data[i], this.apiRequest, this.langSelectedId));
        //             }
        //             console.log("Resources LOADED - ", lang);
        //         }).then(() => {
        //             this.orderBy("resKeyDefaultValue");
        //             this.loading = false;
        //         });
        // }
        // else {
        //     console.log("Cant load resources without project Id and locale Id");
        //     console.log("Project id: " + this.projectSelectedId + "\nLang id: " + this.langSelectedId);
        // }
    }
}
