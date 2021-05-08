<template>
  <div class="detail__container" v-if="employee">
    <h3>Email:</h3>
    <h4>{{ employee.email }}</h4>
    <h3>Salary:</h3>
    <h4>RM {{ displaySalary(employee.salary) }}</h4>
    <h3>Date of Birth:</h3>
    <h4>{{ displayDob(employee.dob) }}</h4>
    <h3>Remarks:</h3>
    <h4>{{ employee.remarks === "" ? "None" : employee.remarks }}</h4>
    <ion-button
      expand="block"
      fill="outline"
      color="primary"
      @click="navigateToDetails"
      >View Employee</ion-button
    >
  </div>
</template>

<script>
export default {
  name: "EmployeeDetail",
  props: ["employee"],
  methods: {
    displaySalary(value) {
      const num = value.toFixed(2);
      const parsed = num.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
      return parsed;
    },
    displayDob(value) {
      const date = new Date(value);
      const parsed = date.toLocaleString().split(",")[0];
      return parsed;
    },
    navigateToDetails() {
      this.$router.push(`/employees/${this.employee.id}`);
    },
  },
};
</script>

<style scoped>
.detail__container {
  display: flex;
  flex-direction: column;
}

.field {
  display: flex;
  flex-direction: row;
}

h3 {
  color: var(--ion-color-step-500);
  font-size: 14px;
  margin: 4px 0;
  font-weight: 600;
  flex: 2;
}

h4 {
  color: var(--ion-color-step-500);
  font-size: 14px;
  margin: 4px 0 12px 0;
  flex: 5;
}
</style>
