<template>
  <div class="players-container">
    <PlayersItem
      v-for="player in players"
      v-bind:player="player">
    </PlayersItem>
  </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue'
import PlayersItem from "@/components/MySquad/PlayersItem.vue"
import SquadInterface from '@/Interfaces/SquadInterface'
import auth from "@/authentificationService";

export default defineComponent({
  name: "PlayersList",
  components: {
    PlayersItem,
  },
  props: {

  },
  data() {
    return {
      players: [],
    }
  },
  watch: {

  },
  mounted() {
    this.getPlayers();
  },
  methods: {
    getPlayers() {
      SquadInterface.getPlayers(auth.getCurrentUser().id).then(json => {this.players = json.data});
    },
  },
})
</script>

<style scoped>
.players-container {
  display: grid;
  grid-template-columns: 1fr 1fr 1fr;
  gap: 50px;
  width: 80%;
  /* border: 2px solid var(--white); */
}
</style>