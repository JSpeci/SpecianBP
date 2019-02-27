import { observer } from 'mobx-react';
import * as React from 'react'
import { AppHeader } from './Components/AppHeader';

export interface AppProps {

}

@observer
export class App extends React.Component<AppProps> {
  render() {
    console.log("Rendering APP");
    return (
      <div className="container">
        <AppHeader />
      </div>
    );
  }
}
