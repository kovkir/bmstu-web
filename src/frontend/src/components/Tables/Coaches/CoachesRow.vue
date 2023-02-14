<template>
    <Row v-if="isInRole == 'guest'" class="coach-row-guest">
      <CoachesRowBody v-bind:coach="coach"/>
    </Row> 
    <Row v-else class="coach-row-user">
      <CoachesRowBody v-bind:coach="coach"/>
    </Row> 
  </template>
  
  <script lang="ts">
  import { computed, defineComponent } from 'vue'
  import Row from "@/components/Tables/Row.vue"
  import CoachesRowBody from "@/components/Tables/Coaches/CoachesRowBody.vue"
  import TextGray from "@/components/Text/TextGray.vue"
  import auth from '@/authentificationService'
  
  export default defineComponent({
    name: "CoachesRow",
    components: {
      Row,
      CoachesRowBody,
      TextGray,
    },
    props: {
      coach: {
        type: Object,
        required: true
      },
    },
    computed: {
      isInRole () {
        return auth.getCurrentUser().permission;
      },
    },
  })
  </script>
  
  <style scoped> 
  .coach-row-guest {
    padding: 10px;
    display: grid;
    grid-template-columns: 1fr 3fr 3fr 3fr;
    column-gap: 50px;
    width: 100%;
  }
  .coach-row-user {
    padding: 10px;
    display: grid;
    grid-template-columns: 1fr 3fr 3fr 3fr 3fr;
    column-gap: 50px;
    width: 100%;
  }
  </style>