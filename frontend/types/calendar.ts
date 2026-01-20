import { parsingUtils } from "logitar-js";

const { parseNumber } = parsingUtils;

const astrologicalSigns: string[] = [
  "Amphore",
  "Archer",
  "Balance",
  "Capricorne",
  "Chariot",
  "Coq",
  "Coquillage",
  "Crabe",
  "Destrier",
  "Lion",
  "Poisson",
  "Scorpion",
  "Berceau",
  "Vipère",
  "Pieuvre",
  "Lotus",
  "Arbre",
  "Échelle",
  "Sabre",
  "Tortue",
  "Lyre",
  "Serpe",
  "Aigle",
  "Caducée",
  "Lune",
];

const plants: string[] = [
  "Moly",
  "Chêne",
  "Bouleau",
  "Saule",
  "Tilleul",
  "Orme",
  "Pin",
  "Genévrier",
  "Frêne",
  "Aubépine",
  "Églantier",
  "Lavande",
  "Menthe",
  "Sauge",
  "Origan",
  "Fenouil",
  "Thym",
  "Romarin",
  "Camomille",
  "Millepertuis",
  "Ortie",
];

function calculateDaysInMonth(month: number, isLeapYear: boolean): number {
  if (month < 1 || month > 12) {
    throw new Error(`The month '${month}' is not valid. It should be inclusively between 1 and 12.`);
  } else if (month < 10 || isLeapYear) {
    return month % 2 ? 30 : 31;
  }
  return month === 11 ? 31 : 30;
}

function isLeapYear(year: number): boolean {
  const index: number = year % 21;
  return index < 20 && index % 4 === 0;
}

export class CalendarDate {
  private year: number = 1;
  private month: number = 1;
  private day: number = 1;

  private isCurrentYearLeaping: boolean = false;
  private daysInYear: number = 0;
  private daysInMonth: number = 0;
  private dayOfYear: number = 0;

  constructor(year: number = 1, month: number = 1, day: number = 1) {
    if (year < 1) {
      throw new Error(`The year '${year}' is not valid. It should be greater than or be equal to 1.`);
    }

    if (month < 1 || month > 12) {
      throw new Error(`The month '${month}' is not valid. It should be inclusively between 1 and 12.`);
    }

    const isCurrentYearLeaping: boolean = isLeapYear(year);
    const daysInMonth: number = calculateDaysInMonth(month, isCurrentYearLeaping);
    if (day < 1 || day > daysInMonth) {
      throw new Error(`The day '${day}' is not valid. It should be inclusively between 1 and ${daysInMonth}.`);
    }

    this.year = year;
    this.month = month;
    this.day = day;

    this.isCurrentYearLeaping = isLeapYear(this.year);
    this.daysInYear = this.isCurrentYearLeaping ? 366 : 365;
    this.daysInMonth = calculateDaysInMonth(this.month, this.isCurrentYearLeaping);

    for (let m = 1; m < this.month; m++) {
      this.dayOfYear += calculateDaysInMonth(m, this.isCurrentYearLeaping);
    }
    this.dayOfYear += this.day;
  }

  getYear(): number {
    return this.year;
  }
  getMonth(): number {
    return this.month;
  }
  getDay(): number {
    return this.day;
  }

  isLeapYear(): boolean {
    return this.isCurrentYearLeaping;
  }
  getDaysInYear(): number {
    return this.daysInYear;
  }
  getDaysInMonth(): number {
    return this.daysInMonth;
  }
  getDayOfYear(): number {
    return this.dayOfYear;
  }

  isSpringEquinox(): boolean {
    return this.month === 3 && this.day === this.daysInMonth;
  }
  isSummerSolstice(): boolean {
    return this.month === 6 && this.day === this.daysInMonth;
  }
  isAutumnEquinox(): boolean {
    return this.month === 9 && this.day === this.daysInMonth;
  }
  isWinterSolstice(): boolean {
    return this.month === 12 && this.day === this.daysInMonth;
  }

  getAstrologicalSign(): string {
    let index: number = this.month - 1;
    if (this.year % 2 === 0) {
      index += 12;
    }
    return astrologicalSigns[index] ?? "";
  }
  getPlant(): string {
    const index: number = this.year % 21;
    return plants[index] ?? "";
  }
}

function parseDate(date: string): CalendarDate {
  const parts: string[] = date.split("-");
  if (parts.length !== 3) {
    throw new Error(`The date '${date}' is not valid. It should match the format YYYY-MM-DD.`);
  }
  return new CalendarDate(parseNumber(parts[0]) ?? 0, parseNumber(parts[1]) ?? 0, parseNumber(parts[2]) ?? 0);
}

export default {
  calculateDaysInMonth,
  isLeapYear,
  parseDate,
};

// TODO(fpion): # du cycle lunaire
// TODO(fpion): animal associé au cycle lunaire
// TODO(fpion): jour de la semaine (lundi-dimanche)
// TODO(fpion): divinité du panthéon
// TODO(fpion): # de la semaine
// TODO(fpion): élément
// TODO(fpion): pictogramme/nom de la phase lunaire

// TODO(fpion): pierre de naissance ?
