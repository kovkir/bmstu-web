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

    async addPlayerToSquad(squadId: number, id: number) {
        console.log("add SquadPlayer:", {squadId, id});
        const result = await this.execute('post', `/${squadId}/players`, {id});
        console.log("addSquadPlayer Status:", result.status);
    },

    deletePlayerFromSquad(squadId: number, playerId: number) {
        console.log("delete SquadPlayer:", {squadId, playerId});
        return this.execute('delete', `/${squadId}/players/${playerId}`);
    },
}