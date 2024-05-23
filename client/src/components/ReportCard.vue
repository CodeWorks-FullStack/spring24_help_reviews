<script setup>
import { Report } from '../models/Report.js';

defineProps({
  report: { type: Report, required: true }
})

</script>


<template>
  <div class="shadow-lg bg-light p-3">
    <div class="d-flex justify-content-between align-items-center">
      <p class="text-success fs-5 flex-grow-1 text-center">"{{ report.title }}"</p>
      <div class="d-flex align-items-center">
        <div class="text-end me-1">
          <p>
            {{ report.creator.name }}
          </p>
          <p>
            {{ report.createdAt.toLocaleString('en-US', { month: 'long', year: '2-digit', day: '2-digit' }) }}
          </p>
        </div>

        <img :src="report.creator.picture" :alt="report.creator.name" class="creator-img">
      </div>
    </div>
    <p>{{ report.body }}</p>
  </div>
</template>


<style scoped>
.creator-img {
  height: 10vh;
  aspect-ratio: 1/1;
  border-radius: 50%;
  object-fit: cover;
}

p {
  margin-bottom: .2em;
}
</style>