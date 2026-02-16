/**
 * The options of the TarCheckbox component.
 */
export type CheckboxOptions = {
  /**
   * The accessibility label describing the checkbox.
   */
  ariaLabel?: string;
  /**
   * When adding a form input text, this is the unique identifier of the form text element. This will specify the `aria-describedby` attribute to ensure assistive technologies will announce the text when the user focuses or enters the control.
   */
  describedBy?: string;
  /**
   * The checkbox will display with a disabled style and will not react to events.
   */
  disabled?: boolean | string;
  /**
   * The unique identifier of the checkbox.
   */
  id?: string;
  /**
   * The checkbox will be inline, allowing it to be stacked with other checkboxes.
   */
  inline?: boolean | string;
  /**
   * The human readable caption of the checkbox.
   */
  label?: string;
  /**
   * The value of the checkbox, which is, if it is checked or not.
   */
  modelValue?: boolean | string;
  /**
   * The name of the checkbox, used when submitting forms.
   */
  name?: string;
  /**
   * The checkbox is required to be checked to submit the form its contained into.
   */
  required?: boolean | string;
  /**
   * The alignment of the checkbox will be reversed.
   */
  reverse?: boolean | string;
  /**
   * The accessibility role of the checkbox. Defaults to empty for checkboxes and `switch` for switches.
   */
  role?: string;
  /**
   * The checkbox will appear in a switch style instead of a checkbox.
   */
  switch?: boolean | string;
  /**
   * The value of the checkbox, used when submitting forms.
   */
  value?: string;
};
