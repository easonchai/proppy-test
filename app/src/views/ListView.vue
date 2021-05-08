<template>
  <base-layout pageTitle="View Employees - List View" :hasFilter="true">
    <EmployeeList />
  </base-layout>
</template>

<script lang="ts">
import EmployeeList from "../components/listView/EmployeeList.vue";

export default {
  name: "ListView",
  components: {
    EmployeeList,
  },
};
</script>
