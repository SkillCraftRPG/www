import type { BadgeVariant } from "./badge";

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
