import { observer } from 'mobx-react';
import * as React from 'react'
import { AppHeader } from './Components/AppHeader';
import { Dashboard } from './Components/Dashboard';
import { AppFooter } from './Components/AppFooter';
import { AppModel } from 'Models/AppModel';

export interface AppProps {
  // router: AppRouter;
  appModel: AppModel;
}

@observer
export class App extends React.Component<AppProps> {
  render() {
    console.log("Rendering APP");
    return (
      <div className="container">
        <AppHeader />
        <Dashboard dashboardModel={this.props.appModel.dashboardModel} />
        <AppFooter />
      </div>
    );
  }
}

// import * as React from 'react'
// import Plot from 'react-plotly.js';

// export class App extends React.Component {
//   render() {
//     return (
//       <Plot
//         data={[
//           {
//             x: [1, 2, 3],
//             y: [2, 6, 3],
//             type: "scatter",
//             mode: "lines+points",
//             marker: {color: "red"},
//           },
//           {type: "bar", x: [1, 2, 3], y: [2, 5, 3]},
//         ]}
//         layout={ {width: 320, height: 240, title: "A Fancy Plot"} }
//       />
//     );
//   }
// }