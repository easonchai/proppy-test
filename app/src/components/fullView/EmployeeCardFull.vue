<template>
  <ion-card v-if="employee">
    <div class="image__container">
      <ion-skeleton-text v-if="imageNotLoaded"></ion-skeleton-text>
      <img :src="employee.photo" @load="updateImageLoaded" />
    </div>
    <ion-card-header>
      <ion-card-title>{{ employee.name }}</ion-card-title>
      <ion-card-subtitle>{{ employee.position.description }}</ion-card-subtitle>
    </ion-card-header>
    <ion-card-content>
      <h3>Phone No.</h3>
      <h4>{{ employee.phoneNo }}</h4>
      <h3>Email</h3>
      <h4>{{ employee.email }}</h4>
      <h3>Gender</h3>
      <h4>{{ displayGender(employee.gender) }}</h4>
      <h3>Date of Birth</h3>
      <h4>{{ displayDob(employee.dob) }}</h4>
      <h3>Salary</h3>
      <h4>RM {{ displaySalary(employee.salary) }}</h4>
      <h3>Remarks</h3>
      <h4>{{ employee.remarks === "" ? "None" : employee.remarks }}</h4>
    </ion-card-content>
    <div class="button__container">
      <div class="column">
        <ion-button expand="block" fill="outline">Edit Employee</ion-button>
      </div>
      <div class="column">
        <ion-button
          expand="block"
          fill="outline"
          color="danger"
          @click="presentAlertConfirm"
          >Delete Employee</ion-button
        >
      </div>
    </div>
  </ion-card>
</template>

<script>
import {
  IonCard,
  IonCardContent,
  IonCardHeader,
  IonCardSubtitle,
  IonCardTitle,
  IonSkeletonText,
  alertController,
  IonButton,
} from "@ionic/vue";
import store from "../../stores";

export default {
  name: "EmployeeCardFull",
  components: {
    IonCard,
    IonCardContent,
    IonCardHeader,
    IonCardSubtitle,
    IonCardTitle,
    IonSkeletonText,
    IonButton,
  },
  data() {
    return {
      imageNotLoaded: true,
    };
  },
  computed: {
    employee: function() {
      return store.state.employeeDetail.employee;
    },
  },
  watch: {
    employee() {
      if (this.employee.deleted) {
        this.$router.back();
      }
    },
    $route() {
      if (this.$route.params) {
        store.dispatch("employeeDetail/getEmployee", this.$route.params.id, {
          root: true,
        });
      }
    },
  },
  mounted() {
    store.dispatch("employeeDetail/getEmployee", this.$route.params.id, {
      root: true,
    });
  },
  methods: {
    displaySalary(value) {
      const num = value.toFixed(2);
      const parsed = num.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
      return parsed;
    },
    displayDob(value) {
      const date = new Date(value);
      const parsed = date.toLocaleString().split(",")[0];
      return parsed;
    },
    displayGender(character) {
      switch (character) {
        case "M":
          return "Male";
        case "F":
          return "Female";
      }
    },
    updateImageLoaded() {
      this.imageNotLoaded = false;
    },
    async presentAlertConfirm() {
      const alert = await alertController.create({
        cssClass: "my-custom-class",
        header: "Confirm Deletion",
        message:
          "Are you sure you want to delete this employee? This action is not reversible!",
        buttons: [
          {
            text: "Cancel",
            role: "cancel",
            cssClass: "secondary",
          },
          {
            text: "Delete",
            handler: () => {
              store.dispatch(
                "employeeDetail/deleteEmployee",
                this.$route.params.id,
                {
                  root: true,
                }
              );
            },
          },
        ],
      });
      return alert.present();
    },
  },
};
</script>

<style scoped>
ion-card {
  display: flex;
  flex-direction: column;
  align-items: flex-start;
  min-width: 80vw;
}

ion-card-title {
  color: var(--ion-color-step-100);
  font-weight: bold;
  font-size: 24px;
  text-align: left;
}

ion-card-subtitle {
  color: var(--ion-color-step-200);
  font-weight: 600;
  font-size: 18px;
  text-align: left;
}

ion-card-content {
  display: flex;
  flex-direction: column;
  align-items: flex-start;
}

h3 {
  color: var(--ion-color-step-500);
  font-size: 16px;
  margin: 4px 0;
  font-weight: 600;
  flex: 2;
}

h4 {
  color: var(--ion-color-step-500);
  font-size: 16px;
  margin: 4px 0 12px 0;
  flex: 5;
}

img {
  flex-shrink: 0;
  min-width: 100%;
  min-height: 100%;
}

.image__container {
  width: 100%;
  min-height: 30vh;
  display: flex;
  justify-content: center;
  align-items: center;
  overflow: hidden;
}

.button__container {
  display: flex;
  flex-direction: row;
  padding: 2vh 2vw;
  justify-content: space-between;
  width: 100%;
}

.column {
  flex: 1;
  display: flex;
  align-items: center;
  justify-content: center;
}
</style>
