<template>
  <input v-model="data" v-if="name == 'password'" type="password" class="input-line" :style="{fontSize}" :placeholder="defaultText">
  <input v-model="data" v-else-if="name == 'select'" class="select-input-line" :style="{fontSize}" :placeholder="defaultText">
  <input v-model="data" v-else class="input-line" :style="{fontSize}" :placeholder="defaultText">
</template>

<script lang="ts">
import { computed, defineComponent } from "vue";

export default defineComponent({
  name: "InputRow",
  data () {
    return {
      data: "",
    }
  },
  components: {},
  props: ['name', 'fontSize', 'defaultText'],
  watch: { 
    data: function() {
      console.log(this.name, this.data);
      this.$emit(this.name, this.data);
    }
  },
});
</script>

<style scoped>
.input-line {
  background: var(--white);
  box-shadow: 0px 0px 20px var(--white);
  border-radius: 20px 20px 20px 20px;
  border: 1px solid var(--gray);
  padding-left: 20px;
  padding-right: 20px;
  padding-top: 15px;
  padding-bottom: 15px;
  color: var(--gray);
}
.select-input-line {
  background: var(--white);
  box-shadow: 0px 0px 20px var(--white);
  border-radius: 20px 20px 20px 20px;
  border: 1px solid var(--white);
  padding-left: 20px;
  padding-right: 20px;
  padding-top: 15px;
  padding-bottom: 15px;
  color: var(--gray);
}
</style>
