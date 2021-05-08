<template>
  <ion-card>
    <img :src="employee.photo" />
    <ion-card-header>
      <ion-card-title>{{ employee.name }}</ion-card-title>
      <ion-card-subtitle>{{ employee.position.description }}</ion-card-subtitle>
    </ion-card-header>
    <ion-card-content>
      <h3>Phone No.</h3>
      <h4>{{ employee.phone_No }}</h4>
      <h3>Email</h3>
      <h4>{{ employee.email }}</h4>
      <h3>Gender</h3>
      <h4>{{ employee.gender }}</h4>
      <h3>Date of Birth</h3>
      <h4>{{ employee.phone_No }}</h4>
      <h3>Salary</h3>
      <h4>{{ employee.phone_No }}</h4>
    </ion-card-content>
  </ion-card>
</template>

<script>
export default {
  name: "EmployeeCard",
  props: ["employee"],
};
</script>

<style scoped></style>
