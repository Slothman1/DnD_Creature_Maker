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
        public List<string> _DamageImmunities = new List<string>();
        public List<string> _ConditionImmunities = new List<string>();
        public List<string> _DamageVulnerability = new List<string>();
        public List<string> _DamageResistance = new List<string>();
        public List<string> _SavingThrowBonuses = new List<string>();
        public List<string> _SkillBonuses = new List<string>();

        public List<string> _senses = new List<string>();
        public List<string> _languages = new List<string>();

        public List<Ability> _Abilities = new List<Ability>();
        public List<string> _Actions = new();
        public List<Ability> _Reactions = new List<Ability>();
        public List<LegendaryActions> _Legendaries = new List<LegendaryActions>();
        public List<string> _advancedSpells = new List<string>();
        public List<AdvancedSpell> _advancedSpellData = new List<AdvancedSpell>();

        public string LegendaryActions { get; set; }

        private static string[] AC;
        private static string[] HP;
        private string[] speed;


        public string name { get; set; }
        public string ArmorClass
        {
            get { return AC[0]; }
            set { AC = value.Replace(")", "").Split(" ("); }
        }
        public string HitPoints
        {
            get { return HP[0]; }
            set { HP = value.Replace(")", "").Split(" ("); }
        }
        public string Speed
        {
            get { return speed[0]; }
            set { speed = value.Split(", "); }
        }

        public string meta { get; set; }
        //monster attribute getter and setters
        #region
        private int _STR, _DEX, _CON, _INT, _WIS, _CHA;
        public string STR { set => _STR = int.Parse(value); }
        public string DEX { set => _DEX = int.Parse(value); }
        public string CON { set => _CON = int.Parse(value); }
        public string INT { set => _INT = int.Parse(value); }
        public string WIS { set => _WIS = int.Parse(value); }
        public string CHA { set => _CHA = int.Parse(value); }
        public int GetSTR { get => _STR; }
        public int GetDEX { get => _DEX; }
        public int GetCON { get => _CON; }
        public int GetINT { get => _INT; }
        public int GetWIS { get => _WIS; }
        public int GetCHA { get => _CHA; }
        #endregion

        public string Languages
        {
            set
            {
                foreach (string i in value.Split(", "))
                    _languages.Add(i);
            }
        }
        public string DamageVulnerabilities
        {
            set
            {
                foreach (string i in value.Split(", "))
                    _DamageVulnerability.Add(i);
            }
        }
        public string DamageResistances 
        {
            set
            {
                foreach (string i in value.Split(", "))
                    _DamageResistance.Add(i);
            }
        }
        public string ConditionImmunities
        {
            set
            {
                foreach (string i in value.Split(", "))
                    _ConditionImmunities.Add(i);
            }
        }
        public string DamageImmunities { get; set; }
        #region
        Util Util = new();
        public int STR_mod { get => Util.Mod_Return(GetSTR); }
        public int DEX_mod { get => Util.Mod_Return(GetDEX); }
        public int CON_mod { get => Util.Mod_Return(GetCON); }
        public int INT_mod { get => Util.Mod_Return(GetINT); }
        public int WIS_mod { get => Util.Mod_Return(GetWIS); }
        public int CHA_mod { get => Util.Mod_Return(GetCHA); }


        public string Senses { get; set; }

        public string Challenge { get; set; }
        public string Traits { get; set; }
        public string Actions
        {
            set
            {
                foreach (string i in value.Split(" </p>"))
                    _Actions.Add(i);
            }
        }

        #endregion
    }
}
