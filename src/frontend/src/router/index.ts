import { createRouter, createWebHistory, RouteRecordRaw } from "vue-router";
import HomeView from "@/views/HomeView.vue";
import AuthorizationView from "@/views/AuthorizationView.vue"
import RegistrationView from "@/views/RegistrationView.vue"
import AgentsView from "@/views/AgentsView.vue"
import PlayersView from "@/views/PlayersView.vue"
import CoachesView from "@/views/CoachesView.vue"

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
  {
    path: "/players",
    name: "players",
    component: PlayersView,
  },
  {
    path: "/coaches",
    name: "coaches",
    component: CoachesView,
  },
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
});

export default router;