import axios from "axios";

axios.defaults.headers.common['Access-Control-Allow-Headers'] = '*';
axios.defaults.headers.common['Access-Control-Allow-Origin'] = '*';
axios.defaults.headers.common['Access-Control-Allow-Methods'] = '*';

export interface Player {
    id: Number,
    clubId: Number,
	surname: String,
	rating: Number,
    country: String,
    price: Number
}

const client = axios.create({
    baseURL: 'https://localhost:5001/api/v1/players',
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
}
