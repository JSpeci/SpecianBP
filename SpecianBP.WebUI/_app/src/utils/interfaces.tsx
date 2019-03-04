export interface SeriesAveraged
{
    fromTime: any;
    toTime: any;
    averageValue: number;
    maxValue:number;
    minValue:number;
    seriesName:string;
}

export interface AveragedParameters
{
    from: any;
    to: any;
    seriesName:string;
    step:any;
}

export interface TimeValuePair
{
    time: any;
    value:number;
    seriesName:string;
}

