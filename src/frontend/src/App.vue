<template>
  <Background>
    <notifications position="top center" classes="notify" width="20%" />
    <router-view/>
  </Background>
</template>

<script lang="ts">
import { defineComponent } from "vue";
import Background from "@/components/Background.vue"

export default defineComponent({
  setup() {
    // auth.logout()
  },
  components: {
    Background
  },
});
</script>


<style>
/* .notify {
  font-size: 28px;
  background: rgba(0, 0, 0, 0.6) !important;
  margin: 0 5px 5px;
  padding: 10px;
  border-left: 15px solid var(--magenta);
  color: var(--cyan);
  text-shadow: 0px 0px 20px var(--magenta);
} */

:root{
  --little-text: 20px;
  --middle-text: 30px;
  --large-text: 50px;
  --pink: rgb(233, 78, 105);
  --blue: rgb(32, 48, 79);
  --green: rgb(143, 196, 105);
  --white: rgb(255, 255, 255);
  --gray: rgb(108, 104, 104);

  --navbar-height: 90px;
  --login-border-width: 200px;
}
</style>
