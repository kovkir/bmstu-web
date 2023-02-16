<template>
  <NavBarView>
    <ClubsTable />
  </NavBarView>
</template>

<script lang="ts">
import { defineComponent } from "vue";
import NavBarView from "@/views/NavBarView.vue"
import ClubsTable from "@/components/Tables/Clubs/ClubsTable.vue"

export default defineComponent({
  name: "ClubsView",
  components: {
    NavBarView,
    ClubsTable,
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