<template>
    <table>
        <thead>
            <tr>
                <th rowspan="2">Date</th>
                <th rowspan="2">Total</th>
                <th colspan="3">Duration</th>
                <th colspan="3">Rating</th>
                <th colspan="2">Response</th>
                <th rowspan="2">Tags</th>
            </tr>
            <tr>
                <th>Duration</th>
                <th>Agents Chating Duration</th>
                <th>Count</th>

                <th>Good</th>
                <th>Bad</th>
                <th>Chats</th>

                <th>Time</th>
                <th>Count</th>
            </tr>
        </thead>
        <tbody>
            <tr v-for="record of recordResult?.records">
                <td>{{ record.date }}</td>
                <td>{{ record.total }}</td>
                <td>{{ record.duration.duration }}</td>
                <td>{{ record.duration.agentsChattingDuration }}</td>
                <td>{{ record.duration.count }}</td>
                <td>{{ record.rating.bad }}</td>
                <td>{{ record.rating.good }}</td>
                <td>{{ record.rating.chats }}</td>
                <td>{{ record.response.responseTime }}</td>
                <td>{{ record.response.count }}</td>
                <td v-if="record?.tags">
                    <div v-for="key in Object.keys(record.tags)" class="tag">
                        {{ key }}:
                        {{ record.tags[key] }}
                    </div>
                </td>
            </tr>
        </tbody>
    </table>
    <section class="page-controls">
        <button @click="setPage(page - 1)">&#60;</button>
        <p>{{ page }}</p>
        <button @click="setPage(page + 1)">&#62;</button>
    </section>
</template>

<script setup lang="ts">
import { onMounted, ref } from 'vue'
import type { RecordResult } from '../types/record'
import { useSettings } from '../settings';

const recordResult = ref<RecordResult>()
const page = ref(1)
const size = ref(7)

onMounted(async () => {
    recordResult.value = await loadData(page.value.toString(), size.value.toString())
})

const setPage = async (newValue: number) => {
    const allCount = recordResult.value?.count ?? -1
    if (newValue < 1 || newValue * size.value > allCount) return

    const result = await loadData(newValue.toString(), size.value.toString())

    if (result?.records?.length) {
        recordResult.value = result
        page.value = newValue
    }
}

const settigns = useSettings()

async function loadData(page: string, size: string): Promise<RecordResult | undefined> {
    const params = new URLSearchParams({ page, size })
    const response = await fetch(settigns.BackendUri + 'Record/GetAll?' + params)
    if (response.ok) {
        return await response.json()
    }
}
</script>

<style scoped>
table {
    width: 100%;
    margin: 0 auto;
    font-size: 15px;
    border-spacing: 0;
    border-collapse: collapse;
}

thead {
    background-color: #f8f8f8;
}

thead th {
    font-weight: 500;
}

td,
th {
    border: 1px solid rgba(128, 128, 128, 0.2);
    text-align: left;
    max-width: 500px;
    padding: .5em;
}

.tag {
    color: #fff;
    margin: .1em;
    padding: .2em .7em;
    border-radius: .5em;
    width: fit-content;
    display: inline-block;
    background-color: var(--primary);
}

.page-controls {
    display: flex;
    user-select: none;
    column-gap: 1em;
    font-size: large;
    align-items: center;
    justify-content: flex-end;
}

.page-controls button {
    border: none;
    color: #fff;
    cursor: pointer;
    padding: .2em .5em;
    font-weight: 500;
    font-size: larger;
    border-radius: .3em;
    background-color: var(--primary);
}
</style>