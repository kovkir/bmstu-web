<template>
  <RowTitle v-if="isInRole == 'guest'" class="player-title-row-guest">
    <PlayersRowTitleBody />
  </RowTitle> 
  <RowTitle v-else class="player-title-row-user">
    <PlayersRowTitleBody />
  </RowTitle> 
</template>

<script lang="ts">
import { computed, defineComponent } from 'vue'
import RowTitle from "@/components/Tables/RowTitle.vue"
import PlayersRowTitleBody from "@/components/Tables/Players/PlayersRowTitleBody.vue"
import TextPink from "@/components/Text/TextPink.vue"
import auth from '@/authentificationService'

export default defineComponent({
  name: "PlayersRowTitle",
  components: {
    RowTitle,
    PlayersRowTitleBody,
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
.player-title-row-guest {
  padding: 10px;
  display: grid;
  grid-template-columns: 1fr 3fr 2.5fr 3fr 3fr 2.5fr;
  column-gap: 50px;
  width: 100%;
}
.player-title-row-user {
  padding: 10px;
  display: grid;
  grid-template-columns: 1fr 3fr 2.5fr 3fr 3fr 2.5fr 3fr;
  column-gap: 50px;
  width: 100%;
}
</style>