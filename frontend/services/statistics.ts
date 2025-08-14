import attributesData from "~/assets/data/attributes.json";
import statisticsData from "~/assets/data/statistics.json";
import type { Attribute, Statistic } from "~/types/game";
import { mapAttribute, mapStatistic } from ".";

function areEqual(a: string, b: string): boolean {
  return a.trim().toLowerCase() === b.trim().toLowerCase();
}

type GetStatisticOptions = {
  attribute?: boolean;
};
export function getStatistic(idOrSlug: string, options?: GetStatisticOptions): Statistic | undefined {
  options ??= {};

  const data = statisticsData.find((statistic) => areEqual(statistic.id, idOrSlug) || areEqual(statistic.slug, idOrSlug));
  if (!data) {
    return undefined;
  }
  const statistic: Statistic = mapStatistic(data);

  if (options.attribute) {
    const attribute = attributesData.find(({ id }) => id === statistic.attributeId);
    if (attribute) {
      statistic.attribute = mapAttribute(attribute);
    }
  }

  return statistic;
}

type GetStatisticsOptions = {
  attribute?: boolean;
};
export function getStatistics(options?: GetStatisticsOptions): Statistic[] {
  options ??= {};

  const statistics: Statistic[] = statisticsData.map(mapStatistic);

  if (options.attribute) {
    const attributes: Map<string, Attribute> = new Map(attributesData.map((attribute) => [attribute.id, mapAttribute(attribute)]));
    statistics.forEach((statistic) => (statistic.attribute = attributes.get(statistic.attributeId)));
  }

  return statistics;
}
