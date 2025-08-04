using Arcabeasts.GameData.Arcabeasts.GameData;
using System;
using System.Collections.Generic;

namespace Arcabeasts.GameData
{
    public static class ArcabeastDB
    {
        public static List<ArcabeastDefinition> All = new List<ArcabeastDefinition>
        {

            new FireArcabeast
            {
                Name = "Volclaw",
                Id = new Guid("45b08e7a-4e53-4691-b63b-e8d5efc69462"),
                Type = "Fire",
                AssetPath = @"Assets\Arcabeasts\FireTypes\Volclaw.png",
                MaxHP = 45,
                MaxMana = 20,
                ManaRegen = 3,
                Speed = 38,
                PhysicalPower = 48,
                ArcanePower = 10,
                PhysicalDefense = 25,
                ArcaneDefense = 14,
                AllowedMoveTypes = new List<string> { "Fire", "Prime" },
                BurnDamage = 2,
                BurnDuration = 3
            },

            new FireArcabeast
            {
                Name = "Blazegut",
                Id = new Guid("63b34b9a-419a-42ac-9da0-041370612dd4"),
                Type = "Fire",
                AssetPath = @"Assets\Arcabeasts\FireTypes\Blazegut.png",
                MaxHP = 52,
                MaxMana = 18,
                ManaRegen = 2,
                Speed = 26,
                PhysicalPower = 40,
                ArcanePower = 20,
                PhysicalDefense = 30,
                ArcaneDefense = 14,
                AllowedMoveTypes = new List<string> { "Fire", "Prime" },
                BurnDamage = 2,
                BurnDuration = 3
            },

            new FireArcabeast
            {
                Name = "Embrant",
                Id = new Guid("e7154e95-8ca6-4f05-b701-dc9386c4fdeb"),
                Type = "Fire",
                AssetPath = @"Assets\Arcabeasts\FireTypes\Embrant.png",
                MaxHP = 40,
                MaxMana = 25,
                ManaRegen = 4,
                Speed = 28,
                PhysicalPower = 36,
                ArcanePower = 35,
                PhysicalDefense = 18,
                ArcaneDefense = 18,
                AllowedMoveTypes = new List<string> { "Fire", "Prime" },
                BurnDamage = 2,
                BurnDuration = 3
            },

            new FireArcabeast
            {
                Name = "Kindrix",
                Id = new Guid("f5bc8b16-7d26-456e-a558-ce36cd30ec0a"),
                Type = "Fire",
                AssetPath = @"Assets\Arcabeasts\FireTypes\Kindrix.png",
                MaxHP = 42,
                MaxMana = 32,
                ManaRegen = 5,
                Speed = 24,
                PhysicalPower = 32,
                ArcanePower = 30,
                PhysicalDefense = 20,
                ArcaneDefense = 20,
                AllowedMoveTypes = new List<string> { "Fire", "Prime" },
                BurnDamage = 2,
                BurnDuration = 3
            },

            new FireArcabeast
            {
                Name = "Pyrrachid",
                Id = new Guid("4299c7ea-fd75-444c-a9f2-18419d86be1d"),
                Type = "Fire",
                AssetPath = @"Assets\Arcabeasts\FireTypes\Pyrrachid.png",
                MaxHP = 38,
                MaxMana = 22,
                ManaRegen = 3,
                Speed = 30,
                PhysicalPower = 28,
                ArcanePower = 28,
                PhysicalDefense = 30,
                ArcaneDefense = 24,
                AllowedMoveTypes = new List<string> { "Fire", "Prime" },
                BurnDamage = 2,
                BurnDuration = 3
            },

            new FireArcabeast
            {
                Name = "Scaldron",
                Id = new Guid("6147234c-dc4e-4cb1-ba00-871a72f45a10"),
                Type = "Fire",
                AssetPath = @"Assets\Arcabeasts\FireTypes\Scaldron.png",
                MaxHP = 43,
                MaxMana = 26,
                ManaRegen = 4,
                Speed = 34,
                PhysicalPower = 30,
                ArcanePower = 26,
                PhysicalDefense = 24,
                ArcaneDefense = 17,
                AllowedMoveTypes = new List<string> { "Fire", "Prime" },
                BurnDamage = 2,
                BurnDuration = 3
            },

            new WaterArcabeast
            {
                Name = "Torrivex",
                Id = new Guid("a73d7b32-e2d4-41e5-89cb-a16572e8e29a"),
                Type = "Water",
                AssetPath = @"Assets\Arcabeasts\WaterTypes\Torrivex.png",
                MaxHP = 42,
                MaxMana = 30,
                ManaRegen = 5,
                Speed = 38,
                PhysicalPower = 28,
                ArcanePower = 28,
                PhysicalDefense = 18,
                ArcaneDefense = 16,
                AllowedMoveTypes = new List<string> { "Water", "Prime" },
                DampenManaDrain = 15
            },

            new WaterArcabeast
            {
                Name = "Aquilure",
                Id = new Guid("e0db2e2a-3758-4cb0-a20c-268684dede5e"),
                Type = "Water",
                AssetPath = @"Assets\Arcabeasts\WaterTypes\Aquilure.png",
                MaxHP = 50,
                MaxMana = 20,
                ManaRegen = 3,
                Speed = 34,
                PhysicalPower = 30,
                ArcanePower = 22,
                PhysicalDefense = 24,
                ArcaneDefense = 20,
                AllowedMoveTypes = new List<string> { "Water", "Prime" },
                DampenManaDrain = 15
            },

            new WaterArcabeast
            {
                Name = "Cryoslip",
                Id = new Guid("755733c9-26fc-4400-b75d-1e8027395b95"),
                Type = "Water",
                AssetPath = @"Assets\Arcabeasts\WaterTypes\Cryoslip.png",
                MaxHP = 38,
                MaxMana = 32,
                ManaRegen = 5,
                Speed = 36,
                PhysicalPower = 30,
                ArcanePower = 26,
                PhysicalDefense = 22,
                ArcaneDefense = 16,
                AllowedMoveTypes = new List<string> { "Water", "Prime" },
                DampenManaDrain = 15
            },

            new WaterArcabeast
            {
                Name = "Drizzleon",
                Id = new Guid("78e24b38-0afb-4bf4-a776-74f686298364"),
                Type = "Water",
                AssetPath = @"Assets\Arcabeasts\WaterTypes\Drizzleon.png",
                MaxHP = 44,
                MaxMana = 26,
                ManaRegen = 4,
                Speed = 32,
                PhysicalPower = 22,
                ArcanePower = 28,
                PhysicalDefense = 24,
                ArcaneDefense = 24,
                AllowedMoveTypes = new List<string> { "Water", "Prime" },
                DampenManaDrain = 15
            },

            new WaterArcabeast
            {
                Name = "Kelvurne",
                Id = new Guid("0fac5103-12dc-4591-a946-38dcda37db2a"),
                Type = "Water",
                AssetPath = @"Assets\Arcabeasts\WaterTypes\Kelvurne.png",
                MaxHP = 35,
                MaxMana = 30,
                ManaRegen = 6,
                Speed = 30,
                PhysicalPower = 18,
                ArcanePower = 36,
                PhysicalDefense = 26,
                ArcaneDefense = 25,
                AllowedMoveTypes = new List<string> { "Water", "Prime" },
                DampenManaDrain = 15
            },

            new WaterArcabeast
            {
                Name = "Murkryl",
                Id = new Guid("19f821ea-ca80-4edf-8a1e-ac5929500186"),
                Type = "Water",
                AssetPath = @"Assets\Arcabeasts\WaterTypes\Murkryl.png",
                MaxHP = 46,
                MaxMana = 24,
                ManaRegen = 3,
                Speed = 28,
                PhysicalPower = 34,
                ArcanePower = 24,
                PhysicalDefense = 22,
                ArcaneDefense = 22,
                AllowedMoveTypes = new List<string> { "Water", "Prime" },
                DampenManaDrain = 15
            },

            new GrassArcabeast
            {
                Name = "Verdeedle",
                Id = new Guid("7d15988c-2c67-46d8-ab56-22b9a55c9b55"),
                Type = "Grass",
                AssetPath = @"Assets\Arcabeasts\GrassTypes\Verdeedle.png",
                MaxHP = 44,
                MaxMana = 28,
                ManaRegen = 4,
                Speed = 30,
                PhysicalPower = 22,
                ArcanePower = 30,
                PhysicalDefense = 28,
                ArcaneDefense = 18,
                AllowedMoveTypes = new List<string> { "Grass", "Prime" },
                PoisonDamage = 4,
                PoisonDuration = 3
            },

            new GrassArcabeast
            {
                Name = "Bloomurk",
                Id = new Guid("ae620350-0f53-4044-a43e-e983f08396ed"),
                Type = "Grass",
                AssetPath = @"Assets\Arcabeasts\GrassTypes\Bloomurk.png",
                MaxHP = 35,
                MaxMana = 34,
                ManaRegen = 5,
                Speed = 38,
                PhysicalPower = 20,
                ArcanePower = 26,
                PhysicalDefense = 28,
                ArcaneDefense = 19,
                AllowedMoveTypes = new List<string> { "Grass", "Prime" },
                PoisonDamage = 4,
                PoisonDuration = 3
            },

            new GrassArcabeast
            {
                Name = "Fungloom",
                Id = new Guid("53c66585-d0a5-40c9-94fb-1857b47dc7ee"),
                Type = "Grass",
                AssetPath = @"Assets\Arcabeasts\GrassTypes\Fungloom.png",
                MaxHP = 42,
                MaxMana = 26,
                ManaRegen = 4,
                Speed = 30,
                PhysicalPower = 26,
                ArcanePower = 26,
                PhysicalDefense = 24,
                ArcaneDefense = 26,
                AllowedMoveTypes = new List<string> { "Grass", "Prime" },
                PoisonDamage = 4,
                PoisonDuration = 3
            },

            new GrassArcabeast
            {
                Name = "Grovejaw",
                Id = new Guid("46528c43-de1e-4cce-8625-321fa83ef96d"),
                Type = "Grass",
                AssetPath = @"Assets\Arcabeasts\GrassTypes\Grovejaw.png",
                MaxHP = 38,
                MaxMana = 24,
                ManaRegen = 3,
                Speed = 28,
                PhysicalPower = 34,
                ArcanePower = 22,
                PhysicalDefense = 26,
                ArcaneDefense = 28,
                AllowedMoveTypes = new List<string> { "Grass", "Prime" },
                PoisonDamage = 4,
                PoisonDuration = 3
            },

            new GrassArcabeast
            {
                Name = "Sapdrip",
                Id = new Guid("66fb660a-bccb-4f80-a3d4-06f11a6d983f"),
                Type = "Grass",
                AssetPath = @"Assets\Arcabeasts\GrassTypes\Sapdrip.png",
                MaxHP = 40,
                MaxMana = 28,
                ManaRegen = 4,
                Speed = 25,
                PhysicalPower = 28,
                ArcanePower = 28,
                PhysicalDefense = 25,
                ArcaneDefense = 26,
                AllowedMoveTypes = new List<string> { "Grass", "Prime" },
                PoisonDamage = 4,
                PoisonDuration = 3
            },

            new GrassArcabeast
            {
                Name = "Thornetusk",
                Id = new Guid("7bdc0bef-d502-4a55-a00d-660a55e51350"),
                Type = "Grass",
                AssetPath = @"Assets\Arcabeasts\GrassTypes\Thornetusk.png",
                MaxHP = 42,
                MaxMana = 26,
                ManaRegen = 3,
                Speed = 36,
                PhysicalPower = 20,
                ArcanePower = 30,
                PhysicalDefense = 24,
                ArcaneDefense = 22,
                AllowedMoveTypes = new List<string> { "Grass", "Prime" },
                PoisonDamage = 4,
                PoisonDuration = 3
            },

            new ElectricArcabeast
            {
                Name = "Zappleech",
                Id = new Guid("201c3762-4824-49ff-ad87-4c4e1ddb4263"),
                Type = "Electric",
                AssetPath = @"Assets\Arcabeasts\ElectricTypes\Zappleech.png",
                MaxHP = 40,
                MaxMana = 30,
                ManaRegen = 4,
                Speed = 32,
                PhysicalPower = 24,
                ArcanePower = 26,
                PhysicalDefense = 24,
                ArcaneDefense = 24,
                AllowedMoveTypes = new List<string> { "Electric", "Prime" },
                ShockDamagePerTurn = 2,
                ShockStunChance = 0.25,
                ShockStunDuration = 2
            },

            new ElectricArcabeast
            {
                Name = "Ampvine",
                Id = new Guid("0a0b6894-f462-4416-aa22-9209c8d395e9"),
                Type = "Electric",
                AssetPath = @"Assets\Arcabeasts\ElectricTypes\Ampvine.png",
                MaxHP = 36,
                MaxMana = 28,
                ManaRegen = 3,
                Speed = 28,
                PhysicalPower = 26,
                ArcanePower = 30,
                PhysicalDefense = 24,
                ArcaneDefense = 28,
                AllowedMoveTypes = new List<string> { "Electric", "Prime" },
                ShockDamagePerTurn = 2,
                ShockStunChance = 0.25,
                ShockStunDuration = 2
            },

            new ElectricArcabeast
            {
                Name = "Fulgirush",
                Id = new Guid("3d69a5b2-cf66-46de-a784-a5db4d228a56"),
                Type = "Electric",
                AssetPath = @"Assets\Arcabeasts\ElectricTypes\Fulgirush.png",
                MaxHP = 38,
                MaxMana = 26,
                ManaRegen = 3,
                Speed = 34,
                PhysicalPower = 28,
                ArcanePower = 24,
                PhysicalDefense = 28,
                ArcaneDefense = 22,
                AllowedMoveTypes = new List<string> { "Electric", "Prime" },
                ShockDamagePerTurn = 2,
                ShockStunChance = 0.25,
                ShockStunDuration = 2
            },

            new ElectricArcabeast
            {
                Name = "Lurexion",
                Id = new Guid("07d27347-b728-43d8-9903-4f39265717e2"),
                Type = "Electric",
                AssetPath = @"Assets\Arcabeasts\ElectricTypes\Lurexion.png",
                MaxHP = 34,
                MaxMana = 28,
                ManaRegen = 4,
                Speed = 38,
                PhysicalPower = 30,
                ArcanePower = 22,
                PhysicalDefense = 24,
                ArcaneDefense = 24,
                AllowedMoveTypes = new List<string> { "Electric", "Prime" },
                ShockDamagePerTurn = 2,
                ShockStunChance = 0.25,
                ShockStunDuration = 2
            },

            new ElectricArcabeast
            {
                Name = "Thundrake",
                Id = new Guid("ddf6500a-c08a-4a7a-939a-8024213ff347"),
                Type = "Electric",
                AssetPath = @"Assets\Arcabeasts\ElectricTypes\Thundrake.png",
                MaxHP = 42,
                MaxMana = 24,
                ManaRegen = 3,
                Speed = 30,
                PhysicalPower = 28,
                ArcanePower = 26,
                PhysicalDefense = 26,
                ArcaneDefense = 24,
                AllowedMoveTypes = new List<string> { "Electric", "Prime" },
                ShockDamagePerTurn = 2,
                ShockStunChance = 0.25,
                ShockStunDuration = 2
            },

            new ElectricArcabeast
            {
                Name = "Voltanaut",
                Id = new Guid("1c297134-a8a6-4127-b773-d6d06c958e61"),
                Type = "Electric",
                AssetPath = @"Assets\Arcabeasts\ElectricTypes\Voltanaut.png",
                MaxHP = 38,
                MaxMana = 28,
                ManaRegen = 4,
                Speed = 34,
                PhysicalPower = 26,
                ArcanePower = 26,
                PhysicalDefense = 24,
                ArcaneDefense = 24,
                AllowedMoveTypes = new List<string> { "Electric", "Prime" },
                ShockDamagePerTurn = 2,
                ShockStunChance = 0.25,
                ShockStunDuration = 2
            },
            new RockArcabeast
            {
                Name = "Terraclaw",
                Id = new Guid("ea51c658-bfd8-4338-9b0b-3baefbad1a3b"),
                Type = "Rock",
                AssetPath = @"Assets\Arcabeasts\RockTypes\Terraclaw.png",
                MaxHP = 44,
                MaxMana = 22,
                ManaRegen = 2,
                Speed = 20,
                PhysicalPower = 26,
                ArcanePower = 20,
                PhysicalDefense = 40,
                ArcaneDefense = 28,
                AllowedMoveTypes = new List<string> { "Rock", "Prime" },
                GuardBreakAmount = 10,
                GuardBreakChance = 20
            },

            new RockArcabeast
            {
                Name = "Geodrail",
                Id = new Guid("fbfad4d1-b1db-4944-9d2f-2fab2365fe03"),
                Type = "Rock",
                AssetPath = @"Assets\Arcabeasts\RockTypes\Geodrail.png",
                MaxHP = 38,
                MaxMana = 24,
                ManaRegen = 2,
                Speed = 24,
                PhysicalPower = 30,
                ArcanePower = 20,
                PhysicalDefense = 36,
                ArcaneDefense = 28,
                AllowedMoveTypes = new List<string> { "Rock", "Prime" },
                GuardBreakAmount = 10,
                GuardBreakChance = 20
            },

            new RockArcabeast
            {
                Name = "Gravlance",
                Id = new Guid("b53624a6-dd90-46b7-9f16-1b9b42ed509c"),
                Type = "Rock",
                AssetPath = @"Assets\Arcabeasts\RockTypes\Gravlance.png",
                MaxHP = 42,
                MaxMana = 26,
                ManaRegen = 3,
                Speed = 18,
                PhysicalPower = 24,
                ArcanePower = 22,
                PhysicalDefense = 42,
                ArcaneDefense = 26,
                AllowedMoveTypes = new List<string> { "Rock", "Prime" },
                GuardBreakAmount = 10,
                GuardBreakChance = 20
            },

            new RockArcabeast
            {
                Name = "Obscavern",
                Id = new Guid("58fa9331-9a90-43cc-a262-7403e8f0b30b"),
                Type = "Rock",
                AssetPath = @"Assets\Arcabeasts\RockTypes\Obscavern.png",
                MaxHP = 46,
                MaxMana = 18,
                ManaRegen = 1,
                Speed = 20,
                PhysicalPower = 28,
                ArcanePower = 26,
                PhysicalDefense = 38,
                ArcaneDefense = 24,
                AllowedMoveTypes = new List<string> { "Rock", "Prime" },
                GuardBreakAmount = 10,
                GuardBreakChance = 20
            },

            new RockArcabeast
            {
                Name = "Runebulk",
                Id = new Guid("16469f9e-72c8-4a77-9e76-aa4bab7aa624"),
                Type = "Rock",
                AssetPath = @"Assets\Arcabeasts\RockTypes\Runebulk.png",
                MaxHP = 40,
                MaxMana = 22,
                ManaRegen = 2,
                Speed = 22,
                PhysicalPower = 26,
                ArcanePower = 24,
                PhysicalDefense = 42,
                ArcaneDefense = 24,
                AllowedMoveTypes = new List<string> { "Rock", "Prime" },
                GuardBreakAmount = 10,
                GuardBreakChance = 20
            },

            new RockArcabeast
            {
                Name = "Shatterox",
                Id = new Guid("df489e50-e4f1-4b93-9f63-59a9193b52a1"),
                Type = "Rock",
                AssetPath = @"Assets\Arcabeasts\RockTypes\Shatterox.png",
                MaxHP = 44,
                MaxMana = 20,
                ManaRegen = 2,
                Speed = 20,
                PhysicalPower = 28,
                ArcanePower = 24,
                PhysicalDefense = 40,
                ArcaneDefense = 24,
                AllowedMoveTypes = new List<string> { "Rock", "Prime" },
                GuardBreakAmount = 10,
                GuardBreakChance = 20
            },

            new AirArcabeast
            {
                Name = "Zephrax",
                Id = new Guid("ec32d3d3-8bb4-4ce9-89a0-65b7c5dc3080"),
                Type = "Air",
                AssetPath = @"Assets\Arcabeasts\AirTypes\Zephrax.png",
                MaxHP = 36,
                MaxMana = 26,
                ManaRegen = 4,
                Speed = 46,
                PhysicalPower = 28,
                ArcanePower = 28,
                PhysicalDefense = 18,
                ArcaneDefense = 18,
                AllowedMoveTypes = new List<string> { "Air", "Prime" },
                EvasionBoostChance = 0.2,
                EvasionBoostDuration = 2,
                EvasionBoostAmount = 10
            },

            new AirArcabeast
            {
                Name = "Aeriscale",
                Id = new Guid("7299c33c-fae2-4522-9e4e-127b53ce3e52"),
                Type = "Air",
                AssetPath = @"Assets\Arcabeasts\AirTypes\Aeriscale.png",
                MaxHP = 40,
                MaxMana = 24,
                ManaRegen = 4,
                Speed = 42,
                PhysicalPower = 30,
                ArcanePower = 22,
                PhysicalDefense = 22,
                ArcaneDefense = 20,
                AllowedMoveTypes = new List<string> { "Air", "Prime" },
                EvasionBoostChance = 0.2,
                EvasionBoostDuration = 2,
                EvasionBoostAmount = 10
            },

            new AirArcabeast
            {
                Name = "Gustowl",
                Id = new Guid("77c72b9c-8604-4f5c-b9c4-90b5f307b3ae"),
                Type = "Air",
                AssetPath = @"Assets\Arcabeasts\AirTypes\Gustowl.png",
                MaxHP = 42,
                MaxMana = 26,
                ManaRegen = 4,
                Speed = 38,
                PhysicalPower = 26,
                ArcanePower = 26,
                PhysicalDefense = 22,
                ArcaneDefense = 20,
                AllowedMoveTypes = new List<string> { "Air", "Prime" },
                EvasionBoostChance = 0.2,
                EvasionBoostDuration = 2,
                EvasionBoostAmount = 10
            },

            new AirArcabeast
            {
                Name = "Skyrant",
                Id = new Guid("5fcf3015-abb6-4b39-95d9-29e27d93ec47"),
                Type = "Air",
                AssetPath = @"Assets\Arcabeasts\AirTypes\Skyrant.png",
                MaxHP = 38,
                MaxMana = 28,
                ManaRegen = 4,
                Speed = 44,
                PhysicalPower = 24,
                ArcanePower = 28,
                PhysicalDefense = 20,
                ArcaneDefense = 20,
                AllowedMoveTypes = new List<string> { "Air", "Prime" },
                EvasionBoostChance = 0.2,
                EvasionBoostDuration = 2,
                EvasionBoostAmount = 10
            },

            new AirArcabeast
            {
                Name = "Twistipede",
                Id = new Guid("2d848b12-7d89-4c8a-b918-0fc1c8de402b"),
                Type = "Air",
                AssetPath = @"Assets\Arcabeasts\AirTypes\Twistipede.png",
                MaxHP = 39,
                MaxMana = 25,
                ManaRegen = 4,
                Speed = 45,
                PhysicalPower = 26,
                ArcanePower = 26,
                PhysicalDefense = 20,
                ArcaneDefense = 19,
                AllowedMoveTypes = new List<string> { "Air", "Prime" },
                EvasionBoostChance = 0.2,
                EvasionBoostDuration = 2,
                EvasionBoostAmount = 10
            },

            new AirArcabeast
            {
                Name = "Whirlighast",
                Id = new Guid("c166fdc6-b2f9-4c9a-8db8-d6126b39462c"),
                Type = "Air",
                AssetPath = @"Assets\Arcabeasts\AirTypes\Whirlighast.png",
                MaxHP = 40,
                MaxMana = 24,
                ManaRegen = 4,
                Speed = 43,
                PhysicalPower = 28,
                ArcanePower = 24,
                PhysicalDefense = 20,
                ArcaneDefense = 22,
                AllowedMoveTypes = new List<string> { "Air", "Prime" },
                EvasionBoostChance = 0.2,
                EvasionBoostDuration = 2,
                EvasionBoostAmount = 10
            },

            new PrimeArcabeast
            {
                Name = "Nullinex",
                Id = new Guid("398cd942-d0de-4059-94a1-df44e1bb0175"),
                Type = "Prime",
                AssetPath = @"Assets\Arcabeasts\PrimeTypes\Nullinex.png",
                MaxHP = 42,
                MaxMana = 32,
                ManaRegen = 5,
                Speed = 34,
                PhysicalPower = 20,
                ArcanePower = 20,
                PhysicalDefense = 36,
                ArcaneDefense = 36,
                AllowedMoveTypes = new List<string> { "Prime", "Prime" },
            },

            new PrimeArcabeast
            {
                Name = "Balvyrn",
                Id = new Guid("2f4c1679-2062-4e42-9b39-e1b73b81dc9e"),
                Type = "Prime",
                AssetPath = @"Assets\Arcabeasts\PrimeTypes\Balvyrn.png",
                MaxHP = 44,
                MaxMana = 30,
                ManaRegen = 5,
                Speed = 32,
                PhysicalPower = 22,
                ArcanePower = 18,
                PhysicalDefense = 38,
                ArcaneDefense = 36,
                AllowedMoveTypes = new List<string> { "Prime", "Prime" },
            },

            new PrimeArcabeast
            {
                Name = "Coreid",
                Id = new Guid("4d3e61f2-68d7-49bc-98a6-1e52b58be632"),
                Type = "Prime",
                AssetPath = @"Assets\Arcabeasts\PrimeTypes\Coreid.png",
                MaxHP = 40,
                MaxMana = 36,
                ManaRegen = 6,
                Speed = 34,
                PhysicalPower = 18,
                ArcanePower = 22,
                PhysicalDefense = 34,
                ArcaneDefense = 36,
                AllowedMoveTypes = new List<string> { "Prime", "Prime" },
            },

            new PrimeArcabeast
            {
                Name = "Evolynx",
                Id = new Guid("18c4519a-e3a0-439f-9bb1-6211ad7584f1"),
                Type = "Prime",
                AssetPath = @"Assets\Arcabeasts\PrimeTypes\Evolynx.png",
                MaxHP = 38,
                MaxMana = 40,
                ManaRegen = 6,
                Speed = 30,
                PhysicalPower = 19,
                ArcanePower = 20,
                PhysicalDefense = 36,
                ArcaneDefense = 37,
                AllowedMoveTypes = new List<string> { "Prime", "Prime" },
            },

            new PrimeArcabeast
            {
                Name = "Precurion",
                Id = new Guid("6e4d530b-679c-4528-bfc6-e949e5412d7a"),
                Type = "Prime",
                AssetPath = @"Assets\Arcabeasts\PrimeTypes\Precurion.png",
                MaxHP = 36,
                MaxMana = 34,
                ManaRegen = 5,
                Speed = 36,
                PhysicalPower = 21,
                ArcanePower = 21,
                PhysicalDefense = 36,
                ArcaneDefense = 36,
                AllowedMoveTypes = new List<string> { "Prime", "Prime" },
            },

            new PrimeArcabeast
            {
                Name = "Myndrel",
                Id = new Guid("1bfb362f-f872-4a90-bc4a-05fcad048cad"),
                Type = "Prime",
                AssetPath = @"Assets\Arcabeasts\PrimeTypes\Myndrel.png",
                MaxHP = 39,
                MaxMana = 32,
                ManaRegen = 5,
                Speed = 33,
                PhysicalPower = 24,
                ArcanePower = 18,
                PhysicalDefense = 38,
                ArcaneDefense = 36,
                AllowedMoveTypes = new List<string> { "Prime", "Prime" },
            },

        };
    }
}
