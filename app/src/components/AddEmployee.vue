<template>
  <EmployeeForm
    :employeeData="employee"
    buttonText="Add Employee"
    @name="updateName"
    @email="updateEmail"
    @phoneNo="updatePhone"
    @gender="updateGender"
    @positionCode="updatePositionCode"
    @salary="updateSalary"
    @photo="updatePhoto"
    @remarks="updateRemarks"
    @dob="updateDOB"
    @formSubmit="createEmployee"
  />
</template>

<script>
import store from "../stores";
import EmployeeForm from "./EmployeeForm";
import { alertController } from "@ionic/vue";

export default {
  components: {
    EmployeeForm,
  },
  name: "AddEmployee",
  data() {
    return {
      employee: {
        name: "",
        email: "",
        phoneNo: "",
        gender: "M",
        positionCode: "A",
        salary: 0,
        photo: "",
        remarks: "",
        dob: "",
      },
    };
  },
  computed: {
    employeeStore() {
      return store.state.employeeCreate.employee;
    },
  },
  watch: {
    employeeStore() {
      if (this.employeeStore.id) {
        this.presentCreateSuccess();
      }
    },
  },
  methods: {
    createEmployee() {
      store.dispatch("employeeCreate/createEmployee", this.employee, {
        root: true,
      });
    },
    updateName(val) {
      this.employee.name = val;
    },
    updateEmail(val) {
      this.employee.email = val;
    },
    updatePhone(val) {
      this.employee.phoneNo = val;
    },
    updateGender(val) {
      this.employee.gender = val;
    },
    updatePositionCode(val) {
      this.employee.positionCode = val;
    },
    updateSalary(val) {
      this.employee.salary = val;
    },
    updatePhoto(val) {
      this.employee.photo = val;
    },
    updateDOB(val) {
      this.employee.dob = val;
    },
    updateRemarks(val) {
      this.employee.remarks = val;
    },
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
