import { observer } from 'mobx-react';
import * as React from 'react'
import { AppHeader } from './Components/AppHeader';
import { Dashboard } from './Components/Dashboard';
import { AppModel } from 'Models/AppModel';




export interface AppProps {
  // router: AppRouter;
  appModel: AppModel;
}

@observer
export class App extends React.Component<AppProps> {
  render() {
    console.log("Rendering APP");

    //ReactPDF.render(<mydoc />, `${__dirname}/pokusnyPDf.pdf`);
    return (
      <div className="container">
        <AppHeader />
        <Dashboard dashboardModel={this.props.appModel.dashboardModel} />
      </div>
    );
  }
}