<template>
  <button class="red-no-active-button">
    <TextWhite fontSize="var(--middle-text)" fontColor>
        <slot></slot>
    </TextWhite>
  </button>
</template>

<script lang="ts">
import { defineComponent } from 'vue'
import TextWhite from '@/components/Text/TextWhite.vue'

export default defineComponent({
  name: "RedNotActiveButton",
  components: {
    TextWhite,
  }
})
</script>

<style>
.red-no-active-button{
  background-color: rgb(233, 78, 105, 0.5);
  border: 2px solid rgb(233, 78, 105, 0.1);
  box-shadow: 0px 0px 10px var(--gray);
  border-radius: 20px 20px 20px 20px;
  padding-left: 15px;
  padding-right: 15px;
  padding-top: 7px;
  padding-bottom: 7px;
  width: 100%;
}
</style>