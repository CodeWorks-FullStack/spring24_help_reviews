import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class RestaurantsService {
  async getAllRestaurants() {
    const res = await api.get('api/restaurants')
    logger.log('GOT RESTAURANTS 🧑‍🍳', res.data)
  }
}

export const restaurantsService = new RestaurantsService()