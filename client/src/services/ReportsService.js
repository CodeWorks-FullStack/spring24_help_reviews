import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class ReportsService {
  async getReportsByRestaurantId(restaurantId) {
    const res = await api.get(`api/restaurants/${restaurantId}/reports`)
    logger.log('GOT REPORTS 🗃️', res.data)
  }
}

export const reportsService = new ReportsService()