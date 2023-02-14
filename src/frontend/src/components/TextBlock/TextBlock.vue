<template>
  <div class="text-block" fontSize="var(--middle-text)">
    <GrayTextBlock>
      <slot></slot>
    </GrayTextBlock>
  </div>
</template>

<script lang="ts">
import { computed, defineComponent } from "vue";
import GrayTextBlock from "@/components/TextBlock/GrayTextBlock.vue"
import { slotFlagsText } from "@vue/shared";

export default defineComponent({
  name: "TextBlock",
  components: {
    GrayTextBlock,
    slotFlagsText
},
  props: {
    fontSize: String,
  },
});
</script>

<style scoped>
.text-block {
  background: var(--pink);
  box-shadow: 0px 0px 20px var(--pink);
  border-radius: 20px 20px 20px 20px;
  border: 1px solid var(--pink);
  padding-left: 20px;
  padding-right: 20px;
  padding-top: 10px;
  padding-bottom: 10px;
  color: var(--gray);
}
</style>
