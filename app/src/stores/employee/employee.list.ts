import { getModule, Module, VuexModule } from "vuex-module-decorators";
import store from "../index";

@Module({
  namespaced: true,
  dynamic: true,
  name: "employee.list",
  store,
})
class ListEmployeeStore extends VuexModule {}

export default getModule(ListEmployeeStore);
