<template>
  <div class="container">
    <AgentsRowTitle />
    <AgentsRow
      class="item"
      v-for="agent in agents"
      v-bind:agent="agent">
    </AgentsRow>
  </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue'
import AgentsRow from "@/components/Tables/Agents/AgentsRow.vue"
import AgentsRowTitle from "@/components/Tables/Agents/AgentsRowTitle.vue"

import AgentInterface from "@/Interfaces/AgentInterface"

export default defineComponent({
  name: "AgentsTable",
  components: {
    AgentsRow,
    AgentsRowTitle
  },
  props: {

  },
  data() {
    return {
      agents: [],
    }
  },
  watch: {

  },
  mounted() {
    this.getAgents();
  },
  methods: {
    getAgents() {
      AgentInterface.getAll().then(json => {this.agents = json.data});
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
  align-items: center;
  /* border: 2px solid var(--gray); */
}
</style>