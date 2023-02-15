<template>
  <button class="input-button">
    <TextWhite fontSize="var(--middle-text)" fontColor>
      <slot></slot>
    </TextWhite>
  </button>
</template>

<script lang="ts">
import { defineComponent } from 'vue'
import TextWhite from '@/components/Text/TextWhite.vue'

export default defineComponent({
  name: "InputButton",
  components: {
    TextWhite,
  }
})
</script>

<style>
.input-button{
  background-color: var(--pink); 
  border: 2px solid var(--pink);
  box-shadow: 0px 0px 10px var(--pink);
  border-radius: 20px 20px 20px 20px;
  padding-left: 15px;
  padding-right: 15px;
  padding-top: 10px;
  padding-bottom: 10px;
  /* min-width: 120px; */
}
.input-button:hover{
  box-shadow: 0px 0px 20px var(--pink);
}
</style>