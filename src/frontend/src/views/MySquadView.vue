<template>
  <NavBarView>
    <div class="container">
      <TextWhite fontSize="var(--large-text)">
        THE PLAYERS OF MY SQUAD
      </TextWhite>
      <PlayersList />
      <TextWhite fontSize="var(--large-text)">
        THE HEAD COACH OF MY SQUAD
      </TextWhite>
      <CoachItem />
    </div>
  </NavBarView>
</template>

<script lang="ts">
import { defineComponent } from "vue";
import NavBarView from "@/views/NavBarView.vue"
import CoachItem from "@/components/MySquad/CoachItem.vue"
import PlayersList from "@/components/MySquad/PlayersList.vue"
import TextWhite from "@/components/Text/TextWhite.vue"

export default defineComponent({
  name: "MySquadView",
  components: {
    NavBarView,
    PlayersList,
    CoachItem,
    TextWhite,
  },
  data() {

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
  justify-content: top;
  align-items: center;
  padding-top: 3%;
  gap: 20px;
}
</style>