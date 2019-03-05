import * as React from 'react'

export interface AppFooterProps {

}

export class AppFooter extends React.Component<AppFooterProps> {

     render() {

        return (
            <div className="footer">
                <div className="footerBody">
                    <span>Powered by React</span>
                </div>
            </div>
        );
    }
}
