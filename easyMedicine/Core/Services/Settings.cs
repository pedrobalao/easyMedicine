//using System;
//using System.Collections.Generic;
//using Plugin.Settings;
//using Plugin.Settings.Abstractions;
//using System.Linq;
//using System.Text;

//namespace easyMedicine
//{

//	/// <summary>
//	/// This is the Settings static class that can be used in your Core solution or in any
//	/// of your client applications. All settings are laid out the same exact way with getters
//	/// and setters. 
//	/// </summary>
//	public static class Settings
//	{
//		private static ISettings AppSettings
//		{
//			get
//			{
//				return CrossSettings.Current;
//			}
//		}

//		#region Setting Constants

//		private const string FavouriteSettingsKey = "Favourites";
//		private static readonly string FavouriteSettingsDefault = string.Empty;

//		#endregion


//		public static void AddFavourite(string idDrug)
//		{
//			var favs = FavouriteSettings;
//			if (!favs.Contains(idDrug))
//			{
//				favs.Add(idDrug);
//				FavouriteSettings = favs;
//			}
//		}


//		public static void RemoveFavourite(string idDrug)
//		{
//			var favs = FavouriteSettings;
//			if (favs.Contains(idDrug))
//			{
//				favs.Remove(idDrug);
//				FavouriteSettings = favs;
//			}
//		}


//		public static List<string> FavouriteSettings
//		{
//			get
//			{
//				var setts = AppSettings.GetValueOrDefault<string>(FavouriteSettingsKey, FavouriteSettingsDefault);
//				if (string.IsNullOrEmpty(setts))
//					return new List<string>();

//				return setts.Split(new char []{','},StringSplitOptions.RemoveEmptyEntries).ToList();

//			}
//			set
//			{
//				var str = new StringBuilder();
//				value.All(x => {
//					str.AppendFormat(",{0}", x);
//					return true;
//				});
//				AppSettings.AddOrUpdateValue<string>(FavouriteSettingsKey, str.ToString());
//			}
//		}

//		public static bool IsFavourite(string drugId) 
//		{
//			return FavouriteSettings.Contains(drugId);
//		}

//	}

//}

