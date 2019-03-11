import * as React from 'react'

export interface AppHeaderProps {

}

export class AppHeader extends React.Component<AppHeaderProps> {

     render() {

        return (
            <div className="header">
                <div className="logo"></div>
                <div className="headerBody">
                    <span>Welcome on dashboard</span>
                </div>
            </div>
        );
    }
}
