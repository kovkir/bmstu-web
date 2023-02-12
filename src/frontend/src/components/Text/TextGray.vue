<template>
  <div class="gray-text" :style="{ fontSize }">
    <slot></slot>
  </div>
</template>

<script lang="ts">
import { defineComponent } from "vue";

export default defineComponent({
  name: "TextGray",
  props: {
    fontSize: String,
  },
});
</script>

<style scoped>
.gray-text {
  color: var(--gray);
  text-shadow: 0px 0px 0px var(--gray);
}
</style>