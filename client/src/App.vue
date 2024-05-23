<script setup>
import { AppState } from './AppState'
import CreateReportModal from './components/CreateReportModal.vue';
import Navbar from './components/Navbar.vue'


</script>

<template>
  <header>
    <Navbar />
  </header>
  <main>
    <router-view />
  </main>

  <CreateReportModal />
</template>

<style lang="scss">
@import "./assets/scss/main.scss";

:root {
  --main-height: calc(100vh - 32px - 64px);
}


footer {
  display: grid;
  place-content: center;
  height: 32px;
}

main {
  background-color: #F2FFEE;
}
</style>
