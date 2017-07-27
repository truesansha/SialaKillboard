export class LocationItem {
    constructor(
        public id: number,
        public name: string,
        public factionId: number,
        public factionName: string,
        public totalKills: number
    ) { }
}