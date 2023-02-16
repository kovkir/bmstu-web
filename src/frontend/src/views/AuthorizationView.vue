<template>
  <NavBarView>
    <Authorization />
  </NavBarView>
</template>

<script lang="ts">
import { defineComponent } from "vue";
import NavBarView from "@/views/NavBarView.vue"
import Authorization from "@/components/Authorization/Authorization.vue"

export default defineComponent({
  name: "AuthorizationView",
  components: {
    NavBarView,
    Authorization,
  },
})
</script>

<style scoped>
.container {
  display: flex;
  flex-direction: column;
  margin: 0;
  width: 100%;
  height: 100%;
  justify-content: top;
  align-items: center;
  gap: 10px;
  padding-top: 5%;
}
</style>