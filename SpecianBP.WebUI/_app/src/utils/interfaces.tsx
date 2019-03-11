export interface SeriesAveraged {
    fromTime: any;
    toTime: any;
    averageValue: number;
    maxValue: number;
    minValue: number;
    seriesName: string;
    unit: string;
}

export interface PlotParameters {
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
    lineColor: rgbColor;
    xAxisTitle: string;
    yAxisTitle: string;
}

export interface rgbColor{
    r:number;
    g:number;
    b:number;
}