<template>
  <div class="detail__container" v-if="employee">
    <h3>Email: {{ employee.email }}</h3>
    <h3>Salary: RM {{ displaySalary(employee.salary) }}</h3>
    <h3>Date of Birth: {{ employee.dob }}</h3>
    <h3>Remarks: {{ employee.remarks }}</h3>
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
  },
};
</script>

<style scoped>
.detail__container {
  display: flex;
  flex-direction: column;
}

h3 {
  color: var(--ion-color-step-500);
  font-size: 14px;
  margin: 4px 0;
}
</style>
