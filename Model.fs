module Model

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

type News = NewsPiece []
