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
