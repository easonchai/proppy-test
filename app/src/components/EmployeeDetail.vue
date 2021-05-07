<template>
  <div class="detail__container" v-if="employee"></div>
</template>

<script>
export default {
  name: "EmployeeDetail",
  props: ["employee"],
};
</script>

<style scoped>
.detail__container {
  display: flex;
  flex-direction: column;
}
</style>
