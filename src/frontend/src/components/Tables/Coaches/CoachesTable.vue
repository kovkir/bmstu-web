<template>
    <div class="container">
      <CoachesRowTitle />
      <CoachesRow
        class="item"
        v-for="coach in coaches"
        v-bind:coach="coach">
      </CoachesRow>
    </div>
  </template>
  
  <script lang="ts">
  import { defineComponent } from 'vue'
  import CoachesRow from "@/components/Tables/Coaches/CoachesRow.vue"
  import CoachesRowTitle from "@/components/Tables/Coaches/CoachesRowTitle.vue"
  import CoachInterface from '@/Interfaces/CoachInterface'
  
  export default defineComponent({
    name: "CoachesTable",
    components: {
      CoachesRow,
      CoachesRowTitle
    },
    props: {
  
    },
    data() {
      return {
        coaches: [],
        
      }
    },
    watch: {
  
    },
    mounted() {
      this.getCoaches();
    },
    methods: {
      getCoaches() {
        CoachInterface.getAll().then(json => {this.coaches = json.data});
      }
    }
  })
  </script>
  
  <style scoped>
  .container {
    display: flex;
    flex-direction: column;
    margin: 0;
    width: 80%;
    height: 90%;
    justify-content: top;
    padding-top: 5%;
    align-items: center;
    /* border: 2px solid var(--gray); */
  }
  </style>