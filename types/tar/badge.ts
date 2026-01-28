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
