<template>
  <Row class="user-row">
    <TextGray fontSize="var(--middle-text)">
      {{ user.id }}
    </TextGray>
    <TextGray fontSize="var(--middle-text)">
      {{ user.login }}
    </TextGray>
    <TextGray fontSize="var(--middle-text)">
      {{ squadRating }}
    </TextGray>
    <div v-if="user.id == currentUserId">
      <RedNotActiveButton>
        Make User
      </RedNotActiveButton>
    </div>
    <div v-else-if="user.permission == 'admin'">
      <RedButton v-on:click="makeUser">
        Make User
      </RedButton>
    </div>
    <div v-else>
      <BlueButton v-on:click="makeAdmin">
        Make Admin
      </BlueButton>
    </div>
  </Row> 
</template>

<script lang="ts">
import { computed, defineComponent } from 'vue'
import Row from "@/components/Tables/Row.vue"
import TextGray from "@/components/Text/TextGray.vue"
import BlueButton from "@/components/Buttons/BlueButton.vue"
import RedButton from "@/components/Buttons/RedButton.vue"
import RedNotActiveButton from "@/components/Buttons/RedNotActiveButton.vue"
import SquadInterface from "@/Interfaces/SquadInterface"
import UserInterface from "@/Interfaces/UserInterface"
import auth from '@/authentificationService'
import router from "@/router";

export default defineComponent({
  name: "UsersRow",
  components: {
    Row,
    TextGray,
    BlueButton,
    RedButton,
    RedNotActiveButton
  },
  props: {
    user: {
      type: Object,
      required: true
    },
  },
  data() {
    return {
      squadRating: '',
    }
  },
  computed: {
    currentUserId () {
      return auth.getCurrentUser().id;
    },
  },
  mounted() {
    SquadInterface.getById(this.user.id).then(json => {this.squadRating = json.data.rating});
  },
  methods: {
    makeUser: function() {
      UserInterface.changePermission(this.user.id, "user");
      router.push("/users");
    },
    makeAdmin: function() {
      UserInterface.changePermission(this.user.id, "admin");
      router.push("/users");
    },
  },
})
</script>

<style scoped>
.user-row {
  padding: 10px;
  display: grid;
  grid-template-columns: 1.5fr 2fr 2fr 2fr;
  column-gap: 50px;
  width: 100%;
}
</style>