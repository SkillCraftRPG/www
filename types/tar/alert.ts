/**
 * The options of the TarAlert component.
 */
export type AlertOptions = {
  /**
   * The close label for accessibility.
   */
  close?: string;
  /**
   * The alert will display a close button that will hide the alert when clicked.
   */
  dismissible?: boolean | string;
  /**
   * This property allows the alert to be bound onto a `v-model` directive to control its display.
   */
  modelValue?: boolean | string;
  /**
   * The alert will be displayed if this property is true.
   */
  show?: boolean | string;
  /**
   * The color variant of the alert.
   */
  variant?: AlertVariant;
};

/**
 * The variants of the TarButton component.
 */
export type AlertVariant = "primary" | "secondary" | "success" | "danger" | "warning" | "info" | "light" | "dark";
