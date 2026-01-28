/**
 * The options of the TarSpinner component.
 */
export type SpinnerOptions = {
  /**
   * The spinner will have a growing animation, instead of a rotating animation.
   */
  grow?: boolean | string;
  /**
   * The spinner will not include a hidden text for accessibility. You have to add this code directly below the spinner:
   *
   * `<span class="visually-hidden" role="status">Loading…</span>`
   */
  inline?: boolean | string;
  /**
   * The text content to place inside the spinner, usually used for accessibility.
   */
  label?: string;
  /**
   * The accessibility role of the spinner.
   */
  role?: string;
  /**
   * The spinner will have a smaller size, ideal when integrating it within other components, such as buttons.
   */
  small?: boolean | string;
  /**
   * The color variant of the spinner.
   */
  variant?: SpinnerVariant;
};

/**
 * The variants of the TarSpinner component.
 */
export type SpinnerVariant = "primary" | "secondary" | "success" | "danger" | "warning" | "info" | "light" | "dark";
