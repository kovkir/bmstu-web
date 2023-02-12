<template>
  <div style="height: var(--navbar-height)">
    <NavBar />
  </div>
  <div class="main" style="height: calc(100% - var(--navbar-height))">
    <slot></slot>
  </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue'
import NavBar from "@/components/NavBar/NavBar.vue"

export default defineComponent({
  name: "NavBarView",
  components: {
    NavBar
  }
})
</script>

<style scoped>
.main {
  display: flex;
  flex-direction: column;
  margin: 0;
  width: 100%;
  height: 100%;
  justify-content: center;
  align-items: center;
  overflow: scroll;
}
</style>