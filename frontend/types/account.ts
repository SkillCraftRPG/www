import type { Actor } from "./game";

export type Contact = {
  isVerified: boolean;
  verifiedBy?: Actor | null;
  verifiedOn?: string | null;
};

export type CurrentUser = {
  displayName: string;
  emailAddress?: string | null;
  pictureUrl?: string | null;
};

export type Email = Contact & {
  address: string;
};

export type SignInPayload = {
  identifier: string;
  password: string;
};

export type UserProfile = {
  uniqueName: string;
  passwordChangedBy?: Actor | null;
  passwordChangedOn?: string | null;
  hasPassword: boolean;
  email?: Email;
  isConfirmed: boolean;
  firstName?: string | null;
  lastName?: string | null;
  fullName?: string | null;
  language?: string | null;
  authenticatedOn?: string | null;
};
