import axios from "axios";

axios.defaults.headers.common['Access-Control-Allow-Headers'] = '*';
axios.defaults.headers.common['Access-Control-Allow-Origin'] = '*';
axios.defaults.headers.common['Access-Control-Allow-Methods'] = '*';

export interface Squad {
    id: Number,
    coachId: Number,
	name: String,
	rating: Number,
}

export interface PlayerId {
    id: Number,
}

export interface CoachId {
    id: Number,
}

const client = axios.create({
    baseURL: 'https://localhost:5001/api/v1/squads',
    validateStatus: function (status) {
        return status < 500;
    }
})

export default {
    execute(method: any, resource: any, data?: any) {
        return client({
            method,
            url: resource,
            data,
            headers: {}
        });
    },

    getAll() {
        return this.execute('get', '/');
    },

    addSquad(coachId: number, name: String, rating: number) {
        console.log("SquadObj:", {coachId, name, rating});
        return this.execute('post', '/', {coachId, name, rating});
    },

    async isPlayerInSquad(squadId: Number, playerId: Number) {
        const result = await this.execute('get', `/${squadId}/players/${playerId}`);
        console.log("getSquadPlayer Status:", result.status);
        
        return result.status == 200;
    },

    async getPlayers(squadId: Number) {
        const result = await this.execute('get', `/${squadId}/players`);
        console.log("get players from squad Status:", result.status);
        return result;
    },

    async addPlayerToSquad(squadId: number, id: number) {
        console.log("add SquadPlayer:", {squadId, id});
        const result = await this.execute('post', `/${squadId}/players`, {id});
        console.log("addSquadPlayer Status:", result.status);
    },

    deletePlayerFromSquad(squadId: number, playerId: number) {
        console.log("delete SquadPlayer:", {squadId, playerId});
        return this.execute('delete', `/${squadId}/players/${playerId}`);
    },

    async isCoachInSquad(squadId: Number, coachId: Number) {
        const result = await this.execute('get', `/${squadId}/coach`);
        console.log("getSquadCoach Status:", result.status);
        
        if (result.status == 200 && result.data.id == coachId) {
            return true;
        }
        return false;
    },

    async getCoach(squadId: Number) {
        const result = await this.execute('get', `/${squadId}/coach`);
        console.log("get coach from squad Status:", result.status);
        return result;
    },

    async addCoachToSquad(squadId: number, id: number) {
        console.log("add SquadCoach:", {squadId, id});
        const result = await this.execute('post', `/${squadId}/coach`, {id});
        console.log("addSquadCoach Status:", result.status);
    },

    deleteCoachFromSquad(squadId: number, coachId: number) {
        console.log("delete SquadCoach:", {squadId, coachId});
        return this.execute('delete', `/${squadId}/coach/${coachId}`);
    },
}