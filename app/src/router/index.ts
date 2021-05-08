import { createRouter, createWebHistory } from "@ionic/vue-router";
import { RouteRecordRaw } from "vue-router";
import Tabs from "../views/Tabs.vue";

const routes: Array<RouteRecordRaw> = [
  {
    path: "/",
    redirect: "/admin/employee/list",
  },
  {
    path: "/admin/employee",
    component: Tabs,
    children: [
      {
        path: "",
        redirect: "/list",
      },
      {
        path: "list",
        component: () => import("@/views/ListView.vue"),
      },
      {
        path: "card",
        component: () => import("@/views/CardView.vue"),
      },
      {
        path: "add",
        component: () => import("@/views/AddView.vue"),
      },
    ],
  },
  {
    path: "/employees/edit/:id",
    component: () => import("@/views/EditView.vue"),
  },
  {
    path: "/employees/:id",
    component: () => import("@/views/DetailsView.vue"),
  },
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
});

export default router;
