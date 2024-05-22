import { AppState } from "../AppState.js"
import { Restaurant } from "../models/Restaurant.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class RestaurantsService {
  async getAllRestaurants() {
    const res = await api.get('api/restaurants')
    logger.log('GOT RESTAURANTS 🧑‍🍳', res.data)
    AppState.restaurants = res.data.map(pojo => new Restaurant(pojo))
  }
}

export const restaurantsService = new RestaurantsService()