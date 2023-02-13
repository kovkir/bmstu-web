<template>
  <button class="green-button">
    <TextWhite fontSize="var(--middle-text)" fontColor>
        <slot></slot>
    </TextWhite>
  </button>
</template>

<script lang="ts">
import { defineComponent } from 'vue'
import TextWhite from '@/components/Text/TextWhite.vue'

export default defineComponent({
  name: "GreenButton",
  components: {
    TextWhite,
  }
})
</script>

<style>
.green-button{
  background-color: var(--green); 
  border: 2px solid var(--green);
  box-shadow: 0px 0px 10px var(--gray);
  border-radius: 20px 20px 20px 20px;
  padding-left: 15px;
  padding-right: 15px;
  padding-top: 7px;
  padding-bottom: 7px;
  /* min-width: 120px; */
}
.green-button:hover{
  box-shadow: 0px 0px 20px var(--green);
}
</style>