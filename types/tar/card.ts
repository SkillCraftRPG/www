import type { ImageOptions } from "./image";

/**
 * The options of the TarCard component.
 */
export type CardOptions = {
  /**
   * The parameters of the bottom image.
   */
  bottomImage?: ImageOptions;
  /**
   * The subtitle that will be displayed inside the card.
   */
  subtitle?: string;
  /**
   * The title that will be displayed inside the card.
   */
  title?: string;
  /**
   * The parameters of the top image.
   */
  topImage?: ImageOptions;
};
