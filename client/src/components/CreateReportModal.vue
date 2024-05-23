<script setup>
import ReportForm from './ReportForm.vue';
</script>


<template>
  <div class="modal fade" id="createReportModal" tabindex="-1" aria-labelledby="createReportModalLabel"
    aria-hidden="true">
    <div class="modal-dialog modal-xl">
      <div class="modal-content">
        <div class="modal-header">
          <h1 class="modal-title fs-5 text-success" id="createReportModalLabel">What do you say?</h1>
          <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div class="modal-body">
          <ReportForm />
        </div>
      </div>
    </div>
  </div>
</template>
