using System;
using System.Collections.Generic;

namespace Arcabeasts.GameData
{
    public static class ArcabeastAbilityDB
    {
        public static List<ArcabeastAbility> All = new List<ArcabeastAbility>
        {
            // Offensive Physical
            new OffensiveAbility {
                Id = new Guid("f38f4874-6940-47b5-921c-34dc934fba25"),
                Name = "Flare Slash",
                Type = "Fire",
                Class = AbilityClass.Physical,
                BasePower = 3,
                ManaCost = 10,
                Accuracy = 0.95,
                Velocity = 1
            },
            new OffensiveAbility {
                Id = new Guid("0410ec6b-9eb2-44cf-a071-2778f52f1e6b"),
                Name = "Ember Jab",
                Type = "Fire",
                Class = AbilityClass.Physical,
                BasePower = 2,
                ManaCost = 5,
                Accuracy = 1.0,
                Velocity = 2
            },
            new OffensiveAbility {
                Id = new Guid("b06dec61-ff5d-4eaf-ab9d-45725842f6d5"),
                Name = "Scorch Strike",
                Type = "Fire",
                Class = AbilityClass.Physical,
                BasePower = 4,
                ManaCost = 14,
                Accuracy = 0.85,
                Velocity = 0.8
            },
            new OffensiveAbility {
                Id = new Guid("34e66109-21ac-4509-b600-6343347b2569"),
                Name = "Molten Charge",
                Type = "Fire",
                Class = AbilityClass.Physical,
                BasePower = 5,
                ManaCost = 16,
                Accuracy = 1.0,
                Velocity = 0.6,
                IsMultiTurn = true
            },
            new OffensiveAbility {
                Id = new Guid("b5190e62-da02-4ea5-a193-a5c6ba2397ff"),
                Name = "Blazing Claw",
                Type = "Fire",
                Class = AbilityClass.Physical,
                BasePower = 3,
                ManaCost = 11,
                Accuracy = 0.9,
                Velocity = 1.1
            },
            new OffensiveAbility {
                Id = new Guid("b3379d2c-b4ba-4c6b-8dab-34e6cdd6a743"),
                Name = "Inferno Punch",
                Type = "Fire",
                Class = AbilityClass.Physical,
                BasePower = 4,
                ManaCost = 13,
                Accuracy = 0.9,
                Velocity = 0.9
            },

            // Defensive Physical
            new DefensiveAbility {
                Id = new Guid("f5747684-7817-41af-a972-3cb91e1253d2"),
                Name = "Heat Harden",
                Type = "Fire",
                Class = AbilityClass.Physical,
                ManaCost = 8,
                TargetStat = "PhysicalDefense",
                BuffPercentage = 0.25,
                Duration = 3,
                CanStack = false
            },
            new DefensiveAbility {
                Id = new Guid("148e7358-3450-442e-bd3a-fce4a245e795"),
                Name = "Adrenal Burn",
                Type = "Fire",
                Class = AbilityClass.Physical,
                ManaCost = 10,
                TargetStat = "Speed",
                BuffPercentage = 0.2,
                Duration = 2,
                CanStack = true
            },
            new DefensiveAbility {
                Id = new Guid("66a195fe-96ac-4577-a8e2-060983f0034c"),
                Name = "Vital Flame",
                Type = "Fire",
                Class = AbilityClass.Physical,
                ManaCost = 12,
                TargetStat = "MaxHP",
                BuffPercentage = 0.15,
                Duration = 0, // remainder of battle
                CanStack = false
            },

            // Offensive Arcane
            new OffensiveAbility {
                Id = new Guid("c775b2bb-b8cc-4356-90d6-45dd125b81fe"),
                Name = "Ash Bolt",
                Type = "Fire",
                Class = AbilityClass.Arcane,
                BasePower = 3,
                ManaCost = 9,
                Accuracy = 0.95,
                Velocity = 1.2
            },
            new OffensiveAbility {
                Id = new Guid("8f0fd1ee-0dc3-405a-844e-275569d16967"),
                Name = "Ignite",
                Type = "Fire",
                Class = AbilityClass.Arcane,
                BasePower = 2,
                ManaCost = 6,
                Accuracy = 1.0,
                Velocity = 1.5
            },
            new OffensiveAbility {
                Id = new Guid("1f929b5c-d032-4f63-adf1-61c57b4581b4"),
                Name = "Flame Surge",
                Type = "Fire",
                Class = AbilityClass.Arcane,
                BasePower = 5,
                ManaCost = 18,
                Accuracy = 0.8,
                Velocity = 0.7
            },
            new OffensiveAbility {
                Id = new Guid("865acce6-37e0-4a70-8918-2d87f7a22e67"),
                Name = "Cinder Ray",
                Type = "Fire",
                Class = AbilityClass.Arcane,
                BasePower = 4,
                ManaCost = 12,
                Accuracy = 0.9,
                Velocity = 1
            },
            new OffensiveAbility {
                Id = new Guid("97df1834-4a81-4918-ab68-03c77524b226"),
                Name = "Firestorm",
                Type = "Fire",
                Class = AbilityClass.Arcane,
                BasePower = 5,
                ManaCost = 15,
                Accuracy = 0.85,
                Velocity = 0.9
            },
            new OffensiveAbility {
                Id = new Guid("47a0068e-b2f1-4a61-9b88-8fcb7f831060"),
                Name = "Thermo Spike",
                Type = "Fire",
                Class = AbilityClass.Arcane,
                BasePower = 3,
                ManaCost = 11,
                Accuracy = 0.95,
                Velocity = 1
            },

            // Defensive Arcane
            new DefensiveAbility {
                Id = new Guid("c0e38c47-125a-4cd0-bcf3-6df58e8a5811"),
                Name = "Mana Furnace",
                Type = "Fire",
                Class = AbilityClass.Arcane,
                ManaCost = 10,
                TargetStat = "ManaRegen",
                BuffPercentage = 0.3,
                Duration = 3,
                CanStack = true
            },
            new DefensiveAbility {
                Id = new Guid("74700739-00e8-40e0-9753-c11677d49aa9"),
                Name = "Arcane Blaze",
                Type = "Fire",
                Class = AbilityClass.Arcane,
                ManaCost = 14,
                TargetStat = "ArcanePower",
                BuffPercentage = 0.2,
                Duration = 2,
                CanStack = false
            },
            new DefensiveAbility {
                Id = new Guid("e7227192-9e07-4621-9690-e880b5227753"),
                Name = "Fire Ward",
                Type = "Fire",
                Class = AbilityClass.Arcane,
                ManaCost = 13,
                TargetStat = "ArcaneDefense",
                BuffPercentage = 0.25,
                Duration = 3,
                CanStack = false
            },
            // --- Water Type Abilities ---

            // Offensive Physical
            new OffensiveAbility {
                Id = new Guid("715d1161-921c-4b1d-9717-c68627ed9d46"),
                Name = "Tide Slam",
                Type = "Water",
                Class = AbilityClass.Physical,
                BasePower = 3,
                ManaCost = 10,
                Accuracy = 0.95,
                Velocity = 1
            },
            new OffensiveAbility {
                Id = new Guid("bccac128-2763-49ad-ab62-8c3ef0a8a9a1"),
                Name = "Crashing Fin",
                Type = "Water",
                Class = AbilityClass.Physical,
                BasePower = 2,
                ManaCost = 6,
                Accuracy = 1.0,
                Velocity = 1.5
            },
            new OffensiveAbility {
                Id = new Guid("7c2b1fa4-a5ce-4ba8-98b5-c76fbc291635"),
                Name = "Deep Crush",
                Type = "Water",
                Class = AbilityClass.Physical,
                BasePower = 4,
                ManaCost = 13,
                Accuracy = 0.85,
                Velocity = 0.9
            },
            new OffensiveAbility {
                Id = new Guid("3c52ad77-b394-4369-8cb0-1c97db46bedf"),
                Name = "Pressure Drive",
                Type = "Water",
                Class = AbilityClass.Physical,
                BasePower = 5,
                ManaCost = 15,
                Accuracy = 1.0,
                Velocity = 0.6,
                IsMultiTurn = true
            },
            new OffensiveAbility {
                Id = new Guid("04b63e2e-350f-4376-8898-c85922f80079"),
                Name = "Jet Bash",
                Type = "Water",
                Class = AbilityClass.Physical,
                BasePower = 3,
                ManaCost = 11,
                Accuracy = 0.9,
                Velocity = 1.2
            },
            new OffensiveAbility {
                Id = new Guid("2ae783b7-52ad-455d-928b-059dae80a042"),
                Name = "Flood Kick",
                Type = "Water",
                Class = AbilityClass.Physical,
                BasePower = 4,
                ManaCost = 14,
                Accuracy = 0.9,
                Velocity = 0.95
            },

            // Defensive Physical
            new DefensiveAbility {
                Id = new Guid("4bcede5f-4783-438f-a164-b96a7ebc1687"),
                Name = "Hydro Shield",
                Type = "Water",
                Class = AbilityClass.Physical,
                ManaCost = 9,
                TargetStat = "PhysicalDefense",
                BuffPercentage = 0.25,
                Duration = 3,
                CanStack = false
            },
            new DefensiveAbility {
                Id = new Guid("5c2c3ba1-802e-4660-a136-b5c049fcd2e2"),
                Name = "Streamline",
                Type = "Water",
                Class = AbilityClass.Physical,
                ManaCost = 10,
                TargetStat = "Speed",
                BuffPercentage = 0.2,
                Duration = 2,
                CanStack = true
            },
            new DefensiveAbility {
                Id = new Guid("17284e7d-e33d-4bb9-a778-f9a30b0c5afd"),
                Name = "Vital Wave",
                Type = "Water",
                Class = AbilityClass.Physical,
                ManaCost = 12,
                TargetStat = "MaxHP",
                BuffPercentage = 0.15,
                Duration = 0,
                CanStack = false
            },

            // Offensive Arcane
            new OffensiveAbility {
                Id = new Guid("7a6e4c0b-2767-40ab-87b0-cb9729267510"),
                Name = "Aqua Bolt",
                Type = "Water",
                Class = AbilityClass.Arcane,
                BasePower = 3,
                ManaCost = 10,
                Accuracy = 0.95,
                Velocity = 1.1
            },
            new OffensiveAbility {
                Id = new Guid("69916e00-c784-43de-84bb-c9c1e5c416e0"),
                Name = "Mist Needle",
                Type = "Water",
                Class = AbilityClass.Arcane,
                BasePower = 2,
                ManaCost = 7,
                Accuracy = 1.0,
                Velocity = 1.6
            },
            new OffensiveAbility {
                Id = new Guid("9af51d1c-91f3-4c87-8caa-576f5e5aef31"),
                Name = "Surge Beam",
                Type = "Water",
                Class = AbilityClass.Arcane,
                BasePower = 5,
                ManaCost = 18,
                Accuracy = 0.8,
                Velocity = 0.8
            },
            new OffensiveAbility {
                Id = new Guid("421afc9d-eca4-4a20-b5e2-f44fd69935c2"),
                Name = "Cascade Ray",
                Type = "Water",
                Class = AbilityClass.Arcane,
                BasePower = 4,
                ManaCost = 13,
                Accuracy = 0.9,
                Velocity = 1
            },
            new OffensiveAbility {
                Id = new Guid("b0ccb9aa-a551-4c94-8fdf-1646ef02bc17"),
                Name = "Bubble Burst",
                Type = "Water",
                Class = AbilityClass.Arcane,
                BasePower = 5,
                ManaCost = 16,
                Accuracy = 0.85,
                Velocity = 0.9
            },
            new OffensiveAbility {
                Id = new Guid("e93d9207-dc4d-4d5d-b5ee-a33f789dd778"),
                Name = "Frozen Jet",
                Type = "Water",
                Class = AbilityClass.Arcane,
                BasePower = 3,
                ManaCost = 12,
                Accuracy = 0.95,
                Velocity = 1
            },

            // Defensive Arcane
            new DefensiveAbility {
                Id = new Guid("55a27fce-83f3-4aff-b36d-2ecff470052e"),
                Name = "Mana Flow",
                Type = "Water",
                Class = AbilityClass.Arcane,
                ManaCost = 11,
                TargetStat = "ManaRegen",
                BuffPercentage = 0.3,
                Duration = 3,
                CanStack = true
            },
            new DefensiveAbility {
                Id = new Guid("d11aa25d-fd13-468d-8ae6-5f0370f1a75c"),
                Name = "Spiritual Stream",
                Type = "Water",
                Class = AbilityClass.Arcane,
                ManaCost = 13,
                TargetStat = "ArcanePower",
                BuffPercentage = 0.2,
                Duration = 2,
                CanStack = false
            },
            new DefensiveAbility {
                Id = new Guid("c5d92361-0629-418d-89ac-b304410a1a96"),
                Name = "Mystic Bubble",
                Type = "Water",
                Class = AbilityClass.Arcane,
                ManaCost = 12,
                TargetStat = "ArcaneDefense",
                BuffPercentage = 0.25,
                Duration = 3,
                CanStack = false
            },
            // --- Grass Type Abilities ---

                // Offensive Physical
                new OffensiveAbility {
                Id = new Guid("2ec275d5-060d-4016-9ec0-1812d1548f9b"),
                    Name = "Vine Lash",
                    Type = "Grass",
                    Class = AbilityClass.Physical,
                    BasePower = 3,
                    ManaCost = 10,
                    Accuracy = 0.95,
                    Velocity = 1.1
                },
                new OffensiveAbility {
                Id = new Guid("8b3f3468-5bf2-4fb5-b035-613643d9ff02"),
                    Name = "Thorn Jab",
                    Type = "Grass",
                    Class = AbilityClass.Physical,
                    BasePower = 2,
                    ManaCost = 7,
                    Accuracy = 1.0,
                    Velocity = 1.4
                },
                new OffensiveAbility {
                Id = new Guid("c5a7e907-a6fe-46cb-a376-8974acb4a368"),
                    Name = "Root Crush",
                    Type = "Grass",
                    Class = AbilityClass.Physical,
                    BasePower = 4,
                    ManaCost = 14,
                    Accuracy = 0.9,
                    Velocity = 0.9
                },
                new OffensiveAbility {
                Id = new Guid("04db46d0-261c-4303-935a-251b895c1bc4"),
                    Name = "Seed Smash",
                    Type = "Grass",
                    Class = AbilityClass.Physical,
                    BasePower = 5,
                    ManaCost = 16,
                    Accuracy = 0.85,
                    Velocity = 0.8,
                    IsMultiTurn = true
                },
                new OffensiveAbility {
                Id = new Guid("a8d01e4f-d28f-4e43-b509-855e671738e5"),
                    Name = "Tangle Kick",
                    Type = "Grass",
                    Class = AbilityClass.Physical,
                    BasePower = 3,
                    ManaCost = 11,
                    Accuracy = 0.95,
                    Velocity = 1.2
                },
                new OffensiveAbility {
                Id = new Guid("8ccaf7b5-8e81-462e-8156-c112da208527"),
                    Name = "Grapple Swipe",
                    Type = "Grass",
                    Class = AbilityClass.Physical,
                    BasePower = 4,
                    ManaCost = 12,
                    Accuracy = 0.9,
                    Velocity = 1.0
                },

                // Defensive Physical
                new DefensiveAbility {
                Id = new Guid("4edc446f-1b12-4b40-98a7-c0a86c063a92"),
                    Name = "Barkskin",
                    Type = "Grass",
                    Class = AbilityClass.Physical,
                    ManaCost = 9,
                    TargetStat = "PhysicalDefense",
                    BuffPercentage = 0.25,
                    Duration = 3,
                    CanStack = false
                },
                new DefensiveAbility {
                Id = new Guid("54c21301-3c69-4ba9-973f-9f1a083184a9"),
                    Name = "Photosprint",
                    Type = "Grass",
                    Class = AbilityClass.Physical,
                    ManaCost = 10,
                    TargetStat = "Speed",
                    BuffPercentage = 0.2,
                    Duration = 2,
                    CanStack = true
                },
                new DefensiveAbility {
                Id = new Guid("f44c1551-82c5-4dc4-ac2c-cd26d2e8e7f5"),
                    Name = "Sap Vitality",
                    Type = "Grass",
                    Class = AbilityClass.Physical,
                    ManaCost = 12,
                    TargetStat = "MaxHP",
                    BuffPercentage = 0.15,
                    Duration = 0,
                    CanStack = false
                },

                // Offensive Arcane
                new OffensiveAbility {
                Id = new Guid("5790c4e5-c088-4c0a-907a-37593f5401ac"),
                    Name = "Spore Shot",
                    Type = "Grass",
                    Class = AbilityClass.Arcane,
                    BasePower = 3,
                    ManaCost = 9,
                    Accuracy = 0.95,
                    Velocity = 1.2
                },
                new OffensiveAbility {
                Id = new Guid("c806f2a6-f74d-4bf7-872a-2a02c138cb15"),
                    Name = "Bloom Ray",
                    Type = "Grass",
                    Class = AbilityClass.Arcane,
                    BasePower = 2,
                    ManaCost = 6,
                    Accuracy = 1.0,
                    Velocity = 1.5
                },
                new OffensiveAbility {
                Id = new Guid("8ee6141c-115d-404a-bdb8-2fcd28981a32"),
                    Name = "Petal Barrage",
                    Type = "Grass",
                    Class = AbilityClass.Arcane,
                    BasePower = 4,
                    ManaCost = 13,
                    Accuracy = 0.9,
                    Velocity = 1.0
                },
                new OffensiveAbility {
                Id = new Guid("cfe8cb86-ab36-436c-9df1-c2847a026cbb"),
                    Name = "Solar Burst",
                    Type = "Grass",
                    Class = AbilityClass.Arcane,
                    BasePower = 5,
                    ManaCost = 17,
                    Accuracy = 0.8,
                    Velocity = 0.8,
                    IsMultiTurn = true
                },
                new OffensiveAbility {
                Id = new Guid("24b13556-9afc-4b09-b03d-57caea08271a"),
                    Name = "Ivy Spiral",
                    Type = "Grass",
                    Class = AbilityClass.Arcane,
                    BasePower = 3,
                    ManaCost = 10,
                    Accuracy = 0.95,
                    Velocity = 1.1
                },
                new OffensiveAbility {
                Id = new Guid("049c87dd-31a1-4190-9006-5264435bdd98"),
                    Name = "Nature Pulse",
                    Type = "Grass",
                    Class = AbilityClass.Arcane,
                    BasePower = 4,
                    ManaCost = 15,
                    Accuracy = 0.85,
                    Velocity = 1.0
                },

                // Defensive Arcane
                new DefensiveAbility {
                Id = new Guid("45aa2957-e68e-4d56-b61c-283f75e339ab"),
                    Name = "Mana Bloom",
                    Type = "Grass",
                    Class = AbilityClass.Arcane,
                    ManaCost = 10,
                    TargetStat = "ManaRegen",
                    BuffPercentage = 0.3,
                    Duration = 3,
                    CanStack = true
                },
                new DefensiveAbility {
                Id = new Guid("9ad04de5-7edf-4418-89c4-8fb4f3e65ac3"),
                    Name = "Spirit Growth",
                    Type = "Grass",
                    Class = AbilityClass.Arcane,
                    ManaCost = 13,
                    TargetStat = "ArcanePower",
                    BuffPercentage = 0.2,
                    Duration = 2,
                    CanStack = false
                },
                new DefensiveAbility {
                Id = new Guid("25009bd5-30df-41cd-8ddd-e07c3b0aafe7"),
                    Name = "Willow Guard",
                    Type = "Grass",
                    Class = AbilityClass.Arcane,
                    ManaCost = 11,
                    TargetStat = "ArcaneDefense",
                    BuffPercentage = 0.25,
                    Duration = 3,
                    CanStack = false
                },
                // --- Electric Type Abilities ---

                // Offensive Physical
                new OffensiveAbility {
                Id = new Guid("244edc02-9a42-4b21-a9df-3e9051df25f0"),
                    Name = "Shock Pummel",
                    Type = "Electric",
                    Class = AbilityClass.Physical,
                    BasePower = 3,
                    ManaCost = 10,
                    Accuracy = 0.95,
                    Velocity = 1.2
                },
                new OffensiveAbility {
                Id = new Guid("74f51f2b-1fde-433e-a89e-82abe73af1f5"),
                    Name = "Volt Slam",
                    Type = "Electric",
                    Class = AbilityClass.Physical,
                    BasePower = 2,
                    ManaCost = 6,
                    Accuracy = 1.0,
                    Velocity = 1.4
                },
                new OffensiveAbility {
                Id = new Guid("3b770bf3-e1ca-4c63-9c74-bf976ef30281"),
                    Name = "Current Bash",
                    Type = "Electric",
                    Class = AbilityClass.Physical,
                    BasePower = 4,
                    ManaCost = 13,
                    Accuracy = 0.9,
                    Velocity = 1.0
                },
                new OffensiveAbility {
                Id = new Guid("979850bf-0a87-4204-a6c6-abfef386ab44"),
                    Name = "Charge Break",
                    Type = "Electric",
                    Class = AbilityClass.Physical,
                    BasePower = 5,
                    ManaCost = 17,
                    Accuracy = 0.85,
                    Velocity = 0.8,
                    IsMultiTurn = true
                },
                new OffensiveAbility {
                Id = new Guid("153ce4f9-f914-4f42-b58a-4f4d96b267a1"),
                    Name = "Livewire Tackle",
                    Type = "Electric",
                    Class = AbilityClass.Physical,
                    BasePower = 3,
                    ManaCost = 11,
                    Accuracy = 0.95,
                    Velocity = 1.1
                },
                new OffensiveAbility {
                Id = new Guid("8933d8b0-2f89-42a5-bbc7-093dd41f55c9"),
                    Name = "Pulse Crash",
                    Type = "Electric",
                    Class = AbilityClass.Physical,
                    BasePower = 4,
                    ManaCost = 14,
                    Accuracy = 0.9,
                    Velocity = 1.0
                },

                // Defensive Physical
                new DefensiveAbility {
                Id = new Guid("1382a029-ea42-418e-9524-e15d38113db7"),
                    Name = "Static Guard",
                    Type = "Electric",
                    Class = AbilityClass.Physical,
                    ManaCost = 10,
                    TargetStat = "PhysicalDefense",
                    BuffPercentage = 0.25,
                    Duration = 3,
                    CanStack = false
                },
                new DefensiveAbility {
                Id = new Guid("f8eb7838-a695-4d26-a62c-9e9aca3f8a31"),
                    Name = "Lightning Reflex",
                    Type = "Electric",
                    Class = AbilityClass.Physical,
                    ManaCost = 11,
                    TargetStat = "Speed",
                    BuffPercentage = 0.2,
                    Duration = 2,
                    CanStack = true
                },
                new DefensiveAbility {
                Id = new Guid("1e25a63d-34a9-443b-993e-590f11025903"),
                    Name = "Surge Vitality",
                    Type = "Electric",
                    Class = AbilityClass.Physical,
                    ManaCost = 12,
                    TargetStat = "MaxHP",
                    BuffPercentage = 0.15,
                    Duration = 0,
                    CanStack = false
                },

                // Offensive Arcane
                new OffensiveAbility {
                Id = new Guid("6949396b-34ed-40d6-b312-02085a7d5abb"),
                    Name = "Zap Ray",
                    Type = "Electric",
                    Class = AbilityClass.Arcane,
                    BasePower = 3,
                    ManaCost = 9,
                    Accuracy = 0.95,
                    Velocity = 1.3
                },
                new OffensiveAbility {
                Id = new Guid("6df479f6-4f3d-4438-869e-cbabf0ea11ba"),
                    Name = "Bolt Chain",
                    Type = "Electric",
                    Class = AbilityClass.Arcane,
                    BasePower = 2,
                    ManaCost = 7,
                    Accuracy = 1.0,
                    Velocity = 1.5
                },
                new OffensiveAbility {
                Id = new Guid("ba43086b-0f71-4d01-8396-484b54d66e68"),
                    Name = "Thunder Arc",
                    Type = "Electric",
                    Class = AbilityClass.Arcane,
                    BasePower = 4,
                    ManaCost = 15,
                    Accuracy = 0.9,
                    Velocity = 1.0
                },
                new OffensiveAbility {
                Id = new Guid("b67d02e5-8fa9-4583-8f4b-8a49e160dee4"),
                    Name = "Storm Focus",
                    Type = "Electric",
                    Class = AbilityClass.Arcane,
                    BasePower = 5,
                    ManaCost = 18,
                    Accuracy = 0.85,
                    Velocity = 0.75,
                    IsMultiTurn = true
                },
                new OffensiveAbility {
                Id = new Guid("8a1aa51d-cb2c-47d6-a18c-32cacd7a11c1"),
                    Name = "Ion Pulse",
                    Type = "Electric",
                    Class = AbilityClass.Arcane,
                    BasePower = 3,
                    ManaCost = 11,
                    Accuracy = 0.95,
                    Velocity = 1.2
                },
                new OffensiveAbility {
                Id = new Guid("bca7f8b6-1723-46e1-a78c-708f29318fb6"),
                    Name = "Arc Flare",
                    Type = "Electric",
                    Class = AbilityClass.Arcane,
                    BasePower = 4,
                    ManaCost = 14,
                    Accuracy = 0.9,
                    Velocity = 1.0
                },

                // Defensive Arcane
                new DefensiveAbility {
                Id = new Guid("bb79d501-e261-4cff-91c1-962ab56c3a4e"),
                    Name = "Amp Focus",
                    Type = "Electric",
                    Class = AbilityClass.Arcane,
                    ManaCost = 12,
                    TargetStat = "ArcanePower",
                    BuffPercentage = 0.2,
                    Duration = 2,
                    CanStack = false
                },
                new DefensiveAbility {
                Id = new Guid("a9f76150-4f18-4422-8c1c-eeb81cb57e49"),
                    Name = "Field Surge",
                    Type = "Electric",
                    Class = AbilityClass.Arcane,
                    ManaCost = 10,
                    TargetStat = "ArcaneDefense",
                    BuffPercentage = 0.25,
                    Duration = 3,
                    CanStack = false
                },
                new DefensiveAbility {
                Id = new Guid("be08cd2d-07ea-4053-9f5b-e5cdf914c292"),
                    Name = "Battery Boost",
                    Type = "Electric",
                    Class = AbilityClass.Arcane,
                    ManaCost = 11,
                    TargetStat = "ManaRegen",
                    BuffPercentage = 0.3,
                    Duration = 3,
                    CanStack = true
                },
                // --- Rock Type Abilities ---

                // Offensive Physical
                new OffensiveAbility {
                Id = new Guid("cd22677d-31a5-44d6-bde0-0b41d628da34"),
                    Name = "Stone Bash",
                    Type = "Rock",
                    Class = AbilityClass.Physical,
                    BasePower = 3,
                    ManaCost = 10,
                    Accuracy = 0.95,
                    Velocity = 1.2
                },
                new OffensiveAbility {
                Id = new Guid("bef3c77e-41b9-408e-95cf-f00322c54716"),
                    Name = "Rubble Strike",
                    Type = "Rock",
                    Class = AbilityClass.Physical,
                    BasePower = 2,
                    ManaCost = 6,
                    Accuracy = 1.0,
                    Velocity = 1.5
                },
                new OffensiveAbility {
                Id = new Guid("b192fd69-fbf1-4863-a356-16d29225dc0e"),
                    Name = "Granite Slam",
                    Type = "Rock",
                    Class = AbilityClass.Physical,
                    BasePower = 4,
                    ManaCost = 13,
                    Accuracy = 0.9,
                    Velocity = 1.0
                },
                new OffensiveAbility {
                Id = new Guid("7c2beb94-c0ba-48c8-84cf-0b6d6c5d6b73"),
                    Name = "Tremor Build",
                    Type = "Rock",
                    Class = AbilityClass.Physical,
                    BasePower = 5,
                    ManaCost = 17,
                    Accuracy = 0.85,
                    Velocity = 0.8,
                    IsMultiTurn = true
                },
                new OffensiveAbility {
                Id = new Guid("fdcb4a74-0795-4fd0-ba98-c5e293307026"),
                    Name = "Quake Fist",
                    Type = "Rock",
                    Class = AbilityClass.Physical,
                    BasePower = 3,
                    ManaCost = 11,
                    Accuracy = 0.95,
                    Velocity = 1.1
                },
                new OffensiveAbility {
                Id = new Guid("a78edba0-fc8c-4b82-891d-4c1efe1850e4"),
                    Name = "Core Drive",
                    Type = "Rock",
                    Class = AbilityClass.Physical,
                    BasePower = 4,
                    ManaCost = 14,
                    Accuracy = 0.9,
                    Velocity = 1.0
                },

                // Defensive Physical
                new DefensiveAbility {
                Id = new Guid("74c61894-4b52-4747-8a33-41444ae5873d"),
                    Name = "Rock Guard",
                    Type = "Rock",
                    Class = AbilityClass.Physical,
                    ManaCost = 10,
                    TargetStat = "PhysicalDefense",
                    BuffPercentage = 0.25,
                    Duration = 3,
                    CanStack = false
                },
                new DefensiveAbility {
                Id = new Guid("5fad512c-adb2-4b3a-be60-96c12ec6f295"),
                    Name = "Heavy Frame",
                    Type = "Rock",
                    Class = AbilityClass.Physical,
                    ManaCost = 12,
                    TargetStat = "MaxHP",
                    BuffPercentage = 0.15,
                    Duration = 0,
                    CanStack = false
                },
                new DefensiveAbility {
                Id = new Guid("d6000278-4c40-4cfe-84c3-9e183eaaa261"),
                    Name = "Steady Legs",
                    Type = "Rock",
                    Class = AbilityClass.Physical,
                    ManaCost = 11,
                    TargetStat = "Speed",
                    BuffPercentage = 0.2,
                    Duration = 2,
                    CanStack = true
                },

                // Offensive Arcane
                new OffensiveAbility {
                Id = new Guid("e255ede6-4200-4c29-a6ef-2919e8730352"),
                    Name = "Pebble Shot",
                    Type = "Rock",
                    Class = AbilityClass.Arcane,
                    BasePower = 3,
                    ManaCost = 9,
                    Accuracy = 0.95,
                    Velocity = 1.3
                },
                new OffensiveAbility {
                Id = new Guid("36ad0970-cb17-4582-8455-792d992562eb"),
                    Name = "Crystal Lance",
                    Type = "Rock",
                    Class = AbilityClass.Arcane,
                    BasePower = 2,
                    ManaCost = 7,
                    Accuracy = 1.0,
                    Velocity = 1.5
                },
                new OffensiveAbility {
                Id = new Guid("ab6e2920-6416-4580-942c-6e415eb14f02"),
                    Name = "Obsidian Blast",
                    Type = "Rock",
                    Class = AbilityClass.Arcane,
                    BasePower = 4,
                    ManaCost = 15,
                    Accuracy = 0.9,
                    Velocity = 1.0
                },
                new OffensiveAbility {
                Id = new Guid("3d5e812d-7996-4270-a76a-119e7458e459"),
                    Name = "Stone Mind",
                    Type = "Rock",
                    Class = AbilityClass.Arcane,
                    BasePower = 5,
                    ManaCost = 18,
                    Accuracy = 0.85,
                    Velocity = 0.75,
                    IsMultiTurn = true
                },
                new OffensiveAbility {
                Id = new Guid("5119df35-31d8-4a16-84cb-9a8f7d7cb773"),
                    Name = "Echo Core",
                    Type = "Rock",
                    Class = AbilityClass.Arcane,
                    BasePower = 3,
                    ManaCost = 11,
                    Accuracy = 0.95,
                    Velocity = 1.2
                },
                new OffensiveAbility {
                Id = new Guid("314cf0db-2e77-4055-b979-66544c8b4251"),
                    Name = "Seismic Ray",
                    Type = "Rock",
                    Class = AbilityClass.Arcane,
                    BasePower = 4,
                    ManaCost = 14,
                    Accuracy = 0.9,
                    Velocity = 1.0
                },

                // Defensive Arcane
                new DefensiveAbility {
                Id = new Guid("f528eea5-40da-4ff0-8937-7bd72beb5cbe"),
                    Name = "Stone Focus",
                    Type = "Rock",
                    Class = AbilityClass.Arcane,
                    ManaCost = 12,
                    TargetStat = "ArcanePower",
                    BuffPercentage = 0.2,
                    Duration = 2,
                    CanStack = false
                },
                new DefensiveAbility {
                Id = new Guid("7339bd51-a473-4ec3-80a5-13fb53f626d7"),
                    Name = "Geomantic Shell",
                    Type = "Rock",
                    Class = AbilityClass.Arcane,
                    ManaCost = 10,
                    TargetStat = "ArcaneDefense",
                    BuffPercentage = 0.25,
                    Duration = 3,
                    CanStack = false
                },
                new DefensiveAbility {
                Id = new Guid("7f6a2afc-a638-4833-b7b8-b268f564977b"),
                    Name = "Earthwell Surge",
                    Type = "Rock",
                    Class = AbilityClass.Arcane,
                    ManaCost = 11,
                    TargetStat = "ManaRegen",
                    BuffPercentage = 0.3,
                    Duration = 3,
                    CanStack = true
                },
                // --- Air Type Abilities ---

                // Offensive Physical
                new OffensiveAbility {
                Id = new Guid("49b0b9ea-434d-409f-b269-f5ea17f059b7"),
                    Name = "Gale Slash",
                    Type = "Air",
                    Class = AbilityClass.Physical,
                    BasePower = 3,
                    ManaCost = 10,
                    Accuracy = 0.95,
                    Velocity = 1.3
                },
                new OffensiveAbility {
                Id = new Guid("b20fb0cf-dc61-4536-b597-e76a40d01d46"),
                    Name = "Cyclone Kick",
                    Type = "Air",
                    Class = AbilityClass.Physical,
                    BasePower = 4,
                    ManaCost = 14,
                    Accuracy = 0.9,
                    Velocity = 1.1
                },
                new OffensiveAbility {
                Id = new Guid("ebe0ed23-8ba5-4d05-9c3f-febe416b2827"),
                    Name = "Whirlwind Jab",
                    Type = "Air",
                    Class = AbilityClass.Physical,
                    BasePower = 2,
                    ManaCost = 6,
                    Accuracy = 1.0,
                    Velocity = 1.6
                },
                new OffensiveAbility {
                Id = new Guid("36009e9b-8d6e-4b75-8d69-81b8adc4e96a"),
                    Name = "Sky Hammer",
                    Type = "Air",
                    Class = AbilityClass.Physical,
                    BasePower = 5,
                    ManaCost = 18,
                    Accuracy = 0.85,
                    Velocity = 0.9,
                    IsMultiTurn = true
                },
                new OffensiveAbility {
                Id = new Guid("1017d262-cdc6-4c3b-8847-92b75c0bf6fb"),
                    Name = "Cloud Dive",
                    Type = "Air",
                    Class = AbilityClass.Physical,
                    BasePower = 3,
                    ManaCost = 11,
                    Accuracy = 0.95,
                    Velocity = 1.2
                },
                new OffensiveAbility {
                Id = new Guid("5aa7ff22-89a7-4065-aa8a-3dcc2ba69ecc"),
                    Name = "Tempest Rush",
                    Type = "Air",
                    Class = AbilityClass.Physical,
                    BasePower = 4,
                    ManaCost = 13,
                    Accuracy = 0.9,
                    Velocity = 1.0
                },

                // Defensive Physical
                new DefensiveAbility {
                Id = new Guid("191b607b-46e4-41d2-8bac-38428abec481"),
                    Name = "Windstep",
                    Type = "Air",
                    Class = AbilityClass.Physical,
                    ManaCost = 9,
                    TargetStat = "Speed",
                    BuffPercentage = 0.3,
                    Duration = 2,
                    CanStack = true
                },
                new DefensiveAbility {
                Id = new Guid("e618bc56-7555-4968-b320-effb756dfb09"),
                    Name = "Feather Guard",
                    Type = "Air",
                    Class = AbilityClass.Physical,
                    ManaCost = 11,
                    TargetStat = "PhysicalDefense",
                    BuffPercentage = 0.2,
                    Duration = 3,
                    CanStack = false
                },
                new DefensiveAbility {
                Id = new Guid("f363fa6a-4fd6-4e69-8d59-5540e602ab06"),
                    Name = "Updraft Vitality",
                    Type = "Air",
                    Class = AbilityClass.Physical,
                    ManaCost = 12,
                    TargetStat = "MaxHP",
                    BuffPercentage = 0.15,
                    Duration = 0,
                    CanStack = false
                },

                // Offensive Arcane
                new OffensiveAbility {
                Id = new Guid("b944238a-1f2f-4644-97d5-ca9792671e7c"),
                    Name = "Air Bolt",
                    Type = "Air",
                    Class = AbilityClass.Arcane,
                    BasePower = 3,
                    ManaCost = 10,
                    Accuracy = 0.95,
                    Velocity = 1.3
                },
                new OffensiveAbility {
                Id = new Guid("945cc8e0-1654-41d5-a219-02155614422d"),
                    Name = "Storm Pulse",
                    Type = "Air",
                    Class = AbilityClass.Arcane,
                    BasePower = 2,
                    ManaCost = 7,
                    Accuracy = 1.0,
                    Velocity = 1.5
                },
                new OffensiveAbility {
                Id = new Guid("30a51242-4d0b-402b-a0ec-f48d0f681374"),
                    Name = "Vortex Ray",
                    Type = "Air",
                    Class = AbilityClass.Arcane,
                    BasePower = 4,
                    ManaCost = 15,
                    Accuracy = 0.9,
                    Velocity = 1.0
                },
                new OffensiveAbility {
                Id = new Guid("94e81000-2760-48b8-a23f-aaf6406ebfd6"),
                    Name = "Zephyr Build",
                    Type = "Air",
                    Class = AbilityClass.Arcane,
                    BasePower = 5,
                    ManaCost = 18,
                    Accuracy = 0.85,
                    Velocity = 0.8,
                    IsMultiTurn = true
                },
                new OffensiveAbility {
                Id = new Guid("af8dcc73-a71e-48a8-a0eb-80b815088c5d"),
                    Name = "Twister Beam",
                    Type = "Air",
                    Class = AbilityClass.Arcane,
                    BasePower = 3,
                    ManaCost = 11,
                    Accuracy = 0.95,
                    Velocity = 1.2
                },
                new OffensiveAbility {
                Id = new Guid("cc71b98d-b359-4c80-adad-30bfe64437f1"),
                    Name = "Shockwind",
                    Type = "Air",
                    Class = AbilityClass.Arcane,
                    BasePower = 4,
                    ManaCost = 13,
                    Accuracy = 0.9,
                    Velocity = 1.0
                },

                // Defensive Arcane
                new DefensiveAbility {
                Id = new Guid("a6e2edc8-358a-4a93-bc05-d610c2e60bfc"),
                    Name = "Sky Focus",
                    Type = "Air",
                    Class = AbilityClass.Arcane,
                    ManaCost = 10,
                    TargetStat = "ArcanePower",
                    BuffPercentage = 0.2,
                    Duration = 2,
                    CanStack = false
                },
                new DefensiveAbility {
                Id = new Guid("b12468c6-7446-4f73-bcb5-bebff5106c8c"),
                    Name = "Aether Shroud",
                    Type = "Air",
                    Class = AbilityClass.Arcane,
                    ManaCost = 12,
                    TargetStat = "ArcaneDefense",
                    BuffPercentage = 0.25,
                    Duration = 3,
                    CanStack = false
                },
                new DefensiveAbility {
                Id = new Guid("72e93ef3-7538-41d3-bd9f-6a3b4aff2e93"),
                    Name = "Wind Meditation",
                    Type = "Air",
                    Class = AbilityClass.Arcane,
                    ManaCost = 11,
                    TargetStat = "ManaRegen",
                    BuffPercentage = 0.3,
                    Duration = 3,
                    CanStack = true
                },
                // --- Prime Type Abilities ---

                // Offensive Physical
                new OffensiveAbility {
                Id = new Guid("5541f417-e83b-40e2-92e5-47da2e7c1a56"),
                    Name = "Unity Strike",
                    Type = "Prime",
                    Class = AbilityClass.Physical,
                    BasePower = 3,
                    ManaCost = 10,
                    Accuracy = 0.95,
                    Velocity = 1.3
                },
                new OffensiveAbility {
                Id = new Guid("1a71e0df-ba85-4a9f-895c-f7f8c4dedb86"),
                    Name = "Balance Breaker",
                    Type = "Prime",
                    Class = AbilityClass.Physical,
                    BasePower = 4,
                    ManaCost = 13,
                    Accuracy = 0.9,
                    Velocity = 1.1
                },
                new OffensiveAbility {
                Id = new Guid("3127464a-0a98-4c3e-9935-9b2e7f9f1514"),
                    Name = "Primal Slam",
                    Type = "Prime",
                    Class = AbilityClass.Physical,
                    BasePower = 2,
                    ManaCost = 7,
                    Accuracy = 1.0,
                    Velocity = 1.5
                },
                new OffensiveAbility {
                Id = new Guid("48a62836-f9ee-49e0-bc7b-132c2ff6f71f"),
                    Name = "Harmonic Blow",
                    Type = "Prime",
                    Class = AbilityClass.Physical,
                    BasePower = 5,
                    ManaCost = 18,
                    Accuracy = 0.85,
                    Velocity = 0.9,
                    IsMultiTurn = true
                },
                new OffensiveAbility {
                Id = new Guid("e05bb151-8352-4c3b-95da-5b9fc12b38bb"),
                    Name = "Core Jab",
                    Type = "Prime",
                    Class = AbilityClass.Physical,
                    BasePower = 3,
                    ManaCost = 11,
                    Accuracy = 0.95,
                    Velocity = 1.2
                },
                new OffensiveAbility {
                Id = new Guid("e7956bdb-c1eb-4d41-96b4-a9079c980a1f"),
                    Name = "Fundamental Flurry",
                    Type = "Prime",
                    Class = AbilityClass.Physical,
                    BasePower = 4,
                    ManaCost = 14,
                    Accuracy = 0.9,
                    Velocity = 1.0
                },

                // Defensive Physical
                new DefensiveAbility {
                Id = new Guid("705dc7f7-ff82-43bd-8f02-19bcf26b89b0"),
                    Name = "Primal Shield",
                    Type = "Prime",
                    Class = AbilityClass.Physical,
                    ManaCost = 10,
                    TargetStat = "PhysicalDefense",
                    BuffPercentage = 0.25,
                    Duration = 3,
                    CanStack = false
                },
                new DefensiveAbility {
                Id = new Guid("134d5e31-2406-48d2-82a5-1e717c94744d"),
                    Name = "Equilibrium Boost",
                    Type = "Prime",
                    Class = AbilityClass.Physical,
                    ManaCost = 12,
                    TargetStat = "PhysicalPower",
                    BuffPercentage = 0.2,
                    Duration = 2,
                    CanStack = false
                },
                new DefensiveAbility {
                Id = new Guid("394772ba-cf66-4b73-a044-c9df5b7ab851"),
                    Name = "Tempo Flow",
                    Type = "Prime",
                    Class = AbilityClass.Physical,
                    ManaCost = 11,
                    TargetStat = "Speed",
                    BuffPercentage = 0.15,
                    Duration = 3,
                    CanStack = true
                },

                // Offensive Arcane
                new OffensiveAbility {
                Id = new Guid("3bef2d72-030f-446e-99f6-826928a22a82"),
                    Name = "Essence Blast",
                    Type = "Prime",
                    Class = AbilityClass.Arcane,
                    BasePower = 3,
                    ManaCost = 10,
                    Accuracy = 0.95,
                    Velocity = 1.3
                },
                new OffensiveAbility {
                Id = new Guid("b75f5bcf-ca06-4ef9-b641-ada390521e14"),
                    Name = "Neutral Ray",
                    Type = "Prime",
                    Class = AbilityClass.Arcane,
                    BasePower = 4,
                    ManaCost = 13,
                    Accuracy = 0.9,
                    Velocity = 1.1
                },
                new OffensiveAbility {
                Id = new Guid("ebaeed56-34f2-4c83-9aaa-f0432ad4ab58"),
                    Name = "Alpha Surge",
                    Type = "Prime",
                    Class = AbilityClass.Arcane,
                    BasePower = 2,
                    ManaCost = 6,
                    Accuracy = 1.0,
                    Velocity = 1.6
                },
                new OffensiveAbility {
                Id = new Guid("48ff9552-d89e-4264-bc89-300c11c519dd"),
                    Name = "Omega Charge",
                    Type = "Prime",
                    Class = AbilityClass.Arcane,
                    BasePower = 5,
                    ManaCost = 18,
                    Accuracy = 0.85,
                    Velocity = 0.8,
                    IsMultiTurn = true
                },
                new OffensiveAbility {
                Id = new Guid("ace717fd-7535-4805-a69f-f2fd3ad2edf9"),
                    Name = "Void Pulse",
                    Type = "Prime",
                    Class = AbilityClass.Arcane,
                    BasePower = 3,
                    ManaCost = 11,
                    Accuracy = 0.95,
                    Velocity = 1.2
                },
                new OffensiveAbility {
                Id = new Guid("c23598c7-edac-486f-b73e-cb0be878ad17"),
                    Name = "Singularity Edge",
                    Type = "Prime",
                    Class = AbilityClass.Arcane,
                    BasePower = 4,
                    ManaCost = 14,
                    Accuracy = 0.9,
                    Velocity = 1.0
                },

                // Defensive Arcane
                new DefensiveAbility {
                Id = new Guid("2f738409-e450-400f-869d-a4f3d1549859"),
                    Name = "Mana Harmony",
                    Type = "Prime",
                    Class = AbilityClass.Arcane,
                    ManaCost = 10,
                    TargetStat = "ManaRegen",
                    BuffPercentage = 0.3,
                    Duration = 3,
                    CanStack = true
                },
                new DefensiveAbility {
                Id = new Guid("3ca4135d-23bd-4c2e-a914-6d0ea296cd9d"),
                    Name = "Arcane Fortify",
                    Type = "Prime",
                    Class = AbilityClass.Arcane,
                    ManaCost = 11,
                    TargetStat = "ArcaneDefense",
                    BuffPercentage = 0.25,
                    Duration = 2,
                    CanStack = false
                },
                new DefensiveAbility {
                Id = new Guid("1c4af361-675b-496b-bf59-13c19bf50e48"),
                    Name = "Mystic Clarity",
                    Type = "Prime",
                    Class = AbilityClass.Arcane,
                    ManaCost = 12,
                    TargetStat = "ArcanePower",
                    BuffPercentage = 0.2,
                    Duration = 2,
                    CanStack = false
                }
        };
    }
}

