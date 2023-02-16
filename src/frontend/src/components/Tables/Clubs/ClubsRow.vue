<template>
  <Row class="club-row">
    <TextGray fontSize="var(--middle-text)">
      {{ club.id }}
    </TextGray>
    <TextGray fontSize="var(--middle-text)">
      {{ club.name }}
    </TextGray>
    <TextGray fontSize="var(--middle-text)">
      {{ club.country }}
    </TextGray>
    <TextGray fontSize="var(--middle-text)">
      {{ club.foundationDate }}
    </TextGray>
    <BlueButton v-on:click="viewPlayers">
      View Players
    </BlueButton>
  </Row> 
</template>

<script lang="ts">
import { computed, defineComponent } from 'vue'
import Row from "@/components/Tables/Row.vue"
import TextGray from "@/components/Text/TextGray.vue"
import BlueButton from "@/components/Buttons/BlueButton.vue"
import router from "@/router";

export default defineComponent({
  name: "ClubsRow",
  components: {
    Row,
    TextGray,
    BlueButton,
  },
  props: {
    club: {
      type: Object,
      required: true
    },
  },
  methods: {
    viewPlayers() {
      router.push({name: 'players', params: { ClubName: this.club.name } })
    },
  },
})
</script>

<style scoped>
.club-row {
  padding: 10px;
  display: grid;
  grid-template-columns: 1fr 3fr 3fr 3fr 3fr;
  column-gap: 50px;
  width: 100%;
}
</style>