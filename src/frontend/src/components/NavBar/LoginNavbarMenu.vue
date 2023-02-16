<template>
  <div class="authorization-menu">
    <router-link style="text-decoration: none" to="/authorization">
      <LoginButton>
        LOG IN
      </LoginButton>
    </router-link>
    <router-link style="text-decoration: none" to="/registration">
      <SignUpButton>
        SIGN UP
      </SignUpButton>
    </router-link>
  </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue'
import LoginButton from '@/components/Buttons/LoginButton.vue'
import SignUpButton from '@/components/Buttons/SignUpButton.vue'

export default defineComponent({
  name: "LoginNavbarMenu",
  components: {
    LoginButton,
    SignUpButton,
  }
})
</script>