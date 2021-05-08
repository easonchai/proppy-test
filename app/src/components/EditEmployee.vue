<template>
  <EmployeeForm
    v-if="employeeData.id"
    :employeeData="employeeData"
    buttonText="Save Changes"
    @name="updateName"
    @email="updateEmail"
    @phoneNo="updatePhone"
    @gender="updateGender"
    @positionCode="updatePositionCode"
    @salary="updateSalary"
    @photo="updatePhoto"
    @remarks="updateRemarks"
    @formSubmit="updateEmployee"
  />
</template>

<script>
import store from "../stores";
import EmployeeForm from "./EmployeeForm";

export default {
  components: {
    EmployeeForm,
  },
  name: "EditEmployee",
  data() {
    return {
      employeeData: {},
    };
  },
  methods: {
    updateEmployee() {
      store.dispatch("employeeDetail/updateEmployee", this.employeeData, {
        root: true,
      });
    },
    updateName(val) {
      this.employeeData.name = val;
    },
    updateEmail(val) {
      this.employeeData.email = val;
    },
    updatePhone(val) {
      this.employeeData.phoneNo = val;
    },
    updateGender(val) {
      this.employeeData.gender = val;
    },
    updatePositionCode(val) {
      this.employeeData.positionCode = val;
    },
    updateSalary(val) {
      this.employeeData.salary = val;
    },
    updatePhoto(val) {
      this.employeeData.photo = val;
    },
    updateRemarks(val) {
      this.employeeData.remarks = val;
    },
  },
  computed: {
    employee() {
      return store.state.employeeDetail.employee;
    },
  },
  watch: {
    employee() {
      if (this.employee.id) {
        this.employeeData = {
          ...this.employee,
          positionCode: this.employee.position.code,
        };
      }
    },
  },
  mounted() {
    store.dispatch("employeeDetail/getEmployee", this.$route.params.id, {
      root: true,
    });
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
