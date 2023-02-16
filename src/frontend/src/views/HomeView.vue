<template>
  <NavBarView>
    <SelectionPlayer />
  </NavBarView>
</template>

<script lang="ts">
import { defineComponent } from "vue";
import NavBarView from "@/views/NavBarView.vue"
import SelectionPlayer from "@/components/Selection/SelectionPlayer.vue"

export default defineComponent({
  name: "HomeView",
  components: {
    NavBarView,
    SelectionPlayer,
  },
  data() {

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
  width: 100%;
  height: 100%;
  justify-content: center;
  align-items: center;
  gap: 10px;
}
</style>