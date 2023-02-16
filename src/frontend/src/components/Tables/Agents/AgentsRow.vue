<template>
  <Row class="agent-row">
    <TextGray fontSize="var(--middle-text)">
      {{ agent.id }}
    </TextGray>
    <TextGray fontSize="var(--middle-text)">
      {{ agent.surname }}
    </TextGray>
    <TextGray fontSize="var(--middle-text)">
      {{ playerSurname }}
    </TextGray>
    <TextGray fontSize="var(--middle-text)">
      {{ agent.country }}
    </TextGray>
  </Row> 
</template>

<script lang="ts">
import { computed, defineComponent } from 'vue'
import Row from "@/components/Tables/Row.vue"
import TextGray from "@/components/Text/TextGray.vue"
import PlayerInterface from "@/Interfaces/PlayerInterface"

export default defineComponent({
  name: "AgentsRow",
  components: {
    Row,
    TextGray,
  },
  props: {
    agent: {
      type: Object,
      required: true
    },
  },
  data() {
    return {
      playerSurname: '',
    }
  },
  mounted() {
    PlayerInterface.getById(this.agent.playerId).then(json => {this.playerSurname = json.data.surname})
  }
})
</script>

<style scoped>
.agent-row {
  padding: 10px;
  display: grid;
  grid-template-columns: 1fr 3fr 3fr 3fr;
  column-gap: 50px;
  width: 100%;
}
</style>