using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DnD_CM_WPF_Lib
{
    /// <summary>
    /// this class is the creation of the monster itself, it takes a majority of the json data and formats it correctly,
    /// this is like the main class and could potentially be broken down futher however i saw no reason too
    /// </summary>
    public class Basics
    {
        #region lists of data that contains multiple values
        //data making is just ctrl + c, ctrl + v
        private List<string> _DamageImmunities = new();
        private List<string> _ConditionImmunities = new();
        private List<string> _DamageVulnerability = new();
        private List<string> _DamageResistance = new();
        private List<string> _SavingThrowBonuses = new();
        private List<string> _SkillBonuses = new();

        private List<string> _senses = new();
        private List<string> _languages = new();

        private List<string> AC = new();
        private static string HP;
        private List<string> speed = new();
        private List<string> metadetails = new();

        #endregion
        #region Monster details
        public string Name { get; set; }
        public string ArmorClass
        {
            set
            {
                foreach (string i in value.Replace(")", "").Split(" ("))
                    AC.Add(i);
            }
            get
            {
                return $"{AC[0]} ({AC[1]})";
            }
        }
        public string HitPoints
        {
            get => HP;
            set => HP = Util.ReturnAverage(Regex.Replace(value, @"\d*\s\(|\)", ""));
        }
        public string getspeed()
        {
            foreach (string i in speed)
            {
                return i;
            }
            return "";
        }
        public string Speed
        {
            set
            {
                foreach (string i in value.Split(", "))
                    speed.Add(i);
            }
            get => getspeed();
        }
        public string getmeta(int i) //method to keep lists private
        {
            return metadetails[i];
        }
        public string Meta //split the data
        {

            set
            {
                if (Regex.IsMatch(value, @"\(\w+, \w+\)"))
                {
                    foreach (string i in value.Split("), "))
                        metadetails.Add(i);
                    metadetails[0] += ")";
                }
                else
                {
                    foreach (string i in value.Split(", "))
                        metadetails.Add(i);
                }
            }
        }
#endregion
        //monster attribute getter and setters
        #region
        private int _STR, _DEX, _CON, _INT, _WIS, _CHA;
        public string STR { set => _STR = Convert.ToInt32(value); }
        public string DEX { set => _DEX = Convert.ToInt32(value); }
        public string CON { set => _CON = Convert.ToInt32(value); }
        public string INT { set => _INT = Convert.ToInt32(value); }
        public string WIS { set => _WIS = Convert.ToInt32(value); }
        public string CHA { set => _CHA = Convert.ToInt32(value); }
        public int GetSTR { get => _STR; }
        public int GetDEX { get => _DEX; }
        public int GetCON { get => _CON; }
        public int GetINT { get => _INT; }
        public int GetWIS { get => _WIS; }
        public int GetCHA { get => _CHA; }
        #endregion
        //all of these are appending to lists
        public string Languages
        {
            set
            {
                foreach (string i in value.Split(", "))
                {
                    _ = i.Trim();
                    _languages.Add(i);
                }
            }
        }
        public string DamageVulnerabilities
        {
            set
            {
                foreach (string i in value.Split(", "))
                {
                    _ = i.Trim();
                    _DamageVulnerability.Add(i);
                }
            }
        }
        public string DamageResistances
        {
            set
            {
                foreach (string i in value.Split(", "))
                {
                    _ = i.Trim();
                    _DamageResistance.Add(i);
                }
            }
        }
        public string ConditionImmunities
        {
            set
            {
                foreach (string i in value.Split(", "))
                {
                    _ = i.Trim();
                    _ConditionImmunities.Add(i);
                }
            }
        }
        public string DamageImmunities
        {
            set
            {
                foreach (string i in value.Split(", "))
                {
                    _ = i.Trim();
                    _DamageImmunities.Add(i);
                }
            }
        }
        #region mod return
        public int STR_mod { get => Util.ModReturn(GetSTR); }
        public int DEX_mod { get => Util.ModReturn(GetDEX); }
        public int CON_mod { get => Util.ModReturn(GetCON); }
        public int INT_mod { get => Util.ModReturn(GetINT); }
        public int WIS_mod { get => Util.ModReturn(GetWIS); }
        public int CHA_mod { get => Util.ModReturn(GetCHA); }
        #endregion
        public string SavingThrows
        {
            set
            {
                foreach (string i in value.Split(", "))
                {
                    _ = i.Trim();
                    _SavingThrowBonuses.Add(i);
                }
            }
        }
        public string Skills
        {
            set
            {
                foreach (string i in value.Split(", "))
                {
                    _ = i.Trim();
                    _SkillBonuses.Add(i);
                }
            }
        }
        public string Senses
        {
            set
            {
                foreach (string i in value.Split(", "))
                {
                    _ = i.Trim();
                    _senses.Add(i);
                }
            }
        }
        private string _challenge;
        public string Challenge { set => _challenge = Regex.Replace(value, @"\((\d|,)*\)", ""); get => ChallengeRating.ReturnCRXP(_challenge); }
        public Trait[] Traits { get; set; }
        public AdvancedSpell[] Spells { get; set; }
        public Attack[] Actions { get; set; }
        public int LegendaryUses { get; set; }
        public LegendaryTrait[] LegendaryActions { get; set; }
        #region return list counts
        //all in an effort to keep private things private
        public int retSTcount()
        {
            return _SavingThrowBonuses.Count;
        }
        public int retSBcount()
        {
            return _SkillBonuses.Count;
        }
        public int retDIcount()
        {
            return _DamageImmunities.Count;
        }
        public int retDRcount()
        {
            return _DamageResistance.Count;
        }
        public int retDVcount()
        {
            return _DamageVulnerability.Count;
        }
        public int retCIcount()
        {
            return _ConditionImmunities.Count;
        }
        #endregion
        #region get from list
        public string GetSavingThrows()
        {
            string savingthrows = "";
            foreach (string i in _SavingThrowBonuses)
            {
                savingthrows += i + ", ";
            }
            if (savingthrows.Length > 2)
            {
                savingthrows = savingthrows.Substring(0, savingthrows.Length - 2);
            }
            return savingthrows;
        }
        public string GetSkills()
        {
            string s = "";
            foreach (string i in _SkillBonuses)
            {
                s += i + ", ";
            }
            if (s.Length > 2)
            {
                s = s.Substring(0, s.Length - 2);
            }
            return s;
        }
        public string GetSenses()
        {
            string s = "";
            foreach (string i in _senses)
            {
                s += i + ", ";
            }
            if (s.Length > 2)
            {
                s = s.Substring(0, s.Length - 2);
            }
            return s;
        }
        public string Getlanguages()
        {
            string s = "";
            foreach (string i in _languages)
            {
                s += i + ", ";
            }
            if (s.Length > 2)
            {
                s = s.Substring(0, s.Length - 2);
            }
            return s;
        }
        public string GetDI()
        {
            string s = "";
            foreach (string i in _DamageImmunities)
            {
                s += i + ", ";
            }
            if (s.Length > 2)
            {
                s = s.Substring(0, s.Length - 2);
            }
            return s;
        }
        public string GetDR()
        {
            string s = "";
            foreach (string i in _DamageResistance)
            {
                s += i + ", ";
            }
            if (s.Length > 2)
            {
                s = s.Substring(0, s.Length - 2);
            }
            return s;
        }
        public string GetDV()
        {
            string s = "";
            foreach (string i in _DamageVulnerability)
            {
                s += i + ", ";
            }
            if (s.Length > 2)
            {
                s = s.Substring(0, s.Length - 2);
            }
            return s;
        }

        public string GetCI()
        {
            string s = "";
            foreach (string i in _ConditionImmunities)
            {
                s += i + ", ";
            }
            if (s.Length > 2)
            {
                s = s.Substring(0, s.Length - 2);
            }
            return s;
        }
        #endregion
    }
}