import { SeriesAveraged, AveragedParameters } from './interfaces';

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

    getAveragedPowerFromTo(params: AveragedParameters): Promise<SeriesAveraged[]> {

        const myHeaders = this.getHeaders();
        myHeaders.append("From", params.from);
        myHeaders.append("To", params.to);
        myHeaders.append("Step", params.step);
        myHeaders.append("SeriesName", params.seriesName);

        var myInit = {
            method: 'GET',
            headers: myHeaders
        };

        return fetch('/api/Series/SingleSeriesAveraged', myInit).then((response) => {
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

    getSeriesUnit(seriesName: string): Promise<string> {

        const myHeaders = this.getHeaders();
        myHeaders.append("SeriesName", seriesName);
        var myInit = {
            method: 'GET',
            headers: myHeaders
        };

        return fetch('/api/AdditionalData/GetSeriesUnit', myInit).then((response) => {
            return response.json();
        }).then((data) => {
            return data;
        });
    }
}