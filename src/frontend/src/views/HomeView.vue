<template>
  <NavBarView>
    
  </NavBarView>
</template>

<script lang="ts">
import { defineComponent } from "vue";
import NavBarView from "@/views/NavBarView.vue"

export default defineComponent({
  name: "HomeView",
  components: {
    NavBarView,

  },
  data() {
    // return {
    //   serverName: '',
    //   gameName: '',
    //   platformId: 0
    // }
  },
  computed: {
    
  },
  methods: {
    
  },
});

</script>

<style scoped>

.container {
  display: flex;
  flex-direction: column;
  margin: 0;
  width: 90%;
  height: 100%;
  justify-content: center;
  align-items: center;
  gap: 10px;
}
.text {
  display: flex;
  flex-direction: row;
  justify-content: left;
  align-items: left;
  width: 100%;
}
</style>