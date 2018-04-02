using System;
using System.Collections;
using System.IO;
using Newtonsoft.Json.Linq;

namespace FrostlingsBot
{
	public static class Config
	{
		private const string Path = "config.env.json";
		private static bool _initialized;
		private static JObject _data;
		private static bool _throwErrors = false;

		public static void Initialize(bool throwErrors=false)
		{
			_data = JObject.Parse(File.ReadAllText(Path));
			_throwErrors = throwErrors;
			_initialized = true;
		}

		public static T Get<T>(string path, T defaultValue)
		{
			if (!_initialized) Initialize();


			JToken v = _data.SelectToken(path, _throwErrors);

			return v == null ? defaultValue : (T) v.Value<T>();
		}
	}
}
