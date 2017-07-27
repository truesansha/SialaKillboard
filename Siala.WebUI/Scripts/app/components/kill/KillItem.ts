import { PlayerItem } from '../player/PlayerItem';

export class KillItem {
    constructor(
        public killId: number,
        public killTime: Date,
        public killerId: number,
        public locationId: number,
        public locationName: string,
        public victimDetails: PlayerItem,
        public involvedPlayers: PlayerItem[]
    ) { }
}