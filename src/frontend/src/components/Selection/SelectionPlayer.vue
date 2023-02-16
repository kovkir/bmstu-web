<template>
  <body class="select-container">
    <SelectionBlock>
      football player
    </SelectionBlock>
    <form class="form-column" @submit.prevent="onSubmit">
      <InputRow @surname="setSurname" name="surname" fontSize="var(--middle-text)" defaultText="Surname"/>
      <InputRow @country="setCountry" name="country" fontSize="var(--middle-text)" defaultText="Country"/>
      <InputRow @clubName="setClubName" name="clubName" fontSize="var(--middle-text)" defaultText="Club name"/>
      <div class="form-row">
        <InputRow @minPrice="setMinPrice" name="minPrice" class="item-row" fontSize="var(--middle-text)" defaultText="Minimal price"/>
        <InputRow @maxPrice="setMaxPrice" name="maxPrice" class="item-row" fontSize="var(--middle-text)" defaultText="Maximal price"/>
      </div>
      <div class="form-row">
        <InputRow @minRating="setMinRating" name="minRating" class="item-row" fontSize="var(--middle-text)" defaultText="Minimal rating"/>
        <InputRow @maxRating="setMaxRating" name="maxRating" class="item-row" fontSize="var(--middle-text)" defaultText="Maximal rating"/>
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
import router from "@/router";

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
      minPrice: 0,
      maxPrice: 1000000,
      minRating: 0,
      maxRating: 100,
    }
  },
  props: {
    fontSize: String,
  },
  methods: {
    async onSubmit() {
      if (this.minPrice > this.maxPrice) {
        this.$notify({
          title: "Error",
          text: "MinPrice should be smaller than MaxPrice",
        });
        return;
      }
      if (this.minRating > this.maxRating) {
        this.$notify({
          title: "Error",
          text: "MinRating should be smaller than MaxRating",
        });
        return;
      }

      console.log("Selection:", this.surname, this.country, this.clubName, this.minPrice, this.maxPrice, this.minRating, this.maxRating);
      router.push({name: 'players', 
        params: {
          ClubName: this.clubName,
          Surname: this.surname,
          Country: this.country,
          MinPrice: this.minPrice,
          MaxPrice: this.maxPrice,
          MinRating: this.minRating,
          MaxRating: this.maxRating
        }
      })
    },
    setSurname(surname : string) {
      this.surname = surname;
      console.log("setSurname", this.surname);
    },
    setCountry(country : string) {
      this.country = country;
    },
    setClubName(clubName : string) {
      this.clubName = clubName;
    },
    setMinPrice(minPrice : number) {
      this.minPrice = minPrice;
    },
    setMaxPrice(maxPrice : number) {
      this.maxPrice = maxPrice;
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
