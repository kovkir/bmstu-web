<template>
  <RowTitle class="agent-title-row">
    <TextPink fontSize="var(--middle-text)">
      ID
    </TextPink>
    <TextPink fontSize="var(--middle-text)">
      SURNAME
    </TextPink>
    <TextPink fontSize="var(--middle-text)">
      FOOTBALLER
    </TextPink>
    <TextPink fontSize="var(--middle-text)">
      COUNTRY
    </TextPink>
  </RowTitle> 
</template>

<script lang="ts">
import { computed, defineComponent } from 'vue'
import RowTitle from "@/components/Tables/RowTitle.vue"
import TextPink from "@/components/Text/TextPink.vue"

export default defineComponent({
  name: "AgentsRowTitle",
  components: {
    RowTitle,
    TextPink,
  },
})
</script>

<style scoped>
.agent-title-row {
  padding: 10px;
  display: grid;
  grid-template-columns: 1fr 3fr 3fr 3fr;
  column-gap: 50px;
  width: 100%;
}
</style>