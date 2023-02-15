<template>
  <body class="select-container">
    <SelectionBlock>
      football player
    </SelectionBlock>
    <form class="form-column" @submit.prevent="onSubmit">
      <InputRow @surname="setSurname" name="select" fontSize="var(--middle-text)" defaultText="Surname"/>
      <InputRow @country="setCountry" name="select" fontSize="var(--middle-text)" defaultText="Country"/>
      <InputRow @clubName="setClubName" name="select" fontSize="var(--middle-text)" defaultText="Club name"/>
      <div class="form-row">
        <InputRow @surname="setSurname" name="select" class="item-row" fontSize="var(--middle-text)" defaultText="Minimal rating"/>
        <InputRow @surname="setSurname" name="select" class="item-row" fontSize="var(--middle-text)" defaultText="Maximal rating"/>
      </div>
      <InputButton>
        Find Players
      </InputButton>
    </form>
  </body>
</template>

<script lang="ts">
import { computed, defineComponent } from "vue";
import SelectionBlock from "@/components/Selection/SelectionBlock.vue"
import InputButton from "@/components/Buttons/InputButton.vue"
import InputRow from "@/components/Input/InputRow.vue"

export default defineComponent({
  name: "SelectionPlayer",
  components: {
    SelectionBlock,
    InputRow,
    InputButton,
  },
  data () {
    return {
      surname: '',
      country: '',
      clubName: '',
      minRating: 0,
      maxRating: 99,
    }
  },
  props: {
    fontSize: String,
  },
  methods: {
    setSurname(surname : string) {
      this.surname = surname;
    },
    setCountry(country : string) {
      this.country = country;
    },
    setClubName(clubName : string) {
      this.clubName = clubName;
    },
    setMinRating(minRating : number) {
      this.minRating = minRating;
    },
    setMaxRating(maxRating : number) {
      this.maxRating = maxRating;
    },
  }
});
</script>

<style scoped>
.select-container {
  display: flex;
  flex-direction: column;
  width: 45%;
  height: 100%;
  align-items: center;
  /* border: 2px solid var(--white); */
  gap: 40px;
  justify-content: center;
}
.form-column {
  display: flex;
  flex-direction: column;
  text-align: center;
  gap: 5px;
  width: 100%;
}
.form-row {
  display: flex;
  flex-direction: row;
  gap: 5px;
  justify-content: center;
}
.item-row {
  width: 50%;
}
</style>
