<template>
  <form class="form__container" @submit.prevent>
    <div class="input__field">
      <ion-label position="floating">Employee Name</ion-label>
      <ion-input
        type="text"
        required
        v-model="name"
        :maxlength="30"
      ></ion-input>
    </div>
    <div class="input__field">
      <ion-label position="floating">Phone No</ion-label>
      <ion-input
        type="tel"
        required
        v-model="phoneNo"
        :maxlength="20"
      ></ion-input>
    </div>
    <div class="input__field">
      <ion-label position="floating">Email</ion-label>
      <ion-input
        type="email"
        required
        v-model="email"
        :maxlength="30"
      ></ion-input>
    </div>
    <div class="input__field">
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
    </div>
    <div class="input__field">
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
    </div>
    <div class="input__field">
      <ion-label position="floating">Salary (RM)</ion-label>
      <ion-input
        type="number"
        inputmode="numeric"
        required
        v-model="salary"
        :maxlength="16"
        :pattern="/^[+]?[0-9]{8,}?[\b]*$/"
      ></ion-input>
    </div>
    <div class="input__field">
      <ion-label position="floating">Photo Filename/URL</ion-label>
      <ion-input
        type="text"
        required
        v-model="photo"
        :maxlength="100"
      ></ion-input>
    </div>
    <div class="input__field">
      <ion-label position="floating">Remarks</ion-label>
      <ion-textarea
        placeholder="Enter employee remarks..."
        v-model="remarks"
        :maxlength="1000"
        :rows="5"
        spellcheck
      ></ion-textarea>
    </div>
    <ion-button expand="block" :disabled="buttonDisabled"
      >Add Employee</ion-button
    >
  </form>
</template>

<script>
import {
  IonInput,
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
        !this.email ||
        !this.gender ||
        !this.positionCode ||
        !this.photo ||
        !this.phoneNo ||
        this.emailError ||
        this.phoneError ||
        this.salaryError
      )
        return true;
      return false;
    },
  },
  watch: {
    email(newVal) {
      this.emailError = !this.email || !validateEmail(newVal);
    },
    phoneNo(newVal) {
      this.phoneError = !this.phoneNo || !validatePhone(newVal);
    },
    salary(newVal) {
      if (newVal < 0) {
        this.salary = 0;
      } else {
        this.salary = Number(newVal);
      }
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

ion-input,
ion-textarea {
  padding: 8px;
  border: 1px solid var(--ion-color-primary);
  margin: 4px 0;
  border-radius: 4px;
  color: var(--ion-color-step-250);
}

ion-input {
  height: 36px;
}

ion-label {
  font-weight: 600;
  color: var(--ion-color-step-250);
  margin-bottom: 8px;
}

.error {
  border: 1px solid var(--ion-color-danger) !important;
}

/* Popover Interface: set color for the popover using Item's CSS variables */
.styled_select .select-interface-option {
  --color: #333;
  --color-hover: #333;
}
</style>
