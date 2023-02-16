<template>
  <NavBarView>
    <AgentsTable />
  </NavBarView>
</template>

<script lang="ts">
import { defineComponent } from "vue";
import NavBarView from "@/views/NavBarView.vue"
import AgentsTable from "@/components/Tables/Agents/AgentsTable.vue"

export default defineComponent({
  name: "AgentsView",
  components: {
    NavBarView,
    AgentsTable,
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