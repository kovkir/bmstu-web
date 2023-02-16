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

  },
  components: {
    Background
  },
});
</script>


<style>
.notify {
  font-size: 28px;
  background: var(--white) !important;
  margin: 0 5px 5px;
  padding: 10px;
  border-left: 15px solid var(--pink);
  color: var(--gray);
  text-shadow: 0px 0px 20px var(--wite);
}

:root{
  --little-text: 20px;
  --middle-text: 30px;
  --large-text: 50px;
  --pink: rgb(233, 78, 105);
  --blue: rgb(32, 48, 79);
  --green: rgb(103, 173, 53);
  --white: rgb(255, 255, 255);
  --gray: rgb(108, 104, 104);

  --navbar-height: 90px;
  --login-border-width: 200px;
}
</style>
