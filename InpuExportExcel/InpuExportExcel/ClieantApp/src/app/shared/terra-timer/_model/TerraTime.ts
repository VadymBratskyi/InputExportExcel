export class TerraTime {
    public Minutes: number;
    public Seconds: number;
    public MiliSeconds: number;

    constructor(options: {
        minutes?: number,
        seconds?: number,
        miliseconds?: number
    }) {
        this.Minutes = options.minutes || 0;
        this.Seconds = options.seconds || 0;
        this.MiliSeconds = options.miliseconds || 0;
    }

    get TerraTimeToString() {     
        return `${this.Minutes > 10 ? this.Minutes : '0'+ this.Minutes}:${this.Seconds > 10 ? this.Seconds : '0'+ this.Seconds}:${this.MiliSeconds > 10 ? this.MiliSeconds : '0'+ this.MiliSeconds}`;
    }
}