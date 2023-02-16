<template>
  <button class="login-button">
    <TextWhite fontSize="var(--little-text)" fontColor>
        <slot></slot>
    </TextWhite>
  </button>
</template>

<script lang="ts">
import { defineComponent } from 'vue'
import TextWhite from '@/components/Text/TextWhite.vue'

export default defineComponent({
  name: "LoginButton",
  components: {
    TextWhite
  }
})
</script>

<style>
.login-button{
  background-color: transparent; 
  border: 2px solid var(--white);
  box-shadow: 0px 0px 10px var(--white);
  border-radius: 0px 0px 0px 0px;
  padding-left: 15px;
  padding-right: 15px;
  padding-top: 7px;
  padding-bottom: 7px;
  min-width: 120px;
}
.login-button:hover{
  box-shadow: 0px 0px 20px var(--white);
}
</style>