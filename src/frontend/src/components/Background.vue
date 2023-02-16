<template>
    <div class="bg-image">
      <slot></slot>
    </div>
  </template>
  
  <script lang="ts">
  import { defineComponent } from 'vue'
  export default defineComponent({
    name: "Background"
  })
  </script>
  
  
  <style scoped>
  .bg-image {
    top: 0pt;
    left: 0pt;
    position: absolute;
    height: 100vh;
    width: 100vw;
    background-image: url("@/assets/img/background.png");
    background-size: cover;
    size: cover;
  }
  </style>