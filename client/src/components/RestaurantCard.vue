<script setup>
import { Restaurant } from '../models/Restaurant.js';

defineProps({
  restaurant: { type: Restaurant, required: true }
})
</script>


<template>
  <RouterLink :to="{ name: 'Restaurant Details', params: { restaurantId: restaurant.id } }">
    <!-- TODO fix weird line height -->
    <div class="bg-light shadow-lg text-dark" :title="`Visit the ${restaurant.name} page!`">
      <img :src="restaurant.imgUrl" :alt="restaurant.name">
      <div class="p-2">
        <p class="mb-0" :class="restaurant.isShutdown ? 'text-danger' : 'text-success'">
          <b>
            {{ restaurant.name }}
          </b>
        </p>
        <p>{{ restaurant.description }}</p>

        <div class="d-flex justify-content-between align-items-center">
          <p class="fs-3 mb-1" :title="`${restaurant.name} has ${restaurant.visits} total visits.`">
            <i class="mdi mdi-account-group text-success"></i>
            {{ restaurant.visits }}
          </p>
          <p class="fs-3 mb-1" :title="`${restaurant.name} has 0 total reports.`">
            <i class="mdi mdi-file text-success"></i>
            <!-- TODO add report count here when backend supports it -->
            0
          </p>
        </div>
      </div>
    </div>
  </RouterLink>
</template>


<style scoped>
img {
  width: 100%;
  aspect-ratio: 1/1;
  object-fit: cover;
}
</style>