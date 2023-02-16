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

    async getById(id: Number) {
        return await this.execute('get', `/${id}`)
    },

    addSquad(coachId: number, name: String, rating: number) {
        return this.execute('post', '/', {coachId, name, rating});
    },

    async isPlayerInSquad(squadId: Number, playerId: Number) {
        const result = await this.execute('get', `/${squadId}/players/${playerId}`);
        return result.status == 200;
    },

    async getPlayers(squadId: Number) {
        const result = await this.execute('get', `/${squadId}/players`);
        console.log("get players from squad Status:", result.status);
        return result;
    },

    async addPlayerToSquad(squadId: number, id: number) {
        return this.execute('post', `/${squadId}/players`, {id});
    },

    deletePlayerFromSquad(squadId: number, playerId: number) {
        return this.execute('delete', `/${squadId}/players/${playerId}`);
    },

    async isCoachInSquad(squadId: Number, coachId: Number) {
        const result = await this.execute('get', `/${squadId}/coach`);
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
        return this.execute('post', `/${squadId}/coach`, {id});
    },

    deleteCoachFromSquad(squadId: number, coachId: number) {
        return this.execute('delete', `/${squadId}/coach/${coachId}`);
    },
}