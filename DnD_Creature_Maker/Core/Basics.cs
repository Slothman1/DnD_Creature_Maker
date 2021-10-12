using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_Creature_Maker
{
    public class Basics
    {
        //data making is just ctrl + c, ctrl + v
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


    public class Rootobject
    {
        public string name { get; set; }
        public string meta { get; set; }
        public string ArmorClass { get; set; }
        public string HitPoints { get; set; }
        public string Speed { get; set; }
        public string STR { get; set; }
        public string STR_mod { get; set; }
        public string DEX { get; set; }
        public string DEX_mod { get; set; }
        public string CON { get; set; }
        public string CON_mod { get; set; }
        public string INT { get; set; }
        public string INT_mod { get; set; }
        public string WIS { get; set; }
        public string WIS_mod { get; set; }
        public string CHA { get; set; }
        public string CHA_mod { get; set; }
        public string DamageImmunities { get; set; }
        public string ConditionImmunities { get; set; }
        public string Senses { get; set; }
        public string Languages { get; set; }
        public string Challenge { get; set; }
        public string Traits { get; set; }
        public string Actions { get; set; }
    }

}
