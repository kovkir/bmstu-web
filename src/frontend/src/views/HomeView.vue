<template>
  <NavBarView>
    <TextBlock>
      football player
    </TextBlock>
  </NavBarView>
</template>

<script lang="ts">
import { defineComponent } from "vue";
import NavBarView from "@/views/NavBarView.vue"
import TextBlock from "@/components/TextBlock/TextBlock.vue"

export default defineComponent({
  name: "HomeView",
  components: {
    NavBarView,
    TextBlock,
  },
  data() {
    // return {
    //   serverName: '',
    //   gameName: '',
    //   platformId: 0
    // }
  },
  computed: {
    
  },
  methods: {
    
  },
});

</script>

<style scoped>
.container {
  display: flex;
  flex-direction: column;
  margin: 0;
  width: 100%;
  height: 100%;
  justify-content: center;
  align-items: center;
  gap: 10px;
}
</style>