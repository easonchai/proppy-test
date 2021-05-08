<template>
  <base-layout pageTitle="View Employees - Card View">
    <CardSlider />
  </base-layout>
</template>

<script lang="ts">
import CardSlider from "@/components/CardSlider.vue";

export default {
  name: "CardView",
  components: { CardSlider },
};
</script>

<style scoped></style>
