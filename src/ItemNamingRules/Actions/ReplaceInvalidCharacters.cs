//-----------------------------------------------------------------------------------
// <copyright file="ReplaceInvalidCharacters.cs" company="Sitecore Shared Source">
// Copyright (c) Sitecore.  All rights reserved.
// </copyright>
// <summary>
// Defines the 
// Sitecore.Sharedsource.Rules.Actions.ReplaceInvalidCharacters 
// type.
// </summary>
// <license>
// http://sdn.sitecore.net/Resources/Shared%20Source/Shared%20Source%20License.aspx
// </license>
// <url>http://marketplace.sitecore.net/en/Modules/Item_Naming_rules.aspx</url>
//-----------------------------------------------------------------------------------

using System;
using System.Text.RegularExpressions;
using Sitecore.Rules;

namespace Sitecore.Sharedsource.ItemNamingRules.Actions
{

    /// <summary>
    /// Rules engine action to replace invalid characters in item names.
    /// </summary>
    /// <typeparam name="T">Type providing rule context.</typeparam>
    public class ReplaceInvalidCharacters<T> : RenamingAction<T>
      where T : RuleContext
    {
        /// <summary>
        /// Gets or sets the string with which to replace invalid characters
        /// in item names.
        /// </summary>
        private string _replaceWith;
        public string ReplaceWith
        {
            get { return _replaceWith; }
            set
            {
                _replaceWith = value.Equals("{remove-spaces}") ? String.Empty : value;
            }
        }

        /// <summary>
        /// Gets or sets the regular expression used to validate each character
        /// in item names.
        /// </summary>
        public string MatchPattern
        {
            get;
            set;
        }

        /// <summary>
        /// Action implementation.
        /// </summary>
        /// <param name="ruleContext">The rule context.</param>
        public override void Apply(T ruleContext)
        {
            ApplyRule(ruleContext);
            CheckItemNameChanged(ruleContext);
        }

        private void ApplyRule(T ruleContext)
        {
            Sitecore.Diagnostics.Assert.IsNotNull(this.ReplaceWith, "ReplaceWith");
            string newName = Regex.Replace(ruleContext.Item.Name, this.MatchPattern, this.ReplaceWith);

            if (this.ReplaceWith.Length > 0)
            {
                string sequence = this.ReplaceWith + this.ReplaceWith;
                while (newName.Contains(sequence))
                {
                    newName = newName.Replace(sequence, this.ReplaceWith);
                }

                if (newName.StartsWith(this.ReplaceWith))
                {
                    newName = newName.Substring(this.ReplaceWith.Length, newName.Length - this.ReplaceWith.Length);
                }

                if (newName.EndsWith(this.ReplaceWith))
                {
                    newName = newName.Substring(0, newName.Length - this.ReplaceWith.Length);
                }

                if (String.IsNullOrEmpty(newName))
                {
                    newName = this.ReplaceWith;
                }
            }

            ruleContext.Item.Name = newName;
        }
    }
}