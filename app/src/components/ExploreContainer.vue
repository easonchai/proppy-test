<template>
  <div id="container">
    <strong>{{ name }}</strong>
    <p>
      Explore
      <a
        target="_blank"
        rel="noopener noreferrer"
        href="https://ionicframework.com/docs/components"
        >UI Components</a
      >
    </p>
  </div>
</template>

<script lang="ts">
import store from "../stores";

export default {
  name: "ExploreContainer",
  props: {
    name: String,
  },
  data() {
    return {
      store: null,
    };
  },
  computed: {
    employeeStore: function() {
      return store.getters;
    },
  },
  mounted() {
    // console.log(store.state.employeeList);
    console.log((store.state as any).employeeList);
    console.log(store.dispatch("employeeList/getAllEmployees", { root: true }));
  },
  watch: {
    "store.state"() {
      console.log((store.state as any).employeeList.employees);
    },
  },
};
</script>

<style scoped>
#container {
  text-align: center;
  position: absolute;
  left: 0;
  right: 0;
  top: 50%;
  transform: translateY(-50%);
}

#container strong {
  font-size: 20px;
  line-height: 26px;
}

#container p {
  font-size: 16px;
  line-height: 22px;
  color: #8c8c8c;
  margin: 0;
}

#container a {
  text-decoration: none;
}
</style>
