using System;

namespace DnD_CM_WPF_Lib
{
    public static class Output
    {
        /// <summary>
        /// returns a formatted string of the paramters of spells and spell data
        /// </summary>
        /// <param name="spell">needs to be advanced spell</param>
        /// <returns>formatted string, all one line for the output</returns>
        public static string Spellblock(AdvancedSpell spell)
        {
            string returnstring = "";
            if (spell.Slot == false)
            {
                if (spell.Uses == -1)
                {
                    returnstring += "<p>At will: ";
                    returnstring += "<i>";
                    foreach (string s in spell.Spell_Names)
                    {
                        returnstring += s.Trim() + ", ";
                    }
                    returnstring += "</i></br>";
                }
                else
                {
                    returnstring += "<p>" + spell.Uses + "/ day each: ";
                    foreach (string s in spell.Spell_Names)
                    {
                        returnstring += "<i>" + s + "</i>" + ", ";
                    }
                    returnstring += "</i></br>";
                }
                return returnstring + "</p>";
            }
            else
            {
                for (int i = 0; i < 10; i++)
                {
                    if (i == 0)
                    {
                        returnstring += "<p>Cantrips (at will): ";
                    }
                    else
                    {
                        string suffix = "";
                        switch (spell.Level)
                        {
                            case 1:
                                suffix = "st";
                                break;
                            case 2:
                                suffix = "nd";
                                break;
                            case 3:
                                suffix = "rd";
                                break;
                            default:
                                suffix = "th";
                                break;
                        }


                        returnstring += "<p>" + i + suffix + " level (" + spell.Uses + " slots): ";
                    }

                    returnstring += "<i>";

                    bool addedData = false;
                    foreach (string s in spell.Spell_Names)
                    {
                        if (!String.IsNullOrEmpty(s) || !String.IsNullOrWhiteSpace(s))
                        {
                            returnstring += "<i>" + s + "</i>" + ", ";
                            addedData = true;
                        }
                    }
                    if (addedData) { returnstring = returnstring.Substring(0, returnstring.Length - 2); }
                    returnstring += "</i></br>" + "</p>";
                }

                return returnstring;
            }
        }
        //returns a formatted string of an attack, excluseds name as that was defined earlier, before this method call
        public static string AttackDescribe(Attack attack)
        {
            string returnstring = "";
            if (attack.AttackType != null)
            {
                returnstring += "<i>" + attack.AttackType + " </i>+";
                returnstring += attack.Bonus + " to hit, ";
                if (attack.Reach > 0)
                {
                    returnstring += "reach " + attack.Reach + " ft., ";
                }
                if (attack.Reach > 0 && attack.Range != null)
                {
                    returnstring += " or ";
                }
                if (attack.Range != null)
                {
                    returnstring += "range " + attack.Range;
                    returnstring += " ft., ";
                }
                returnstring += attack.Target + ".";
                returnstring += " <i>Hit:</i>";
                if (attack.Damage != null)
                {
                    returnstring += attack.Damage + " " + attack.DamageType.ToLower() + " damage";
                }
                if (attack.ExtraDamage != null)
                {
                    returnstring += " plus " + attack.ExtraDamage + " " + attack.ExtraDamageType.ToLower() + " damage";
                }
                if (attack.Description != null)
                {
                    returnstring += " " + attack.Description;
                }

            }
            else
            {
                returnstring += " " + attack.Description;
            }

            return returnstring;
        }
        //this is a template for the legendary actions text, no current DnD creature has a singular legendary action hence plural is always used
        public static string legendaryplate(string name, Basics b)
        {
            return "The " + name + " can take " + b.LegendaryUses + " legendary actions, choosing from the options below. Only one legendary action can be" +
                " used at a time and only at the end of another creature's turn. The " + name + " regains spent legendary actions at the start of its turn.";
        }

    }
}
