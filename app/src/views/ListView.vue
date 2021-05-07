<template>
  <base-layout pageTitle="View Employees - List View">
    <EmployeeList />
  </base-layout>
</template>

<script lang="ts">
import EmployeeList from "@/components/EmployeeList.vue";

export default {
  name: "ListView",
  components: {
    EmployeeList,
  },
};
</script>
