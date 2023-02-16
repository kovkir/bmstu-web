<template>
  <div class="container">
    <UsersRowTitle />
    <UsersRow
      v-for="user in users"
      v-bind:user="user">
    </UsersRow>
  </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue'
import UsersRow from "@/components/Tables/Users/UsersRow.vue"
import UsersRowTitle from "@/components/Tables/Users/UsersRowTitle.vue"
import UserInterface from "@/Interfaces/UserInterface"

export default defineComponent({
  name: "UsersTable",
  components: {
    UsersRow,
    UsersRowTitle
  },
  data() {
    return {
      users: [],
    }
  },
  mounted() {
    this.getUsers();
  },
  methods: {
    getUsers() {
      UserInterface.getAll().then(json => {this.users = json.data});
    },
  },
})
</script>

<style scoped>
.container {
  display: flex;
  flex-direction: column;
  margin: 0;
  width: 90%;
  height: 90%;
  justify-content: top;
  padding-top: 5%;
  align-items: center;
  /* border: 2px solid var(--gray); */
}
</style>