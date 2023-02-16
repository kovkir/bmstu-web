<template>
  <div class="container">
    <SquadsRowTitle />
    <SquadsRow
      v-for="squad in squads"
      v-bind:squad="squad">
    </SquadsRow>
  </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue'
import SquadsRow from "@/components/Tables/Squads/SquadsRow.vue"
import SquadsRowTitle from "@/components/Tables/Squads/SquadsRowTitle.vue"
import SquadInterface from '@/Interfaces/SquadInterface'

export default defineComponent({
  name: "SquadsTable",
  components: {
    SquadsRow,
    SquadsRowTitle
  },
  data() {
    return {
      squads: [],
    }
  },
  mounted() {
    this.getSquads();
  },
  methods: {
    getSquads() {
      SquadInterface.getAll().then(json => {this.squads = json.data});
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