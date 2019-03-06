import { ApiRequest } from 'utils/ApiRequest';
import { DashboardModel } from './DashboardModel';

export class AppModel {

    apiRequest: ApiRequest;
    dashboardModel: DashboardModel;

    constructor(apiRequest: ApiRequest) {
        this.apiRequest = apiRequest;
        this.dashboardModel = new DashboardModel(apiRequest);
    }
}