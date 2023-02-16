<template>
  <nav class="navbar-container">
    <div v-if="isInRole == 'user'" class="navbar-menu-container">
      <UserNavbarMenu />
      <LogoutNavbarMenu />
    </div>
    <div v-else-if="isInRole == 'admin'" class="navbar-menu-container">
      <AdminNavbarMenu />
      <LogoutNavbarMenu />
    </div>
    <div v-else class="navbar-menu-container">
      <GuestNavbarMenu />
      <LoginNavbarMenu />
    </div>
  </nav>
</template>

<script lang="ts">
import { defineAsyncComponent, defineComponent } from 'vue'
import GuestNavbarMenu from '@/components/NavBar/GuestNavbarMenu.vue'
import UserNavbarMenu from '@/components/NavBar/UserNavbarMenu.vue'
import AdminNavbarMenu from '@/components/NavBar/AdminNavbarMenu.vue'
import LoginNavbarMenu from '@/components/NavBar/LoginNavbarMenu.vue'
import LogoutNavbarMenu from '@/components/NavBar/LogoutNavbarMenu.vue'

import auth from '@/authentificationService'

export default defineComponent({
  name: "NavBar",
  components: {
    GuestNavbarMenu,
    UserNavbarMenu,
    AdminNavbarMenu,
    LoginNavbarMenu,
    LogoutNavbarMenu
  },
  data() {

  },
  computed: {
    isInRole () {
      if (auth.getCurrentUser()) { 
        return auth.getCurrentUser().permission;
      }
      else {
        auth.logout()
        return "guest"
      }
    }
  },
  methods: {

  }
})
</script>

<style>
.navbar-container {
  position: fixed;
  height: var(--navbar-height);
  box-shadow: 0px 0px 10px var(--white);
  left: 0;
  right: 0;
  display: flex;
  justify-content: space-between;
}
.navbar-menu-container {
  position: fixed;
  height: var(--navbar-height);
  left: 1;
  right: 0;
  padding-left: 1.4rem;
  padding-right: 1.4rem;
  display: flex;
  justify-content: space-between;
  align-items: center;
}
.navbar-menu {
  display: flex;
  gap: 10px;
  padding-left: 1.4rem;
  padding-right: 1.4rem;
}
.authorization-menu {
  display: flex;
  gap: 10px;
}
</style>
