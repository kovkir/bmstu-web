<template>
  <div class="authorization-menu">
    <router-link style="text-decoration: none" to="/">
      <LogoutButton>
        LOG OUT
      </LogoutButton>
    </router-link>
  </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue'
import LogoutButton from '@/components/Buttons/LogoutButton.vue'

export default defineComponent({
  name: "LoginNavbarMenu",
  components: {
    LogoutButton,
  }
})
</script>