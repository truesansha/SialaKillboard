export class PlayerClassItem {
    constructor(
        public killId: number,
        public killTime: Date,
        public victimName: string,
        public victimClass: string,
        public killerName: string,
        public locationName: string,
        public victimFaction: string,
        public victimFactionId: number
    ) { }
}