import * as React from 'react'
import { DashboardModel } from 'Models/DashboardModel';

export interface ActionButtonsProps {
    model: DashboardModel;
}

export class ActionButtons extends React.Component<ActionButtonsProps> {

    render() {
        const model = this.props.model;
        const actionButtons = (
            <div className="actionsPanel">
                <div className="form-group settingsItem">
                    <button className="btn btn-success inline-button" onClick={model.showSettingsPanel} type="button">Add something ?</button >
                </div>
                <div className="form-group settingsItem">
                    <button className="btn btn-danger inline-button" onClick={model.clearDash} type="button">Clear dash</button >
                </div>
                <div className="form-group settingsItem">
                    <button className="btn btn-warn inline-button" onClick={model.exportButtonClicked} type="button">Export</button >
                </div>
            </div>
        );
        return actionButtons;
    }
}
