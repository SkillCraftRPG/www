export default defineI18nConfig(() => ({
  numberFormats: {
    fr: {
      integer: {
        style: "decimal",
        minimumFractionDigits: 0,
        maximumFractionDigits: 0,
      },
      price: {
        style: "decimal",
        minimumFractionDigits: 0,
        maximumFractionDigits: 2,
      },
      weight: {
        style: "decimal",
        minimumFractionDigits: 0,
        maximumFractionDigits: 2,
      },
    },
  },
}));
