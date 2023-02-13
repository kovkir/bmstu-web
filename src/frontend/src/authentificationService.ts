import SquadInterface from "./Interfaces/SquadInterface";
import UserInterface from "./Interfaces/UserInterface";

interface User {
    id: Number,
    login: String,
    permission: String
}

export default {
    async login(login: String, password: String) {
        const result = await UserInterface.login(login, password);
        console.log("LoginAuth:", result.status);

        if (result.status == 200) {
            console.log(result.data);
            localStorage.setItem('currentUser', JSON.stringify(result.data));
            console.log("currentUser: ", JSON.parse(String(localStorage.getItem("currentUser"))));
            return true;
        }

        return false;
    },

    async register(login: String, password: String) {
        const resUser = await UserInterface.register(login, password);
        console.log("RegisterAuth:", resUser.status);

        if (resUser.status == 200) {
            const resSquad = await SquadInterface.addSquad(0, login + "Squad", 0);
            console.log("AddSquadAuth:", resSquad.status);
            return true;
        }

        return false;
    },
    
    getCurrentUser() {
        return JSON.parse(String(localStorage.getItem("currentUser")));
    },
    
    logout() {
        console.log("LogoutAuth");
        const user: User = {
            id: 0,
            login: "guest",
            permission: "guest"
        }
    
        localStorage.setItem('currentUser', JSON.stringify(user));
        console.log("currentUser: ", JSON.parse(String(localStorage.getItem("currentUser"))));
    }
}