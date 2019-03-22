import * as React from 'react'


export interface AppHeaderProps {
    
}

export class AppHeader extends React.Component<AppHeaderProps> {

     render() {

        return (
            <div className="appHeader">
                <div className="logo"></div>
                <div className="headerBody">
                    <span>Welcome on dashboard. Now you can compose your report.</span>
                </div>
            </div>
        );
    }
}
