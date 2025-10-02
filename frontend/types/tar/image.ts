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
