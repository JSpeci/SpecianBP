import { SeriesAveraged, PlotParameters, MeasurementPlace, MultilinePlot, MultilinePlotParams, SavedDashboardModel } from './interfaces';

//helper object
export class ApiRequest {

    url: string;

    constructor(url: string) {
        this.url = url;
    }

    getHeaders() {
        const myHeaders = new Headers();
        myHeaders.append("Content-Type", "application/json");
        //myHeaders.set("Authorization", "Bearer " + (window as any).restDriverAccessToken);
        return myHeaders;
    }

    getValues(): Promise<string[]> {

        const myHeaders = this.getHeaders();

        var myInit = {
            method: 'GET',
            headers: myHeaders
        };

        return fetch('/api/Values', myInit).then((response) => {

            return response.json();
        }).then((data) => {
            return data;
        });
    }

    getAveragedSeriesData(params: PlotParameters): Promise<SeriesAveraged[]> {

        const myHeaders = this.getHeaders();
        myHeaders.append("From", params.seriesParams.from);
        myHeaders.append("To", params.seriesParams.to);
        myHeaders.append("Step", params.seriesParams.line.step);
        myHeaders.append("SeriesName", params.seriesParams.line.seriesName);
        myHeaders.append("MeasurementPlaceNumberId", params.seriesParams.line.measurementPlaceNumberId.toString());

        var myInit = {
            method: 'GET',
            headers: myHeaders
        };

        console.log(JSON.stringify(params));
        

        return fetch('/api/Series/SingleSeriesAveraged', myInit).then((response) => {
            
            return response.json();
        }).then((data) => {
            console.log(JSON.stringify(data));
            return data;
        });
    }

    postPdfExportParams(params: MultilinePlotParams[], filename: string = "PlotPdfExport.pdf"): Promise<void> {

        console.log(JSON.stringify(params));

        var myInit = {
            method: 'POST',
            headers: {
              'Accept': 'application/json',
              'Content-Type': 'application/json'
            },
            body: JSON.stringify(params)
        };

        const queryParams = "?fileName=" + filename;

        return fetch('/api/Series/Export' + queryParams, myInit).then((response) => {
            return response.json();
        }).then((data) => {
            return data;
        });
    }

    saveDashboardModel(params: MultilinePlotParams[], createdBy:string, name: string = "SomethingSaved"): Promise<void> {

        console.log("Saving",JSON.stringify(params));

        var myInit = {
            method: 'POST',
            headers: {
              'Accept': 'application/json',
              'Content-Type': 'application/json'
            },
            body: JSON.stringify(params)
        };

        const queryParams = "?name=" + name + "&createdBy=" + createdBy;

        return fetch('/api/Series/SaveDashboardModel' + queryParams, myInit).then((response) => {
            return response.json();
        }).then((data) => {
            return data;
        });
    }

    getPowerSeriesNamesList(): Promise<string[]> {

        const myHeaders = this.getHeaders();

        var myInit = {
            method: 'GET',
            headers: myHeaders
        };

        return fetch('/api/AdditionalData/AllSeriesNames', myInit).then((response) => {
            return response.json();
        }).then((data) => {
            return data;
        });
    }

    getSavedDashboards(): Promise<SavedDashboardModel[]> {

        const myHeaders = this.getHeaders();

        var myInit = {
            method: 'GET',
            headers: myHeaders
        };

        return fetch('/api/Series/SaveDashboardModels', myInit).then((response) => {
            return response.json();
        }).then((data) => {
            return data;
        });
    }

    getSeriesUnit(seriesName: string): Promise<string> {

        const myHeaders = this.getHeaders();
        myHeaders.append("SeriesName", seriesName);
        var myInit = {
            method: 'GET',
            headers: myHeaders
        };

        return fetch('/api/AdditionalData/GetSeriesUnit', myInit)
        .then((response) => {
            return response.json();
        }).then((data) => {
            return data;
        });
    }

    getMeasurementPlaces(): Promise<MeasurementPlace[]> {

        const myHeaders = this.getHeaders();
        var myInit = {
            method: 'GET',
            headers: myHeaders
        };

        return fetch('/api/MeasurementPlaces/All', myInit).then((response) => {
            return response.json();
        }).then((data) => {
            return data;
        });
    }
}