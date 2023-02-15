<template>
  <TextGray fontSize="var(--middle-text)">
    {{ player.id }}
  </TextGray>
  <TextGray fontSize="var(--middle-text)">
    {{ player.surname }}
  </TextGray>
  <TextGray fontSize="var(--middle-text)">
    {{ player.rating }}
  </TextGray>
  <TextGray fontSize="var(--middle-text)">
    {{ player.country }}
  </TextGray>
  <TextGray fontSize="var(--middle-text)">
    {{ clubName }}
  </TextGray>
  <TextGray fontSize="var(--middle-text)">
    {{ player.price }}
  </TextGray>
  <TextGray  v-if="isInRole != 'guest'" fontSize="var(--little-text)">
    <div v-if="isMyPlayer">
      <RedButton v-on:click="deletePlayer">
        Delete
      </RedButton>
    </div>
    <div v-else>
      <GreenButton v-on:click="addPlayer">
        Add
      </GreenButton>
    </div>
  </TextGray>
</template>

<script lang="ts">
import { computed, defineComponent } from 'vue'
import TextGray from "@/components/Text/TextGray.vue"
import GreenButton from "@/components/Buttons/GreenButton.vue"
import RedButton from "@/components/Buttons/RedButton.vue"
import ClubInterface from "@/Interfaces/ClubInterface"
import SquadInterface from "@/Interfaces/SquadInterface"
import auth from '@/authentificationService'
import router from "@/router";

export default defineComponent({
  name: "PlayersRowBody",
  components: {
    TextGray,
    GreenButton,
    RedButton,
  },
  props: {
    player: {
      type: Object,
      required: true
    },
  },
  data() {
    return {
      clubName: '',
      isMyPlayer: false,
    }
  },
  computed: {
    isInRole () {
      return auth.getCurrentUser().permission;
    },
  },
  async mounted() {
    ClubInterface.getById(this.player.clubId).then(json => {this.clubName = json.data.name});
    this.isMyPlayer = await SquadInterface.isPlayerInSquad(auth.getCurrentUser().id, this.player.id);
  },
  methods: {
    addPlayer: function() {
      SquadInterface.addPlayerToSquad(auth.getCurrentUser().id, this.player.id);
      router.push("/mysquad");
    },
    deletePlayer: function() {
      SquadInterface.deletePlayerFromSquad(auth.getCurrentUser().id, this.player.id);
      router.push("/mysquad");
    },
  },
})
</script>

<style scoped>
</style>