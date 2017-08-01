export class KillListItem {
    constructor(
        public killId: number,
        public killTime: Date,
        public victimName: string,
        public victimId: number,
        public victimClassId: number,
        public victimClass: string,
        public victimFaction: string,
        public victimFactionId: number,
        public killerClassId: number,
        public killerClass: string,
        public killerId: number,
        public killerName: string,
        public killerFactionId: number,
        public killerFaction: string,
        public locationName: string,
        public locationId: number,
        public locationFaction: string,
        public locationFactionId: number
    ) { }
}