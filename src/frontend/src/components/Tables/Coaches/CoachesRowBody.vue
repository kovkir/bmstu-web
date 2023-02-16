<template>
  <TextGray fontSize="var(--middle-text)">
    {{ coach.id }}
  </TextGray>
  <TextGray fontSize="var(--middle-text)">
    {{ coach.surname }}
  </TextGray>
  <TextGray fontSize="var(--middle-text)">
    {{ coach.country }}
  </TextGray>
  <TextGray fontSize="var(--middle-text)">
    {{ coach.workExperience }}
  </TextGray>
  <TextGray  v-if="isInRole != 'guest'" fontSize="var(--little-text)">
    <div v-if="isMyCoach">
      <RedButton v-on:click="deleteCoach">
        Delete
      </RedButton>
    </div>
    <div v-else>
      <GreenButton v-on:click="addCoach">
        Add
      </GreenButton>
    </div>
  </TextGray>
</template>

<script lang="ts">
import { computed, defineComponent } from 'vue'
import TextGray from "@/components/Text/TextGray.vue"
import GreenButton from "@/components/Buttons/GreenButton.vue"
import RedButton from "@/components/Buttons/RedButton.vue"
import SquadInterface from "@/Interfaces/SquadInterface"
import auth from '@/authentificationService'
import router from "@/router";

export default defineComponent({
  name: "CoachesRowBody",
  components: {
    TextGray,
    GreenButton,
    RedButton,
  },
  props: {
    coach: {
      type: Object,
      required: true
    },
  },
  data() {
    return {
      isMyCoach: false,
    }
  },
  computed: {
    isInRole () {
      return auth.getCurrentUser().permission;
    },
  },
  async mounted() {
    this.isMyCoach = await SquadInterface.isCoachInSquad(auth.getCurrentUser().id, this.coach.id);
  },
  methods: {
    addCoach: function() {
      SquadInterface.addCoachToSquad(auth.getCurrentUser().id, this.coach.id);
      router.push("/mysquad");
    },
    deleteCoach: function() {
      SquadInterface.deleteCoachFromSquad(auth.getCurrentUser().id, this.coach.id);
      router.push("/mysquad");
    },
  },
})
</script>

<style scoped>
</style>