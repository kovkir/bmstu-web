<template>
  <div class="gray-text-block" :style="{fontSize}">
    <slot></slot>
  </div>
</template>

<script lang="ts">
import { computed, defineComponent } from "vue";

export default defineComponent({
  name: "TextBlock",
  props: {
    fontSize: String,
  },
});
</script>

<style scoped>
.gray-text-block {
  background: var(--white);
  box-shadow: 0px 0px 10px var(--white);
  border-radius: 20px 20px 20px 20px;
  border: 1px solid var(--white);
  padding-left: 20px;
  padding-right: 20px;
  padding-top: 10px;
  padding-bottom: 10px;
  color: var(--gray);
}
</style>
