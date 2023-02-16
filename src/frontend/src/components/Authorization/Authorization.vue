<template>
  <body class="container">
    <body class="authorization-container">
      <form class="form-column" @submit.prevent="onSubmit">
          <TextGray fontSize="var(--large-text)" fontColor>
            Authorization
          </TextGray>
          <InputRow @login="setLogin" name="login" fontSize="var(--middle-text)" defaultText="Login*"/>
          <InputRow @password="setPassword" name="password" fontSize="var(--middle-text)" defaultText="Password*"/>
          <InputButton>
            Log In
          </InputButton>
          <div class="form-row">
            <TextGray fontSize="var(--little-text)">
                Don't have an account?
            </TextGray>
            <TextPink fontSize="var(--little-text)">
              <router-link style="color: var(--pink)" to="/registration">Sign Up now</router-link>
            </TextPink>
          </div>
      </form>
    </body>
  </body>
</template>

<script lang="ts">
import { defineComponent } from 'vue'
import InputRow from '@/components/Input/InputRow.vue'
import TextGray from "@/components/Text/TextGray.vue"
import TextPink from "@/components/Text/TextPink.vue"
import InputButton from "@/components/Buttons/InputButton.vue"

import auth from "@/authentificationService";
import router from "@/router";

export default defineComponent({
  name: "Authorization",
  components: {
    InputRow,
    TextGray,
    TextPink,
    InputButton,
  },
  data () {
    return {
      login: '',
      password: '',
    }
  },
  methods: {
    async onSubmit() {
      console.log("Authorization:", this.login, this.password);

      if (this.login == '' || this.password == '') {
        this.$notify({
          title: "Error",
          text: "Login and Password are Required",
        });
        return;
      }

      const result = await auth.login(this.login, this.password);

      if (result) {
        console.log("You are logged in")
        router.push("/");
      }
      else {
        console.log("Incorrect Data")

        this.$notify({
          title: "Error",
          text: "Login Or Password is Incorrect",
        });
      }
    },
    setLogin(login : string) {
      this.login = login;
    },
    setPassword(password : string) {
      this.password = password;
    },
  }
})
</script>

<style scoped>
.authorization-container {
  background: var(--white);
  box-shadow: 0px 0px 20px var(--white);
  border-radius: 20px 20px 20px 20px;
  padding-left: 2%;
  padding-right: 2%;
  padding-top: 1%;
  padding-bottom: 1%; 
  color: var(--gray);
  width: 35%;
}
.form-column {
  display: flex;
  flex-direction: column;
  text-align: center;
  gap: 10px;
}
.form-row {
  display: flex;
  flex-direction: row;
  gap: 10px;
  justify-content: center;
}
</style>