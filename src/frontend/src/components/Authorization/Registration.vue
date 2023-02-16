<template>
  <body class="container">
    <body class="registration-container">
      <form class="form-column" @submit.prevent="onSubmit">
          <TextGray fontSize="var(--large-text)" fontColor>
            Registration
          </TextGray>
          <InputRow @login="setLogin" name="login" fontSize="var(--middle-text)" defaultText="Login*"/>
          <InputRow @password="setPassword" name="password" fontSize="var(--middle-text)" defaultText="Password*"/>
          <InputRow @passwordConfirm="setPasswordConfirm" name="passwordConfirm" fontSize="var(--middle-text)" defaultText="Password Confirm*"/>
          <InputButton>
            Sign Up
          </InputButton>
          <div class="form-row">
            <TextGray fontSize="var(--little-text)">
              Already have an account?
            </TextGray>
            <TextPink fontSize="var(--little-text)">
              <router-link style="color: var(--pink)" to="/authorization">Log In now</router-link>
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
  name: "Registration",
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
      passwordConfirm: '',
    }
  },
  methods: {
    async onSubmit() {
      console.log("Registration:", this.login, this.password, this.passwordConfirm);

      if (this.login == '' || this.password == '' || this.passwordConfirm == '') {
        this.$notify({
          title: "Error",
          text: "Data is Required",
        });
        return;
      }

      if (this.password != this.passwordConfirm) {
        this.$notify({
          title: "Error",
          text: "Passwords are Different",
        });
        return;
      }

      const result = await auth.register(this.login, this.password);

      if (result) {
        await auth.login(this.login, this.password);
        router.push("/");
      }
      else {
        console.log("Incorrect Data")

        this.$notify({
          title: "Error",
          text: "Login is currently Used",
        });
      }
    },
    setLogin(login : string) {
      this.login = login;
    },
    setPassword(password : string) {
      this.password = password;
    },
    setPasswordConfirm(passwordConfirm : string) {
      this.passwordConfirm = passwordConfirm;
    },
  }
})
</script>

<style scoped>
.registration-container {
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