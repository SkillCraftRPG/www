import { createI18n } from "vue-i18n";

import fr from "./fr";

type MessageSchema = typeof fr;

export default createI18n<[MessageSchema], "fr">({
  legacy: false,
  locale: "fr",
  fallbackLocale: "fr",
  messages: {
    fr,
  },
  datetimeFormats: {
    fr: {
      medium: {
        year: "numeric",
        month: "long",
        day: "numeric",
        hour: "numeric",
        minute: "numeric",
        second: "numeric",
      },
    },
  },
  numberFormats: {
    fr: {
      currency: {
        style: "currency",
        currency: "CAD",
        currencyDisplay: "narrowSymbol",
        notation: "standard",
      },
      decimal: {
        style: "decimal",
        minimumFractionDigits: 2,
      },
      percent: {
        style: "percent",
        minimumFractionDigits: 3,
      },
    },
  },
});
