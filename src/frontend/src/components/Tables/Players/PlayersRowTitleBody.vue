<template>
  <TextPink fontSize="var(--middle-text)">
    ID
  </TextPink>
  <TextPink fontSize="var(--middle-text)">
    SURNAME
  </TextPink>
  <TextPink fontSize="var(--middle-text)">
    RATING
  </TextPink>
  <TextPink fontSize="var(--middle-text)">
    COUNTRY
  </TextPink>
  <TextPink fontSize="var(--middle-text)">
    CLUB
  </TextPink>
  <TextPink fontSize="var(--middle-text)">
    PRICE
  </TextPink>
  <TextPink  v-if="isInRole != 'guest'" fontSize="var(--middle-text)">
    MY SQUAD
  </TextPink>
</template>

<script lang="ts">
import { computed, defineComponent } from 'vue'
import TextPink from "@/components/Text/TextPink.vue"
import auth from '@/authentificationService'

export default defineComponent({
  name: "PlayersRowTitleBody",
  components: {
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
</style>