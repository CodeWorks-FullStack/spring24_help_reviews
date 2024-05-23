<script setup>
import { computed, onMounted } from 'vue';
import { restaurantsService } from '../services/RestaurantsService.js';
import Pop from '../utils/Pop.js';
import { useRoute, useRouter } from 'vue-router';
import { AppState } from '../AppState.js';
import { reportsService } from '../services/ReportsService.js';

const restaurant = computed(() => AppState.activeRestaurant)

const route = useRoute()

const router = useRouter()

async function getRestaurantById() {
  try {
    await restaurantsService.getRestaurantById(route.params.restaurantId)
  } catch (error) {
    // NOTE if you are trying to access data that you should not be able to access, go back to the home page
    if (error.response.data.includes('😉')) {
      router.push({ name: 'Home' })
      Pop.error(error.response.data + '🙎‍♂️')
    }
    else {
      Pop.error(error)
    }
  }
}

async function getReportsByRestaurantId() {
  try {
    await reportsService.getReportsByRestaurantId(route.params.restaurantId)
  } catch (error) {
    Pop.error(error)
  }
}

async function updateRestaurant() {
  try {
    const message = `Are you sure that you want to ${restaurant.value.isShutdown ? 'open' : 'close'} ${restaurant.value.name}?`

    const wantsToUpdate = await Pop.confirm(message)

    if (!wantsToUpdate) { return }

    const restaurantData = { isShutdown: !restaurant.value.isShutdown }

    await restaurantsService.updateRestaurant(restaurant.value.id, restaurantData)
  }
  catch (error) {
    Pop.error(error);
  }
}

onMounted(() => {
  getRestaurantById()
  getReportsByRestaurantId()
})
</script>


<template>
  <div v-if="restaurant" class="container">
    <section class="row my-3">
      <div class="col-12">
        <div class="d-flex justify-content-between">
          <h1 class="text-success mb-0">{{ restaurant.name }}</h1>
          <p v-if="restaurant.isShutdown" class="bg-danger text-light fs-1 mb-0">
            <i class="mdi mdi-close-circle"></i>
            Currently Shutdown
          </p>
        </div>
        <img :src="restaurant.imgUrl" :alt="restaurant.name" class="restaurant-img"
          :class="{ 'grayscale': restaurant.isShutdown }">
        <div class="p-3">
          <p>{{ restaurant.description }}</p>

          <div class="d-flex justify-content-between">

            <div class="d-flex justify-content-between align-items-center gap-3">
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

            <div class="d-flex gap-2">
              <button v-if="restaurant.isShutdown" @click="updateRestaurant()" class="btn btn-success fs-5">
                <i class="mdi mdi-door-open"></i>
                Re-open
              </button>
              <button v-else @click="updateRestaurant()" class="btn btn-danger fs-5">
                <i class="mdi mdi-door"></i>
                Shutdown
              </button>
              <button @click="Pop.error('This feature is not supported')" class="btn btn-danger fs-5">
                <i class="mdi mdi-delete"></i>
                Delete
              </button>
            </div>
          </div>
        </div>
      </div>
    </section>
  </div>

  <div v-else class="container-fluid">
    <section class="row">
      <div class="col-12 fs-1">
        <h1>Loading...</h1>
        <marquee behavior="alternate" direction="up" class="outer">
          <marquee direction="right" scrollamount="20">
            <i class="mdi mdi-rodent"></i> <i class="mdi mdi-cheese mdi-spin"></i>
          </marquee>
        </marquee>
      </div>
    </section>
  </div>
</template>


<style scoped>
.outer {
  height: 20vh;
}

.restaurant-img {
  width: 100%;
  height: 50vh;
  object-fit: cover;
}

.grayscale {
  filter: grayscale();
}
</style>