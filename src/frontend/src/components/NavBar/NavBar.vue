<template>
  <nav class="navbar-container">
    <!-- <div v-if="isInRole == 'user'">
      <UserNavbarMenu />
    </div>
    <div v-else-if="isInRole == 'admin'">
      <AdminNavbarMenu />
    </div>
    <div v-else>
      <GuestNavbarMenu />
    </div> -->
    <!-- <div>
      <nav class="navbar-menu-container">
        <AdminNavbarMenu />
        <LogoutNavbarMenu />
      </nav>
    </div> -->
    <div>
      <nav class="navbar-menu-container">
        <GuestNavbarMenu />
        <LoginNavbarMenu />
      </nav>
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

// import auth from '@/authentificationService'
// import UserInterface from '@/Interfaces/UserInterface'

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
    // return {
    //   componentName: 'GuestNavbarMenu'
    // }
  },
  computed: {
    // isInRole () {
    //   return auth.getCurrentUser().role;
    // }
  },
  methods: {
    // setGuest: function() {
    //   console.log('guest')
    //   console.log(auth.getCurrentUser())
    //   this.componentName = 'GuestNavbarMenu'
    // },
    // setUser: function() {
    //   auth.logout()
    //   location.reload()
    // },
    // setAdmin: async function() {
    //   console.log(await UserInterface.getAll());
    //   console.log('admin')
    //   this.componentName = 'AdminNavbarMenu'
    // },
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
