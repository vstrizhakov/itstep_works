using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace RegistryClass
{
	class Program
	{
		static void Main(string[] args)
		{
			RegistryKey Key = Registry.CurrentUser;
			Console.WriteLine("Name: {0}", Key.Name);
			Console.WriteLine("SubKey Count: {0}", Key.SubKeyCount);

			//	//RegistryKey newKey = Key.CreateSubKey("Software\\Linux");
			//	//newKey.Close();
			//	//Key.DeleteSubKey("Software\\Linux");

			//	//String[] subKeyArr = Key.GetSubKeyNames();
			//	//foreach (String subKeyName in subKeyArr)
			//	//	Console.WriteLine(subKeyName);

			//	RegistryKey subKey = Key.OpenSubKey("Software\\WinRAR\\ArcHistory");
			//	String[] valueNames = subKey.GetValueNames();
			//	foreach (String valueName in valueNames)
			//		Console.WriteLine("Key = {0}, Values = {1}", valueName, subKey.GetValue(valueName));
			//	subKey.Close();

			RegistryKey newKey = Key.CreateSubKey("Software\\Linux");
			newKey.SetValue("Greeting", "Hello, World");
			newKey.SetValue("number", 12, RegistryValueKind.DWord);

			newKey.Close();
		}
	}
}
