<template>
  <RowTitle class="user-title-row">
    <TextPink fontSize="var(--middle-text)">
      ID
    </TextPink>
    <TextPink fontSize="var(--middle-text)">
      LOGIN
    </TextPink>
    <TextPink fontSize="var(--middle-text)">
      RATING SQUAD
    </TextPink>
    <TextPink fontSize="var(--middle-text)">
      PERMISSION
    </TextPink>
  </RowTitle> 
</template>

<script lang="ts">
import { computed, defineComponent } from 'vue'
import RowTitle from "@/components/Tables/RowTitle.vue"
import TextPink from "@/components/Text/TextPink.vue"

export default defineComponent({
  name: "UsersRowTitle",
  components: {
    RowTitle,
    TextPink,
  },
})
</script>

<style scoped>
.user-title-row {
  padding: 10px;
  display: grid;
  grid-template-columns: 1.5fr 2fr 2fr 2fr;
  column-gap: 50px;
  width: 100%;
}
</style>