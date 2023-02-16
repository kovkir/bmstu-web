import { createRouter, createWebHistory, RouteRecordRaw } from "vue-router";
import HomeView from "@/views/HomeView.vue";
import AuthorizationView from "@/views/AuthorizationView.vue"
import RegistrationView from "@/views/RegistrationView.vue"
import AgentsView from "@/views/AgentsView.vue"
import PlayersView from "@/views/PlayersView.vue"
import CoachesView from "@/views/CoachesView.vue"
import MySquadView from "@/views/MySquadView.vue"

const routes: Array<RouteRecordRaw> = [
  {
    path: "/",
    name: "home",
    component: HomeView,
  },
  {
    path: "/authorization",
    name: "authorization",
    component: AuthorizationView,
  },
  {
    path: "/registration",
    name: "registration",
    component: RegistrationView,
  },
  {
    path: "/agents",
    name: "agents",
    component: AgentsView,
  },
  // {
  //   path: "/players",
  //   name: "players",
  //   component: PlayersView,
  // },
  {
    path: "/players:ClubName?:Surname?:Country?:MinPrice?:MaxPrice?:MinRating?:MaxRating?",
    name: "players",
    component: PlayersView,
    props: true,
  },
  {
    path: "/coaches",
    name: "coaches",
    component: CoachesView,
  },
  {
    path: "/mysquad",
    name: "mysquad",
    component: MySquadView,
  },
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
});

export default router;