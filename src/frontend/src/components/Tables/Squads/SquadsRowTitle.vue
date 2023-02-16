<template>
  <RowTitle class="squad-title-row">
    <TextPink fontSize="var(--middle-text)">
      ID
    </TextPink>
    <TextPink fontSize="var(--middle-text)">
      NAME
    </TextPink>
    <TextPink fontSize="var(--middle-text)">
      COACH SURNAME
    </TextPink>
    <TextPink fontSize="var(--middle-text)">
      RATING
    </TextPink>
  </RowTitle> 
</template>

<script lang="ts">
import { computed, defineComponent } from 'vue'
import RowTitle from "@/components/Tables/RowTitle.vue"
import TextPink from "@/components/Text/TextPink.vue"

export default defineComponent({
  name: "SquadsRowTitle",
  components: {
    RowTitle,
    TextPink,
  },
})
</script>

<style scoped>
.squad-title-row {
  padding: 10px;
  display: grid;
  grid-template-columns: 1fr 3fr 3fr 3fr;
  column-gap: 50px;
  width: 100%;
}
</style>