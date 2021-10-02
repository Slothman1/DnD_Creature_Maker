using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_Creature_Maker
{
    public class Basics
    {
        public List<string> DamageImmunities = new List<string>();
        public List<string> ConditionImmunities = new List<string>();
        public List<string> DamageVulnerability = new List<string>();
        public List<string> SavingThrowBonuses = new List<string>();
        public List<string> SkillBonuses = new List<string>();

        public List<string> _Senses = new List<string>();
        public List<string> _languages = new List<string>();

        public List<Ability> _Abilities = new List<Ability>();
        public List<Ability> _Actions = new List<Ability>();
        public List<Ability> _Reactions = new List<Ability>();
        public List<LegendaryActions> _Legendaries = new List<LegendaryActions>();
        public List<string> _advancedSpells = new List<string>();
        public List<AdvancedSpell> _advancedSpellData = new List<AdvancedSpell>();

        public string LegendaryActions { get; set; }

        public string Title = "";
        public int STR, DEX, CON, INT, WIS, CHA, proficiency = 0;
        public string Speed = "";
        public static string AC = "";
        public static string HP = "";

        public static string CreatureName = "";
        public static string CreatureSize = "";
        public static string CreatureType = "";
        public static string CreatureAlign = "";
    }
}
