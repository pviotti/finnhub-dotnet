namespace Finnhub

type CompanyProfile =
    { country: string
      currency: string
      exchange: string
      ipo: string
      marketCapitalization: float
      name: string
      phone: string
      shareOutstanding: float
      ticker: string
      weburl: string
      logo: string
      finnhubIndustry: string }

type Symbol =
    { description: string
      displaySymbol: string
      symbol: string
      ``type``: string }

type SymbolLookup = { count: int; result: Symbol [] }

type NewsPiece =
    { category: string
      datetime: int64
      headline: string
      id: int
      image: string
      related: string
      source: string
      summary: string
      url: string }

type CompanyNews = NewsPiece []

type NewsSentiment =
    { buzz: {| articlesInLastWeek: int
               buzz: float
               weeklyAverage: float |}
      companyNewsScore: float
      sectorAverageBullishPercent: float
      sectorAverageNewsScore: float
      sentiment: {| bearishPercent: float
                    bullishPercent: float |}
      symbol: string }

type Value = {| period: string; v: float |}

type Annual =
    { currentRatio: Value []
      salesPerShare: Value []
      netMargin: Value [] }

type BasicFinancials =
    { symbol: string
      metricType: string
      metric: {| ``10DayAverageTradingVolume``: float
                 ``52WeekHigh``: float
                 ``52WeekLow``: float
                 ``52WeekLowDate``: string
                 ``52WeekPriceReturnDaily``: float
                 beta: float |}
      series: {| annual: Annual |} }

type IPOCalendarEntry =
    {| date: string
       exchange: string
       name: string
       numberOfShares: int64
       price: string
       status: string
       symbol: string
       totalSharesvalue: int64 |}

type IPOCalendar = { ipoCalendar: IPOCalendarEntry [] }

type RecommendationEntry =
    { buy: float
      hold: float
      sell: float
      strongBuy: float
      strongSell: float
      symbol: string
      period: string }

type Recommendation = RecommendationEntry []

type EarningCalendarEntry =
    { date: string
      epsActual: float
      epsEstimate: float
      hour: string
      quarter: int
      revenueActual: int64
      revenueEstimate: int64
      symbol: string
      year: int }

type EarningCalendar =
    { earningCalendar: EarningCalendarEntry [] }

type Quote =
    { c: float
      h: float
      l: float
      o: float
      pc: float
      t: int64 }
