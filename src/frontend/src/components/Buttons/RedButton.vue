<template>
  <button class="red-button">
    <TextWhite fontSize="var(--middle-text)" fontColor>
        <slot></slot>
    </TextWhite>
  </button>
</template>

<script lang="ts">
import { defineComponent } from 'vue'
import TextWhite from '@/components/Text/TextWhite.vue'

export default defineComponent({
  name: "RedButton",
  components: {
    TextWhite,
  }
})
</script>

<style>
.red-button{
  background-color: var(--pink); 
  border: 2px solid var(--pink);
  box-shadow: 0px 0px 10px var(--gray);
  border-radius: 20px 20px 20px 20px;
  padding-left: 15px;
  padding-right: 15px;
  padding-top: 7px;
  padding-bottom: 7px;
  width: 100%;
}
.red-button:hover{
  box-shadow: 0px 0px 20px var(--pink);
}
</style>