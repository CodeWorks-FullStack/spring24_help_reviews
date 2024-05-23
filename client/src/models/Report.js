export class Report {
  constructor(data) {
    this.id = data.id
    this.createdAt = new Date(data.createdAt)
    this.updatedAt = new Date(data.updatedAt)
    this.title = data.title
    this.body = data.body
    this.imgUrl = data.imgUrl || ''
    this.restaurantId = data.restaurantId
    this.creatorId = data.creatorId
    this.creator = data.creator
  }
}

