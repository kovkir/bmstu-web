<template>
  <div class="row">
    <slot></slot>
  </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue'

export default defineComponent({
  name: "Row"
})
</script>

<style scoped>
.row {
  background: rgba(255, 255, 255, 0.9);
  box-shadow: 0px 0px 50px var(--gray);
  border-radius: 0px 0px 0px 0px;
}
</style>