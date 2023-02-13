<template>
  <Row v-if="isInRole == 'guest'" class="player-row-guest">
    <PlayersRowBody v-bind:player="player"/>
  </Row> 
  <Row v-else class="player-row-user">
    <PlayersRowBody v-bind:player="player"/>
  </Row> 
</template>

<script lang="ts">
import { computed, defineComponent } from 'vue'
import Row from "@/components/Tables/Row.vue"
import PlayersRowBody from "@/components/Tables/Players/PlayersRowBody.vue"
import TextGray from "@/components/Text/TextGray.vue"
import auth from '@/authentificationService'

export default defineComponent({
  name: "PlayersRow",
  components: {
    Row,
    PlayersRowBody,
    TextGray,
  },
  props: {
    player: {
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
.player-row-guest {
  padding: 10px;
  display: grid;
  grid-template-columns: 1fr 3fr 2.5fr 3fr 3fr 2.5fr;
  column-gap: 50px;
  width: 100%;
}
.player-row-user {
  padding: 10px;
  display: grid;
  grid-template-columns: 1fr 3fr 2.5fr 3fr 3fr 2.5fr 3fr;
  column-gap: 50px;
  width: 100%;
}
</style>