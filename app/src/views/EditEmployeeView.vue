<template>
  <base-layout pageTitle="Edit Employee">
    <EditEmployee />
  </base-layout>
</template>

<script lang="ts">
import EditEmployee from "@/components/EditEmployee.vue";

export default {
  name: "EditEmployeeView",
  components: {
    EditEmployee,
  },
};
</script>
