export class PlayerItem {
    constructor(
        public id: number,
        public name: string,
        public class1Id: number,
        public class1: string,
        public class1Level: number,
        public raceId: number,
        public race: string,
        public factionId: number,
        public faction: string,
        public damage: number,
        public totalKills: number,
        public totalDeaths: number
    ) { }
}