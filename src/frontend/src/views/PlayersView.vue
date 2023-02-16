<template>
  <NavBarView>
    <PlayersTable 
      v-bind:ClubName="ClubName"
      v-bind:Surname="Surname"
      v-bind:Country="Country"
      v-bind:MinPrice="MinPrice"
      v-bind:MaxPrice="MaxPrice"
      v-bind:MinRating="MinRating"
      v-bind:MaxRating="MaxRating" />
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
  props: [
    "ClubName", 
    "Surname",
    "Country",
    "MinPrice",
    "MaxPrice",
    "MinRating",
    "MaxRating"
  ],
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