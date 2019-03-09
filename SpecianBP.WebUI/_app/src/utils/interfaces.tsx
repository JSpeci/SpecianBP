export interface SeriesAveraged {
    fromTime: any;
    toTime: any;
    averageValue: number;
    maxValue: number;
    minValue: number;
    seriesName: string;
}

export interface AveragedParameters {
    from: any;
    to: any;
    seriesName: string;
    step: any;
    chartProps: ChartProps;
}

export interface TimeValuePair {
    time: any;
    value: number;
    seriesName: string;
}

export interface ChartProps {
    type: string;
    xSize: number;
    ySize: number;
}