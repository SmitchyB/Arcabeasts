// BattleArena.cs
using Arcabeasts.Combat;
using Arcabeasts.DataLib;
using Arcabeasts.GameData;
using Arcabeasts.GameData.Arcabeasts.GameData;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ArcabeastsMain.Pages
{
    public partial class BattleArena : Form
    {
        private readonly UserProfile _profile;
        private readonly int _profileIndex;
        private readonly Guid _userId;

        private ArcabeastDefinition _userArcabeastDef;
        private ArcabeastInstance _userInstance;
        private List<ArcabeastAbility> _userAbilities = new List<ArcabeastAbility>();

        private ArcabeastDefinition _opponentArcabeastDef;
        private ArcabeastInstance _opponentInstance;

        private BattleContext _battleContext;
        private BattleFlow _battleFlow;

        public BattleArena(UserProfile profile, int profileIndex, Guid userId)
        {
            InitializeComponent();

            _profile = profile;
            _profileIndex = profileIndex;
            _userId = userId;

            SetupUserArcabeast();
            SetupOpponentArcabeast();

            _battleContext = new BattleContext
            {
                PlayerInstance = _userInstance,
                OpponentInstance = _opponentInstance,
                TurnNumber = 1,
                OriginalProfile = _profile,
                ProfileIndex = _profileIndex,
                UserId = _userId
            };

            _battleContext.OnBattleEnded = (playerWon) =>
            {
                BattleContext.Current = null;
                var resultForm = new PostBattle(_battleContext, playerWon);
                resultForm.Show();
                this.Invoke((Action)(() => this.Hide()));
            };
            BattleContext.Current = _battleContext;
            _battleContext.Log = AppendCombatText;
            _battleFlow = new BattleFlow(_battleContext);
            UpdateTurnLabel();
        }

        private void SetupUserArcabeast()
        {
            _userArcabeastDef = ArcabeastDB.All.First(a => a.Id == _profile.Arcabeast.ArcabeastId);
            var scaledDef = LevelStatCalculator.ScaleStats(_userArcabeastDef, _profile.Arcabeast.Level);

            _userAbilities = ArcabeastAbilityDB.All
                .Where(a => scaledDef.AllowedMoveTypes.Contains(a.Type) && _profile.Arcabeast.LearnedMoveIds.Contains(a.Id))
                .ToList();

            _userInstance = ArcabeastFactory.CreateInstance(
                scaledDef,
                string.IsNullOrWhiteSpace(_profile.Arcabeast.CustomName)
                    ? scaledDef.Name
                    : _profile.Arcabeast.CustomName,
                _profile.Arcabeast.Level,
                _profile.Arcabeast.Experience,
                _profile.Arcabeast.LearnedMoveIds
            );

            // 🔁 Apply scaled stats to instance
            _userInstance.MaxHP = scaledDef.MaxHP;
            _userInstance.MaxMana = scaledDef.MaxMana;
            _userInstance.ManaRegen = scaledDef.ManaRegen;
            _userInstance.Speed = scaledDef.Speed;
            _userInstance.PhysicalPower = scaledDef.PhysicalPower;
            _userInstance.ArcanePower = scaledDef.ArcanePower;
            _userInstance.PhysicalDefense = scaledDef.PhysicalDefense;
            _userInstance.ArcaneDefense = scaledDef.ArcaneDefense;
            _userInstance.Evasiveness = scaledDef.Evasiveness;
            _userInstance.CurrentHP = _userInstance.MaxHP;
            _userInstance.CurrentMana = _userInstance.MaxMana;

            DrawUserUI();
        }


        private void SetupOpponentArcabeast()
        {
            _opponentInstance = ChooseOpponent.GenerateOpponent(_userInstance.Level);
            _opponentArcabeastDef = ArcabeastDB.All.First(a => a.Id == _opponentInstance.ArcabeastId);
            DrawOpponentUI();
        }

        private void DrawUserUI()
        {
            lblUserName.Text = _userInstance.DisplayName;
            lblUserLevel.Text = $"Level: {_userInstance.Level}";
            lblUserHP.Text = $"HP: {_userInstance.CurrentHP}/{_userInstance.MaxHP}";
            lblUserMana.Text = $"Mana: {_userInstance.CurrentMana}/{_userInstance.MaxMana}";

            barUserHP.Maximum = _userInstance.MaxHP;
            barUserHP.Value = _userInstance.CurrentHP;

            barUserMana.Maximum = _userInstance.MaxMana;
            barUserMana.Value = _userInstance.CurrentMana;

            picUser.Image = Image.FromFile(_userArcabeastDef.AssetPath);
            lblUserStats.Text = $"SPD: {_userInstance.TempSpeed}\n" +
                        $"PWR: {_userInstance.TempPhysicalPower}\n" +
                        $"ARC: {_userInstance.TempArcanePower}\n" +
                        $"DEF: {_userInstance.TempPhysicalDefense}\n" +
                        $"ARDEF: {_userInstance.TempArcaneDefense}\n" +
                        $"EVA: {_userInstance.TempEvasiveness}";
            lblUserEffects.Text = string.Join("\n",
                _userInstance.ActiveEffects.Select(e =>
                {
                    var ability = ArcabeastAbilityDB.All.FirstOrDefault(a => a.Id == e.Id);
                    string name = ability?.Name ?? e.GetType().Name;
                    return $"{name} ({e.RemainingTurns} turns)";
                })
            );
        }

        private void DrawOpponentUI()
        {
            lblOpponentName.Text = _opponentInstance.DisplayName;
            lblOpponentLevel.Text = $"Level: {_opponentInstance.Level}";
            lblOpponentHP.Text = $"HP: {_opponentInstance.CurrentHP}/{_opponentInstance.MaxHP}";
            lblOpponentMana.Text = $"Mana: {_opponentInstance.CurrentMana}/{_opponentInstance.MaxMana}";

            barOpponentHP.Maximum = _opponentInstance.MaxHP;
            barOpponentHP.Value = _opponentInstance.CurrentHP;

            barOpponentMana.Maximum = _opponentInstance.MaxMana;
            barOpponentMana.Value = _opponentInstance.CurrentMana;

            picOpponent.Image = Image.FromFile(_opponentArcabeastDef.AssetPath);

            lblOpponentStats.Text = $"SPD: {_opponentInstance.TempSpeed}\n" +
                            $"PWR: {_opponentInstance.TempPhysicalPower}\n" +
                            $"ARC: {_opponentInstance.TempArcanePower}\n" +
                            $"DEF: {_opponentInstance.TempPhysicalDefense}\n" +
                            $"ARDEF: {_opponentInstance.TempArcaneDefense}\n" +
                            $"EVA: {_opponentInstance.TempEvasiveness}";
            lblOpponentEffects.Text = string.Join("\n",
               _opponentInstance.ActiveEffects.Select(e =>
               {
                   var ability = ArcabeastAbilityDB.All.FirstOrDefault(a => a.Id == e.Id);
                   string name = ability?.Name ?? e.GetType().Name;
                   return $"{name} ({e.RemainingTurns} turns)";
               })

            );

            DisplayAbilityButtons();
        }

        private void DisplayAbilityButtons()
        {
            Button[] buttons = { btnAbility1, btnAbility2, btnAbility3, btnAbility4, btnAbility5 };
            var displayAbilities = new List<ArcabeastAbility>(_userAbilities);

            // Add pseudo Rest ability (button 5)
            var restAbility = new DefensiveAbility
            {
                Id = Guid.Empty,
                Name = "Rest",
                ManaCost = 0,
                Type = "None",
                Class = AbilityClass.Physical,
                Duration = 0,
                BuffPercentage = 0,
                TargetStat = "None",
                Velocity = 1.0,
                CanStack = false
            };

            displayAbilities.Add(restAbility);

            bool hasUsable = false;

            for (int i = 0; i < buttons.Length; i++)
            {
                if (i < displayAbilities.Count)
                {
                    var ability = displayAbilities[i];
                    bool canUse = ability.Name == "Rest" || _userInstance.CurrentMana >= ability.ManaCost;

                    buttons[i].Text = $"{ability.Name} ({ability.ManaCost})";
                    buttons[i].Tag = ability;
                    buttons[i].Visible = true;
                    buttons[i].Enabled = canUse;

                    if (canUse && ability.Name != "Rest")
                        hasUsable = true;
                }
                else
                {
                    buttons[i].Visible = false;
                }
            }

            // If no usable abilities (excluding Rest), do not auto-process turn
            if (!hasUsable)
            {
                txtCombatLog.Text += $"{_userInstance.DisplayName} has no usable abilities. You need to Rest.\r\n";
            }
        }


        private void AbilityButton_Click(object sender, EventArgs e)
        {
            txtCombatLog.Clear();
            ToggleAbilityButtons(false); // Disable buttons
            var playerAbility = (ArcabeastAbility)((Button)sender).Tag;
            _battleFlow.ExecuteTurn(playerAbility, OnTurnComplete);
        }

        private void ToggleAbilityButtons(bool visible)
        {
            btnAbility1.Visible = visible;
            btnAbility2.Visible = visible;
            btnAbility3.Visible = visible;
            btnAbility4.Visible = visible;
            btnAbility1.Enabled = visible;
        }

        public void AppendCombatText(string message)
        {
            txtCombatLog.AppendText(message + "\r\n");
        }

        private void OnTurnComplete()
        {
            UpdateTurnLabel();
            ToggleAbilityButtons(true);
            DrawUserUI();
            DrawOpponentUI();
        }

        private void UpdateTurnLabel()
        {
            lblTurnNumber.Text = $"Turn: {_battleContext.TurnNumber}";

            // Player HP/Mana
            barUserHP.Value = Math.Max(0, _userInstance.CurrentHP);
            barUserMana.Value = Math.Max(0, _userInstance.CurrentMana);
            lblUserHP.Text = $"HP: {_userInstance.CurrentHP}/{_userInstance.MaxHP}";
            lblUserMana.Text = $"Mana: {_userInstance.CurrentMana}/{_userInstance.MaxMana}";

            // Opponent HP/Mana
            barOpponentHP.Value = Math.Max(0, _opponentInstance.CurrentHP);
            barOpponentMana.Value = Math.Max(0, _opponentInstance.CurrentMana);
            lblOpponentHP.Text = $"HP: {_opponentInstance.CurrentHP}/{_opponentInstance.MaxHP}";
            lblOpponentMana.Text = $"Mana: {_opponentInstance.CurrentMana}/{_opponentInstance.MaxMana}";
        }
    }
}
