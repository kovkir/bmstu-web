import axios from "axios";

axios.defaults.headers.common['Access-Control-Allow-Headers'] = '*';
axios.defaults.headers.common['Access-Control-Allow-Origin'] = '*';
axios.defaults.headers.common['Access-Control-Allow-Methods'] = '*';

export interface FilterPlayer {
    clubName: String,
    surname: String,
    country: String,
    minPrice: Number,
    maxPrice: Number,
    minRating: Number,
    maxRating: Number,
}

const client = axios.create({
    baseURL: 'https://localhost:5001/api/v1/players',
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
            headers: {},
            params: params
        });
    },

    async getById(id: Number) {
        return await this.execute('get', `/${id}`)
    },

    // getAll() {
    //     return this.execute('get', '/');
    // },

    getAll(
        ClubName: string,
        Surname: string,
        Country: string,
        MinPrice: number | null = null,
        MaxPrice: number | null = null,
        MinRating: number | null = null,
        MaxRating: number | null = null,
        ) {
        console.log("getAllPlayersByParameters: ", {ClubName, Surname, Country, MinPrice, MaxPrice, MinRating, MaxRating});
        return this.execute('get', '/', null, {ClubName, Surname, Country, MinPrice, MaxPrice, MinRating, MaxRating});
    },
}
