using CefSharp;
using CefSharp.OffScreen;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;

namespace DnD_CM_WPF_Lib
{
    public class Statblock
    {
        public static List<string> output = new();
        private static string Title = "";
        private static string savefilename = "";
        /// <summary>
        /// a method to properly return javascript so that the custom html elements are made properly
        /// </summary>
        /// <param name="identifier"> string of the name of the custom html tags being created</param>
        private static void AddTemplateScript(string identifier)
        {
            output.Add(@"<script>{");
            output.Add(@$"let templateElement = document.getElementById('{identifier}');");
            output.Add(@$"createCustomElement('{identifier}', templateElement.content)");
            output.Add(@"}</script>");
        }
        /// <summary>
        /// method to return a cone shape on the statblock, purely styleistic
        /// </summary>
        private static void TaperedRule()
        {
            output.Add(@"<tapered-rule></tapered-rule>");
        }
        /// <summary>
        /// takes the URI file in the resources folder and makes a png of the DnD statblock background
        /// </summary>
        /// <returns>image</returns>
        private static string backgroundimage()
        {
            return File.ReadAllText("D:\\Projects\\DnD_Creature_Maker\\DnD_CM_WPF_Lib\\Resources\\file.uri");
        }
        /// <summary>
        /// this method has a lot of lines but not a lot of complexity, the list method of adding elements means that support for infinite traits, actions and sucha re possible
        /// </summary>
        /// <param name="basics"> needs the json monster so a class called later can use it</param>
        /// <returns>returns a very long string of the html elements</returns>
        public static string OutputStatblock(Basics basics)
        {
            output.Clear();

            #region
            output.Add(@"<!DOCTYPE html>");
            output.Add(@"<html>");

            // Head and Title
            #region
            output.Add(@"<head>");

            // Inline links
            output.Add(@"<link href=""https://fonts.googleapis.com/css?family=Libre+Baskerville:700"" rel=""stylesheet"" type=""text/css""/>");
            output.Add(@"<link href=""http://fonts.googleapis.com/css?family=Noto+Sans:400,700,400italic,700italic"" rel=""stylesheet"" type=""text/css""/><meta charset=""utf-8""/>");
            output.Add(@"<title>" + Title + "</title>");

            // Styles
            output.Add(@"<style>");
            output.Add(@"body {");
            output.Add(@"margin: 0");
            output.Add(@"}");
            output.Add(@"stat-block {");
            output.Add(@"margin-left: 20px;");
            output.Add(@"margin-top: 20px;");
            output.Add(@"margin-bottom: 20px;");
            output.Add(@"}</style>");
            output.Add(@"<script>");
            output.Add(@"function createCustomElement(name, contentNode, elementClass = null)");
            output.Add(@"{if (elementClass === null) {");
            output.Add(@"customElements.define(name,");
            output.Add(@"class extends HTMLElement {");
            output.Add(@"constructor() {");
            output.Add(@"super();");
            output.Add(@"this.attachShadow({ mode: 'open'})");
            output.Add(@".appendChild(contentNode.cloneNode(true));");
            output.Add(@"}");
            output.Add(@"})} else{");
            output.Add(@"customElements.define(name, elementClass(contentNode));");
            output.Add(@"}}");
            output.Add(@"</script>");
            output.Add(@"</head>");
            #endregion

            // Body Style
            #region
            output.Add(@"<body style=""background-image: url('" + backgroundimage() + @"'); background-repeat: repeat-y;"">");
            //output.Add(@"<body>");
            output.Add(@"<template id=""tapered-rule"">");
            output.Add(@"<style>");
            output.Add(@"svg {");
            output.Add(@"fill: #922610;");
            output.Add(@"stroke: #922610;");
            output.Add(@"margin-top: 0.6em;");
            output.Add(@"margin-bottom: 0.35em;");
            output.Add(@"}");
            output.Add(@"</style>");
            output.Add(@"<svg height=""5"" width=""400"">");
            output.Add(@"<polyline points=""0,0 400,2.5 0,5""></polyline>");
            output.Add(@"</svg>");
            output.Add(@"</template>");
            #endregion

            // Scripts
            // Tapered Rule Template
            #region
            AddTemplateScript("tapered-rule");
            #endregion

            // Tapered Rule Script and Top-Stats Template
            #region
            output.Add(@"<template id=""top-stats"">");
            output.Add(@"<style> ::slotted(*) {color: #7A200D;} </style>");
            TaperedRule();
            output.Add(@"<slot></slot>");
            TaperedRule();
            output.Add(@"</template>");
            #endregion

            // Top-Stats Script
            #region
            AddTemplateScript("top-stats");
            #endregion

            // Creature Heading Template
            #region
            output.Add(@"<template id=""creature-heading"">");
            output.Add(@"<style>");

            output.Add(@"::slotted(h1) {");
            output.Add(@"font-family: 'Libre Baskerville', 'Lora', 'Calisto MT', 'Bookman Old Style', Bookman, 'Goudy Old Style', 
                Garamond, 'Hoefler Text', 'Bitstream Charter', Georgia, serif;");
            output.Add(@"color: #7A200D;");
            output.Add(@"font-weight: 700;");
            output.Add(@"margin: 0px;");
            output.Add(@"font-size: 23px;");
            output.Add(@"letter-spacing: 1px;");
            output.Add(@"font-variant: small-caps;");
            output.Add(@"}");

            output.Add(@"::slotted(h2) {");
            output.Add(@"font-weight: normal;");
            output.Add(@"font-style: italic;");
            output.Add(@"font-size: 12px;");
            output.Add(@"margin: 0;");
            output.Add(@"}");
            output.Add(@"</style>");
            output.Add(@"<slot></slot>");
            output.Add(@"</template>");
            #endregion

            // Creature-Heading Script
            #region
            AddTemplateScript("creature-heading");
            #endregion

            // Abilities-Block Template
            #region
            output.Add(@"<template id=""abilities-block"">");
            output.Add(@"<style>");
            output.Add(@":host {");
            output.Add(@"color: #7A200D;");
            output.Add(@"}");

            output.Add(@"table {");
            output.Add(@"width: 100%;");
            output.Add(@"border: 0px;");
            output.Add(@"border-collapse: collapse;");
            output.Add(@"}");

            output.Add(@"th, td {");
            output.Add(@"width: 50px;");
            output.Add(@"text-align: center;");
            output.Add(@"}");
            output.Add(@"</style>");
            TaperedRule();

            // Stat Table
            output.Add(@"<table>");
            output.Add(@"<tbody>");
            output.Add(@"<tr>");
            output.Add(@"<th>STR</th>");
            output.Add(@"<th>DEX</th>");
            output.Add(@"<th>CON</th>");
            output.Add(@"<th>INT</th>");
            output.Add(@"<th>WIS</th>");
            output.Add(@"<th>CHA</th>");
            output.Add(@"</tr>");
            output.Add(@"<tr>");
            output.Add(@"<td id=""str""></th>");
            output.Add(@"<td id=""dex""></th>");
            output.Add(@"<td id=""con""></th>");
            output.Add(@"<td id=""int""></th>");
            output.Add(@"<td id=""wis""></th>");
            output.Add(@"<td id=""cha""></th>");
            output.Add(@"</tr>");
            output.Add(@"</tbody>");
            output.Add(@"</table>");
            TaperedRule();
            output.Add(@"</template>");
            #endregion

            // Abilities-Block Script
            #region
            output.Add(@"<script>{");
            output.Add(@"function abilityModifier(abilityScore) {");
            output.Add(@"let score = parseInt(abilityScore, 10);");
            output.Add(@"return Math.floor((score - 10) / 2);");
            output.Add(@"}");

            output.Add(@"function formattedModifier(abilityModifier) {");
            output.Add(@"if (abilityModifier >= 0) {");
            output.Add(@"return '+' + abilityModifier;");
            output.Add(@"}");
            output.Add(@"return '-' + Math.abs(abilityModifier);");
            output.Add(@"}");

            output.Add(@"function abilityText(abilityScore) {");
            output.Add(@"return [String(abilityScore),");
            output.Add(@"' (',");
            output.Add(@"formattedModifier(abilityModifier(abilityScore)),");
            output.Add(@"')'].join('');");
            output.Add(@"}");

            output.Add(@"function elementClass(contentNode) {");
            output.Add(@"return class extends HTMLElement {");
            output.Add(@"constructor() {");
            output.Add(@"super();");
            output.Add(@"this.attachShadow({mode: 'open'})");
            output.Add(@".appendChild(contentNode.cloneNode(true));");
            output.Add(@"}");
            output.Add(@"connectedCallback() {");
            output.Add(@"let root = this.shadowRoot;");
            output.Add(@"for (let i = 0; i < this.attributes.length; i++) {");
            output.Add(@"let attribute = this.attributes[i];");
            output.Add(@"let abilityShortName = attribute.name.split('-')[1];");
            output.Add(@"root.getElementById(abilityShortName).textContent =");
            output.Add(@"abilityText(attribute.value);");
            output.Add(@"}}}}");
            output.Add(@"let templateElement = document.getElementById('abilities-block');");
            output.Add(@"createCustomElement('abilities-block', templateElement.content, elementClass);");
            output.Add(@"}</script>");
            #endregion

            // Property-Block Template
            #region
            output.Add(@"<template id=""property-block"">");
            output.Add(@"<style>");
            output.Add(@":host {");
            output.Add(@"margin-top: 0.3em;");
            output.Add(@"margin-bottom: 0.9em;");
            output.Add(@"line-height: 1.5;");
            output.Add(@"display: block;");
            output.Add(@"}");

            output.Add(@"::slotted(h4) {");
            output.Add(@"margin: 0;");
            output.Add(@"display: inline;");
            output.Add(@"font-weight: bold;");
            output.Add(@"font-style: italic;");
            output.Add(@"}");

            output.Add(@"::slotted(p:first-of-type) {");
            output.Add(@"display: inline;");
            output.Add(@"text-indent: 0;");
            output.Add(@"}");

            output.Add(@"::slotted(p) {");
            output.Add(@"text-indent: 1em;");
            output.Add(@"margin: 0;");
            output.Add(@"}");
            output.Add(@"</style>");

            output.Add(@"<slot></slot>");
            output.Add(@"</template>");
            #endregion

            // Property-Block Script
            #region
            AddTemplateScript("property-block");
            #endregion

            // Property-Line Template
            #region
            output.Add(@"<template id=""property-line"">");
            output.Add(@"<style>");
            output.Add(@":host {");
            output.Add(@"line-height: 1.4;");
            output.Add(@"display: block;");
            output.Add(@"text-indent: -1em;");
            output.Add(@"padding-left: 1em;");
            output.Add(@"}");

            //output.Add(@"div {");
            //output.Add(@"text-indent: -1em;");
            //output.Add(@"margin-left: 1em;");
            //output.Add(@"}");

            output.Add(@"::slotted(h4) {");
            output.Add(@"margin: 0;");
            output.Add(@"display: inline;");
            output.Add(@"font-weight: bold;");
            output.Add(@"}");

            output.Add(@"::slotted(p:first-of-type) {");
            output.Add(@"display: inline;");
            output.Add(@"text-indent: 0;");
            output.Add(@"}");

            output.Add(@"::slotted(p) {");
            output.Add(@"text-indent: 1em;");
            output.Add(@"margin: 0;");
            output.Add(@"}");

            output.Add(@"</style>");
            output.Add(@"<slot></slot>");
            output.Add(@"</template>");
            #endregion

            // Property-Line Script
            #region
            AddTemplateScript("property-line");
            #endregion

            // Stat-Block Template
            #region
            output.Add(@"<template id=""stat-block"">");
            output.Add(@"<style>");
            output.Add(@":host {");
            output.Add(@"display: inline-block;");
            output.Add(@"}");
            output.Add(@"#content-wrap {");
            output.Add(@"width: 400px;");
            output.Add(@"font-family: 'Noto Sans', 'Myriad Pro', Scala Sans, Helvetica, Arial,");
            output.Add(@"sans-serif;");
            output.Add(@"font-size: 13.5px;");
            output.Add(@"background: #FDF1DC;");
            output.Add(@"padding: 0.6em;");
            output.Add(@"padding-bottom: 0.5em;");
            output.Add(@"border: 1px #DDD solid;");
            output.Add(@"box-shadow: 0 0 1.5em #867453;");

            output.Add(@"z-index: 0;");

            output.Add(@"margin-left: 2px;");
            output.Add(@"margin-right: 2px;");
            output.Add(@"}");

            output.Add(@"::slotted(h3) {");
            output.Add(@"border-bottom: 1px solid #7A200D;");
            output.Add(@"color: #7A200D;");
            output.Add(@"font-size: 21px;");
            output.Add(@"font-variant: small-caps;");
            output.Add(@"font-weight: normal;");
            output.Add(@"letter-spacing: 1px;");
            output.Add(@"margin: 0;");
            output.Add(@"margin-bottom: 0.3em;");
            output.Add(@"");
            output.Add(@"break-before: column;");
            output.Add(@"break-inside: avoid-column;");
            output.Add(@"break-after: avoid-column;");
            output.Add(@"}");

            output.Add(@"::slotted(p) {");
            output.Add(@"margin-top: 0.3em;");
            output.Add(@"margin-bottom: 0.9em;");
            output.Add(@"line-height: 1.5;");
            output.Add(@"}");

            output.Add(@".bar {");
            output.Add(@"height: 5px;");
            output.Add(@"background: #E69A28;");
            output.Add(@"border: 1px solid #000;");
            output.Add(@"position: relative;");
            output.Add(@"z-index: 1;");
            output.Add(@"}");

            output.Add(@"::slotted(*:last-child) {");
            output.Add(@"margin-bottom: 0;");
            output.Add(@"}");
            output.Add(@"</style>");
            output.Add(@"<div class=""bar""></div>");
            output.Add(@"<div id=""content-wrap"">");
            output.Add(@"<slot></slot>");
            output.Add(@"</div>");
            output.Add(@"<div class=""bar""></div>");
            output.Add(@"</template>");
            #endregion

            // Stat-Block Script
            #region
            AddTemplateScript("stat-block");
            #endregion
            #endregion
            OutputStatblockData(basics);
            string returnstring = "";
            foreach (string item in output)
            {
                returnstring += item + Environment.NewLine;
            }
            return returnstring;
        }
        //used in screenshot to return the proper height
        private static int BrowserHeight(ChromiumWebBrowser b)
        {
            // Get Document Height
            var task = b.EvaluateScriptAsync("(function() { var body = document.body, html = document.documentElement; return  Math.max( body.scrollHeight, body.offsetHeight, html.clientHeight, html.scrollHeight, html.offsetHeight ); })();");

            task.ContinueWith(t =>
            {
                if (!t.IsFaulted)
                {
                    var response = t.Result;
                    var EvaluateJavaScriptResult = response.Success ? (response.Result ?? "null") : response.Message;
                    //MessageBox.Show(response.Result.ToString());                    
                    //MessageBox.Show(EvaluateJavaScriptResult.ToString());                    
                }
            });

            if (task.Result.Result == null) { return 0; }
            return Convert.ToInt32(task.Result.Result.ToString());
        }
        //used to wait time, useful when making browsers to enable slower PCs to not run into errors
        private static Task Delay(double milliseconds)
        {
            var tcs = new TaskCompletionSource<bool>();
            System.Timers.Timer timer = new();
            timer.Elapsed += (obj, args) => tcs.TrySetResult(true);
            timer.Interval = milliseconds;
            timer.AutoReset = false;
            timer.Start();
            return tcs.Task;
        }
        /// <summary>
        /// creates a new browser instance and then makes an image of that, exporting a bitmap
        /// </summary>
        /// <param name="filename"> this needs to be the file location of where to save the .png file</param>
        /// <param name="zoomlevel">shouldn't really be anything but 0, however may be usedful if trying to make the image bigger, through not quite working correctly</param>
        /// <param name="FileData">needs to be the filepath of the initial json file</param>
        public static async void Screenshot(string filename, int zoomlevel, string FileData)
        {
            var browser = new ChromiumWebBrowser();
            bool check = browser.IsBrowserInitialized;
            await Delay(20);
            browser.LoadHtml("<html><head></head><body></body></html>", "http://rendering/");
            browser.LoadHtml(OutputStatblock(Input.LoadData(FileData)), "http://rendering/");
            savefilename = filename;
            await Delay(500);
            int wide = 460;
            int tall = 0;
            while (tall == 0)
            {
                tall = BrowserHeight(browser);
                System.Threading.Thread.Sleep(100);
            }

            wide *= zoomlevel + 1;
            tall *= zoomlevel + 1;
            browser.Size = new(wide, tall);
            await Delay(500);

            await browser.ScreenshotAsync().ContinueWith(DisplayBitmap);
        }
        private static void DisplayBitmap(Task<Bitmap> task)
        {
            var bitmap = task.Result;

            // Save the Bitmap to the path.
            // The image type is auto-detected via the ".png" extension.
            string filename = savefilename.Split('\\')[savefilename.Split('\\').Length - 1];
            bitmap.Save(Path.GetTempPath() + filename);

            // We no longer need the Bitmap.
            // Dispose it to avoid keeping the memory alive.  Especially important in 32-bit applications.
            bitmap.Dispose();

            try
            {
                if (File.Exists(savefilename))
                {
                    File.Delete(savefilename);
                }

                File.Move(Path.GetTempPath() + filename, savefilename);
            }
            catch (Exception ex) { Console.WriteLine("Error Saving File." + Environment.NewLine + "Error: " + ex.Message); }
        }
        /// <summary>
        /// takes in the data from the jsonmonster instance and formats it to the stablock
        /// using the same tactics as from the output statblock
        /// </summary>
        /// <param name="monster">json monster</param>
        private static void OutputStatblockData(Basics monster)
        {
            output.Add(@"");
            output.Add(@"");
            output.Add(@"");

            #region Statblock add variables
            output.Add(@"<stat-block>");

            //creature heading
            output.Add(@"<creature-heading>");
            output.Add(@"<h1>" + monster.Name.Replace('*', ' ').Trim() + "</h1>");
            output.Add(@"<h2>" + monster.getmeta(0) + ", " + monster.getmeta(1) + "</h2>");
            output.Add(@"</creature-heading>");

            // Top Stats            
            output.Add(@"<top-stats>");

            output.Add(@"<property-line>");
            output.Add(@"<h4>Armor Class</h4>");
            output.Add(@"<p>" + monster.ArmorClass + "</p>");
            output.Add(@"</property-line>");

            output.Add(@"<property-line>");
            output.Add(@"<h4>Hit Points</h4>");
            output.Add(@"<p>" + monster.HitPoints + "</p>");
            output.Add(@"</property-line>");

            output.Add(@"<property-line>");
            output.Add(@"<h4>Speed</h4>");
            output.Add(@"<p>" + monster.getspeed() + "</p>");
            output.Add(@"</property-line>");

            // Stats            
            string stats = "<abilities-block data-";
            stats += "cha=\"" + monster.GetCHA + "\" ";
            stats += "data-con=\"" + monster.GetCON + "\" ";
            stats += "data-dex=\"" + monster.GetDEX + "\" ";
            stats += "data-int=\"" + monster.GetINT + "\" ";
            stats += "data-str=\"" + monster.GetSTR + "\" ";
            stats += "data-wis=\"" + monster.GetWIS + "\">";
            stats += "</abilities-block>";

            output.Add(stats);

            // Immunities, Resistances, Senses, Languages            
            if (monster.retSTcount() > 0)
            {
                output.Add(@"<property-line>");
                output.Add(@"<h4>Saving Throws</h4>");
                output.Add(@"<p>" + monster.GetSavingThrows() + "</p>");
                output.Add(@"</property-line>");
            }

            if (monster.retSBcount() > 0)
            {
                output.Add(@"<property-line>");
                output.Add(@"<h4>Skills</h4>");
                output.Add(@"<p>" + monster.GetSkills() + "</p>");
                output.Add(@"</property-line>");
            }

            if (monster.retDIcount() > 0)
            {
                output.Add(@"<property-line>");
                output.Add(@"<h4>Damage Immunities</h4>");
                output.Add(@"<p>" + monster.GetDI() + "</p>");
                output.Add(@"</property-line>");
            }

            if (monster.retDRcount() > 0)
            {
                output.Add(@"<property-line>");
                output.Add(@"<h4>Damage Resistances</h4>");
                output.Add(@"<p>" + monster.GetDR() + "</p>");
                output.Add(@"</property-line>");
            }

            if (monster.retDVcount() > 0)
            {
                output.Add(@"<property-line>");
                output.Add(@"<h4>Damage Vulnerabilities</h4>");
                output.Add(@"<p>" + monster.GetDV() + "</p>");
                output.Add(@"</property-line>");
            }

            if (monster.retCIcount() > 0)
            {
                output.Add(@"<property-line>");
                output.Add(@"<h4>Condition Immunities</h4>");
                output.Add(@"<p>" + monster.GetCI() + "</p>");
                output.Add(@"</property-line>");
            }

            output.Add(@"<property-line>");
            output.Add(@"<h4>Senses</h4>");
            output.Add(@"<p>" + monster.GetSenses() + "</p>");
            output.Add(@"</property-line>");

            output.Add(@"<property-line>");
            output.Add(@"<h4>Languages</h4>");
            output.Add(@"<p>" + monster.Getlanguages() + "</p>");
            output.Add(@"</property-line>");

            output.Add(@"<property-line>");
            output.Add(@"<h4>Challenge</h4>");
            output.Add(@"<p>" + monster.Challenge + "</p>");
            output.Add(@"</property-line>");
            output.Add(@"</top-stats>");

            if (monster.Traits != null)
            {
                if (monster.Traits.Length > 0)
                {
                    foreach (Trait t in monster.Traits)
                    {
                        output.Add(@"<property-block>");
                        output.Add(@"<h4>" + t.ProperName() + ".</h4>");
                        string abilityDescription = "";

                        foreach (string abilityWord in t.Description.Split(' '))
                        {
                            if (!abilityWord.Contains('\n'))
                            {
                                abilityDescription += abilityWord + " ";
                            }
                            else
                            {
                                string breakString = "</br></p><p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                                abilityDescription += abilityWord.Replace('\n'.ToString(), breakString) + " ";
                            }
                        }

                        output.Add(@"<p>" + abilityDescription + "</p>");
                        output.Add(@"</property-block>");
                    }
                }
            }
            if (monster.Spells != null)
            {
                foreach (AdvancedSpell spell in monster.Spells)
                {

                    output.Add(@"<property-block>");
                    output.Add(Output.Spellblock(spell));
                    output.Add(@"</property-block>");
                }
            }

            if (monster.Actions != null)
            {
                if (monster.Actions.Length > 0)
                {
                    output.Add(@"<property-block><h3 style=""border-bottom: 1px solid #7A200D; color:#7A200D; font-size: 18px; font-variant: small-caps; font-weight: normal; letter-spacing: 1px; margin: 0;"">Actions</h3></property-block>");
                    foreach (Attack attack in monster.Actions)
                    {
                        output.Add(@"<property-block>");
                        output.Add(@"<h4>" + attack.ProperName());
                        if (attack.Uses != null)
                        {
                            output.Add(@" " + attack.Uses);
                        }
                        output.Add(@".</h4> ");
                        output.Add("<p>" + Output.AttackDescribe(attack) + "</p>");
                        output.Add(@"</property-block>");
                    }
                }
            }



            if (monster.LegendaryActions != null)
            {
                if (monster.LegendaryActions.Length > 0)
                {
                    output.Add(@"<h3 style=""border-bottom: 1px solid #7A200D; color:#7A200D; font-size: 18px; font-variant: small-caps; font-weight: normal; letter-spacing: 1px; margin: 0;"">Legendary Actions</h3>");
                    output.Add(@"<property-block>");
                    output.Add(@"<p>" + Output.legendaryplate(monster.Name, monster) + "</p></br></br>");
                    foreach (LegendaryTrait trait in monster.LegendaryActions)
                    {
                        output.Add(@"<h4>" + trait.ProperName() + ". </h4>");
                        output.Add(@"" + trait.Description + "<br>");
                    }
                    output.Add(@"</property-block>");
                }
            }

            // Writeout
            output.Add("</stat-block>");
            output.Add("</body>");
            output.Add("</html>");
            #endregion
        }
    }
}
