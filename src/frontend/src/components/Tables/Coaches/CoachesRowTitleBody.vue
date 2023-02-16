<template>
  <TextPink fontSize="var(--middle-text)">
    ID
  </TextPink>
  <TextPink fontSize="var(--middle-text)">
    SURNAME
  </TextPink>
  <TextPink fontSize="var(--middle-text)">
    COUNTRY
  </TextPink>
  <TextPink fontSize="var(--middle-text)">
    WORK EXPERIENCE
  </TextPink>
  <TextPink  v-if="isInRole != 'guest'" fontSize="var(--middle-text)">
    SQUAD
  </TextPink>
</template>

<script lang="ts">
import { computed, defineComponent } from 'vue'
import TextPink from "@/components/Text/TextPink.vue"
import auth from '@/authentificationService'

export default defineComponent({
  name: "CoachesRowTitleBody",
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