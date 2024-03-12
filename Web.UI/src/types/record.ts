export type RecordResult = {
    records: Record[],
    count: number
}

export type Record = {
    date: string,
    total: number,
    duration: Duration,
    rating: Rating,
    response: Response,
    tags: Tags
}

export type Duration = {
    agentsChattingDuration: number,
    duration: number,
    count: number
}

export type Rating = {
    good: number,
    bad: number,
    chats: number
}

export type Response = {
    responseTime: number,
    count: number
}

export type Tags = {
    [name: string]: number
}