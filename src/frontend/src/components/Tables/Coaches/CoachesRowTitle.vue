<template>
    <RowTitle v-if="isInRole == 'guest'" class="coach-title-row-guest">
      <CoachesRowTitleBody />
    </RowTitle> 
    <RowTitle v-else class="coach-title-row-user">
      <CoachesRowTitleBody />
    </RowTitle> 
  </template>
  
  <script lang="ts">
  import { computed, defineComponent } from 'vue'
  import RowTitle from "@/components/Tables/RowTitle.vue"
  import CoachesRowTitleBody from "@/components/Tables/Coaches/CoachesRowTitleBody.vue"
  import TextPink from "@/components/Text/TextPink.vue"
  import auth from '@/authentificationService'
  
  export default defineComponent({
    name: "CoachesRowTitle",
    components: {
      RowTitle,
      CoachesRowTitleBody,
      TextPink,
    },
    computed: {
      isInRole () {
        return auth.getCurrentUser().permission;
      },
    },
  })
  </script>
  
  <style scoped>
  .coach-title-row-guest {
    padding: 10px;
    display: grid;
    grid-template-columns: 1fr 3fr 3fr 3fr;
    column-gap: 50px;
    width: 100%;
  }
  .coach-title-row-user {
    padding: 10px;
    display: grid;
    grid-template-columns: 1fr 3fr 3fr 3fr 3fr;
    column-gap: 50px;
    width: 100%;
  }
  </style>