<template>
  <RowTitle class="club-title-row">
    <TextPink fontSize="var(--middle-text)">
      ID
    </TextPink>
    <TextPink fontSize="var(--middle-text)">
      NAME
    </TextPink>
    <TextPink fontSize="var(--middle-text)">
      COUNTRY
    </TextPink>
    <TextPink fontSize="var(--middle-text)">
      FOUNDATION DATE
    </TextPink>
    <TextPink fontSize="var(--middle-text)">
      PLAYERS
    </TextPink>
  </RowTitle> 
</template>

<script lang="ts">
import { computed, defineComponent } from 'vue'
import RowTitle from "@/components/Tables/RowTitle.vue"
import TextPink from "@/components/Text/TextPink.vue"

export default defineComponent({
  name: "ClubsRowTitle",
  components: {
    RowTitle,
    TextPink,
  },
})
</script>

<style scoped>
.club-title-row {
  padding: 10px;
  display: grid;
  grid-template-columns: 1fr 3fr 3fr 3fr 3fr;
  column-gap: 50px;
  width: 100%;
}
</style>