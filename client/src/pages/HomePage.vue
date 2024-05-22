<script setup>
import { computed, onMounted } from 'vue';
import Pop from '../utils/Pop.js';
import { restaurantsService } from '../services/RestaurantsService.js';
import { AppState } from '../AppState.js';

const restaurants = computed(() => AppState.restaurants)

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
  <div class="container-fluid">
    <section class="row">
      <div v-for="restaurant in restaurants" :key="restaurant.id" class="col-12 col-md-4 p-4">
        <RestaurantCard :restaurant="restaurant" />
      </div>
    </section>
  </div>
</template>

<style scoped lang="scss"></style>
