using Arcabeasts.Combat;
using Arcabeasts.GameData;
using Arcabeasts.GameData.Arcabeasts.GameData;
using System;
using System.Collections.Generic;

namespace Arcabeasts.Combat
{
    public static class ArcabeastFactory
    {
        public static ArcabeastInstance CreateInstance(ArcabeastDefinition def, string displayName, int level, int experience, List<Guid> learnedMoves)
        {
            var baseInstance = new ArcabeastInstance
            {
                ArcabeastId = def.Id,
                DisplayName = displayName,
                Level = level,
                Experience = experience,
                MaxHP = def.MaxHP,
                MaxMana = def.MaxMana,
                CurrentHP = def.MaxHP,
                CurrentMana = def.MaxMana,
                ManaRegen = def.ManaRegen,
                Speed = def.Speed,
                PhysicalPower = def.PhysicalPower,
                ArcanePower = def.ArcanePower,
                PhysicalDefense = def.PhysicalDefense,
                ArcaneDefense = def.ArcaneDefense,
                Evasiveness = def.Evasiveness,
                TempSpeed = def.Speed,
                TempPhysicalPower = def.PhysicalPower,
                TempArcanePower = def.ArcanePower,
                TempPhysicalDefense = def.PhysicalDefense,
                TempArcaneDefense = def.ArcaneDefense,
                TempEvasiveness = def.Evasiveness,
                DamageMultipliers = new Dictionary<string, double>(def.DamageMultipliers),
                LearnedMoveIds = new List<Guid>(learnedMoves),
                ActiveEffects = new List<ActiveEffect>()
            };

            if (def is FireArcabeast fire)
            {
                return ApplyToSubclass(new FireArcabeastInst
                {
                    BurnChance = fire.BurnChance,
                    BurnDamage = fire.BurnDamage,
                    BurnDuration = fire.BurnDuration,
                    IsStackable = fire.isStackable,
                    PassiveAbilityId = fire.PassiveAbilityId
                }, baseInstance);
            }
            else if (def is GrassArcabeast grass)
            {
                return ApplyToSubclass(new GrassArcabeastInst
                {
                    PoisonChance = grass.PoisonChance,
                    PoisonDamage = grass.PoisonDamage,
                    PoisonDuration = grass.PoisonDuration,
                    IsStackable = grass.isStackable,
                    PassiveAbilityId = grass.PassiveAbilityId
                }, baseInstance);
            }
            else if (def is ElectricArcabeast elec)
            {
                return ApplyToSubclass(new ElectricArcabeastInst
                {
                    ShockDamagePerTurn = elec.ShockDamagePerTurn,
                    ShockStunChance = elec.ShockStunChance,
                    ShockStunDuration = elec.ShockStunDuration,
                    IsStackable = elec.isStackable,
                    PassiveAbilityId = elec.PassiveAbilityId
                }, baseInstance);
            }
            else if (def is WaterArcabeast water)
            {
                return ApplyToSubclass(new WaterArcabeastInst
                {
                    DampenManaDrain = water.DampenManaDrain,
                    DampenChance = water.DampenChance,
                    IStackable = water.isStackable,
                    PassiveAbilityId = water.PassiveAbilityId
                }, baseInstance);
            }
            else if (def is RockArcabeast rock)
            {
                return ApplyToSubclass(new RockArcabeastInst
                {
                    GuardBreakAmount = rock.GuardBreakAmount,
                    GuardBreakChance = rock.GuardBreakChance,
                    IsStackable = rock.isStackable,
                    PassiveAbilityId = rock.PassiveAbilityId
                }, baseInstance);
            }
            else if (def is AirArcabeast air)
            {
                return ApplyToSubclass(new AirArcabeastInst
                {
                    EvasionBoostChance = air.EvasionBoostChance,
                    EvasionBoostAmount = air.EvasionBoostAmount,
                    EvasionBoostDuration = air.EvasionBoostDuration,
                    IsStackable = air.isStackable,
                    PassiveAbilityId = air.PassiveAbilityId
                }, baseInstance);
            }

            return baseInstance;
        }
        private static T ApplyToSubclass<T>(T target, ArcabeastInstance source) where T : ArcabeastInstance
        {
            target.ArcabeastId = source.ArcabeastId;
            target.DisplayName = source.DisplayName;
            target.Level = source.Level;
            target.Experience = source.Experience;
            target.MaxHP = source.MaxHP;
            target.MaxMana = source.MaxMana;
            target.CurrentHP = source.CurrentHP;
            target.CurrentMana = source.CurrentMana;
            target.ManaRegen = source.ManaRegen;
            target.Speed = source.Speed;
            target.PhysicalPower = source.PhysicalPower;
            target.ArcanePower = source.ArcanePower;
            target.PhysicalDefense = source.PhysicalDefense;
            target.ArcaneDefense = source.ArcaneDefense;
            target.Evasiveness = source.Evasiveness;
            target.TempSpeed = source.TempSpeed;
            target.TempPhysicalPower = source.TempPhysicalPower;
            target.TempArcanePower = source.TempArcanePower;
            target.TempPhysicalDefense = source.TempPhysicalDefense;
            target.TempArcaneDefense = source.TempArcaneDefense;
            target.TempEvasiveness = source.TempEvasiveness;
            target.DamageMultipliers = source.DamageMultipliers;
            target.LearnedMoveIds = source.LearnedMoveIds;
            target.ActiveEffects = source.ActiveEffects;
            return target;
        }
    }
}

