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
