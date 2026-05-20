/**
 * The options of a breadcrumb inside the TarBreadcrumb component.
 */
export type Breadcrumb = {
  /**
   * The text to display inside the breadcrumb.
   */
  text: string;
  /**
   * The Nuxt route location to navigate to.
   */
  to?: string;
};

/**
 * The options of the TarBreadcrumb component.
 */
export type BreadcrumbOptions = {
  /**
   * The accessibility label describing the breadcrumbs.
   */
  ariaLabel?: string;
  /**
   * The list of breadcrumbs to display.
   */
  breadcrumbs?: Breadcrumb[];
  /**
   * The divider character or string that will be displayed between breadcrumbs.
   */
  divider?: string;
};
