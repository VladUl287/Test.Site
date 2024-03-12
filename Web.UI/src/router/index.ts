import { RouteRecordRaw, createRouter, createWebHistory } from 'vue-router'

const routes: RouteRecordRaw[] = [
    {
        path: '/projects',
        name: 'projects',
        component: () => import('../views/Projects.vue')
    },
    {
        path: '/project/:id',
        name: 'project',
        component: () => import('../views/Project.vue'),
        children: [
            {
                path: 'table',
                name: 'table',
                component: () => import('../views/Table.vue')
            }
        ]
    },
    {
        path: '/:pathMatch(.*)*',
        redirect: () => ({ path: '/projects' })
    }
]

const router = createRouter({
    history: createWebHistory(),
    routes
})

export default router