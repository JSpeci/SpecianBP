import * as React from 'react';
import * as ReactDOM from 'react-dom';
import { observable, computed, action } from 'mobx';
import { ApiRequest } from 'utils/ApiRequest';

export class DashboardItemModel {

    @observable loading: boolean;


    apiRequest: ApiRequest;

    @observable filterEmpty: boolean;
    @observable filterText: string;
    @observable filterExact: boolean;

    @observable countOfResourcesForShowing: number = 20;

    orderByKey: string = "resKeyDefaultValue";
    orderByAsc: boolean = true;

    constructor(apiRequest: ApiRequest) {
        this.loading = true;
        this.apiRequest = apiRequest;
        this.filterText = "";   //important for filtering by empty only after reload immediately
    }


    @action.bound
    moveDownFocus( ){
        
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
