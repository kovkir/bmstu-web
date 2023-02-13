import axios from "axios";

axios.defaults.headers.common['Access-Control-Allow-Headers'] = '*';
axios.defaults.headers.common['Access-Control-Allow-Origin'] = '*';
axios.defaults.headers.common['Access-Control-Allow-Methods'] = '*';

export interface User {
    id: Number,
    login: String,
    permission: String
}

const client = axios.create({
    baseURL: 'https://localhost:5001/api/v1/users',
    validateStatus: function (status) {
        return status < 500;
    }
})

export default {
    execute(method: any, resource: any, data?: any, params?: any) {
        return client({
            method,
            url: resource,
            data,
            headers: { },
            params: params
        })
    },

    login (login: String, password: String) {
        return this.execute('post', '/login', {login, password});
    },

    register (login: String, password: String) {
        return this.execute('post', 'register', {login, password});
    },

    getAll() {
        return this.execute('get', '/');
    },
}
