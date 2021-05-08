<template>
  <base-layout pageTitle="Employee Details">
    <EmployeeCardFull />
  </base-layout>
</template>

<script lang="ts">
import EmployeeCardFull from "../components/fullView/EmployeeCardFull.vue";

export default {
  name: "FullDetailsView",
  components: {
    EmployeeCardFull,
  },
};
</script>
