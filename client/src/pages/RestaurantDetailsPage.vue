<script setup>
import { onMounted } from 'vue';
import { restaurantsService } from '../services/RestaurantsService.js';
import Pop from '../utils/Pop.js';
import { useRoute } from 'vue-router';

const route = useRoute()

async function getRestaurantById() {
  try {
    await restaurantsService.getRestaurantById(route.params.restaurantId)
  } catch (error) {
    Pop.error(error)
  }
}

onMounted(() => {
  getRestaurantById()
})
</script>


<template>
  <h1>Restaurant Details Page!</h1>
</template>


<style scoped></style>