<template>
  <NavBarView>
    <UsersTable />
  </NavBarView>
</template>

<script lang="ts">
import { defineComponent } from "vue";
import NavBarView from "@/views/NavBarView.vue"
import UsersTable from "@/components/Tables/Users/UsersTable.vue"

export default defineComponent({
  name: "UsersView",
  components: {
    NavBarView,
    UsersTable,
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