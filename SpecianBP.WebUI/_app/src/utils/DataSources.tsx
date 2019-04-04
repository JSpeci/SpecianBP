
export interface ListItem {
    id: string | number;
    title: string;
}

export class DataSources {

    static aggregationFuncTypes(): ListItem[] {

        return [
            { id: 0, title: "Average" },
            { id: 1, title: "Min" },
            { id: 2, title: "Max" },
        ];
    }
}