/**
 * The options of the TarInput component.
 */
export type InputOptions = {
  /**
   * When adding a form input text, this is the unique identifier of the form text element. This will specify the `aria-describedby` attribute to ensure assistive technologies will announce the text when the user focuses or enters the control.
   */
  describedBy?: string;
  /**
   * The input will display with a disabled style and will not react to events.
   */
  disabled?: boolean | string;
  /**
   * The label will appear floating in the input, moving when the value is modified. The `label` and `placeholder` properties are required for floating labels to function properly.
   */
  floating?: boolean | string;
  /**
   * The unique identifier of the input.
   */
  id?: string;
  /**
   * The human readable caption of the input.
   */
  label?: string;
  /**
   * - For textual inputs (text, search, url, tel, email, and password), this is the maximum length in characters of a valid value.
   * - For numeric inputs (number and range), this is the maximum valid numeral value.
   * - For date inputs, this is the maximum date, using the `YYYY-MM-DD` format.
   * - For time inputs, this is the maximum time, using the `HH:MM` format.
   * - For month inputs, this is the maximum month, using the `YYYY-MM` format.
   * - For week inputs, this is the maximum week, using the `YYYY-WNN` format, NN being the week number.
   * - For datetime-local inputs, this is the maximum moment, using the `YYYY-MM-DDTHH:mm` format.
   */
  max?: number | string;
  /**
   * - For textual inputs (text, search, url, tel, email, and password), this is the minimum length in characters of a valid value.
   * - For numeric inputs (number and range), this is the minimum valid numeral value.
   * - For date inputs, this is the minimum date, using the `YYYY-MM-DD` format.
   * - For time inputs, this is the minimum time, using the `HH:MM` format.
   * - For month inputs, this is the minimum month, using the `YYYY-MM` format.
   * - For week inputs, this is the minimum week, using the `YYYY-WNN` format, NN being the week number.
   * - For datetime-local inputs, this is the minimum moment, using the `YYYY-MM-DDTHH:mm` format.
   */
  min?: number | string;
  /**
   * The value of the field.
   */
  modelValue?: string;
  /**
   * The name of the input, used when submitting forms.
   */
  name?: string;
  /**
   * The regular expression a valid value must match. Only textual inputs (text, search, url, tel, email, and password) support this property.
   */
  pattern?: string;
  /**
   * This text will appear inside the input when no value has been set. Only textual and number inputs (number, text, search, url, tel, email, and password) support this property.
   */
  placeholder?: string;
  /**
   * When the input is readonly, this will display the value as text instead of an input, preserving margin and padding, but removing form field styling.
   */
  plaintext?: boolean | string;
  /**
   * The value of the input will not be editable.
   */
  readonly?: boolean | string;
  /**
   * The input is required to submit the form its contained into. If the value is `label`, then the input label will appear as required, but the input itself will not have the required attribute. This is useful for client-validated forms.
   */
  required?: boolean | string;
  /**
   * The size of the input.
   */
  size?: InputSize;
  /**
   * The status of the input. The input will display a valid style (green border) or invalid style (red border) when specified.
   */
  status?: InputStatus;
  /**
   * - For numeric inputs (number and range), the value of each increase or decrease.
   * - For date/time inputs (date, time, month, week, and datetime-local), the value can be a number or "any". Its interpretation depends on the input type, so please consult documentation about inputs if you are unsure about how to use the step for those input types.
   */
  step?: number | string;
  /**
   * The type of the input.
   */
  type?: InputType;
};

/**
 * The sizes of the TarInput component.
 */
export type InputSize = "small" | "medium" | "large";

/**
 * The status values of the TarInput component.
 */
export type InputStatus = "invalid" | "valid";

/**
 * The types of the TarInput component.
 */
export type InputType = "text" | "search" | "url" | "tel" | "email" | "password" | "number" | "range" | "date" | "time" | "month" | "week" | "datetime-local";
