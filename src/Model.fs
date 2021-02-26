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
      sentiment: {| bearishPercent: int
                    bullishPercent: int |}
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
