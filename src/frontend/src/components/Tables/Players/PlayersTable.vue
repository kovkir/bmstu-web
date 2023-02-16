<template>
  <div class="container">
    <PlayersRowTitle />
    <PlayersRow
      v-for="player in players"
      v-bind:player="player">
    </PlayersRow>
  </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue'
import PlayersRow from "@/components/Tables/Players/PlayersRow.vue"
import PlayersRowTitle from "@/components/Tables/Players/PlayersRowTitle.vue"
import PlayerInterface from '@/Interfaces/PlayerInterface'

export default defineComponent({
  name: "PlayersTable",
  components: {
    PlayersRow,
    PlayersRowTitle
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
    return {
      players: [],
      
    }
  },
  mounted() {
    this.getPlayers();
  },
  methods: {
    getPlayers() {
      PlayerInterface.getAll(
        this.ClubName, this.Surname, this.Country, this.MinPrice, 
        this.MaxPrice, this.MinRating, this.MaxRating).then(json => {this.players = json.data});
    }
  }
})
</script>

<style scoped>
.container {
  display: flex;
  flex-direction: column;
  margin: 0;
  width: 90%;
  height: 90%;
  justify-content: top;
  padding-top: 5%;
  align-items: flex-start;
  /* border: 2px solid var(--gray); */
}
</style>