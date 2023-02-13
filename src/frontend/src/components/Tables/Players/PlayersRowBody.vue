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
    <GreenButton>
      Add Player
    </GreenButton>
  </TextGray>
</template>

<script lang="ts">
import { computed, defineComponent } from 'vue'
import TextGray from "@/components/Text/TextGray.vue"
import GreenButton from "@/components/Buttons/GreenButton.vue"
import RedButton from "@/components/Buttons/RedButton.vue"
import ClubInterface from "@/Interfaces/ClubInterface"
import auth from '@/authentificationService'

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
    }
  },
  computed: {
    isInRole () {
      return auth.getCurrentUser().permission;
    },
  },
  mounted() {
    ClubInterface.getById(this.player.clubId).then(json => {this.clubName = json.data.name})
  }
})
</script>

<style scoped>
</style>