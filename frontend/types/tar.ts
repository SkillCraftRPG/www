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


/**
 * The fullscreen modes of the TarModal component.
 */
export type FullscreenMode = boolean | "below-small" | "below-medium" | "below-large" | "below-x-large" | "below-xx-large";

/**
 * The options of the TarModal component.
 */
export type ModalOptions = {
  /**
   * The modal will be vertically centered.
   */
  centered?: boolean | string;
  /**
   * The close label for accessibility.
   */
  close?: string;
  /**
   * The modal will be animated using a fading transition when opened or closed.
   */
  fade?: boolean | string;
  /**
   * The fullscreen mode of the modal.
   */
  fullscreen?: FullscreenMode;
  /**
   * The unique identifier of the modal.
   */
  id?: string;
  /**
   * A scrollbar will be displayed inside the modal.
   */
  scrollable?: boolean | string;
  /**
   * The size of the modal.
   */
  size?: ModalSize;
  /**
   * The modal will not close when clicking outside of it.
   */
  static?: boolean | string;
  /**
   * The title that will appear in the toast header.
   */
  title?: string;
};

/**
 * The sizes of the TarModal component.
 */
export type ModalSize = "small" | "medium" | "large" | "x-large";




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
