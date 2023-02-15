<template>
  <div class="coach-container">
      <div v-if="coach.id" class="coach-item">
        <TextGray fontSize="var(--middle-text)">
          {{ coach.surname }}
        </TextGray>
        <TextPink fontSize="var(--middle-text)">
          {{ coach.country }}
        </TextPink>
        <TextGray fontSize="var(--middle-text)">
          {{ coach.workExperience }}
        </TextGray>
        <RedButton v-on:click="deleteCoach">
          Delete
        </RedButton>
      </div>
      <div v-else class="coach-item">
        <TextGray fontSize="var(--middle-text)">
          Сoach is absent
        </TextGray>
        <GreenButton v-on:click="addCoach">
          Add
        </GreenButton>
      </div>
  </div>
</template>

<script lang="ts">
import { computed, defineComponent } from 'vue'
import SquadInterface from '@/Interfaces/SquadInterface'
import GreenButton from "@/components/Buttons/GreenButton.vue"
import RedButton from "@/components/Buttons/RedButton.vue"
import TextGray from "@/components/Text/TextGray.vue"
import TextPink from "@/components/Text/TextPink.vue"
import auth from '@/authentificationService'
import router from "@/router"

export default defineComponent({
  name: "CoachItem",
  components: {
    GreenButton,
    RedButton,
    TextGray,
    TextPink,
  },
  props: {

  },
  data() {
    return {
      coach: {
        id: 0,
        surname: '',
        country: '',
        workExperience: 0
      },
    }
  },
  async mounted() {
    this.getCoach();
  },
  methods: {
    getCoach() {
      SquadInterface.getCoach(auth.getCurrentUser().id).then(json => {this.coach = json.data});
    },
    addCoach: function() {
      SquadInterface.addCoachToSquad(auth.getCurrentUser().id, this.coach.id);
      router.push("/coaches");
    },
    deleteCoach: function() {
      SquadInterface.deleteCoachFromSquad(auth.getCurrentUser().id, this.coach.id);
      router.push("/coaches");
    },
  },
})
</script>

<style scoped>
.coach-container {
  padding-bottom: 50px;
  display: grid;
  grid-template-columns: 1fr 1fr 1fr;
  gap: 50px;
  width: 80%;
  height: 100%;
  align-items: center;
  text-align: center;
  /* border: 2px solid var(--white); */
}
.coach-item {
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  grid-column: 2;
  border: 2px solid var(--white);
  background-color: var(--white); 
  box-shadow: 0px 0px 10px var(--white);
  border-radius: 20px 20px 20px 20px;
  padding: 15px;
  gap: 10px;
}
</style>