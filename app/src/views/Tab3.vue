<template>
  <base-layout pageTitle="Add Employee">
    <AddEmployee />
  </base-layout>
</template>

<script lang="ts">
import AddEmployee from "@/components/AddEmployee.vue";

export default {
  name: "Tab3",
  components: {
    AddEmployee,
  },
};
</script>
