import { observable, computed, action } from 'mobx';
import { ApiRequest } from 'utils/ApiRequest';

//constants defined by actual data state
export const DefaultFromTime: Date = new Date(2018,3,1,0,0,0);
export const DefaultToTime: Date = new Date(2018,6,1,0,0,0);

export class DashboardModel {

    @observable loading: boolean;

    @observable dateFrom: Date;
    @observable dateTo: Date;

    apiRequest: ApiRequest;

    constructor(apiRequest: ApiRequest) {
        this.loading = true;
        this.apiRequest = apiRequest;
        this.dateFrom = DefaultFromTime;
        this.dateTo = DefaultToTime;
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
        console.log(this.dateFrom, this.dateTo);
    }

    async loadAllResources() {

        this.loading = true;

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
