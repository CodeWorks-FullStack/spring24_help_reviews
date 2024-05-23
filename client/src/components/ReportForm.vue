<script setup>
import { computed, ref } from 'vue';
import { AppState } from '../AppState.js';
import Pop from '../utils/Pop.js';
import { reportsService } from '../services/ReportsService.js';

// NOTE I only want to show restaurants that I don't own here
const restaurants = computed(() => AppState.restaurants.filter(restaurant => restaurant.creatorId != AppState.account?.id))

const reportFormData = ref({
  title: '',
  body: '',
  imgUrl: '',
  restaurantId: 0
})


async function createReport() {
  try {
    await reportsService.createReport(reportFormData.value)
    reportFormData.value = {
      title: '',
      body: '',
      imgUrl: '',
      restaurantId: 0
    }
    Pop.success("Created report!")

  } catch (error) {
    Pop.error(error)
  }
}
</script>


<template>
  <form @submit.prevent="createReport()">
    <select v-model="reportFormData.restaurantId" class="form-select mb-3" aria-label="Default select example" required>
      <option v-for="restaurant in restaurants" :key="restaurant.id" :value="restaurant.id">
        {{ restaurant.name }}
      </option>
    </select>
    <div class="mb-3">
      <label for="title" class="form-label">Report Title</label>
      <input v-model="reportFormData.title" type="text" class="form-control" id="title" required maxlength="255">
    </div>
    <div class="mb-3">
      <label for="imgUrl" class="form-label">Report ImgUrl</label>
      <input v-model="reportFormData.imgUrl" type="url" class="form-control" id="imgUrl" maxlength="1000">
    </div>
    <div class="mb-3">
      <label for="body" class="form-label">Report Body</label>
      <textarea v-model="reportFormData.body" class="form-control" id="body" required maxlength="1000"></textarea>
    </div>
    <button type="submit" class="btn btn-primary">Submit</button>
  </form>
</template>


<style scoped></style>