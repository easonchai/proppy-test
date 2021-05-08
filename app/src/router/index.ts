import { createRouter, createWebHistory } from "@ionic/vue-router";
import { RouteRecordRaw } from "vue-router";
import Tabs from "../views/Tabs.vue";

const routes: Array<RouteRecordRaw> = [
  {
    path: "/",
    redirect: "/views/list_employee",
  },
  {
    path: "/views/",
    component: Tabs,
    children: [
      {
        path: "",
        redirect: "/views/list_employee",
      },
      {
        path: "list_employee",
        component: () => import("@/views/ListView.vue"),
      },
      {
        path: "view_employee",
        component: () => import("@/views/CardView.vue"),
      },
      {
        path: "add_employee",
        component: () => import("@/views/AddEmployeeView.vue"),
      },
    ],
  },
  {
    path: "/employees/:id",
    component: () => import("@/views/FullDetailsView.vue"),
  },
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
});

export default router;
