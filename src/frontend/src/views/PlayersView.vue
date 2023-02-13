<template>
  <NavBarView>
    <PlayersTable />
  </NavBarView>
</template>

<script lang="ts">
import { defineComponent } from "vue";
import NavBarView from "@/views/NavBarView.vue"
import PlayersTable from "@/components/Tables/Players/PlayersTable.vue"

export default defineComponent({
  name: "PlayersView",
  components: {
    NavBarView,
    PlayersTable,
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