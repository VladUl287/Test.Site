import { inject, App } from 'vue'

const key = 'settings'

const settingsDefault: AppSettings = {
    BackendUri: 'https://localhost:7101/'
}

export const settingsPlugin = {
    install(app: App) {
        app.provide(key, {
            BackendUri: 'https://localhost:7101/'
        })
    }
}

export const useSettings = (): AppSettings => {
    return inject<AppSettings>(key, { ...settingsDefault })
}

export type AppSettings = {
    BackendUri: string
}