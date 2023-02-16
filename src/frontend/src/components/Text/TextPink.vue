<template>
  <div class="pink-text" :style="{ fontSize }">
    <slot></slot>
  </div>
</template>

<script lang="ts">
import { defineComponent } from "vue";

export default defineComponent({
  name: "TextPink",
  props: {
    fontSize: String,
  },
});
</script>

<style scoped>
.pink-text {
  color: var(--pink);
  text-shadow: 0px 0px 0px var(--pink);
}
</style>