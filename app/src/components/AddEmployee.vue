<template>
  <form class="form__container" @submit.prevent>
    <ion-item class="input__field">
      <ion-label position="floating">Employee Name</ion-label>
      <ion-input type="text" required v-model="name"></ion-input>
    </ion-item>
    <ion-item class="input__field">
      <ion-label position="floating">Phone No</ion-label>
      <ion-input type="phone" required v-model="phoneNo"></ion-input>
    </ion-item>
    <ion-item class="input__field">
      <ion-label position="floating">Email</ion-label>
      <ion-input type="email" required v-model="email"></ion-input>
    </ion-item>
    <ion-item class="input__field">
      <ion-label>Gender</ion-label>
      <ion-select
        placeholder="Select One"
        v-model="gender"
        interface="popover"
        :interface-options="options"
      >
        <ion-select-option value="F">Female</ion-select-option>
        <ion-select-option value="M">Male</ion-select-option>
      </ion-select>
    </ion-item>
    <ion-item class="input__field">
      <ion-label>Position</ion-label>
      <ion-select
        placeholder="Select One"
        v-model="positionCode"
        interface="popover"
        :interface-options="options"
      >
        <ion-select-option value="A">Senior Manager</ion-select-option>
        <ion-select-option value="B">Manager</ion-select-option>
        <ion-select-option value="C">Engineer</ion-select-option>
        <ion-select-option value="D">Designer</ion-select-option>
        <ion-select-option value="E">CEO</ion-select-option>
        <ion-select-option value="F">COO</ion-select-option>
        <ion-select-option value="G">CTO</ion-select-option>
        <ion-select-option value="H">CMO</ion-select-option>
      </ion-select>
    </ion-item>
    <ion-item class="input__field">
      <ion-label position="floating">Salary (RM)</ion-label>
      <ion-input type="number" required v-model="salary"></ion-input>
    </ion-item>
    <ion-item class="input__field">
      <ion-label position="floating">Image URL</ion-label>
      <ion-input type="text" required v-model="photo"></ion-input>
    </ion-item>
    <ion-item class="input__field">
      <ion-label position="floating">Remarks</ion-label>
      <ion-textarea
        placeholder="Enter employee remarks..."
        v-model="remarks"
      ></ion-textarea>
    </ion-item>
    <ion-button expand="block" :disabled="buttonDisabled"
      >Add Employee</ion-button
    >
  </form>
</template>

<script>
import {
  IonInput,
  IonItem,
  IonLabel,
  IonTextarea,
  IonButton,
  IonSelectOption,
  IonSelect,
} from "@ionic/vue";
import { validateEmail, validatePhone } from "../utils/validation";

export default {
  components: {
    IonInput,
    IonItem,
    IonLabel,
    IonTextarea,
    IonButton,
    IonSelectOption,
    IonSelect,
  },
  name: "AddEmployee",
  data() {
    return {
      name: "",
      email: "",
      phoneNo: "",
      gender: "M",
      positionCode: "A",
      salary: 0,
      photo: "",
      remarks: "",
      emailError: false,
      phoneError: false,
      salaryError: false,
      options: {
        cssClass: "styled_select",
      },
    };
  },
  computed: {
    buttonDisabled() {
      if (
        !this.name ||
        this.emailError ||
        this.phoneError ||
        !this.gender ||
        !this.positionCode ||
        this.salaryError ||
        !this.photo
      )
        return true;
      return false;
    },
  },
  watch: {
    email(newVal) {
      this.emailError = !this.email || !validateEmail(newVal);
    },
    phone(newVal) {
      this.phoneError = !this.phone || !validatePhone(newVal);
    },
  },
  methods: {
    createEmployee() {
      console.log("create");
    },
  },
};
</script>

<style scoped>
.form__container {
  display: flex;
  flex-direction: column;
  padding: 8vw;
}

.input__field {
  margin-bottom: 14px;
}

/* Popover Interface: set color for the popover using Item's CSS variables */
.styled_select .select-interface-option {
  --color: #333;
  --color-hover: #333;
}
</style>
