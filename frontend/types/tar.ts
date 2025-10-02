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


/**
 * The options of the TarAvatar component.
 */
export type AvatarOptions = {
  /**
   * The display name of the user or actor, used in the image replacement text.
   */
  displayName?: string;
  /**
   * The email address of the user, used to load its Gravatar if `url` is falsy.
   */
  emailAddress?: string;
  /**
   * The Font Awesome icon to display.
   */
  icon?: string | string[];
  /**
   * The height of the avatar, in pixels.
   */
  size?: number | string;
  /**
   * The URL of the picture to display in the avatar.
   */
  url?: string;
  /**
   * The color variant of the badge, when displaying an icon.
   */
  variant?: BadgeVariant;
};

/**
 * The options of the TarBadge component.
 */
export type BadgeOptions = {
  /**
   * The badge will be rounded like a pill, using a larger `border-radius`.
   */
  pill?: boolean | string;
  /**
   * The color variant of the badge.
   */
  variant?: BadgeVariant;
};

/**
 * The variants of the TarBadge component.
 */
export type BadgeVariant = "primary" | "secondary" | "success" | "danger" | "warning" | "info" | "light" | "dark";

/**
 * The options of the TarImage component.
 */
export type ImageOptions = {
  /**
   * The text that will replace the image if the source is not found.
   */
  alt?: string;
  /**
   * The image will be displayed in a circle.
   */
  circle?: boolean | string;
  /**
   * The image will scale with its parent width.
   */
  fluid?: boolean | string;
  /**
   * The height of the image, in pixels, without an unit.
   */
  height?: number | string;
  /**
   * The corners of the image will be rounded.
   */
  rounded?: boolean | string;
  /**
   * The source URL of the image.
   */
  src: string;
  /**
   * The image will be given a rounded 1px border appearance.
   */
  thumbnail?: boolean | string;
  /**
   * The width of the image, in pixels, without an unit.
   */
  width?: number | string;
};

/**
 * The options of the TarProgress component.
 */
export type ProgressOptions = {
  /**
   * The progress bar will be animated. The `striped` property must be set to `true` for the animation to function properly.
   */
  animated?: boolean | string;
  /**
   * The accessibility label describing the progress bar.
   */
  ariaLabel?: string;
  /**
   * The text displayed inside the progress bar.
   */
  label?: string;
  /**
   * The maximum value of the progress bar.
   */
  max?: number | string;
  /**
   * The minimum value of the progress bar.
   */
  min?: number | string;
  /**
   * The progress bar will display with a striped style.
   */
  striped?: boolean | string;
  /**
   * The current value of the progress bar, between `min` and `max`.
   */
  value?: number | string;
  /**
   * The color variant of the progress bar.
   */
  variant?: ProgressVariant;
};

/**
 * The variants of the TarProgress component.
 */
export type ProgressVariant = "primary" | "secondary" | "success" | "danger" | "warning" | "info" | "light" | "dark";

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
