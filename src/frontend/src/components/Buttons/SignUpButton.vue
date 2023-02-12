<template>
  <button class="signup-button">
    <TextWhite fontSize="var(--little-text)" fontColor>
        <slot></slot>
    </TextWhite>
  </button>
</template>

<script lang="ts">
import { defineComponent } from 'vue'
import TextWhite from '@/components/Text/TextWhite.vue'

export default defineComponent({
  name: "SignUpButton",
  components: {
    TextWhite
  }
})
</script>

<style>
.signup-button{
  display: flex;
  flex-direction: row;
  justify-content: center;
  align-items: center;
  background-color: var(--pink); 
  border: 2px solid var(--white);
  box-shadow: 0px 0px 10px var(--white);
  border-radius: 0px 0px 0px 0px;
  padding-left: 15px;
  padding-right: 15px;
  padding-top: 7px;
  padding-bottom: 7px;
  min-width: 120px;
}
.signup-button:hover{
  box-shadow: 0px 0px 20px var(--white);
}
</style>