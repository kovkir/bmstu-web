<template>
  <button class="blue-button">
    <TextWhite fontSize="var(--middle-text)" fontColor>
        <slot></slot>
    </TextWhite>
  </button>
</template>

<script lang="ts">
import { defineComponent } from 'vue'
import TextWhite from '@/components/Text/TextWhite.vue'

export default defineComponent({
  name: "BlueButton",
  components: {
    TextWhite,
  }
})
</script>

<style>
.blue-button{
  background-color: var(--blue); 
  border: 2px solid var(--blue);
  box-shadow: 0px 0px 10px var(--gray);
  border-radius: 20px 20px 20px 20px;
  padding-left: 15px;
  padding-right: 15px;
  padding-top: 7px;
  padding-bottom: 7px;
  width: 100%;
}
.blue-button:hover{
  box-shadow: 0px 0px 20px var(--blue);
}
</style>