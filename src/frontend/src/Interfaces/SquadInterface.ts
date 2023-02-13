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
}