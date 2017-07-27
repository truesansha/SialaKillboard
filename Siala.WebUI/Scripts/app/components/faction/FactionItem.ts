export class FactionItem {
    constructor(
        public id: number,
        public name: string,
        public description: string,
        public totalDeaths: number,
        public totalKills: number
    ) { }
}