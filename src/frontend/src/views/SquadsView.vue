<template>
  <NavBarView>
    <SquadsTable />
  </NavBarView>
</template>

<script lang="ts">
import { defineComponent } from "vue";
import NavBarView from "@/views/NavBarView.vue"
import SquadsTable from "@/components/Tables/Squads/SquadsTable.vue"

export default defineComponent({
  name: "SquadsView",
  components: {
    NavBarView,
    SquadsTable,
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
</style>