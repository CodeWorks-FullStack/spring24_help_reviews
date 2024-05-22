<script setup>
import { Restaurant } from '../models/Restaurant.js';

defineProps({
  restaurant: { type: Restaurant, required: true }
})
</script>


<template>
  <div>
    {{ restaurant.name }}
  </div>
</template>


<style scoped></style>