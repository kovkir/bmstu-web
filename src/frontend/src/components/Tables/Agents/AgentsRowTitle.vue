<template>
  <RowTitle class="agent-title-row">
    <TextPink class="item" fontSize="var(--middle-text)">
      ID
    </TextPink>
    <TextPink class="item" fontSize="var(--middle-text)">
      SURNAME
    </TextPink>
    <TextPink class="item" fontSize="var(--middle-text)">
      FOOTBALLER
    </TextPink>
    <TextPink class="item" fontSize="var(--middle-text)">
      COUNTRY
    </TextPink>
  </RowTitle> 
</template>

<script lang="ts">
import { computed, defineComponent } from 'vue'
import RowTitle from "@/components/Tables/RowTitle.vue"
import TextPink from "@/components/Text/TextPink.vue"
// import ServerMenu from "@/components/Servers/ServerMenu.vue"

// import { stringLiteral } from '@babel/types'

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
.item:nth-child(1) {
  grid-column: 1;
  grid-row: 1;
}
.item:nth-child(2) {
  grid-column: 2;
  grid-row: 1;
}
.item:nth-child(3) {
  grid-column: 3;
  grid-row: 1;
}
.item:nth-child(4) {
  grid-column: 4;
  grid-row: 1;
}
</style>