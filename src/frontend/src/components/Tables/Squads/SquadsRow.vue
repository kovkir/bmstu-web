<template>
  <Row class="squad-row">
    <TextGray fontSize="var(--middle-text)">
      {{ squad.id }}
    </TextGray>
    <TextGray fontSize="var(--middle-text)">
      {{ squad.name }}
    </TextGray>
    <TextGray fontSize="var(--middle-text)">
      {{ coachSurname }}
    </TextGray>
    <TextGray fontSize="var(--middle-text)">
      {{ squad.rating }}
    </TextGray>
  </Row> 
</template>

<script lang="ts">
import { computed, defineComponent } from 'vue'
import Row from "@/components/Tables/Row.vue"
import TextGray from "@/components/Text/TextGray.vue"
import CoachInterface from "@/Interfaces/CoachInterface"

export default defineComponent({
  name: "SquadsRow",
  components: {
    Row,
    TextGray,
  },
  props: {
    squad: {
      type: Object,
      required: true
    },
  },
  data() {
    return {
      coachSurname: '',
    }
  },
  mounted() {
    CoachInterface.getById(this.squad.coachId).then(json => {this.coachSurname = json.data.surname});
  },
})
</script>

<style scoped> 
.squad-row {
  padding: 10px;
  display: grid;
  grid-template-columns: 1fr 3fr 3fr 3fr;
  column-gap: 50px;
  width: 100%;
}
</style>