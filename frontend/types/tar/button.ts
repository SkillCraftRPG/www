/**
 * The sizes of the TarButton component.
 */
export type ButtonSize = "small" | "medium" | "large";

/**
 * The options of the TarButton component.
 */
export type ButtonOptions = {
  /**
   * The button will display with a disabled style and will not react to events.
   */
  disabled?: boolean | string;
  /**
   * The Font Awesome icon to display when not loading.
   */
  icon?: string | string[];
  /**
   * The button will display a spinner instead of its icon.
   */
  loading?: boolean | string;
  /**
   * The name of the button, used when submitting forms.
   */
  name?: string;
  /**
   * The button text will not wrap.
   */
  nowrap?: boolean | string;
  /**
   * The button will use a colored outline instead of solid colors.
   */
  outline?: boolean | string;
  /**
   * The size of the button.
   */
  size?: ButtonSize;
  /**
   * The hidden text for accessibility of the button's spinner.
   */
  status?: string;
  /**
   * The text displayed inside the button.
   */
  text?: string;
  /**
   * The type of the button.
   */
  type?: ButtonType;
  /**
   * The value of the button, used when submitting forms.
   */
  value?: string;
  /**
   * The color variant of the button.
   */
  variant?: ButtonVariant;
};

/**
 * The types of the TarButton component.
 */
export type ButtonType = "button" | "submit" | "reset";

/**
 * The variants of the TarButton component.
 */
export type ButtonVariant = "primary" | "secondary" | "success" | "danger" | "warning" | "info" | "light" | "dark" | "link";
