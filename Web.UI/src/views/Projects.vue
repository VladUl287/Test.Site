<template>
    <nav>
        <div>
            <p>Projects: </p>
            <router-link to="/project/1">Project_1</router-link>
            <router-link to="/project/2">Project_2</router-link>
            <router-link to="/project/2">Project_3</router-link>
        </div>
    </nav>
</template>

<script setup lang="ts">
</script>

<style scoped>
nav {
    display: flex;
    align-items: center;
    flex-direction: column;
    height: 100%;
    padding: .5em;
}

nav div {
    width: max(250px, 30%);
}

nav a {
    display: block;
    width: 100%;
    padding: 1em;
    color: unset;
    margin: 0 0 .5em 0;
    border-radius: .5em;
    text-decoration: none;
    border: 1px solid #075d8833;
    background-color: var(--gray-l);
}
</style>