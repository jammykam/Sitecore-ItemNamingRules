using System;
using System.Reflection;
using Sitecore.Configuration;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Events;
using Sitecore.Publishing;

namespace Sitecore.Sharedsource.ItemNamingRules.Events
{
    public class ItemEventRulesHandler
    {
        private const string ItemSavingRules = "{2F0D793D-3C8D-4B2B-A8FD-AC08C6758108}";

        /// <summary>Called when the item is saving.</summary>
        protected void OnItemSaving(object sender, EventArgs args)
        {
            Assert.ArgumentNotNull(sender, "sender");
            Assert.ArgumentNotNull((object)args, "args");

            // Do not run rules when installting Sitecore packages
            if (Sitecore.Context.Job?.Name == "Install")
                return;

            // Do not run rules when publishing
            if (!Settings.Rules.ItemEventHandlers.RunDuringPublishing && PublishHelper.IsPublishing())
                return;

            Item obj = Event.ExtractParameter(args, 0) as Item;
            if (obj == null)
                return;

            this.RunItemSavingRules(obj);
        }

        /// <summary>Runs the custom item saving rules.</summary>
        private void RunItemSavingRules(Item item)
        {
            // Reflect and call the Static RunRules method with our custom Item Saving rules folder
            var refelectedMethod = typeof(Sitecore.Rules.ItemEventHandler)
                                         .GetMethod("RunRules", BindingFlags.Static | BindingFlags.NonPublic);
            refelectedMethod.Invoke(null, new object[] { item, MainUtil.GetID(ItemSavingRules) });
        }
    }
}