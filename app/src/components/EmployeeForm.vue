<template>
  <form class="form__container" @submit.prevent>
    <div class="input__field">
      <ion-label position="floating">Employee Name</ion-label>
      <ion-input
        type="text"
        required
        v-model="employee.name"
        :maxlength="30"
        :class="{ error: nameError }"
      ></ion-input>
      <span class="error__message" v-if="nameError"
        >Please enter a valid name!</span
      >
    </div>
    <div class="input__field">
      <ion-label position="floating">Phone No</ion-label>
      <ion-input
        type="tel"
        required
        v-model="employee.phoneNo"
        :maxlength="20"
        :class="{ error: phoneError }"
      ></ion-input>
      <span class="error__message" v-if="phoneError"
        >Please enter a valid phone number!</span
      >
    </div>
    <div class="input__field">
      <ion-label position="floating">Email</ion-label>
      <ion-input
        type="email"
        required
        v-model="employee.email"
        :maxlength="30"
        :class="{ error: emailError }"
      ></ion-input>
      <span class="error__message" v-if="emailError"
        >Please enter a valid email!</span
      >
    </div>
    <div class="input__field">
      <ion-label>Gender</ion-label>
      <ion-select
        placeholder="Select One"
        v-model="employee.gender"
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
        v-model="employee.positionCode"
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
        v-model="employee.salary"
        :maxlength="16"
        :class="{ error: salaryError }"
      ></ion-input>
      <span class="error__message" v-if="salaryError"
        >Please enter a valid salary!</span
      >
    </div>
    <div class="input__field">
      <ion-label position="floating">Photo Filename/URL</ion-label>
      <ion-input
        type="text"
        required
        v-model="employee.photo"
        :maxlength="100"
        :class="{ error: photoError }"
      ></ion-input>
      <span class="error__message" v-if="photoError"
        >Please enter a valid photo name/URL!</span
      >
    </div>
    <div class="input__field">
      <ion-label position="floating">Remarks</ion-label>
      <ion-textarea
        placeholder="Enter employee remarks..."
        v-model="employee.remarks"
        :maxlength="1000"
        :rows="5"
        spellcheck
      ></ion-textarea>
    </div>
    <ion-button expand="block" :disabled="buttonDisabled" @click="emitClick">{{
      buttonText
    }}</ion-button>
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
  alertController,
} from "@ionic/vue";
import { validateEmail, validatePhone } from "../utils/validation";
import store from "../stores";

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
  props: ["employeeData", "buttonText"],
  emits: [
    "name",
    "email",
    "phoneNo",
    "gender",
    "positionCode",
    "salary",
    "photo",
    "remarks",
    "formSubmit",
  ],
  data() {
    return {
      employee: this.employeeData,
      nameError: false,
      emailError: false,
      phoneError: false,
      salaryError: false,
      photoError: false,
      options: {
        cssClass: "styled_select",
      },
    };
  },
  computed: {
    buttonDisabled() {
      if (
        !this.employee.name ||
        !this.employee.email ||
        !this.employee.gender ||
        !this.employee.positionCode ||
        !this.employee.photo ||
        !this.employee.phoneNo ||
        this.emailError ||
        this.phoneError ||
        this.nameError ||
        this.photoError ||
        this.salaryError
      )
        return true;
      return false;
    },
    employeeStore() {
      return store.state.employeeCreate.employee;
    },
    error() {
      return store.state.employeeCreate.error;
    },
  },
  watch: {
    "employee.name"() {
      this.nameError = !this.employee.name;
      if (!this.nameError) {
        this.$emit("name", this.employee.name);
      }
    },
    "employee.photo"() {
      this.photoError = !this.employee.photo;
      if (!this.photoError) {
        this.$emit("photo", this.employee.photo);
      }
    },
    "employee.email"(newVal) {
      this.emailError = !this.employee.email || !validateEmail(newVal);
      if (!this.emailError) {
        this.$emit("email", this.employee.email);
      }
    },
    "employee.phoneNo"(newVal) {
      this.phoneError = !this.employee.phoneNo || !validatePhone(newVal);
      if (!this.phoneError) {
        this.$emit("phoneNo", this.employee.phoneNo);
      }
    },
    "employee.salary"(newVal) {
      if (isNaN(newVal)) this.salaryError = true;
      else {
        this.employee.salary = parseInt(newVal);
        this.salaryError = false;
      }
      if (!this.salaryError) {
        this.$emit("salary", this.employee.salary);
      }
    },
    "employee.gender"(newVal) {
      this.$emit("gender", newVal);
    },
    "employee.positionCode"(newVal) {
      this.$emit("positionCode", newVal);
    },
    employeeStore() {
      if (this.employeeStore.id) {
        this.presentCreateSuccess();
      }
    },
    error() {
      // Will improve in future
      let errorMessage =
        "An error occured when saving the employee: Some of the data might already exist";
      if (
        this.error.message !==
        "An error occurred when saving the employee: An error occurred while updating the entries. See the inner exception for details."
      )
        errorMessage = this.error.message;
      this.presentCreateFailed(errorMessage);
    },
  },
  methods: {
    async presentCreateSuccess() {
      const alert = await alertController.create({
        header: "Create Success!",
        message: "This employee was created successfully.",
        buttons: [
          {
            text: "OK",
            handler: () => {
              this.$router.go();
            },
          },
        ],
      });
      await alert.present();

      const { role } = await alert.onDidDismiss();
    },
    async presentCreateFailed(errorMessage) {
      const alert = await alertController.create({
        header: "Create Failed!",
        message: errorMessage,
        buttons: ["OK"],
      });
      await alert.present();

      const { role } = await alert.onDidDismiss();
    },
    emitClick() {
      this.$emit("formSubmit");
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
ion-textarea,
ion-select {
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
  border: 2px solid var(--ion-color-danger) !important;
}

.error__message {
  color: var(--ion-color-danger);
  margin-top: 4px;
  font-size: 14px;
}

/* Popover Interface: set color for the popover using Item's CSS variables */
.styled_select .select-interface-option {
  --color: #333;
  --color-hover: #333;
}
</style>
