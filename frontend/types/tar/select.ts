/**
 * Represents a select option.
 */
export type SelectOption = {
  /**
   * The option will display with a disabled style and will not react to events.
   */
  disabled?: boolean;
  /**
   * A label indicating the meaning of the option.
   */
  label?: string;
  /**
   * The text to display inside the option.
   */
  text?: string;
  /**
   * The value associated with the option.
   */
  value?: string;
};

/**
 * The options of the TarSelect component.
 */
export type SelectOptions = {
  /**
   * The accessibility label describing the select.
   */
  ariaLabel?: string;
  /**
   * When adding a form select text, this is the unique identifier of the form text element. This will specify the `aria-describedby` attribute to ensure assistive technologies will announce the text when the user focuses or enters the control.
   */
  describedBy?: string;
  /**
   * The select will display with a disabled style and will not react to events.
   */
  disabled?: boolean | string;
  /**
   * The label will appear floating in the select, moving when the value is modified. The `label` property is required for floating labels to function properly.
   */
  floating?: boolean | string;
  /**
   * The unique identifier of the select.
   */
  id?: string;
  /**
   * The human readable caption of the select.
   */
  label?: string;
  /**
   * The value of the select.
   */
  modelValue?: string;
  /**
   * The select will allow multiple options to be selected.
   */
  multiple?: boolean | string;
  /**
   * The name of the select, used when submitting forms.
   */
  name?: string;
  /**
   * The options that will be displayed inside the select.
   */
  options?: SelectOption[];
  /**
   * This text will appear inside the select when no value has been selected.
   */
  placeholder?: string;
  /**
   * The select is required to submit the form its contained into. If the value is `label`, then the select label will appear as required, but the select itself will not have the required attribute. This is useful for client-validated forms.
   */
  required?: boolean | string;
  /**
   * The size of the select.
   */
  size?: SelectSize;
  /**
   * The status of the select. The select will display a valid style (green border) or invalid style (red border) when specified.
   */
  status?: SelectStatus;
};

/**
 * The sizes of the TarSelect component.
 */
export type SelectSize = "small" | "medium" | "large";

/**
 * The status values of the TarSelect component.
 */
export type SelectStatus = "invalid" | "valid";
