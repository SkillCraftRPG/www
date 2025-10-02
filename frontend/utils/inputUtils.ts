import type { InputType } from "~/types/tar/input";

/**
 * Returns a value indicating whether or not the specified type is a date-time input type.
 * @param type The input type to check.
 * @returns True if the type is a date-time input type, or false otherwise.
 */
export function isDateTimeInput(type?: InputType): boolean {
  switch (type) {
    case "date":
    case "datetime-local":
    case "month":
    case "time":
    case "week":
      return true;
  }
  return false;
}

/**
 * Returns a value indicating whether or not the specified type is a numeric input type.
 * @param type The input type to check.
 * @returns True if the type is a numeric input type, or false otherwise.
 */
export function isNumericInput(type?: InputType): boolean {
  switch (type) {
    case "number":
    case "range":
      return true;
  }
  return false;
}

/**
 * Returns a value indicating whether or not the specified type is a textual input type.
 * @param type The input type to check.
 * @returns True if the type is a textual input type, or false otherwise.
 */
export function isTextualInput(type?: InputType): boolean {
  switch (type) {
    case "email":
    case "password":
    case "search":
    case "tel":
    case "text":
    case "url":
    case undefined:
      return true;
  }
  return false;
}
