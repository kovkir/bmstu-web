<template>
  <NavBarView>
    <Registration />
  </NavBarView>
</template>

<script lang="ts">
import { defineComponent } from "vue";
import NavBarView from "@/views/NavBarView.vue"
import Registration from "@/components/Authorization/Registration.vue"

export default defineComponent({
  name: "RegistrationView",
  components: {
    NavBarView,
    Registration,
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
  justify-content: center;
  align-items: center;
  gap: 10px;
  padding-bottom: 13%;
}
</style>