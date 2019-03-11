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
    lineColor: rgbColor;
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

export interface rgbColor{
    r:number;
    g:number;
    b:number;
}