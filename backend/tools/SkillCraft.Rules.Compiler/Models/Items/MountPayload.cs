using CsvHelper.Configuration.Attributes;
using SkillCraft.Core;

namespace SkillCraft.Rules.Compiler.Models.Items;

internal class MountPayload
{
  [Index(0)]
  [Name("id")]
  public Guid Id { get; set; }

  [Index(1)]
  [Name("slug")]
  public string Slug { get; set; } = string.Empty;

  [Index(2)]
  [Name("name")]
  public string Name { get; set; } = string.Empty;

  [Index(3)]
  [Name("price")]
  public decimal Price { get; set; }

  [Index(4)]
  [Name("vigor")]
  public int Vigor { get; set; }

  [Index(5)]
  [Name("size")]
  public SizeCategory Size { get; set; }

  [Index(6)]
  [Name("load")]
  public int? Load { get; set; }

  [Index(7)]
  [Name("speed")]
  public decimal Speed { get; set; }

  [Index(8)]
  [Name("description")]
  public string Description { get; set; } = string.Empty;

  public override bool Equals(object? obj) => obj is MountPayload mount && mount.Id == Id;
  public override int GetHashCode() => Id.GetHashCode();
  public override string ToString() => $"{Name} | {GetType()} (Id={Id})";
}
