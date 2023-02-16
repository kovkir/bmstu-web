<template>
  <div class="container">
    <ClubsRowTitle />
    <ClubsRow
      v-for="club in clubs"
      v-bind:club="club">
    </ClubsRow>
  </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue'
import ClubsRow from "@/components/Tables/Clubs/ClubsRow.vue"
import ClubsRowTitle from "@/components/Tables/Clubs/ClubsRowTitle.vue"
import ClubInterface from "@/Interfaces/ClubInterface"

export default defineComponent({
  name: "ClubsTable",
  components: {
    ClubsRow,
    ClubsRowTitle
  },
  data() {
    return {
      clubs: [],
    }
  },
  mounted() {
    this.getClubs();
  },
  methods: {
    getClubs() {
      ClubInterface.getAll().then(json => {this.clubs = json.data});
    },
  },
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