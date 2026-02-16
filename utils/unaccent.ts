export default function (value: string): string {
  return value.normalize("NFD").replace(/[\u0300-\u036f]/g, "");
}
