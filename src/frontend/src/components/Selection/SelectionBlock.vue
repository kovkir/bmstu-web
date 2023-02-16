<template>
  <div class="selection-block">
    <TextWhite fontSize="var(--large-text)">
      Selection of
    </TextWhite>
    <GrayTextBlock fontSize="var(--middle-text)">
      <slot></slot>
    </GrayTextBlock>
  </div>
</template>

<script lang="ts">
import { computed, defineComponent } from "vue";
import GrayTextBlock from "@/components/Selection/GrayTextBlock.vue"
import TextWhite from "@/components/Text/TextWhite.vue"
import { slotFlagsText } from "@vue/shared";

export default defineComponent({
  name: "SelectionBlock",
  components: {
    GrayTextBlock,
    slotFlagsText,
    TextWhite
},
  props: {
    fontSize: String,
  },
});
</script>

<style scoped>
.selection-block {
  background: var(--pink);
  box-shadow: 0px 0px 20px var(--pink);
  border-radius: 20px 20px 20px 20px;
  border: 1px solid var(--pink);
  padding-left: 20px;
  padding-right: 10px;
  padding-top: 10px;
  padding-bottom: 10px;
  color: var(--gray);

  display: grid;
  grid-template-columns: 1fr 1.2fr;
  /* column-gap: 50px; */
  width: 100%;
}
</style>
