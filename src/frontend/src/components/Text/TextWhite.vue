<template>
  <div class="white-text" :style="{ fontSize }">
    <slot></slot>
  </div>
</template>

<script lang="ts">
import { defineComponent } from "vue";

export default defineComponent({
  name: "TextWhite",
  props: {
    fontSize: String,
  },
});
</script>

<style scoped>
.white-text {
  color: var(--white);
  text-shadow: 0px 0px 0px var(--white);
}

/* .white-text:hover{
  color: var(--pink);
  text-shadow: 0px 0px 0px var(--pink);
} */

</style>