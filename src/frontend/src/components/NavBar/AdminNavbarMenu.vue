<template>
  <div class="navbar-menu">
    <router-link style="text-decoration: none" to="/">
      <NavbarButton>
        HOME
      </NavbarButton>
    </router-link>
    <router-link style="text-decoration: none" to="/mysquad">
      <NavbarButton>
        MY SQUAD
      </NavbarButton>
    </router-link>
    <router-link style="text-decoration: none" to="/users">
      <NavbarButton>
        USERS
      </NavbarButton>
    </router-link>
    <router-link style="text-decoration: none" to="/squads">
      <NavbarButton>
        SQUADS
      </NavbarButton>
    </router-link>
    <router-link style="text-decoration: none" to="/players">
      <NavbarButton>
        PLAYERS
      </NavbarButton>
    </router-link>
    <router-link style="text-decoration: none" to="/coaches">
      <NavbarButton>
        COACHES
      </NavbarButton>
    </router-link>
    <router-link style="text-decoration: none" to="/clubs">
      <NavbarButton>
        CLUBS
      </NavbarButton>
    </router-link>
    <router-link style="text-decoration: none" to="/agents">
      <NavbarButton>
        AGENTS
      </NavbarButton>
    </router-link>
  </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue'
import NavbarButton from '@/components/Buttons/NavbarButton.vue'

export default defineComponent({
  name: "AdminNavbarMenu",
  components: {
    NavbarButton
  }
})
</script>