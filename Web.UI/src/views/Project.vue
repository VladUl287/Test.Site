<template>
    <div class="container">
        <nav>
            <router-link :to="{ name: 'table' }">Table</router-link>
            <router-link to="/nav1">Nav1</router-link>
            <router-link to="/nav2">Nav2</router-link>
            <router-link to="/nav3">Nav3</router-link>
        </nav>
        <router-view />
    </div>
</template>

<style scoped>
.container {
    max-height: 100%;
    overflow-y: auto;
    padding: 1em .3em;
    scrollbar-gutter: stable both-edges;
}

nav {
    text-align: center;
    padding: .5em 0 1.5em 0;
}

nav a {
    color: unset;
    margin: 0 1em;
    padding: .3em 1em;
    border-radius: .3em;
    text-decoration: none;
    border: 1px solid #075d8833;
    background-color: var(--gray-l);
}
</style>