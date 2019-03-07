import * as React from 'react';
import * as ReactDOM from 'react-dom';
import 'bootstrap/dist/css/bootstrap.min.css';
import { App } from './App';
import { AppModel } from './Models/AppModel';
import { ApiRequest } from './utils/ApiRequest';


let apiRequester = new ApiRequest("https://localhost:44340");
let appModel = new AppModel(apiRequester);

ReactDOM.render(
  <App appModel={appModel} />,
  document.getElementById('root')
);