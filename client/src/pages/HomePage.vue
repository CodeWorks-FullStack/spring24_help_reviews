<script setup>
import { onMounted } from 'vue';
import Pop from '../utils/Pop.js';
import { restaurantsService } from '../services/RestaurantsService.js';

async function getAllRestaurants() {
  try {
    await restaurantsService.getAllRestaurants()
  } catch (error) {
    Pop.error(error)
  }
}

onMounted(() => {
  getAllRestaurants()
})
</script>

<template>
  <h1>SUP</h1>
</template>

<style scoped lang="scss"></style>
