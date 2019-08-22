﻿#region HEADER
//    TrackerEmulator.TrackerEmulator
//    Created by Nikita Neverov at 20.08.2019 12:50
#endregion

using System.Collections.Generic;
using System.Collections.ObjectModel;
using TrackerEmulator.Entites;
using TrackerEmulator.ViewModels;

namespace TrackerEmulator.Helpers.Extension
{
    public static class ObservableCollectionExtension
    {
        public static void AddPages(this ObservableCollection<NavigationItem> navigationCollection,
                                    IEnumerable<BasePageViewModel> pages)
        {
            foreach (var element in pages)
            {
                navigationCollection.Add(new NavigationItem(element));
            }
        }

        public static void AddPages(this ObservableCollection<BasePageViewModel> pagesCollection,
                                    IEnumerable<BasePageViewModel> pages)
        {
            foreach (var element in pages)
            {
                pagesCollection.Add(element);
            }
        }
    }
}