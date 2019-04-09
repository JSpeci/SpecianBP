import * as React from 'react'
import { DashboardModel } from 'Models/DashboardModel';
import { observer } from 'mobx-react';

export interface ActionButtonsProps {
    model: DashboardModel;
}

@observer
export class ActionButtons extends React.Component<ActionButtonsProps> {

    // getFileDefaultValue = () => {
    //     let d = new Date();

    //     let result = d.getFullYear() + "-" + ('0' + (d.getMonth() + 1)).slice(-2) + "-" + ('0' + d.getDate()).slice(-2) + " " + ('0' + d.getHours()).slice(-2) + ":" + ('0' + d.getMinutes()).slice(-2) + ":" + ('0' + d.getSeconds()).slice(-2);

    //     return ;
    // }


    // fileNameDefaultValue: string;

    // constructor(props: any) {
    //     super(props);
    //     this.fileNameDefaultValue = this.getFileDefaultValue();
    //     this.props.model.exportFilenameChaged(this.fileNameDefaultValue);
    // }

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
                {
                    model.ItemModels.length > 0 &&
                    <div className="form-group settingsItem">
                        <button className="btn btn-warn inline-button" onClick={model.exportButtonClicked} type="button">Export</button >
                    </div>
                }
                {
                    model.ItemModels.length > 0 &&
                    <div className="form-group settingsItem exportFileNameInput">
                        <input type="text" className="form-control" placeholder="fileName.pdf" defaultValue={"PdfExportedReport.pdf"} onChange={(e) => model.exportFilenameChaged(e.target.value)} />
                    </div>
                }
                {
                    model.ItemModels.length > 0 &&
                    <div className="form-group settingsItem">
                        <button className="btn btn-info inline-button" onClick={model.saveDashboardButtonClicked} type="button">Save Dashboard</button >
                    </div>
                }
                {
                    model.ItemModels.length > 0 &&
                    <div className="form-group settingsItem exportFileNameInput">
                        <input type="text" className="form-control" placeholder="name Of saved" defaultValue={"SomethingSaved"} onChange={(e) => model.exportFilenameChaged(e.target.value)} />
                    </div>
                }
            </div>
        );
        return actionButtons;
    }
}
