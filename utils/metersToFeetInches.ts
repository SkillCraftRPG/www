export default function (meters: number): number[] {
  const inches: number = (meters * 100) / 2.54;
  return [Math.floor(inches / 12), inches % 12];
}
