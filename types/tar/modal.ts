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
