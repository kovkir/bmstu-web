<template>
  <div class="row-title">
    <slot></slot>
  </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue'

export default defineComponent({
  name: "RowTitle"
})
</script>

<style scoped>
.row-title {
  background: rgba(255, 255, 255, 0.9);
  box-shadow: 0px 0px 50px var(--gray);
  border-radius: 30px 30px 0px 0px;
}
</style>