<template>
  <Row class="agent-row">
    <TextGray class="item" fontSize="var(--middle-text)">
      {{ agent.id }}
    </TextGray>
    <TextGray class="item" fontSize="var(--middle-text)">
      {{ agent.surname }}
    </TextGray>
    <TextGray class="item" fontSize="var(--middle-text)">
      {{ playerSurname }}
    </TextGray>
    <TextGray class="item" fontSize="var(--middle-text)">
      {{ agent.country }}
    </TextGray>
  </Row> 
</template>

<script lang="ts">
import { computed, defineComponent } from 'vue'
import Row from "@/components/Tables/Row.vue"
import TextGray from "@/components/Text/TextGray.vue"
// import ServerMenu from "@/components/Servers/ServerMenu.vue"
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
.item:nth-child(1) {
  grid-column: 1;
  grid-row: 1;
}
.item:nth-child(2) {
  grid-column: 2;
  grid-row: 1;
}
.item:nth-child(3) {
  grid-column: 3;
  grid-row: 1;
}
.item:nth-child(4) {
  grid-column: 4;
  grid-row: 1;
}
</style>