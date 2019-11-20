export class MyFile
{
    public FileName: string;   

    constructor(options: {
        fileName: string
    }) {
        this.FileName = options.fileName
    }
}