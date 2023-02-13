<template>
  <div class="authorization-menu">
    <LogoutButton @click="logout">
      LOG OUT
    </LogoutButton>
  </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue'
import LogoutButton from '@/components/Buttons/LogoutButton.vue'
import auth from "@/authentificationService"

export default defineComponent({
  name: "LoginNavbarMenu",
  components: {
    LogoutButton,
  },
  methods: {
    logout () {
      auth.logout();
      this.$router.push({ path: '/authorization' })
    },
  }
})
</script>