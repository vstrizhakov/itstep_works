using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace AjaxCities.Models
{
	public static class LiteralInverter
	{
		static private string EnglishLiterals = "qwertyuiop[]asdfghjkl;'zxcvbnm,.";
		static private string RussianLiterals = "йцукенгшщзхъфывапролджэячсмитьбю.";

		static private string RussianLowercase = "а б в г д е ё ж з и й к л м н о п р с т у ф х ц ч ш щ ъ ы ь э ю я";
		static private string RussianUppercase = "А Б В Г Д Е Ё Ж З И Й К Л М Н О П Р С Т У Ф Х Ц Ч Ш Щ Ъ Ы Ь Э Ю Я";

		static private string EnglishLowercase = "a b v g d e yo zh z i y k l m n o p r s t u f kh ts ch sh shch \" y ' e yu ya";
		static private string EnglishUppercase = "A B V G D E Yo Zh Z I Y K L M N O P R S T U F Kh Ts Ch Sh Shch \" Y ' E Yu Ya";

		static public string Translit(string input)
		{
			List<string> russiansLowercase = RussianLowercase.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
			List<string> russiansUppercase = RussianUppercase.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
			List<string> englishLowercase = EnglishLowercase.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
			List<string> englishUppercase = EnglishUppercase.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

			char[] tmp = input.ToArray();
			StringBuilder builder = new StringBuilder();
			for (int i = 0; i < tmp.Length; i++)
			{
				string c = tmp[i].ToString();
				int index = russiansLowercase.IndexOf(c);
				if (index != -1)
				{
					builder.Append(englishLowercase[index]);
				}
				else
				{
					index = russiansUppercase.IndexOf(c);
					if (index != -1)
					{
						builder.Append(englishUppercase[index]);
					}
					else
					{
						builder.Append(c);
					}
				}
			}
			return builder.ToString();
		}

		static public string Invert(string input)
		{
			char[] tmp = input.ToArray();
			for (int i = 0; i < input.Length; i++)
			{
				char c = tmp[i];
				int index = EnglishLiterals.IndexOf(c);
				if (index != -1)
				{
					tmp[i] = RussianLiterals[index];
				}
				else
				{
					index = RussianLiterals.IndexOf(c);
					if (index != -1)
					{
						tmp[i] = EnglishLiterals[index];
					}
				}
			}
			return new String(tmp);
		}
	}
}