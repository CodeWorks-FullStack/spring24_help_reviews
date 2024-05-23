export class Restaurant {
  constructor(data) {
    // TODO make databaseitem class to inherit from
    this.id = data.id
    this.createdAt = new Date(data.createdAt)
    this.updatedAt = new Date(data.updatedAt)
    this.name = data.name
    this.imgUrl = data.imgUrl
    this.description = data.description
    this.visits = data.visits
    this.isShutdown = data.isShutdown
    this.creatorId = data.creatorId
    // TODO make profile class
    this.creator = data.creator
    this.reportCount = data.reportCount
  }
}

