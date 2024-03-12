import { inject, App } from 'vue'

const key = 'settings'

const settingsDefault: AppSettings = {
    BackendUri: 'http://localhost:5148/'
}

export const settingsPlugin = {
    install(app: App) {
        app.provide(key, {
            BackendUri: 'http://localhost:5148/'
        })
    }
}

export const useSettings = (): AppSettings => {
    return inject<AppSettings>(key, { ...settingsDefault })
}

export type AppSettings = {
    BackendUri: string
}