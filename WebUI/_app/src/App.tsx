import { observer } from 'mobx-react';
import * as React from 'react'

export interface AppProps {

}

@observer
export class App extends React.Component<AppProps> {
  render() {
    console.log("Rendering APP");
    return (
      <div className="container">
        HELLOasdasdasdas
      </div>
    );
  }
}
