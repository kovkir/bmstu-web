<template>
    <NavBarView>
      <CoachesTable />
    </NavBarView>
  </template>
  
  <script lang="ts">
  import { defineComponent } from "vue";
  import NavBarView from "@/views/NavBarView.vue"
  import CoachesTable from "@/components/Tables/Coaches/CoachesTable.vue"
  
  export default defineComponent({
    name: "CoachesView",
    components: {
      NavBarView,
      CoachesTable,
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