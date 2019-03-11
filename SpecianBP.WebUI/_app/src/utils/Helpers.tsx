import { rgbColor } from 'utils/interfaces';

export class Helpers{

    public static getRgbString(input: rgbColor):string{
        return "rgb(" + input.r + ", " + input.g + ", " + input.b + ")";
    }

}

