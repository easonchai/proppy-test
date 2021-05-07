<template>
  <form class="form__container" @submit.prevent>
    <!-- <ion-grid>
      <ion-row>
        <ion-col>
          <ion-item>
            <ion-label position="stacked">Employee Name</ion-label>
            <ion-input placeholder="Enter employee name..."></ion-input>
          </ion-item>
        </ion-col>
        <ion-col>
          <ion-item>
            <ion-label position="stacked">Phone Number</ion-label>
            <ion-input></ion-input>
          </ion-item>
        </ion-col>
      </ion-row>
      <ion-row>
        <ion-col>
          <ion-item>
            <ion-label position="stacked">Email</ion-label>
            <ion-input></ion-input>
          </ion-item>
        </ion-col>
        <ion-col>
          <ion-item>
            <ion-label position="stacked">Gender</ion-label>
            <ion-input></ion-input>
          </ion-item>
        </ion-col>
      </ion-row>
      <ion-row>
        <ion-col>
          <ion-item>
            <ion-label position="stacked">Position</ion-label>
            <ion-input></ion-input>
          </ion-item>
        </ion-col>
        <ion-col>
          <ion-item>
            <ion-label position="stacked">Date of Birth</ion-label>
            <ion-input></ion-input>
          </ion-item>
        </ion-col>
      </ion-row>
      <ion-row>
        <ion-col>
          <ion-item>
            <ion-label position="stacked">Salary</ion-label>
            <ion-input></ion-input>
          </ion-item>
        </ion-col>
        <ion-col>
          <ion-item>
            <ion-label position="stacked">Employee Name</ion-label>
            <ion-input></ion-input>
          </ion-item>
        </ion-col>
      </ion-row>
      <ion-row>
        <ion-col>
          <ion-item>
            <ion-label position="stacked">Salary</ion-label>
            <ion-input></ion-input>
          </ion-item>
        </ion-col>
        <ion-col>
          <ion-item>
            <ion-label position="stacked">Employee Name</ion-label>
            <ion-input></ion-input>
          </ion-item>
        </ion-col>
      </ion-row>
      <ion-item>
        <ion-textarea placeholder="Enter remarks here..."></ion-textarea>
      </ion-item>
    </ion-grid> -->
    <ion-item class="input__field">
      <ion-label position="floating">Employee Name</ion-label>
      <ion-input type="text" required></ion-input>
    </ion-item>
    <ion-item class="input__field">
      <ion-label position="floating">Phone No</ion-label>
      <ion-input type="phone" required></ion-input>
    </ion-item>
    <ion-item class="input__field">
      <ion-label position="floating">Email</ion-label>
      <ion-input type="email" required></ion-input>
    </ion-item>
    <ion-item class="input__field">
      <ion-label>Gender</ion-label>
      <ion-select placeholder="Select One">
        <ion-select-option value="F">Female</ion-select-option>
        <ion-select-option value="M">Male</ion-select-option>
      </ion-select>
    </ion-item>
    <ion-item class="input__field">
      <ion-label>Position</ion-label>
      <ion-select placeholder="Select One">
        <ion-select-option value="A">Senior Manager</ion-select-option>
        <ion-select-option value="B">Manager</ion-select-option>
        <ion-select-option value="C">Engineer</ion-select-option>
        <ion-select-option value="D">Designer</ion-select-option>
        <ion-select-option value="E">CEO</ion-select-option>
        <ion-select-option value="F">COO</ion-select-option>
        <ion-select-option value="G">CTO</ion-select-option>
        <ion-select-option value="H">CMO</ion-select-option>
      </ion-select>
    </ion-item>
    <ion-item class="input__field">
      <ion-label position="floating">Salary (RM)</ion-label>
      <ion-input type="decimal" required></ion-input>
    </ion-item>
    <ion-item class="input__field">
      <ion-label position="floating">Image URL</ion-label>
      <ion-input type="text" required></ion-input>
    </ion-item>
    <ion-item class="input__field">
      <ion-label position="floating">Remarks</ion-label>
      <ion-textarea placeholder="Enter employee remarks..."></ion-textarea>
    </ion-item>
    <ion-button expand="block">Add Employee</ion-button>
  </form>
</template>

<script>
import { IonInput, IonItem, IonLabel } from "@ionic/vue";
import { defineComponent } from "vue";

export default {
  components: { IonInput, IonItem, IonLabel },
  name: "AddEmployee",
};
</script>

<style scoped>
.form__container {
  display: flex;
  flex-direction: column;
  padding: 8vw;
}

.input__field {
  margin-bottom: 14px;
}
</style>
