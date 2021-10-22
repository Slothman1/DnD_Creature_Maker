using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace DnD_Creature_Maker
{
    public class Basics
    {
        #region
        //data making is just ctrl + c, ctrl + v
        public List<string> _DamageImmunities = new List<string>();
        public List<string> _ConditionImmunities = new List<string>();
        public List<string> _DamageVulnerability = new List<string>();
        public List<string> _DamageResistance = new List<string>();
        public List<string> _SavingThrowBonuses = new List<string>();
        public List<string> _SkillBonuses = new List<string>();

        public List<string> _senses = new List<string>();
        public List<string> _languages = new List<string>();

        private static string[] AC;
        private static string[] HP;
        private string[] speed;
        #endregion

        public string Name { get; set; }
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

        public string Meta { get; set; }
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
        public string DamageImmunities
        {
            set
            {
                foreach (string i in value.Split(", "))
                    _DamageImmunities.Add(i);
            }
        }
        #region
        public int STR_mod { get => Util.Mod_Return(GetSTR); }
        public int DEX_mod { get => Util.Mod_Return(GetDEX); }
        public int CON_mod { get => Util.Mod_Return(GetCON); }
        public int INT_mod { get => Util.Mod_Return(GetINT); }
        public int WIS_mod { get => Util.Mod_Return(GetWIS); }
        public int CHA_mod { get => Util.Mod_Return(GetCHA); }
        public string SavingThrows { get; set; }
        public string Skills { get; set; }
        public string Senses { get; set; }
        private string _challenge;
        public string Challenge { set => _challenge = Regex.Replace(value, @"\((\d|,)*\)", ""); get => ChallengeRating.ReturnCRXP(_challenge); }
        public Trait[] Traits { get; set; }
        public Attack[] Actions { get; set; }
        public int LegendaryUses { get; set; }
        public LegendaryTrait[] LegendaryActions { get; set; }
        public AdvancedSpell[] Spells { get; set; }

        #endregion
    }
}