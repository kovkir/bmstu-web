<template>
  <div class="players-item">
    <TextGray fontSize="var(--middle-text)">
      {{ player.surname }}
    </TextGray>
    <TextPink fontSize="var(--middle-text)">
      {{ player.rating }}
    </TextPink>
    <TextGray fontSize="var(--middle-text)">
      {{ player.country }}
    </TextGray>
    <TextGray fontSize="var(--middle-text)">
      {{ clubName }}
    </TextGray>
    <TextGray fontSize="var(--middle-text)">
      {{ player.price }}
    </TextGray>
    <RedButton v-on:click="deletePlayer">
      Delete
    </RedButton>
  </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue'
import TextGray from "@/components/Text/TextGray.vue"
import TextPink from "@/components/Text/TextPink.vue"
import RedButton from "@/components/Buttons/RedButton.vue"
import ClubInterface from '@/Interfaces/ClubInterface'
import SquadInterface from '@/Interfaces/SquadInterface'
import auth from '@/authentificationService'
import router from "@/router"

export default defineComponent({
  name: "PlayersTable",
  components: {
    TextGray,
    TextPink,
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
    }
  },
  mounted() {
    ClubInterface.getById(this.player.clubId).then(json => {this.clubName = json.data.name});
  },
  methods: {
    deletePlayer: function() {
      SquadInterface.deletePlayerFromSquad(auth.getCurrentUser().id, this.player.id);
      router.push("/players");
    },
  },
})
</script>

<style scoped>
.players-item {
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  border: 2px solid var(--white);
  background-color: var(--white); 
  box-shadow: 0px 0px 10px var(--white);
  border-radius: 20px 20px 20px 20px;
  padding: 15px;
  gap: 10px;
}
</style>