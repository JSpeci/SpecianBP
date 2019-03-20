export interface SeriesAveraged {
    fromTime: any;
    toTime: any;
    averageValue: number;
    maxValue: number;
    minValue: number;
    seriesName: string;
    unit: string;
}

export interface SeriesLineParams{
    seriesName: string;
    step: any;
    measurementPlaceNumberId: number;
}

export interface SeriesParams{
    from: any;
    to: any;
    line: SeriesLineParams;
}

export interface MyPlotData {
    data: SeriesAveraged[];
    params: PlotParameters;
}

export interface PlotParameters {
    seriesParams: SeriesParams;
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
    lineWidth: number;
}

export interface MeasurementPlace {
    numberId: number;
    displayName: string;
    fileName: string;
    adress: string;
}

export interface rgbColor {
    r: number;
    g: number;
    b: number;
}