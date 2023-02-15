<template>
  <button class="navbar-button">
    <TextWhite fontSize="var(--little-text)" fontColor>
        <slot></slot>
    </TextWhite>
  </button>
</template>

<script lang="ts">
import { defineComponent } from 'vue'
import TextWhite from '@/components/Text/TextWhite.vue'

export default defineComponent({
  name: "NuvbarButton",
  components: {
    TextWhite
  }
})
</script>

<style>
.navbar-button{
  background-color: transparent; 
  border: 2px solid var(--white);
  box-shadow: 0px 0px 10px var(--white);
  border-radius: 20px 20px 20px 20px;
  padding-left: 15px;
  padding-right: 15px;
  padding-top: 7px;
  padding-bottom: 7px;
  min-width: 117px;
}
.navbar-button:hover{
  box-shadow: 0px 0px 20px var(--white);
}
</style>