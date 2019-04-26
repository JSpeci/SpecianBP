import * as React from 'react'
import { observer } from 'mobx-react';
import { observable, action } from 'mobx';

export interface LoadingProps {
    text?: string;
}

export class Loading extends React.Component<LoadingProps> {
    render() {
        return (
            <div className="loading">
                <span>{this.props.text || "Loading ..."}</span>
            </div>
        );
    }
}


export interface ShowCountProps {
    model: ShowCountModel;
}

export class ShowCountModel {
    @observable count: number = 1;
    @action public increment(): void {
        this.count++;
    }
}

@observer
export class ShowCount extends React.Component<ShowCountProps> {
    render() {
        return (
            <span onClick={this.props.model.increment}>
                {this.props.model.count}
            </span>
        );
    }
}